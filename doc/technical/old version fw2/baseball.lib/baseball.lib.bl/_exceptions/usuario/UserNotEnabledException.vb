Namespace _exceptions.usuario
    Public Class UserNotEnabledException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new(baseball.lib.bl._common.constantes.mensaje.NOT_ENABLED_USER, baseball.lib.bl._common.constantes.mensaje.NOTIFY_ADMINISTRATOR)
        End Sub

    End Class
End Namespace

