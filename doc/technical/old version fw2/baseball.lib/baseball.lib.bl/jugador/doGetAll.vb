Namespace jugador

    Public Class doGetAll
        Inherits _template.ActionBL

        Private accionjugador As New baseball.lib.dao.jugador.fachada
        Public Shadows Function execute() As List(Of baseball.lib.vo.Jugador)
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Dim res As List(Of baseball.lib.vo.Jugador)
            Try
                res = accionjugador.getAll()
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace