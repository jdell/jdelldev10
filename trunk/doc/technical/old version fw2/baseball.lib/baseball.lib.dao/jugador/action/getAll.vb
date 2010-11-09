
Namespace jugador.action
    Friend Class getAll
        Implements _common.plain.NonTransactionalPlainAction


        Public Sub New()
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim jugadorDAO As New DAO.jugadorDAO

            Return jugadorDAO.getAll(factory.Command)
        End Function
    End Class
End Namespace
