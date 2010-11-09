Namespace _exceptions.usuario
    Public Class UserNotFoundException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new(baseball.lib.bl._common.constantes.mensaje.NOT_FOUND_USER, baseball.lib.bl._common.constantes.mensaje.NOTIFY_ADMINISTRATOR)
        End Sub

    End Class
End Namespace

