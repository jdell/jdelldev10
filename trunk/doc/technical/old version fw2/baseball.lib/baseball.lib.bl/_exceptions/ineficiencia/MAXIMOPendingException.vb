Namespace _exceptions.ineficiencia
    Public Class MAXIMOPendingException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("No se puede cerrar la ineficiencia dado que aún hay costes pendientes en MÁXIMO.")
        End Sub

    End Class
End Namespace

