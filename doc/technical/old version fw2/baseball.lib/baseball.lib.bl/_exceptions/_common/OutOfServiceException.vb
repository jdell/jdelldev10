Namespace _exceptions._common
    Public Class OutOfServiceException
        Inherits BaseballException

        Public Sub New(ByVal message As String)
            MyBase.new(message, baseball.lib.bl._common.constantes.mensaje.NOTIFY_ADMINISTRATOR)
        End Sub

    End Class
End Namespace

