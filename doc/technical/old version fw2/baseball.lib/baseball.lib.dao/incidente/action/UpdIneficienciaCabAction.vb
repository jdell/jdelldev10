
Namespace equipo.action
    Friend Class UpdequipoCabAction
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
            trans.Comentario = gesInef.lib.vo.transaction.TransactionVO.COMMENT_MODIFICACION + Me._equipo.GetType.Name
            trans.Usuario = _equipo.Usuario.Codigo
            trans.Id = transactionDAO.insertRegistro(factory.Command, trans)
            Dim logDAO As New Log.DAO.LogDAO

            Dim inefBDAnterior As baseball.lib.vo.Equipo = equipoDAO.getequipoAllData(factory.Command, Me._equipo)
            Dim aLog As gesInef.lib.vo.log.LogVO() = gesInef.lib.vo.transaction.TransactionVO.GenerateLog(inefBDAnterior, Me._equipo, Me._equipo.Id)
            If Not (aLog Is Nothing) Then
                For Each log As gesInef.lib.vo.log.LogVO In aLog
                    log.Transaccion = trans
                    log.Accion = gesInef.lib.vo.log.LogVO.action_MODIFICACION
                    logDAO.insertRegistro(factory.Command, log)
                Next
            End If
            '***********************

            equipoDAO.updateRegistro(factory.Command, _equipo)

            Return Me._equipo.Substract(inefBDAnterior)

        End Function
    End Class
End Namespace
