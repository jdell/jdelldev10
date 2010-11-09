
Namespace anotador.action
    Friend Class [get]
        Implements _common.plain.NonTransactionalPlainAction

        Private _anotador As baseball.lib.vo.Anotador

        Public Sub New(ByVal anotador As baseball.lib.vo.Anotador)
            Me._anotador = anotador
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim anotadorDAO As New DAO.anotadorDAO

            Return anotadorDAO.get(factory.Command, _anotador)
        End Function
    End Class
End Namespace
