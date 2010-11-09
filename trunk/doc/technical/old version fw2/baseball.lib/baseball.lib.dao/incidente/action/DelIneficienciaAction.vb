
Namespace equipo.action
    Friend Class DelequipoAction
        Implements _common.plain.TransactionalPlainAction

        Private _equipo As baseball.lib.vo.Equipo

        Public Sub New(ByVal equipo As baseball.lib.vo.Equipo)
            Me._equipo = equipo
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim equipoDAO As New DAO.equipoDAO



            '20070329: Log de transacciones
            Dim transactionDAO As New Transaction.DAO.TransactionDAO

            Dim trans As New gesInef.lib.vo.transaction.TransactionVO
            trans.Comentario = gesInef.lib.vo.transaction.TransactionVO.COMMENT_BORRADO + Me._equipo.GetType.Name
            If Not (_equipo.Usuario Is Nothing) Then trans.Usuario = _equipo.Usuario.Codigo
            trans.Id = transactionDAO.insertRegistro(factory.Command, trans)
            Dim logDAO As New Log.DAO.LogDAO

            Dim aLog As gesInef.lib.vo.log.LogVO() = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(Me._equipo, Me._equipo.Id, "")
            If Not (aLog Is Nothing) Then
                For Each log As gesInef.lib.vo.log.LogVO In aLog
                    log.Transaccion = trans
                    log.Accion = gesInef.lib.vo.log.LogVO.action_BORRADO
                    logDAO.insertRegistro(factory.Command, log)
                Next
            End If

            Dim costeDAO As New Coste.DAO.CosteDAO

            Dim aDbCostes As gesInef.lib.vo.coste.CosteChunkVO()
            aDbCostes = costeDAO.getCostesByequipo(factory.Command, Me._equipo)
            If Not (aDbCostes Is Nothing) Then
                For Each cost As gesInef.lib.vo.coste.CosteChunkVO In aDbCostes
                    aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(cost.Coste, cost.Id, "")
                    For Each log As gesInef.lib.vo.log.LogVO In aLog
                        log.Transaccion = trans
                        log.Accion = gesInef.lib.vo.log.LogVO.action_BORRADO
                        logDAO.insertRegistro(factory.Command, log)
                    Next
                Next
            End If

            Dim accionDAO As New Accion.DAO.accionDAO

            Dim aDbAcciones As gesInef.lib.vo.accion.AccionChunkVO()
            aDbAcciones = accionDAO.selectRegistroesByequipo(factory.Command, Me._equipo)
            If Not (aDbAcciones Is Nothing) Then
                For Each acc As gesInef.lib.vo.accion.AccionChunkVO In aDbAcciones
                    aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(acc.Accion, acc.Id, "")
                    For Each log As gesInef.lib.vo.log.LogVO In aLog
                        log.Transaccion = trans
                        log.Accion = gesInef.lib.vo.log.LogVO.action_BORRADO
                        logDAO.insertRegistro(factory.Command, log)
                    Next
                Next
            End If

            Dim comisionDAO As New Comision.DAO.ComisionDAO

            Dim comision As gesInef.lib.vo.comision.ComisionVO
            comision = comisionDAO.selectRegistroByequipo(factory.Command, Me._equipo)
            If Not (comision Is Nothing) Then
                aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(comision, comision.Id, "")
                For Each log As gesInef.lib.vo.log.LogVO In aLog
                    log.Transaccion = trans
                    log.Accion = gesInef.lib.vo.log.LogVO.action_BORRADO
                    logDAO.insertRegistro(factory.Command, log)
                Next

                Dim integranteDAO As New Integrante.DAO.IntegranteDAO

                Dim aDbIntegrantes As gesInef.lib.vo.integrante.IntegranteChunkVO()
                aDbIntegrantes = integranteDAO.getIntegrantesByComision(factory.Command, comision)
                If Not (aDbIntegrantes Is Nothing) Then
                    For Each int As gesInef.lib.vo.integrante.IntegranteChunkVO In aDbIntegrantes
                        aLog = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(int.Integrante, int.Id, "")
                        For Each log As gesInef.lib.vo.log.LogVO In aLog
                            log.Transaccion = trans
                            log.Accion = gesInef.lib.vo.log.LogVO.action_BORRADO
                            logDAO.insertRegistro(factory.Command, log)
                        Next
                    Next
                End If
            End If

            '<20070611> Borrado de ficheros de la BD
            'Sistema de log no implementado aqui
            Dim ficheroDAO As New Fichero.DAO.FicheroDAO

            ficheroDAO.delFicheroByequipo(factory.Command, Me._equipo)
            '</20070611> **************************

            '***********************

            Return equipoDAO.deleteRegistro(factory.Command, _equipo)
        End Function
    End Class
End Namespace
