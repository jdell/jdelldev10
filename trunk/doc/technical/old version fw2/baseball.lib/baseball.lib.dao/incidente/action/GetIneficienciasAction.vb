
Namespace equipo.action
    Friend Class GetequiposAction
        Implements _common.plain.NonTransactionalPlainAction


        Public Sub New()
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim equipoDAO As New DAO.equipoDAO

            Return equipoDAO.selectRegistros(factory.Command)
        End Function
    End Class
End Namespace
