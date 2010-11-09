Namespace _exceptions.ineficiencia
    Public Class MissingAreaException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("No se ha establecido el área.")
        End Sub

    End Class
End Namespace

