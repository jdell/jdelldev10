
Namespace equipo.action
    Friend Class GetequipoAction
        Implements _common.plain.NonTransactionalPlainAction

        Private _equipo As baseball.lib.vo.Equipo

        Public Sub New(ByVal equipo As baseball.lib.vo.Equipo)
            Me._equipo = equipo
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim equipoDAO As New DAO.equipoDAO

            Return equipoDAO.getequipoAllData(factory.Command, _equipo)
        End Function
    End Class
End Namespace
