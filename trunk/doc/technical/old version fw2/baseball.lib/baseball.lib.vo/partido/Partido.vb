Public Class Partido

    Public Sub New()
        Me._amonestaciones = String.Empty
        Me._anotador = Nothing
        Me._arbitro1 = Nothing
        Me._arbitro2 = Nothing
        Me._arbitro3 = Nothing
        Me._arbitro4 = Nothing
        Me._categoria = Nothing
        Me._competicion = Nothing
        Me._division = String.Empty
        Me._estado = tESTADOPARTIDO.PENDIENTE
        Me._expulsiones = String.Empty
        Me._fecha = DateTime.Now
        Me._homeClub = Nothing
        Me._id = common.constantes.vacio.ID
        Me._localidad = String.Empty
        Me._modalidad = tMODALIDADPARTIDO.BEISBOL
        Me._observaciones = String.Empty
        Me._terrenojuego = String.Empty
        Me._visitante = Nothing
    End Sub

    Private _id As Int16
    Public Property Id() As Int16
        Get
            Return _id
        End Get
        Set(ByVal value As Int16)
            _id = value
        End Set
    End Property

    Private _homeClub As Equipo
    Public Property HomeClub() As Equipo
        Get
            Return _homeClub
        End Get
        Set(ByVal value As Equipo)
            _homeClub = value
        End Set
    End Property

    Private _visitante As Equipo
    Public Property Visitante() As Equipo
        Get
            Return _visitante
        End Get
        Set(ByVal value As Equipo)
            _visitante = value
        End Set
    End Property

    Private _arbitro1 As Arbitro
    Public Property Arbitro1() As Arbitro
        Get
            Return _arbitro1
        End Get
        Set(ByVal value As Arbitro)
            _arbitro1 = value
        End Set
    End Property

    Private _arbitro2 As Arbitro
    Public Property Arbitro2() As Arbitro
        Get
            Return _arbitro2
        End Get
        Set(ByVal value As Arbitro)
            _arbitro2 = value
        End Set
    End Property

    Private _arbitro3 As Arbitro
    Public Property Arbitro3() As Arbitro
        Get
            Return _arbitro3
        End Get
        Set(ByVal value As Arbitro)
            _arbitro3 = value
        End Set
    End Property

    Private _arbitro4 As Arbitro
    Public Property Arbitro4() As Arbitro
        Get
            Return _arbitro4
        End Get
        Set(ByVal value As Arbitro)
            _arbitro4 = value
        End Set
    End Property

    Private _anotador As Anotador
    Public Property Anotador() As Anotador
        Get
            Return _anotador
        End Get
        Set(ByVal value As Anotador)
            _anotador = value
        End Set
    End Property

    Private _estado As tESTADOPARTIDO
    Public Property Estado() As tESTADOPARTIDO
        Get
            Return _estado
        End Get
        Set(ByVal value As tESTADOPARTIDO)
            _estado = value
        End Set
    End Property

    Private _fecha As Date
    Public Property Fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property

    Private _division As String
    Public Property Division() As String
        Get
            Return _division
        End Get
        Set(ByVal value As String)
            _division = value
        End Set
    End Property

    Private _competicion As Competicion
    Public Property Competicion() As Competicion
        Get
            Return _competicion
        End Get
        Set(ByVal value As Competicion)
            _competicion = value
        End Set
    End Property

    Private _categoria As Categoria
    Public Property Categoria() As Categoria
        Get
            Return _categoria
        End Get
        Set(ByVal value As Categoria)
            _categoria = value
        End Set
    End Property

    Private _modalidad As tMODALIDADPARTIDO
    Public Property Modalidad() As tMODALIDADPARTIDO
        Get
            Return _modalidad
        End Get
        Set(ByVal value As tMODALIDADPARTIDO)
            _modalidad = value
        End Set
    End Property

    Private _terrenojuego As String
    Public Property Terreno() As String
        Get
            Return _terrenojuego
        End Get
        Set(ByVal value As String)
            _terrenojuego = value
        End Set
    End Property

    Private _amonestaciones As String
    Public Property Amonestaciones() As String
        Get
            Return _amonestaciones
        End Get
        Set(ByVal value As String)
            _amonestaciones = value
        End Set
    End Property

    Private _expulsiones As String
    Public Property Expulsiones() As String
        Get
            Return _expulsiones
        End Get
        Set(ByVal value As String)
            _expulsiones = value
        End Set
    End Property

    Private _observaciones As String
    Public Property Observaciones() As String
        Get
            Return _observaciones
        End Get
        Set(ByVal value As String)
            _observaciones = value
        End Set
    End Property

    Private _localidad As String
    Public Property Localidad() As String
        Get
            Return _localidad
        End Get
        Set(ByVal value As String)
            _localidad = value
        End Set
    End Property

    Private _anotacionHomeClub As HojaAnotacion
    Public Property AnotacionHomeClub() As HojaAnotacion
        Get
            Return _anotacionHomeClub
        End Get
        Set(ByVal value As HojaAnotacion)
            _anotacionHomeClub = value
        End Set
    End Property

    Private _anotacionVisitante As HojaAnotacion
    Public Property AnotacionVisitante() As HojaAnotacion
        Get
            Return _anotacionVisitante
        End Get
        Set(ByVal value As HojaAnotacion)
            _anotacionVisitante = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim res As String = String.Empty

        If (Not Me.HomeClub Is Nothing) AndAlso (Not Me.Visitante Is Nothing) Then
            res = String.Format("{0}: {1} - {2}", [lib].common.funciones.getinfo.FECHA(Me.Fecha, True), Me.HomeClub.ToString, Me.Visitante.ToString)
        End If

        Return res
    End Function

End Class
