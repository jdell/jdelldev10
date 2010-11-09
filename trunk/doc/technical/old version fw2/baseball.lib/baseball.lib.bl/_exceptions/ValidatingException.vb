Namespace _exceptions
    Public MustInherit Class ValidatingException
        Inherits BaseballException

        Public Sub New(ByVal mensaje As String)
            MyBase.New(mensaje)
        End Sub

        Public Sub New(ByVal mensaje As String, ByVal detalle As String)
            MyBase.New(mensaje, detalle)
        End Sub

    End Class

End Namespace
