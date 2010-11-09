Namespace hojaanotacion

    Public Class doUpdate
        Inherits _template.ActionBL

        Private accionhojaanotacion As New baseball.lib.dao.hojaanotacion.fachada
        Private _hojaanotacion As baseball.lib.vo.HojaAnotacion


        Public Sub New(ByVal hojaanotacion As baseball.lib.vo.HojaAnotacion)
            _hojaanotacion = hojaanotacion
        End Sub
        Public Shadows Function execute() As Object
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Try
                If (_hojaanotacion Is Nothing) Then
                    Throw New _exceptions._common.NullReferenceException()
                End If

                Return accionhojaanotacion.update(_hojaanotacion)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace
