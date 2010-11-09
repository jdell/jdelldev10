Namespace _exceptions.ineficiencia
    Public Class MissingUnitException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("No se ha establecido la unidad.")
        End Sub

    End Class
End Namespace

