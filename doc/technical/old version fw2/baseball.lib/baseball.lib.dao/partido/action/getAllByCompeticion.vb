
Namespace partido.action
    Friend Class getAllByCompeticion
        Implements _common.plain.NonTransactionalPlainAction

        Private _competicion As vo.Competicion
        Public Sub New(ByVal competicion As vo.Competicion)
            _competicion = competicion
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim partidoDAO As New DAO.partidoDAO

            Return partidoDAO.getAll(factory.Command, _competicion)
        End Function
    End Class
End Namespace
