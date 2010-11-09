Namespace hojaanotacion.pitcher

    Public Class doGetAll
        Inherits _template.ActionBL

        Private accionhojaanotacionpitcher As New baseball.lib.dao.hojaanotacionpitcher.fachada
        Public Shadows Function execute() As List(Of baseball.lib.vo.HojaAnotacionPitcher)
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Dim res As List(Of baseball.lib.vo.HojaAnotacionPitcher)
            Try
                res = accionhojaanotacionpitcher.getAll()
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace