
Namespace estadistica.action
    Friend Class getAllForBatting
        Implements _common.plain.NonTransactionalPlainAction

        Dim _filtro As vo.FiltroEstadistica
        Public Sub New(ByVal filtro As vo.FiltroEstadistica)
            _filtro = filtro
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim estadisticaDAO As New DAO.estadisticaDAO

            Return estadisticaDAO.getAll(factory.Command)
        End Function
    End Class
End Namespace
