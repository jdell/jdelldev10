
Namespace usuario.action
    Friend Class checkIfExists
        Implements _common.plain.NonTransactionalPlainAction

        Private _usuario As baseball.lib.vo.Usuario

        Public Sub New(ByVal usuario As baseball.lib.vo.Usuario)
            Me._usuario = usuario
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim usuarioDAO As New DAO.usuarioDAO

            Return usuarioDAO.checkIfExists(factory.Command, _usuario)
        End Function
    End Class
End Namespace
