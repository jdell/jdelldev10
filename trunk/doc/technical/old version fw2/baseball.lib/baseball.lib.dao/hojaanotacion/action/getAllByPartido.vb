
Namespace hojaanotacion.action
    Friend Class getAllByPartido
        Implements _common.plain.NonTransactionalPlainAction

        Private _partido As baseball.lib.vo.Partido
        Private _full As Boolean
        Public Sub New(ByVal partido As baseball.lib.vo.Partido, Optional ByVal full As Boolean = False)
            _partido = partido
            _full = full
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim hojaanotacionDAO As New DAO.hojaanotacionDAO

            Return hojaanotacionDAO.getAllByPartido(factory.Command, _partido)
        End Function
    End Class
End Namespace
