Namespace _exceptions.partido
    Public Class MissingModalityException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("Falta indicar la modalidad.")
        End Sub

    End Class
End Namespace

