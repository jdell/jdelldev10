Namespace competicion.action
    Friend Class add
        Implements _common.plain.TransactionalPlainAction

        Private _competicion As baseball.lib.vo.Competicion

        Public Sub New(ByVal competicion As baseball.lib.vo.Competicion)
            Me._competicion = competicion
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim competicionDAO As New DAO.competicionDAO

            _competicion.Id = competicionDAO.add(factory.Command, _competicion)

            Return _competicion
        End Function
    End Class
End Namespace
