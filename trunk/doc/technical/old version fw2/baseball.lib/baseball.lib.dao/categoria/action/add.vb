Namespace categoria.action
    Friend Class add
        Implements _common.plain.TransactionalPlainAction

        Private _categoria As baseball.lib.vo.Categoria

        Public Sub New(ByVal categoria As baseball.lib.vo.Categoria)
            Me._categoria = categoria
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim categoriaDAO As New DAO.categoriaDAO

            _categoria.Id = categoriaDAO.add(factory.Command, _categoria)

            Return _categoria
        End Function
    End Class
End Namespace
