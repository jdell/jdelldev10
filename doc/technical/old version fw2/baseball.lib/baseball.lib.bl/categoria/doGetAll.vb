Namespace categoria

    Public Class doGetAll
        Inherits _template.ActionBL

        Private accioncategoria As New baseball.lib.dao.categoria.fachada
        Public Shadows Function execute() As List(Of baseball.lib.vo.Categoria)
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Dim res As List(Of baseball.lib.vo.Categoria)
            Try
                res = accioncategoria.getAll()
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace