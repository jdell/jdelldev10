
Namespace equipo.action
    Friend Class GetequiposByAreasUsuarioAction
        Implements _common.plain.NonTransactionalPlainAction

        Private _usuario As gesInef.lib.vo.usuario.UsuarioVO

        Public Sub New(ByVal _usuario As gesInef.lib.vo.usuario.UsuarioVO)
            Me._usuario = _usuario
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim equipoDAO As New DAO.equipoDAO

            Return equipoDAO.getequiposByAreasUsuario(factory.Command, Me._usuario)
        End Function
    End Class
End Namespace
