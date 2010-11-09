Namespace _exceptions._common
    Public Class AccessNotAllowedException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new(baseball.lib.bl._common.constantes.mensaje.NO_ACCESS_ALLOWED, baseball.lib.bl._common.constantes.mensaje.NOTIFY_ADMINISTRATOR)
        End Sub

    End Class
End Namespace

