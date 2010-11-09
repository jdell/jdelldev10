Namespace _exceptions._common
    Public Class NullReferenceException
        Inherits BaseballException

        Public Sub New()
            MyBase.new("Objeto no especificado [¿Null?]", baseball.lib.bl._common.constantes.mensaje.NOTIFY_ADMINISTRATOR)
        End Sub

    End Class
End Namespace

