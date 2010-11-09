Namespace _exceptions._common
    Public Class IncorrectFormatConfigFileException
        Inherits BaseballException

        Public Sub New()
            MyBase.new(baseball.lib.bl._common.constantes.mensaje.INCORRECT_FORMAT_CONFIG_FILE, baseball.lib.bl._common.constantes.mensaje.NOTIFY_ADMINISTRATOR)
        End Sub

    End Class
End Namespace

