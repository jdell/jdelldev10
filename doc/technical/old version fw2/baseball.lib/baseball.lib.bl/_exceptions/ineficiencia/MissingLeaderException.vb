Namespace _exceptions.ineficiencia
    Public Class MissingLeaderException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("Debe indicar el l�der de la comisi�n.")
        End Sub

    End Class
End Namespace

