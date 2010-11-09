Namespace tipos
    <Serializable()> _
    Public Class ParInt32
        Inherits ParObject

        Public Sub New()
        End Sub

        Public Property Desde() As Nullable(Of Int32)
            Get
                Return Me.Object1
            End Get
            Set(ByVal value As Nullable(Of Int32))
                Me.Object1 = value
            End Set
        End Property
        Public Property Hasta() As Nullable(Of Int32)
            Get
                Return Me.Object2
            End Get
            Set(ByVal value As Nullable(Of Int32))
                Me.Object2 = value
            End Set
        End Property

    End Class
End Namespace

