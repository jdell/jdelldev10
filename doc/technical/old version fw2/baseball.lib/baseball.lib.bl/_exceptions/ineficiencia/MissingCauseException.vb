Namespace _exceptions.ineficiencia
    Public Class MissingCauseException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("No se ha establecido la causa o causas de la ineficiencia.")
        End Sub

    End Class
End Namespace

