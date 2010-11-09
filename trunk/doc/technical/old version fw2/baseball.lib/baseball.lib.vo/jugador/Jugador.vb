Public Class Jugador

    Private _id As Integer
    Private _nombre As String
    Private _apellido1 As String
    Private _apellido2 As String
    Private _equipo As Equipo

    Public Sub New()
        Me._apellido1 = String.Empty
        Me._apellido2 = String.Empty
        Me._equipo = Nothing
        Me._id = common.constantes.vacio.ID
        Me._nombre = String.Empty
    End Sub

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

    Public Property Apellido1() As String
        Get
            Return _apellido1
        End Get
        Set(ByVal value As String)
            _apellido1 = value
        End Set
    End Property

    Public Property Apellido2() As String
        Get
            Return _apellido2
        End Get
        Set(ByVal value As String)
            _apellido2 = value
        End Set
    End Property


    Public Property Equipo() As Equipo
        Get
            Return _equipo
        End Get
        Set(ByVal value As Equipo)
            _equipo = value
        End Set
    End Property

    Public ReadOnly Property FullName() As String
        Get
            If (Id <> baseball.lib.common.constantes.vacio.ID) Then
                Return String.Format("{0} {1}, {2}", Me.Apellido1.ToUpper, Me.Apellido2.ToUpper, Me.Nombre.ToLower)
            Else
                Return ""
            End If
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return FullName
    End Function

End Class
