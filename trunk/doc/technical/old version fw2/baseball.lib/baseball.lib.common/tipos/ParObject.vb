Namespace tipos
    <Serializable()> _
    Public Class ParObject

        Private _obj1 As Object
        Private _obj2 As Object

        Public Sub New()
            _obj1 = Nothing
            _obj2 = Nothing
        End Sub

        Protected Property Object1() As Object
            Get
                Return _obj1
            End Get
            Set(ByVal value As Object)
                _obj1 = value
            End Set
        End Property
        Protected Property Object2() As Object
            Get
                Return _obj2
            End Get
            Set(ByVal value As Object)
                _obj2 = value
            End Set
        End Property

    End Class
End Namespace

