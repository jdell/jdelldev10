Namespace hojaanotacion.catcher

    Public Class doGet
        Inherits _template.ActionBL

        Private accionhojaanotacioncatcher As New baseball.lib.dao.hojaanotacioncatcher.fachada
        Private _hojaanotacioncatcher As baseball.lib.vo.HojaAnotacionCatcher

        Public Sub New(ByVal hojaanotacioncatcher As baseball.lib.vo.HojaAnotacionCatcher)
            _hojaanotacioncatcher = hojaanotacioncatcher
        End Sub

        Public Shadows Function execute() As baseball.lib.vo.HojaAnotacionCatcher
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Try
                If (_hojaanotacioncatcher Is Nothing) Then
                    Throw New _exceptions._common.NullReferenceException()
                End If

                Return accionhojaanotacioncatcher.get(_hojaanotacioncatcher)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace

