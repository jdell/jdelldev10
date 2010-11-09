
Namespace partido.action
    Friend Class remove
        Implements _common.plain.TransactionalPlainAction

        Private _partido As baseball.lib.vo.Partido

        Public Sub New(ByVal partido As baseball.lib.vo.Partido)
            Me._partido = partido
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim partidoDAO As New DAO.partidoDAO

            Return partidoDAO.remove(factory.Command, _partido)
        End Function
    End Class
End Namespace
