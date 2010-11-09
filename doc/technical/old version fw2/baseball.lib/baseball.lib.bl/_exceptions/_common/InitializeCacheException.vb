Namespace _exceptions._common
    Public Class InitializeCacheException
        Inherits BaseballException

        Public Sub New()
            MyBase.new(baseball.lib.bl._common.constantes.mensaje.NOT_LOADED_CACHE, baseball.lib.bl._common.constantes.mensaje.NOTIFY_ADMINISTRATOR)
        End Sub

    End Class
End Namespace

