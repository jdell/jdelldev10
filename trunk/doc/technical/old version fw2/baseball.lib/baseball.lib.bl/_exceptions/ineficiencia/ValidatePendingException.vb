Namespace _exceptions.ineficiencia
    Public Class ValidatePendingException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("No se puede cerrar la ineficiencia dado que est� pendiente de validar.")
        End Sub

    End Class
End Namespace

