Public Class Competicion

    Public Sub New()
        Me._id = common.constantes.vacio.ID
        Me._descripcion = String.Empty
    End Sub

    Private _id As Short
    Public Property Id() As Short
        Get
            Return _id
        End Get
        Set(ByVal value As Short)
            _id = value
        End Set
    End Property

    Private _descripcion As String
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
