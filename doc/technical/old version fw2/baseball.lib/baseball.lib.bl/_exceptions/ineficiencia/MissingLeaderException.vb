Namespace _exceptions.ineficiencia
    Public Class MissingLeaderException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("Debe indicar el líder de la comisión.")
        End Sub

    End Class
End Namespace

