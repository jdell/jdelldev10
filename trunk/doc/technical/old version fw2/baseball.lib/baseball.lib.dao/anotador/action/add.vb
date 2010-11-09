Namespace anotador.action
    Friend Class add
        Implements _common.plain.TransactionalPlainAction

        Private _anotador As baseball.lib.vo.Anotador

        Public Sub New(ByVal anotador As baseball.lib.vo.Anotador)
            Me._anotador = anotador
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim anotadorDAO As New DAO.anotadorDAO

            _anotador.Id = anotadorDAO.add(factory.Command, _anotador)

            Return _anotador
        End Function
    End Class
End Namespace
