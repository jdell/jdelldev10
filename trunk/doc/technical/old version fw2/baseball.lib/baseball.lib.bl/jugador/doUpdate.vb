Namespace jugador

    Public Class doUpdate
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

                If (_jugador.Equipo Is Nothing) OrElse (_jugador.Equipo.Id = baseball.lib.common.constantes.vacio.ID) Then
                    Throw New _exceptions.usuario.MissingTeamException()
                End If

                Return accionjugador.update(_jugador)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace
