Public Class Equipo

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

    Private _jugadores As New List(Of Jugador)
    Public ReadOnly Property Jugadores() As List(Of Jugador)
        Get
            Return _jugadores
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Descripcion
    End Function

End Class
