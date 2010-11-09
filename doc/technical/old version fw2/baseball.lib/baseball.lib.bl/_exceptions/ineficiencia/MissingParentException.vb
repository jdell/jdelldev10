Namespace _exceptions.ineficiencia
    Public Class MissingParentException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("La ineficiencia es Periódica/Ocasional, debe indicar la ineficiencia original.")
        End Sub

    End Class
End Namespace

