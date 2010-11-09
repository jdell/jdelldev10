
Namespace categoria.action
    Friend Class remove
        Implements _common.plain.TransactionalPlainAction

        Private _categoria As baseball.lib.vo.Categoria

        Public Sub New(ByVal categoria As baseball.lib.vo.Categoria)
            Me._categoria = categoria
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim categoriaDAO As New DAO.categoriaDAO

            Return categoriaDAO.remove(factory.Command, _categoria)
        End Function
    End Class
End Namespace
