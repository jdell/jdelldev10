Namespace hojaanotacion.player
    Public Class doRemove
        Inherits _template.ActionBL

        Private accionhojaanotacionplayer As New baseball.lib.dao.hojaanotacionplayer.fachada
        Private _hojaanotacionplayer As baseball.lib.vo.HojaAnotacionPlayer

        Public Sub New(ByVal hojaanotacionplayer As baseball.lib.vo.HojaAnotacionPlayer)
            _hojaanotacionplayer = hojaanotacionplayer
        End Sub
        Public Shadows Function execute() As Object
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Try
                If (_hojaanotacionplayer Is Nothing) Then
                    Throw New _exceptions._common.NullReferenceException()
                End If

                Return accionhojaanotacionplayer.remove(_hojaanotacionplayer)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace
