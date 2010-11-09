Namespace _exceptions.ineficiencia
    Public Class MissingZoneException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("No se ha establecido la zona.")
        End Sub

    End Class
End Namespace

