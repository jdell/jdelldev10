Namespace hojaanotacion.catcher

    Public Class doGetAll
        Inherits _template.ActionBL

        Private accionhojaanotacioncatcher As New baseball.lib.dao.hojaanotacioncatcher.fachada
        Public Shadows Function execute() As List(Of baseball.lib.vo.HojaAnotacionCatcher)
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Dim res As List(Of baseball.lib.vo.HojaAnotacionCatcher)
            Try
                res = accionhojaanotacioncatcher.getAll()
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace