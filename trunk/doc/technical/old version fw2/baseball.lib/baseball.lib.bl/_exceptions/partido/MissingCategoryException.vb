Namespace _exceptions.partido
    Public Class MissingCategoryException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("Falta indicar la categoria.")
        End Sub

    End Class
End Namespace

