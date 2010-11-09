
Namespace hojaanotacionpitcher.action
    Friend Class getAll
        Implements _common.plain.NonTransactionalPlainAction


        Public Sub New()
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim hojaanotacionpitcherDAO As New DAO.hojaanotacionpitcherDAO

            Return hojaanotacionpitcherDAO.getAll(factory.Command)
        End Function
    End Class
End Namespace
