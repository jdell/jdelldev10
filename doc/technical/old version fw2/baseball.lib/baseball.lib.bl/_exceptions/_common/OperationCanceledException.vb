Namespace _exceptions._common
    Public Class OperationCanceledException
        Inherits BaseballException

        Public Sub New()
            MyBase.new(baseball.lib.bl._common.constantes.mensaje.OPERATION_CANCELED)
        End Sub

    End Class
End Namespace

