
Namespace hojaanotacioncatcher.action
    Friend Class getAll
        Implements _common.plain.NonTransactionalPlainAction


        Public Sub New()
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim hojaanotacioncatcherDAO As New DAO.hojaanotacioncatcherDAO

            Return hojaanotacioncatcherDAO.getAll(factory.Command)
        End Function
    End Class
End Namespace
