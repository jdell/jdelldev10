Namespace _exceptions.ineficiencia
    Public Class MissingTypeOfInefficiencyException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("No se ha establecido el tipo de ineficiencia.")
        End Sub

    End Class
End Namespace

