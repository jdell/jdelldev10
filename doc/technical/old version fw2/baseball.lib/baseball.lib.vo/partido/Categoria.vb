Public Class Categoria

    Private _id As Int16
    Private _descripcion As String

    Public Sub New()
        Me._id = common.constantes.vacio.ID
        Me._descripcion = String.Empty
    End Sub

    Public Property Id() As Int16
        Get
            Return _id
        End Get
        Set(ByVal value As Int16)
            _id = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Descripcion
    End Function

End Class
