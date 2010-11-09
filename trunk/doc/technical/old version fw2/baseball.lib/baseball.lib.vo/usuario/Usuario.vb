Public Class Usuario
    Private _codigo As String

    Public Sub New()

    End Sub

    Public Sub New(ByVal codigo As String)
        _codigo = codigo
    End Sub

    Private _id As Int16
    Private _nombre As String

    Public Property Id() As Int16
        Get
            Return _id
        End Get
        Set(ByVal value As Int16)
            _id = value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Codigo
    End Function
End Class
