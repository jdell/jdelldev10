'TODO: Revisar a fondo cuando haya tiempo. Hay muchisimas cosas "del pasado"
Namespace equipo.action
    Friend Class AddequipoAction
        Implements _common.plain.TransactionalPlainAction

        Private _equipo As baseball.lib.vo.Equipo

        Public Sub New(ByVal equipo As baseball.lib.vo.Equipo)
            Me._equipo = equipo
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim equipoDAO As New DAO.equipoDAO
            Dim costeDAO As New Coste.DAO.CosteDAO
            Dim accionDAO As New Accion.DAO.accionDAO
            Dim comisionDAO As New Comision.DAO.ComisionDAO
            Dim integranteDAO As New Integrante.DAO.IntegranteDAO

            '20070403: Obtenemos la configuracion ****
            Dim configurationDAO As New Configuration.DAO.ConfigurationDAO

            Dim configCurrentYear As New gesInef.lib.vo.configuracion.ConfigurationVO
            Dim configCurrentCounter As New gesInef.lib.vo.configuracion.ConfigurationVO

            configCurrentCounter.Parametro = gesInef.lib.dao.Configuration.DAO.ConfigurationDAO.CONFIG_CURRENTCOUNTER_INEF
            configCurrentCounter = configurationDAO.selectRegistro(factory.Command, configCurrentCounter)

            configCurrentYear.Parametro = gesInef.lib.dao.Configuration.DAO.ConfigurationDAO.CONFIG_CURRENTYEAR_INEF
            configCurrentYear = configurationDAO.selectRegistro(factory.Command, configCurrentYear)

            If (configCurrentYear Is Nothing) Then
                configCurrentYear = New gesInef.lib.vo.configuracion.ConfigurationVO
                configCurrentYear.Parametro = gesInef.lib.dao.Configuration.DAO.ConfigurationDAO.CONFIG_CURRENTYEAR_INEF
                configCurrentYear.Valor = _equipo.Fecha.Year.ToString

                configurationDAO.insertRegistro(factory.Command, configCurrentYear)
                If (configCurrentCounter Is Nothing) Then
                    configCurrentCounter = New gesInef.lib.vo.configuracion.ConfigurationVO
                    configCurrentCounter.Parametro = gesInef.lib.dao.Configuration.DAO.ConfigurationDAO.CONFIG_CURRENTCOUNTER_INEF
                    configCurrentCounter.Valor = "0"

                    configurationDAO.insertRegistro(factory.Command, configCurrentCounter)
                Else
                    configCurrentCounter.Valor = "0"
                    configurationDAO.updateRegistro(factory.Command, configCurrentCounter)
                End If
            Else
                If (configCurrentYear.Valor <> _equipo.Fecha.Year.ToString) Then
                    configCurrentYear.Valor = _equipo.Fecha.Year.ToString
                    configurationDAO.updateRegistro(factory.Command, configCurrentYear)

                    If (configCurrentCounter Is Nothing) Then
                        configCurrentCounter = New gesInef.lib.vo.configuracion.ConfigurationVO
                        configCurrentCounter.Parametro = gesInef.lib.dao.Configuration.DAO.ConfigurationDAO.CONFIG_CURRENTCOUNTER_INEF
                        configCurrentCounter.Valor = "0"

                        configurationDAO.insertRegistro(factory.Command, configCurrentCounter)
                    Else
                        configCurrentCounter.Valor = "0"
                        configurationDAO.updateRegistro(factory.Command, configCurrentCounter)
                    End If
                Else
                    If (configCurrentCounter Is Nothing) Then
                        configCurrentCounter = New gesInef.lib.vo.configuracion.ConfigurationVO
                        configCurrentCounter.Parametro = gesInef.lib.dao.Configuration.DAO.ConfigurationDAO.CONFIG_CURRENTCOUNTER_INEF
                        configCurrentCounter.Valor = "0"

                        configurationDAO.insertRegistro(factory.Command, configCurrentCounter)
                    End If
                End If
            End If

            _equipo.Numero = Convert.ToInt64(configCurrentCounter.Valor)
            _equipo.Numero += 1
            _equipo.Codigo = gesInef.lib.util.constantes.vacio.CODIGO
            configCurrentCounter.Valor = Convert.ToString(_equipo.Numero)
            configurationDAO.updateRegistro(factory.Command, configCurrentCounter)

            '*****************************************
            _equipo.Id = equipoDAO.insertRegistro(factory.Command, _equipo)

            '20070329: Log de transacciones
            Dim aLog As gesInef.lib.vo.log.LogVO() = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(Me._equipo, Me._equipo.Id, "")
            'If Not (aLog Is Nothing) Then
            Dim transactionDAO As New Transaction.DAO.TransactionDAO

            Dim trans As New gesInef.lib.vo.transaction.TransactionVO
            trans.Comentario = gesInef.lib.vo.transaction.TransactionVO.COMMENT_NUEVO + Me._equipo.GetType.Name
            trans.Usuario = _equipo.Usuario.Codigo
            trans.Id = transactionDAO.insertRegistro(factory.Command, trans)

            Dim logDAO As New Log.DAO.LogDAO

            For Each log As gesInef.lib.vo.log.LogVO In aLog
                log.Transaccion = trans
                log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                logDAO.insertRegistro(factory.Command, log)
            Next
            'End If
            '***********************


            If Not (_equipo.Costes Is Nothing) Then
                For Each coste As gesInef.lib.vo.coste.CosteVO In _equipo.Costes
                    coste.equipo = _equipo
                    coste.Id = costeDAO.insertRegistro(factory.Command, coste)
                    aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(coste, coste.Id, "")
                    For Each log As gesInef.lib.vo.log.LogVO In aLog
                        log.Transaccion = trans
                        log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                        logDAO.insertRegistro(factory.Command, log)
                    Next
                Next
            End If
            '<20071004> Cambio! esto debería haber ido aquí desde el principio
            'Comprobación del tipo de repetición de la equipo
            If (_equipo.Repeticion <> baseball.lib.vo.Equipo.tPeriodicidadInef.Ocasional) Then
                If Not (_equipo.Acciones Is Nothing) Then
                    Dim tareaDAO As New Tarea.DAO.TareaDAO

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
                    Next
                End If

                If Not (_equipo.Comision Is Nothing) Then
                    _equipo.Comision.equipo = _equipo
                    _equipo.Comision.Id = comisionDAO.insertRegistro(factory.Command, _equipo.Comision)
                    ' ******* Log ********
                    aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(_equipo.Comision, _equipo.Comision.Id, "")
                    For Each log As gesInef.lib.vo.log.LogVO In aLog
                        log.Transaccion = trans
                        log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                        logDAO.insertRegistro(factory.Command, log)
                    Next
                    '*********************
                    If Not (_equipo.Comision.Integrantes Is Nothing) Then
                        For Each integrante As gesInef.lib.vo.integrante.IntegranteVO In _equipo.Comision.Integrantes
                            integrante.Comision = _equipo.Comision
                            integrante.Id = integranteDAO.insertRegistro(factory.Command, integrante)
                            ' ******* Log ********
                            aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(integrante, integrante.Id, "")
                            For Each log As gesInef.lib.vo.log.LogVO In aLog
                                log.Transaccion = trans
                                log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                                logDAO.insertRegistro(factory.Command, log)
                            Next
                            '*********************
                        Next
                    End If
                End If

            Else
                If (Not _equipo.equipoOriginal Is Nothing) Then
                    '***************** Acciones *****************
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
                                Else
                                    If (htDbAccion.ContainsKey(Accion.Id)) Then
                                        Accion.Tareas = tareaDAO.selectRegistrosByAccion(factory.Command, Accion)

                                        ' ******* Log ********
                                        aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(CType(htDbAccion.Item(Accion.Id), gesInef.lib.vo.accion.AccionChunkVO).Accion, Accion, Accion.Id)
                                        If Not (aLog Is Nothing) Then
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


                    '***************** Comision/Integrantes *****************
                    Dim counterComision As Integer = 0

                    If Not (_equipo.Comision Is Nothing) Then
                        _equipo.Comision.equipo = _equipo.equipoOriginal
                        '<20080123> Un control...por controlar...
                        'If (comisionDAO.selectRegistro(factory.Command, _equipo.Comision) Is Nothing) Then
                        '    _equipo.Comision.equipo = _equipo
                        '    _equipo.Comision.Id = comisionDAO.insertRegistro(factory.Command, _equipo.Comision)
                        'End If
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
                        '</20080123> ****************************

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
                                    Else
                                        If (htDbIntegrante.ContainsKey(Integrante.Id)) Then
                                            ' ******* Log ********
                                            aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(CType(htDbIntegrante.Item(Integrante.Id), gesInef.lib.vo.integrante.IntegranteChunkVO).Integrante, Integrante, Integrante.Id)
                                            If Not (aLog Is Nothing) Then
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

            ''</20071004> ****************************************************

            '<20070606>  * Anexo de ficheros directamente a la BD *
            If Not (_equipo.FicherosVO Is Nothing) Then
                Dim ficherovoDAO As New Fichero.DAO.FicheroDAO

                For Each fichero As gesInef.lib.vo.fichero.FicheroVO In _equipo.FicherosVO
                    'Es una insercion, asi que todos los ficheros son nuevos
                    'simplemente los copiamos
                    fichero.equipo = Me._equipo
                    ficherovoDAO.insertRegistro(factory.Command, fichero)
                    '' ******* Log ********
                    'aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(accion, accion.Id, "")
                    'For Each log As gesInef.lib.vo.log.LogVO In aLog
                    '    log.Transaccion = trans
                    '    log.Accion = gesInef.lib.vo.log.LogVO.action_NUEVO
                    '    logDAO.insertRegistro(factory.Command, log)
                    'Next
                    '*********************
                Next
            End If
            '</20070606>  ****************************************
            Return _equipo
        End Function
    End Class
End Namespace
