Namespace jugador
    Public Class doRemove
        Inherits _template.ActionBL

        Private accionjugador As New baseball.lib.dao.jugador.fachada
        Private _jugador As baseball.lib.vo.Jugador

        Public Sub New(ByVal jugador As baseball.lib.vo.Jugador)
            _jugador = jugador
        End Sub
        Public Shadows Function execute() As Object
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Try
                If (_jugador Is Nothing) Then
                    Throw New _exceptions._common.NullReferenceException()
                End If

                Return accionjugador.remove(_jugador)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace
