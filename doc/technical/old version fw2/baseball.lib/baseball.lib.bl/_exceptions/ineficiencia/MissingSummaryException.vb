Namespace _exceptions.ineficiencia
    Public Class MissingSummaryException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("No se ha establecido la descripci�n resumida.")
        End Sub

    End Class
End Namespace

