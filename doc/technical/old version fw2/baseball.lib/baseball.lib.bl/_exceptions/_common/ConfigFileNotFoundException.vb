Namespace _exceptions._common
    Public Class ConfigFileNotFoundException
        Inherits BaseballException

        Public Sub New()
            MyBase.new(baseball.lib.bl._common.constantes.mensaje.NOT_FOUND_CONFIGFILE, baseball.lib.bl._common.constantes.mensaje.NOTIFY_ADMINISTRATOR)
        End Sub

    End Class
End Namespace

