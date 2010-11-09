
Namespace equipo.action
    Friend Class UpdequipoAction
        Implements _common.plain.TransactionalPlainAction

        Private _equipo As baseball.lib.vo.Equipo

        Public Sub New(ByVal equipo As baseball.lib.vo.Equipo)
            Me._equipo = equipo
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            '20070425: Devolvemos la equipo "cambio" para poder enviar la
            'notificacion en condiciones
            Dim equipoCambio As New baseball.lib.vo.Equipo
            ''******************************

            Dim equipoDAO As New DAO.equipoDAO
            Dim costeDAO As New Coste.DAO.CosteDAO
            Dim accionDAO As New Accion.DAO.accionDAO
            Dim comisionDAO As New Comision.DAO.ComisionDAO
            Dim integranteDAO As New Integrante.DAO.IntegranteDAO

            '20070329: Log de transacciones
            Dim transactionDAO As New Transaction.DAO.TransactionDAO

            Dim trans As New gesInef.lib.vo.transaction.TransactionVO
            trans.Comentario = gesInef.lib.vo.transaction.TransactionVO.COMMENT_MODIFICACION + Me._equipo.GetType.Name
            trans.Usuario = _equipo.Usuario.Codigo
            trans.Id = transactionDAO.insertRegistro(factory.Command, trans)
            Dim logDAO As New Log.DAO.LogDAO

            Dim aLog As gesInef.lib.vo.log.LogVO()
            Dim inefBDAnterior As baseball.lib.vo.Equipo = equipoDAO.getequipoAllData(factory.Command, Me._equipo)
            aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(inefBDAnterior, Me._equipo, Me._equipo.Id)

            '20070425: equipo Cambio
            equipoCambio = Me._equipo.Substract(inefBDAnterior)
            '*****************************

            If Not (aLog Is Nothing) Then
                For Each log As gesInef.lib.vo.log.LogVO In aLog
                    log.Transaccion = trans
                    log.Accion = gesInef.lib.vo.log.LogVO.action_MODIFICACION
                    logDAO.insertRegistro(factory.Command, log)
                Next
            End If
            '***********************

            equipoDAO.updateRegistro(factory.Command, _equipo)

            '***************** Costes *****************
            Dim counterCoste As Integer = 0

            If Not (_equipo.Costes Is Nothing) Then
                Dim aDbCostes As gesInef.lib.vo.coste.CosteChunkVO()
                aDbCostes = costeDAO.getCostesByequipo(factory.Command, _equipo)
                If (aDbCostes Is Nothing) Then
                    For Each coste As gesInef.lib.vo.coste.CosteVO In _equipo.Costes
                        coste.equipo = _equipo
                        coste.Id = costeDAO.insertRegistro(factory.Command, coste)
                        ' ******* Log ********
                        aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(coste, coste.Id, "")
                        For Each log As gesInef.lib.vo.log.LogVO In aLog
                            log.Transaccion = trans
                            log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                            logDAO.insertRegistro(factory.Command, log)
                        Next
                        '*********************
                        '20070504: Cambio! sólo cojo las que verdaderamente cambian
                        'boolCambioCoste = True
                        ReDim Preserve equipoCambio.Costes(counterCoste)
                        equipoCambio.Costes(counterCoste) = coste
                        equipoCambio.Costes(counterCoste).Id = gesInef.lib.util.constantes.vacio.ID
                        counterCoste += 1
                        '**********************************************************
                    Next
                Else
                    Dim htDbCoste As Hashtable = gesInef.lib.util.funciones.Arrays.ArrayToHashTable(aDbCostes, "Id")
                    'Dim htMeCoste As Hashtable = gesInef.lib.util.funciones.Arrays.ArrayToHashTable(Me._equipo.Costes, "Id")

                    'For Each coste As gesInef.lib.vo.coste.CosteVO In htMeCoste.Values
                    For Each coste As gesInef.lib.vo.coste.CosteVO In Me._equipo.Costes
                        coste.equipo = _equipo
                        If (coste.Id = gesInef.lib.util.constantes.vacio.ID) Then
                            coste.Id = costeDAO.insertRegistro(factory.Command, coste)
                            ' ******* Log ********
                            aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(coste, coste.Id, "")
                            If Not (aLog Is Nothing) Then
                                For Each log As gesInef.lib.vo.log.LogVO In aLog
                                    log.Transaccion = trans
                                    log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                                    logDAO.insertRegistro(factory.Command, log)
                                Next
                            End If
                            '*********************
                            '20070504: Cambio! sólo cojo las que verdaderamente cambian
                            'boolCambioCoste = True
                            ReDim Preserve equipoCambio.Costes(counterCoste)
                            equipoCambio.Costes(counterCoste) = coste
                            equipoCambio.Costes(counterCoste).Id = gesInef.lib.util.constantes.vacio.ID
                            counterCoste += 1
                            '**********************************************************
                        Else
                            If (htDbCoste.ContainsKey(coste.Id)) Then
                                ' ******* Log ********
                                aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(CType(htDbCoste.Item(coste.Id), gesInef.lib.vo.coste.CosteChunkVO).Coste, coste, coste.Id)
                                If Not (aLog Is Nothing) Then
                                    '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                    'boolCambioCoste = True
                                    ReDim Preserve equipoCambio.Costes(counterCoste)
                                    equipoCambio.Costes(counterCoste) = coste
                                    counterCoste += 1
                                    '**********************************************************
                                    For Each log As gesInef.lib.vo.log.LogVO In aLog
                                        log.Transaccion = trans
                                        log.Accion = gesInef.lib.vo.log.LogVO.action_MODIFICACION
                                        logDAO.insertRegistro(factory.Command, log)
                                    Next
                                End If
                                '*********************
                                costeDAO.updateRegistro(factory.Command, coste)
                                htDbCoste.Remove(coste.Id)
                            Else
                                coste.Id = costeDAO.insertRegistro(factory.Command, coste)
                                ' ******* Log ********
                                aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(coste, coste.Id, "")
                                If Not (aLog Is Nothing) Then
                                    For Each log As gesInef.lib.vo.log.LogVO In aLog
                                        log.Transaccion = trans
                                        log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                                        logDAO.insertRegistro(factory.Command, log)
                                    Next
                                End If
                                '*********************
                                '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                'boolCambioCoste = True
                                ReDim Preserve equipoCambio.Costes(counterCoste)
                                equipoCambio.Costes(counterCoste) = coste
                                equipoCambio.Costes(counterCoste).Id = gesInef.lib.util.constantes.vacio.ID
                                counterCoste += 1
                                '**********************************************************
                            End If
                        End If

                    Next
                    For Each cost As gesInef.lib.vo.coste.CosteChunkVO In htDbCoste.Values
                        ' ******* Log ********
                        aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(cost.Coste, cost.Id, "")
                        If Not (aLog Is Nothing) Then
                            For Each log As gesInef.lib.vo.log.LogVO In aLog
                                log.Transaccion = trans
                                log.Accion = gesInef.lib.vo.log.LogVO.action_BORRADO
                                logDAO.insertRegistro(factory.Command, log)
                            Next
                        End If
                        '*********************
                        costeDAO.deleteRegistro(factory.Command, cost.Coste)
                    Next
                End If
            Else
                Dim aDbCostes As gesInef.lib.vo.coste.CosteChunkVO()
                aDbCostes = costeDAO.getCostesByequipo(factory.Command, _equipo)
                If Not (aDbCostes Is Nothing) Then
                    For Each cost As gesInef.lib.vo.coste.CosteChunkVO In aDbCostes
                        ' ******* Log ********
                        aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(cost.Coste, cost.Id, "")
                        For Each log As gesInef.lib.vo.log.LogVO In aLog
                            log.Transaccion = trans
                            log.Accion = gesInef.lib.vo.log.LogVO.action_BORRADO
                            logDAO.insertRegistro(factory.Command, log)
                        Next
                        '*********************
                    Next
                    costeDAO.delCosteByequipo(factory.Command, _equipo)
                End If
            End If


            '<20071004> Cambio! esto debería haber ido aquí desde el principio
            'Comprobación del tipo de repetición de la equipo
            If (_equipo.Repeticion <> baseball.lib.vo.Equipo.tPeriodicidadInef.Ocasional) Then
                '***************** Acciones *****************
                'Dim boolCambioAccion As Boolean = False
                Dim counterAccion As Integer = 0

                If Not (_equipo.Acciones Is Nothing) Then
                    Dim tareaDAO As New Tarea.DAO.TareaDAO

                    Dim aDbAcciones As gesInef.lib.vo.accion.AccionChunkVO()
                    aDbAcciones = accionDAO.selectRegistroesByequipo(factory.Command, _equipo)
                    If (aDbAcciones Is Nothing) Then
                        For Each accion As gesInef.lib.vo.accion.AccionVO In _equipo.Acciones
                            accion.equipo = _equipo
                            accion.Id = accionDAO.insertRegistro(factory.Command, accion)
                            ' ******* Log ********
                            aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(accion, accion.Id, "")
                            For Each log As gesInef.lib.vo.log.LogVO In aLog
                                log.Transaccion = trans
                                log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                                logDAO.insertRegistro(factory.Command, log)
                            Next
                            '*********************
                            '20070504: Cambio! sólo cojo las que verdaderamente cambian
                            'boolCambioAccion = True
                            ReDim Preserve equipoCambio.Acciones(counterAccion)
                            equipoCambio.Acciones(counterAccion) = accion
                            '**********************************************************
                            '<20070906> Insercion de Tareas
                            If (Not accion.Tareas Is Nothing) Then
                                For Each tarea As gesInef.lib.vo.tarea.TareaVO In accion.Tareas
                                    tarea.Accion = accion
                                    tarea.FechaCompletada = accion.FechaRealizacion
                                    tarea.Completada = tarea.FechaCompletada <> gesInef.lib.util.constantes.vacio.FECHA
                                    tarea.Estado = gesInef.lib.vo.tarea.TareaVO.EstadoAccionToEstadoOutlook(accion.Estado)
                                    tarea.Id = tareaDAO.insertRegistro(factory.Command, tarea)
                                Next
                            End If
                            '******************************
                            equipoCambio.Acciones(counterAccion).Id = gesInef.lib.util.constantes.vacio.ID
                            counterAccion += 1
                        Next
                    Else
                        Dim htDbAccion As Hashtable = gesInef.lib.util.funciones.Arrays.ArrayToHashTable(aDbAcciones, "Id")
                        'Dim htMeAccion As Hashtable = gesInef.lib.util.funciones.Arrays.ArrayToHashTable(Me._equipo.Acciones, "Id")

                        '                    For Each Accion As gesInef.lib.vo.accion.AccionVO In htMeAccion.Values
                        For Each Accion As gesInef.lib.vo.accion.AccionVO In Me._equipo.Acciones
                            Accion.equipo = _equipo
                            If (Accion.Id = gesInef.lib.util.constantes.vacio.ID) Then
                                Accion.Id = accionDAO.insertRegistro(factory.Command, Accion)
                                ' ******* Log ********
                                aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(Accion, Accion.Id, "")
                                For Each log As gesInef.lib.vo.log.LogVO In aLog
                                    log.Transaccion = trans
                                    log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                                    logDAO.insertRegistro(factory.Command, log)
                                Next
                                '*********************
                                '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                'boolCambioAccion = True
                                ReDim Preserve equipoCambio.Acciones(counterAccion)
                                equipoCambio.Acciones(counterAccion) = Accion
                                '**********************************************************
                                '<20070906> Insercion de Tareas
                                If (Not Accion.Tareas Is Nothing) Then
                                    For Each tarea As gesInef.lib.vo.tarea.TareaVO In Accion.Tareas
                                        tarea.Accion = Accion
                                        tarea.FechaCompletada = Accion.FechaRealizacion
                                        tarea.Completada = tarea.FechaCompletada <> gesInef.lib.util.constantes.vacio.FECHA
                                        tarea.Estado = gesInef.lib.vo.tarea.TareaVO.EstadoAccionToEstadoOutlook(Accion.Estado)
                                        tarea.Id = tareaDAO.insertRegistro(factory.Command, tarea)
                                    Next
                                End If
                                '******************************
                                equipoCambio.Acciones(counterAccion).Id = gesInef.lib.util.constantes.vacio.ID
                                counterAccion += 1
                            Else
                                If (htDbAccion.ContainsKey(Accion.Id)) Then
                                    Accion.Tareas = tareaDAO.selectRegistrosByAccion(factory.Command, Accion)

                                    ' ******* Log ********
                                    aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(CType(htDbAccion.Item(Accion.Id), gesInef.lib.vo.accion.AccionChunkVO).Accion, Accion, Accion.Id)
                                    If Not (aLog Is Nothing) Then
                                        '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                        'boolCambioAccion = True
                                        ReDim Preserve equipoCambio.Acciones(counterAccion)
                                        equipoCambio.Acciones(counterAccion) = Accion
                                        counterAccion += 1
                                        '**********************************************************
                                        For Each log As gesInef.lib.vo.log.LogVO In aLog
                                            log.Transaccion = trans
                                            log.Accion = gesInef.lib.vo.log.LogVO.action_MODIFICACION
                                            logDAO.insertRegistro(factory.Command, log)
                                        Next
                                    End If
                                    '*********************
                                    accionDAO.updateRegistro(factory.Command, Accion)
                                    '<20070906> Actualizacion de Tareas
                                    If (Not Accion.Tareas Is Nothing) Then
                                        For Each tarea As gesInef.lib.vo.tarea.TareaVO In Accion.Tareas
                                            tarea.Accion = Accion
                                            tarea.FechaCompletada = Accion.FechaRealizacion
                                            tarea.Completada = tarea.FechaCompletada <> gesInef.lib.util.constantes.vacio.FECHA
                                            tarea.Estado = gesInef.lib.vo.tarea.TareaVO.EstadoAccionToEstadoOutlook(Accion.Estado)
                                            tarea.Id = tareaDAO.updateRegistro(factory.Command, tarea)
                                        Next
                                    End If
                                    '******************************
                                    htDbAccion.Remove(Accion.Id)
                                Else
                                    Accion.Id = accionDAO.insertRegistro(factory.Command, Accion)
                                    ' ******* Log ********
                                    aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(Accion, Accion.Id, "")
                                    For Each log As gesInef.lib.vo.log.LogVO In aLog
                                        log.Transaccion = trans
                                        log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                                        logDAO.insertRegistro(factory.Command, log)
                                    Next
                                    '*********************
                                    '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                    'boolCambioAccion = True
                                    ReDim Preserve equipoCambio.Acciones(counterAccion)
                                    equipoCambio.Acciones(counterAccion) = Accion
                                    '**********************************************************
                                    '<20070906> Insercion de Tareas
                                    If (Not Accion.Tareas Is Nothing) Then
                                        For Each tarea As gesInef.lib.vo.tarea.TareaVO In Accion.Tareas
                                            tarea.Accion = Accion
                                            tarea.FechaCompletada = Accion.FechaRealizacion
                                            tarea.Completada = tarea.FechaCompletada <> gesInef.lib.util.constantes.vacio.FECHA
                                            tarea.Estado = gesInef.lib.vo.tarea.TareaVO.EstadoAccionToEstadoOutlook(Accion.Estado)
                                            tarea.Id = tareaDAO.insertRegistro(factory.Command, tarea)
                                        Next
                                    End If
                                    '******************************
                                    equipoCambio.Acciones(counterAccion).Id = gesInef.lib.util.constantes.vacio.ID
                                    counterAccion += 1
                                End If
                            End If
                        Next
                        For Each acc As gesInef.lib.vo.accion.AccionChunkVO In htDbAccion.Values
                            ' ******* Log ********
                            aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(acc, acc.Id, "")
                            For Each log As gesInef.lib.vo.log.LogVO In aLog
                                log.Transaccion = trans
                                log.Accion = gesInef.lib.vo.log.LogVO.action_BORRADO
                                logDAO.insertRegistro(factory.Command, log)
                            Next
                            '*********************
                            accionDAO.deleteRegistro(factory.Command, acc.Accion)
                        Next
                    End If
                Else
                    Dim aDbAcciones As gesInef.lib.vo.accion.AccionChunkVO()
                    aDbAcciones = accionDAO.selectRegistroesByequipo(factory.Command, _equipo)
                    If Not (aDbAcciones Is Nothing) Then
                        For Each Acc As gesInef.lib.vo.accion.AccionChunkVO In aDbAcciones
                            ' ******* Log ********
                            aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(Acc.Accion, Acc.Id, "")
                            For Each log As gesInef.lib.vo.log.LogVO In aLog
                                log.Transaccion = trans
                                log.Accion = gesInef.lib.vo.log.LogVO.action_BORRADO
                                logDAO.insertRegistro(factory.Command, log)
                            Next
                            '*********************
                        Next
                        accionDAO.delAccionByequipo(factory.Command, _equipo)
                    End If
                End If

                '***************** Comision/Integrantes *****************
                Dim counterComision As Integer = 0

                If Not (_equipo.Comision Is Nothing) Then
                    _equipo.Comision.equipo = _equipo
                    '<20071022> Parche: Pérdida de la comision
                    Dim tmpComision As gesInef.lib.vo.comision.ComisionVO = comisionDAO.selectRegistro(factory.Command, _equipo.Comision)
                    If (tmpComision Is Nothing) Then
                        If (_equipo.Repeticion <> baseball.lib.vo.Equipo.tPeriodicidadInef.Ocasional) Then
                            tmpComision = comisionDAO.selectRegistroByequipo(factory.Command, _equipo)

                            If (tmpComision Is Nothing) Then
                                _equipo.Comision.Id = comisionDAO.insertRegistro(factory.Command, _equipo.Comision)
                            Else
                                _equipo.Comision.Id = tmpComision.Id
                            End If
                        Else
                            'Es Ocasional
                            If (Not _equipo.equipoOriginal Is Nothing) Then
                                _equipo.Comision = comisionDAO.selectRegistroByequipo(factory.Command, _equipo.equipoOriginal)
                            Else

                            End If
                        End If
                    End If
                    '</20071022> ****************************

                    equipoCambio.Comision = New gesInef.lib.vo.comision.ComisionVO
                    equipoCambio.Comision.Id = _equipo.Comision.Id
                    equipoCambio.Comision.equipo = equipoCambio

                    comisionDAO.updateRegistro(factory.Command, _equipo.Comision)

                    If Not (_equipo.Comision.Integrantes Is Nothing) Then
                        Dim aDbIntegrantes As gesInef.lib.vo.integrante.IntegranteChunkVO()
                        aDbIntegrantes = integranteDAO.getIntegrantesByComision(factory.Command, _equipo.Comision)
                        If (aDbIntegrantes Is Nothing) Then
                            'boolCambioComision = True
                            For Each Integrante As gesInef.lib.vo.integrante.IntegranteVO In _equipo.Comision.Integrantes
                                Integrante.Comision = _equipo.Comision
                                Integrante.Id = integranteDAO.insertRegistro(factory.Command, Integrante)

                                ' ******* Log ********
                                aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(Integrante, Integrante.Id, "")
                                For Each log As gesInef.lib.vo.log.LogVO In aLog
                                    log.Transaccion = trans
                                    log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                                    logDAO.insertRegistro(factory.Command, log)
                                Next
                                '*********************
                                '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                'boolCambioComision = True
                                ReDim Preserve equipoCambio.Comision.Integrantes(counterComision)
                                equipoCambio.Comision.Integrantes(counterComision) = Integrante
                                equipoCambio.Comision.Integrantes(counterComision).Id = gesInef.lib.util.constantes.vacio.ID
                                counterAccion += 1
                                '**********************************************************
                            Next
                        Else
                            Dim htDbIntegrante As Hashtable = gesInef.lib.util.funciones.Arrays.ArrayToHashTable(aDbIntegrantes, "Id")
                            'Dim htMeIntegrante As Hashtable = gesInef.lib.util.funciones.Arrays.ArrayToHashTable(Me._equipo.Integrantes, "Id")

                            '                    For Each Integrante As gesInef.lib.vo.integrante.IntegranteVO In htMeIntegrante.Values
                            For Each Integrante As gesInef.lib.vo.integrante.IntegranteVO In Me._equipo.Comision.Integrantes
                                Integrante.Comision = _equipo.Comision
                                If (Integrante.Id = gesInef.lib.util.constantes.vacio.ID) Then
                                    'boolCambioComision = True
                                    Integrante.Id = integranteDAO.insertRegistro(factory.Command, Integrante)
                                    ' ******* Log ********
                                    aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(Integrante, Integrante.Id, "")
                                    For Each log As gesInef.lib.vo.log.LogVO In aLog
                                        log.Transaccion = trans
                                        log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                                        logDAO.insertRegistro(factory.Command, log)
                                    Next
                                    '*********************
                                    '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                    'boolCambioComision = True
                                    ReDim Preserve equipoCambio.Comision.Integrantes(counterComision)
                                    equipoCambio.Comision.Integrantes(counterComision) = Integrante
                                    equipoCambio.Comision.Integrantes(counterComision).Id = gesInef.lib.util.constantes.vacio.ID
                                    counterAccion += 1
                                    '**********************************************************
                                Else
                                    If (htDbIntegrante.ContainsKey(Integrante.Id)) Then
                                        ' ******* Log ********
                                        aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(CType(htDbIntegrante.Item(Integrante.Id), gesInef.lib.vo.integrante.IntegranteChunkVO).Integrante, Integrante, Integrante.Id)
                                        If Not (aLog Is Nothing) Then
                                            '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                            'boolCambioComision = True
                                            ReDim Preserve equipoCambio.Comision.Integrantes(counterComision)
                                            equipoCambio.Comision.Integrantes(counterComision) = Integrante
                                            counterAccion += 1
                                            '**********************************************************
                                            For Each log As gesInef.lib.vo.log.LogVO In aLog
                                                log.Transaccion = trans
                                                log.Accion = gesInef.lib.vo.log.LogVO.action_MODIFICACION
                                                logDAO.insertRegistro(factory.Command, log)
                                            Next
                                        End If
                                        '*********************
                                        integranteDAO.updateRegistro(factory.Command, Integrante)
                                        htDbIntegrante.Remove(Integrante.Id)
                                    Else
                                        Integrante.Id = integranteDAO.insertRegistro(factory.Command, Integrante)
                                        ' ******* Log ********
                                        aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(Integrante, Integrante.Id, "")
                                        For Each log As gesInef.lib.vo.log.LogVO In aLog
                                            log.Transaccion = trans
                                            log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                                            logDAO.insertRegistro(factory.Command, log)
                                        Next
                                        '*********************
                                        '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                        'boolCambioComision = True
                                        ReDim Preserve equipoCambio.Comision.Integrantes(counterComision)
                                        equipoCambio.Comision.Integrantes(counterComision) = Integrante
                                        equipoCambio.Comision.Integrantes(counterComision).Id = gesInef.lib.util.constantes.vacio.ID
                                        counterAccion += 1
                                        '**********************************************************
                                    End If
                                End If
                            Next
                            For Each acc As gesInef.lib.vo.integrante.IntegranteChunkVO In htDbIntegrante.Values
                                ' ******* Log ********
                                aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(acc, acc.Id, "")
                                For Each log As gesInef.lib.vo.log.LogVO In aLog
                                    log.Transaccion = trans
                                    log.Accion = gesInef.lib.vo.log.LogVO.action_BORRADO
                                    logDAO.insertRegistro(factory.Command, log)
                                Next
                                '*********************
                                integranteDAO.deleteRegistro(factory.Command, acc.Integrante)
                            Next
                        End If
                    Else
                        Dim aDbIntegrantes As gesInef.lib.vo.integrante.IntegranteChunkVO()
                        aDbIntegrantes = integranteDAO.getIntegrantesByComision(factory.Command, _equipo.Comision)
                        If Not (aDbIntegrantes Is Nothing) Then
                            For Each Int As gesInef.lib.vo.integrante.IntegranteChunkVO In aDbIntegrantes
                                ' ******* Log ********
                                aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(Int.Integrante, Int.Id, "")
                                For Each log As gesInef.lib.vo.log.LogVO In aLog
                                    log.Transaccion = trans
                                    log.Accion = gesInef.lib.vo.log.LogVO.action_BORRADO
                                    logDAO.insertRegistro(factory.Command, log)
                                Next
                                '*********************
                                integranteDAO.deleteRegistro(factory.Command, Int.Integrante)
                            Next
                        End If
                    End If
                Else
                    _equipo.Comision = comisionDAO.selectRegistroByequipo(factory.Command, _equipo)
                    comisionDAO.deleteRegistro(factory.Command, _equipo.Comision)
                End If
            Else
                'Es ocasional
                If (Not _equipo.equipoOriginal Is Nothing) Then
                    '***************** Acciones *****************
                    'Dim boolCambioAccion As Boolean = False
                    Dim counterAccion As Integer = 0

                    If Not (_equipo.Acciones Is Nothing) Then
                        Dim tareaDAO As New Tarea.DAO.TareaDAO

                        Dim aDbAcciones As gesInef.lib.vo.accion.AccionChunkVO()
                        aDbAcciones = accionDAO.selectRegistroesByequipo(factory.Command, _equipo.equipoOriginal)
                        If (aDbAcciones Is Nothing) Then
                            For Each accion As gesInef.lib.vo.accion.AccionVO In _equipo.Acciones
                                accion.equipo = _equipo.equipoOriginal
                                accion.Id = accionDAO.insertRegistro(factory.Command, accion)
                                ' ******* Log ********
                                aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(accion, accion.Id, "")
                                For Each log As gesInef.lib.vo.log.LogVO In aLog
                                    log.Transaccion = trans
                                    log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                                    logDAO.insertRegistro(factory.Command, log)
                                Next
                                '*********************
                                '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                'boolCambioAccion = True
                                ReDim Preserve equipoCambio.Acciones(counterAccion)
                                equipoCambio.Acciones(counterAccion) = accion
                                '**********************************************************
                                '<20070906> Insercion de Tareas
                                If (Not accion.Tareas Is Nothing) Then
                                    For Each tarea As gesInef.lib.vo.tarea.TareaVO In accion.Tareas
                                        tarea.Accion = accion
                                        tarea.FechaCompletada = accion.FechaRealizacion
                                        tarea.Completada = tarea.FechaCompletada <> gesInef.lib.util.constantes.vacio.FECHA
                                        tarea.Estado = gesInef.lib.vo.tarea.TareaVO.EstadoAccionToEstadoOutlook(accion.Estado)
                                        tarea.Id = tareaDAO.insertRegistro(factory.Command, tarea)
                                    Next
                                End If
                                '******************************
                                equipoCambio.Acciones(counterAccion).Id = gesInef.lib.util.constantes.vacio.ID
                                counterAccion += 1
                            Next
                        Else
                            Dim htDbAccion As Hashtable = gesInef.lib.util.funciones.Arrays.ArrayToHashTable(aDbAcciones, "Id")
                            For Each Accion As gesInef.lib.vo.accion.AccionVO In Me._equipo.Acciones
                                Accion.equipo = _equipo.equipoOriginal
                                If (Accion.Id = gesInef.lib.util.constantes.vacio.ID) Then
                                    Accion.Id = accionDAO.insertRegistro(factory.Command, Accion)
                                    ' ******* Log ********
                                    aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(Accion, Accion.Id, "")
                                    For Each log As gesInef.lib.vo.log.LogVO In aLog
                                        log.Transaccion = trans
                                        log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                                        logDAO.insertRegistro(factory.Command, log)
                                    Next
                                    '*********************
                                    '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                    'boolCambioAccion = True
                                    ReDim Preserve equipoCambio.Acciones(counterAccion)
                                    equipoCambio.Acciones(counterAccion) = Accion
                                    '**********************************************************
                                    '<20070906> Insercion de Tareas
                                    If (Not Accion.Tareas Is Nothing) Then
                                        For Each tarea As gesInef.lib.vo.tarea.TareaVO In Accion.Tareas
                                            tarea.Accion = Accion
                                            tarea.FechaCompletada = Accion.FechaRealizacion
                                            tarea.Completada = tarea.FechaCompletada <> gesInef.lib.util.constantes.vacio.FECHA
                                            tarea.Estado = gesInef.lib.vo.tarea.TareaVO.EstadoAccionToEstadoOutlook(Accion.Estado)
                                            tarea.Id = tareaDAO.insertRegistro(factory.Command, tarea)
                                        Next
                                    End If
                                    '******************************
                                    equipoCambio.Acciones(counterAccion).Id = gesInef.lib.util.constantes.vacio.ID
                                    counterAccion += 1
                                Else
                                    If (htDbAccion.ContainsKey(Accion.Id)) Then
                                        Accion.Tareas = tareaDAO.selectRegistrosByAccion(factory.Command, Accion)

                                        ' ******* Log ********
                                        aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(CType(htDbAccion.Item(Accion.Id), gesInef.lib.vo.accion.AccionChunkVO).Accion, Accion, Accion.Id)
                                        If Not (aLog Is Nothing) Then
                                            '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                            'boolCambioAccion = True
                                            ReDim Preserve equipoCambio.Acciones(counterAccion)
                                            equipoCambio.Acciones(counterAccion) = Accion
                                            counterAccion += 1
                                            '**********************************************************
                                            For Each log As gesInef.lib.vo.log.LogVO In aLog
                                                log.Transaccion = trans
                                                log.Accion = gesInef.lib.vo.log.LogVO.action_MODIFICACION
                                                logDAO.insertRegistro(factory.Command, log)
                                            Next
                                        End If
                                        '*********************
                                        accionDAO.updateRegistro(factory.Command, Accion)
                                        '<20070906> Actualizacion de Tareas
                                        If (Not Accion.Tareas Is Nothing) Then
                                            For Each tarea As gesInef.lib.vo.tarea.TareaVO In Accion.Tareas
                                                tarea.Accion = Accion
                                                tarea.FechaCompletada = Accion.FechaRealizacion
                                                tarea.Completada = tarea.FechaCompletada <> gesInef.lib.util.constantes.vacio.FECHA
                                                tarea.Estado = gesInef.lib.vo.tarea.TareaVO.EstadoAccionToEstadoOutlook(Accion.Estado)
                                                tarea.Id = tareaDAO.updateRegistro(factory.Command, tarea)
                                            Next
                                        End If
                                        '******************************
                                        htDbAccion.Remove(Accion.Id)
                                    Else
                                        Accion.Id = accionDAO.insertRegistro(factory.Command, Accion)
                                        ' ******* Log ********
                                        aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(Accion, Accion.Id, "")
                                        For Each log As gesInef.lib.vo.log.LogVO In aLog
                                            log.Transaccion = trans
                                            log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                                            logDAO.insertRegistro(factory.Command, log)
                                        Next
                                        '*********************
                                        '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                        'boolCambioAccion = True
                                        ReDim Preserve equipoCambio.Acciones(counterAccion)
                                        equipoCambio.Acciones(counterAccion) = Accion
                                        '**********************************************************
                                        '<20070906> Insercion de Tareas
                                        If (Not Accion.Tareas Is Nothing) Then
                                            For Each tarea As gesInef.lib.vo.tarea.TareaVO In Accion.Tareas
                                                tarea.Accion = Accion
                                                tarea.FechaCompletada = Accion.FechaRealizacion
                                                tarea.Completada = tarea.FechaCompletada <> gesInef.lib.util.constantes.vacio.FECHA
                                                tarea.Estado = gesInef.lib.vo.tarea.TareaVO.EstadoAccionToEstadoOutlook(Accion.Estado)
                                                tarea.Id = tareaDAO.insertRegistro(factory.Command, tarea)
                                            Next
                                        End If
                                        '******************************
                                        equipoCambio.Acciones(counterAccion).Id = gesInef.lib.util.constantes.vacio.ID
                                        counterAccion += 1
                                    End If
                                End If
                            Next
                            For Each acc As gesInef.lib.vo.accion.AccionChunkVO In htDbAccion.Values
                                ' ******* Log ********
                                aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(acc, acc.Id, "")
                                For Each log As gesInef.lib.vo.log.LogVO In aLog
                                    log.Transaccion = trans
                                    log.Accion = gesInef.lib.vo.log.LogVO.action_BORRADO
                                    logDAO.insertRegistro(factory.Command, log)
                                Next
                                '*********************
                                accionDAO.deleteRegistro(factory.Command, acc.Accion)
                            Next
                        End If
                    Else
                        Dim aDbAcciones As gesInef.lib.vo.accion.AccionChunkVO()
                        aDbAcciones = accionDAO.selectRegistroesByequipo(factory.Command, _equipo.equipoOriginal)
                        If Not (aDbAcciones Is Nothing) Then
                            For Each Acc As gesInef.lib.vo.accion.AccionChunkVO In aDbAcciones
                                ' ******* Log ********
                                aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(Acc.Accion, Acc.Id, "")
                                For Each log As gesInef.lib.vo.log.LogVO In aLog
                                    log.Transaccion = trans
                                    log.Accion = gesInef.lib.vo.log.LogVO.action_BORRADO
                                    logDAO.insertRegistro(factory.Command, log)
                                Next
                                '*********************
                            Next
                            accionDAO.delAccionByequipo(factory.Command, _equipo.equipoOriginal)
                        End If
                    End If
                    '*****************************

                    '***************** Comision/Integrantes *****************
                    'Dim boolCambioComision As Boolean = False
                    Dim counterComision As Integer = 0

                    If Not (_equipo.Comision Is Nothing) Then
                        _equipo.Comision.equipo = _equipo.equipoOriginal
                        '<20071022> Parche: Pérdida de la comision
                        Dim tmpComision As gesInef.lib.vo.comision.ComisionVO = comisionDAO.selectRegistro(factory.Command, _equipo.Comision)
                        If (tmpComision Is Nothing) Then
                            If (_equipo.Repeticion <> baseball.lib.vo.Equipo.tPeriodicidadInef.Ocasional) Then
                                _equipo.Comision = comisionDAO.selectRegistroByequipo(factory.Command, _equipo)
                            Else
                                'Es Ocasional
                                If (Not _equipo.equipoOriginal Is Nothing) Then
                                    tmpComision = comisionDAO.selectRegistroByequipo(factory.Command, _equipo.equipoOriginal)

                                    If (tmpComision Is Nothing) Then
                                        _equipo.Comision.Id = comisionDAO.insertRegistro(factory.Command, _equipo.Comision)
                                    Else
                                        _equipo.Comision.Id = tmpComision.Id
                                    End If
                                End If
                            End If
                        End If
                        '</20071022> ****************************
                        equipoCambio.Comision = New gesInef.lib.vo.comision.ComisionVO
                        equipoCambio.Comision.Id = _equipo.Comision.Id
                        equipoCambio.Comision.equipo = equipoCambio

                        comisionDAO.updateRegistro(factory.Command, _equipo.Comision)

                        If Not (_equipo.Comision.Integrantes Is Nothing) Then
                            Dim aDbIntegrantes As gesInef.lib.vo.integrante.IntegranteChunkVO()
                            aDbIntegrantes = integranteDAO.getIntegrantesByComision(factory.Command, _equipo.Comision)
                            If (aDbIntegrantes Is Nothing) Then
                                'boolCambioComision = True
                                For Each Integrante As gesInef.lib.vo.integrante.IntegranteVO In _equipo.Comision.Integrantes
                                    Integrante.Comision = _equipo.Comision
                                    Integrante.Id = integranteDAO.insertRegistro(factory.Command, Integrante)

                                    ' ******* Log ********
                                    aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(Integrante, Integrante.Id, "")
                                    For Each log As gesInef.lib.vo.log.LogVO In aLog
                                        log.Transaccion = trans
                                        log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                                        logDAO.insertRegistro(factory.Command, log)
                                    Next
                                    '*********************
                                    '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                    'boolCambioComision = True
                                    ReDim Preserve equipoCambio.Comision.Integrantes(counterComision)
                                    equipoCambio.Comision.Integrantes(counterComision) = Integrante
                                    equipoCambio.Comision.Integrantes(counterComision).Id = gesInef.lib.util.constantes.vacio.ID
                                    counterAccion += 1
                                    '**********************************************************
                                Next
                            Else
                                Dim htDbIntegrante As Hashtable = gesInef.lib.util.funciones.Arrays.ArrayToHashTable(aDbIntegrantes, "Id")
                                For Each Integrante As gesInef.lib.vo.integrante.IntegranteVO In Me._equipo.Comision.Integrantes
                                    Integrante.Comision = _equipo.Comision
                                    If (Integrante.Id = gesInef.lib.util.constantes.vacio.ID) Then
                                        'boolCambioComision = True
                                        Integrante.Id = integranteDAO.insertRegistro(factory.Command, Integrante)
                                        ' ******* Log ********
                                        aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(Integrante, Integrante.Id, "")
                                        For Each log As gesInef.lib.vo.log.LogVO In aLog
                                            log.Transaccion = trans
                                            log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                                            logDAO.insertRegistro(factory.Command, log)
                                        Next
                                        '*********************
                                        '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                        'boolCambioComision = True
                                        ReDim Preserve equipoCambio.Comision.Integrantes(counterComision)
                                        equipoCambio.Comision.Integrantes(counterComision) = Integrante
                                        equipoCambio.Comision.Integrantes(counterComision).Id = gesInef.lib.util.constantes.vacio.ID
                                        counterAccion += 1
                                        '**********************************************************
                                    Else
                                        If (htDbIntegrante.ContainsKey(Integrante.Id)) Then
                                            ' ******* Log ********
                                            aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(CType(htDbIntegrante.Item(Integrante.Id), gesInef.lib.vo.integrante.IntegranteChunkVO).Integrante, Integrante, Integrante.Id)
                                            If Not (aLog Is Nothing) Then
                                                '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                                'boolCambioComision = True
                                                ReDim Preserve equipoCambio.Comision.Integrantes(counterComision)
                                                equipoCambio.Comision.Integrantes(counterComision) = Integrante
                                                counterAccion += 1
                                                '**********************************************************
                                                For Each log As gesInef.lib.vo.log.LogVO In aLog
                                                    log.Transaccion = trans
                                                    log.Accion = gesInef.lib.vo.log.LogVO.action_MODIFICACION
                                                    logDAO.insertRegistro(factory.Command, log)
                                                Next
                                            End If
                                            '*********************
                                            integranteDAO.updateRegistro(factory.Command, Integrante)
                                            htDbIntegrante.Remove(Integrante.Id)
                                        Else
                                            Integrante.Id = integranteDAO.insertRegistro(factory.Command, Integrante)
                                            ' ******* Log ********
                                            aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(Integrante, Integrante.Id, "")
                                            For Each log As gesInef.lib.vo.log.LogVO In aLog
                                                log.Transaccion = trans
                                                log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                                                logDAO.insertRegistro(factory.Command, log)
                                            Next
                                            '*********************
                                            '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                            'boolCambioComision = True
                                            ReDim Preserve equipoCambio.Comision.Integrantes(counterComision)
                                            equipoCambio.Comision.Integrantes(counterComision) = Integrante
                                            equipoCambio.Comision.Integrantes(counterComision).Id = gesInef.lib.util.constantes.vacio.ID
                                            counterAccion += 1
                                            '**********************************************************
                                        End If
                                    End If
                                Next
                                For Each acc As gesInef.lib.vo.integrante.IntegranteChunkVO In htDbIntegrante.Values
                                    ' ******* Log ********
                                    aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(acc, acc.Id, "")
                                    For Each log As gesInef.lib.vo.log.LogVO In aLog
                                        log.Transaccion = trans
                                        log.Accion = gesInef.lib.vo.log.LogVO.action_BORRADO
                                        logDAO.insertRegistro(factory.Command, log)
                                    Next
                                    '*********************
                                    integranteDAO.deleteRegistro(factory.Command, acc.Integrante)
                                Next
                            End If
                        Else
                            Dim aDbIntegrantes As gesInef.lib.vo.integrante.IntegranteChunkVO()
                            aDbIntegrantes = integranteDAO.getIntegrantesByComision(factory.Command, _equipo.Comision)
                            If Not (aDbIntegrantes Is Nothing) Then
                                For Each Int As gesInef.lib.vo.integrante.IntegranteChunkVO In aDbIntegrantes
                                    ' ******* Log ********
                                    aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(Int.Integrante, Int.Id, "")
                                    For Each log As gesInef.lib.vo.log.LogVO In aLog
                                        log.Transaccion = trans
                                        log.Accion = gesInef.lib.vo.log.LogVO.action_BORRADO
                                        logDAO.insertRegistro(factory.Command, log)
                                    Next
                                    '*********************
                                    integranteDAO.deleteRegistro(factory.Command, Int.Integrante)
                                Next
                            End If
                        End If
                    Else
                        _equipo.Comision = comisionDAO.selectRegistroByequipo(factory.Command, _equipo.equipoOriginal)
                        comisionDAO.deleteRegistro(factory.Command, _equipo.Comision)
                    End If
                End If
            End If

            '<20070611> Cambio! Ficheros directamente en la BD
            Dim counterFicheros As Integer = 0
            Dim ficheroDAO As New Fichero.DAO.FicheroDAO

            If Not (_equipo.FicherosVO Is Nothing) Then
                'Compruebo si había algún archivo anexado con anterioridad
                Dim aDbFicheros As gesInef.lib.vo.fichero.FicheroVO()
                aDbFicheros = ficheroDAO.getFicherosByequipo(factory.Command, _equipo)

                If (aDbFicheros Is Nothing) Then
                    For Each fichero As gesInef.lib.vo.fichero.FicheroVO In _equipo.FicherosVO
                        fichero.equipo = _equipo
                        fichero.Id = ficheroDAO.insertRegistro(factory.Command, fichero)
                        '' ******* Log ********
                        'aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(accion, accion.Id, "")
                        'For Each log As gesInef.lib.vo.log.LogVO In aLog
                        '    log.Transaccion = trans
                        '    log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                        '    logDAO.insertRegistro(factory.Command, log)
                        'Next
                        ''*********************
                        '20070504: Cambio! sólo cojo las que verdaderamente cambian
                        'boolCambioAccion = True
                        ReDim Preserve equipoCambio.FicherosVO(counterFicheros)
                        equipoCambio.FicherosVO(counterFicheros) = fichero
                        equipoCambio.FicherosVO(counterFicheros).Id = gesInef.lib.util.constantes.vacio.ID
                        counterFicheros += 1
                        '**********************************************************
                    Next
                Else
                    Dim htDbFichero As Hashtable = gesInef.lib.util.funciones.Arrays.ArrayToHashTable(aDbFicheros, "Id")
                    For Each fichero As gesInef.lib.vo.fichero.FicheroVO In Me._equipo.FicherosVO
                        fichero.equipo = _equipo
                        If (fichero.Id = gesInef.lib.util.constantes.vacio.ID) Then
                            fichero.Id = ficheroDAO.insertRegistro(factory.Command, fichero)
                            '' ******* Log ********
                            'aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(accion, accion.Id, "")
                            'For Each log As gesInef.lib.vo.log.LogVO In aLog
                            '    log.Transaccion = trans
                            '    log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                            '    logDAO.insertRegistro(factory.Command, log)
                            'Next
                            ''*********************
                            '20070504: Cambio! sólo cojo las que verdaderamente cambian
                            'boolCambioAccion = True
                            ReDim Preserve equipoCambio.FicherosVO(counterFicheros)
                            equipoCambio.FicherosVO(counterFicheros) = fichero
                            equipoCambio.FicherosVO(counterFicheros).Id = gesInef.lib.util.constantes.vacio.ID
                            counterFicheros += 1
                            '**********************************************************
                        Else
                            If (htDbFichero.ContainsKey(fichero.Id)) Then
                                '' ******* Log ********
                                'aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(CType(htDbFichero.Item(Accion.Id), gesInef.lib.vo.accion.AccionChunkVO).accion, Accion, Accion.Id)
                                'If Not (aLog Is Nothing) Then
                                '    '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                '    'boolCambioAccion = True
                                ReDim Preserve equipoCambio.FicherosVO(counterFicheros)
                                equipoCambio.FicherosVO(counterFicheros) = fichero
                                counterFicheros += 1
                                '    '**********************************************************
                                '    For Each log As gesInef.lib.vo.log.LogVO In aLog
                                '        log.Transaccion = trans
                                '        log.Accion = gesInef.lib.vo.log.LogVO.action_MODIFICACION
                                '        logDAO.insertRegistro(factory.Command, log)
                                '    Next
                                'End If
                                ''*********************
                                ficheroDAO.updateRegistro(factory.Command, fichero)
                                htDbFichero.Remove(fichero.Id)
                            Else
                                fichero.Id = ficheroDAO.insertRegistro(factory.Command, fichero)
                                '' ******* Log ********
                                'aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(fichero, fichero.Id, "")
                                'For Each log As gesInef.lib.vo.log.LogVO In aLog
                                '    log.Transaccion = trans
                                '    log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                                '    logDAO.insertRegistro(factory.Command, log)
                                'Next
                                ''*********************
                                '20070504: Cambio! sólo cojo las que verdaderamente cambian
                                'boolCambioAccion = True
                                ReDim Preserve equipoCambio.FicherosVO(counterFicheros)
                                equipoCambio.FicherosVO(counterFicheros) = fichero
                                equipoCambio.FicherosVO(counterFicheros).Id = gesInef.lib.util.constantes.vacio.ID
                                counterFicheros += 1
                                '**********************************************************
                            End If
                        End If
                    Next
                    For Each fich As gesInef.lib.vo.fichero.FicheroVO In htDbFichero.Values
                        '' ******* Log ********
                        'aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(acc, acc.Id, "")
                        'For Each log As gesInef.lib.vo.log.LogVO In aLog
                        '    log.Transaccion = trans
                        '    log.Accion = gesInef.lib.vo.log.LogVO.action_BORRADO
                        '    logDAO.insertRegistro(factory.Command, log)
                        'Next
                        ''*********************
                        ficheroDAO.deleteRegistro(factory.Command, fich)
                    Next
                End If

            Else
                'Si el array está vacío, borro todos los archivos del directorio
                ' y el mismo directorio
                ficheroDAO.delFicheroByequipo(factory.Command, Me._equipo)
            End If
            '</20070611> ************************************

            '<20070612> Cambio! Añadir siempre la descripción de la equipo
            equipoCambio.Resumen = Me._equipo.Resumen
            '</20070612> ******************************************************

            '20070425: equipo Cambio
            Return equipoCambio
            '*****************************
        End Function
    End Class
End Namespace
