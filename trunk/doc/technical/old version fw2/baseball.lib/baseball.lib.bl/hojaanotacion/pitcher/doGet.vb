Namespace hojaanotacion.pitcher

    Public Class doGet
        Inherits _template.ActionBL

        Private accionhojaanotacionpitcher As New baseball.lib.dao.hojaanotacionpitcher.fachada
        Private _hojaanotacionpitcher As baseball.lib.vo.HojaAnotacionPitcher

        Public Sub New(ByVal hojaanotacionpitcher As baseball.lib.vo.HojaAnotacionPitcher)
            _hojaanotacionpitcher = hojaanotacionpitcher
        End Sub

        Public Shadows Function execute() As baseball.lib.vo.HojaAnotacionPitcher
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Try
                If (_hojaanotacionpitcher Is Nothing) Then
                    Throw New _exceptions._common.NullReferenceException()
                End If

                Return accionhojaanotacionpitcher.get(_hojaanotacionpitcher)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace

