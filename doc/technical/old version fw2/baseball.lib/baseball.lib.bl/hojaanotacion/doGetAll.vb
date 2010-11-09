Namespace hojaanotacion

    Public Class doGetAll
        Inherits _template.ActionBL

        Private accionhojaanotacion As New baseball.lib.dao.hojaanotacion.fachada
        Public Shadows Function execute() As List(Of baseball.lib.vo.HojaAnotacion)
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Dim res As List(Of baseball.lib.vo.HojaAnotacion)
            Try
                res = accionhojaanotacion.getAll()
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace