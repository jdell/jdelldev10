Namespace _exceptions.ineficiencia
    Public Class MAXIMOPendingException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("No se puede cerrar la ineficiencia dado que a�n hay costes pendientes en M�XIMO.")
        End Sub

    End Class
End Namespace

