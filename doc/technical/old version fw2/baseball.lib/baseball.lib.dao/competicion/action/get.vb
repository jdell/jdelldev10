
Namespace competicion.action
    Friend Class [get]
        Implements _common.plain.NonTransactionalPlainAction

        Private _competicion As baseball.lib.vo.Competicion

        Public Sub New(ByVal competicion As baseball.lib.vo.Competicion)
            Me._competicion = competicion
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim competicionDAO As New DAO.competicionDAO

            Return competicionDAO.get(factory.Command, _competicion)
        End Function
    End Class
End Namespace
