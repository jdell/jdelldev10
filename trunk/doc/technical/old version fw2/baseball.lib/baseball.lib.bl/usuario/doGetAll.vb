Namespace usuario

    Public Class doGetAll
        Inherits _template.ActionBL

        Private accionusuario As New baseball.lib.dao.usuario.fachada
        Public Shadows Function execute() As List(Of baseball.lib.vo.Usuario)
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Dim res As List(Of baseball.lib.vo.Usuario)
            Try
                res = accionusuario.getAll()
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace