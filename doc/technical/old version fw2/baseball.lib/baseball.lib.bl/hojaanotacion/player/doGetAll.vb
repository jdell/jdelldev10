Namespace hojaanotacion.player

    Public Class doGetAll
        Inherits _template.ActionBL

        Private accionhojaanotacionplayer As New baseball.lib.dao.hojaanotacionplayer.fachada
        Public Shadows Function execute() As List(Of baseball.lib.vo.HojaAnotacionPlayer)
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Dim res As List(Of baseball.lib.vo.HojaAnotacionPlayer)
            Try
                res = accionhojaanotacionplayer.getAll()
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace