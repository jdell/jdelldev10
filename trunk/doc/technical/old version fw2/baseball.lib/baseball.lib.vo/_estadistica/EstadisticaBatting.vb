Public Class EstadisticaBatting

    Private _jugador As Jugador
    Public Property Jugador() As Jugador
        Get
            Return _jugador
        End Get
        Set(ByVal value As Jugador)
            _jugador = value
        End Set
    End Property

    Private _c As Short
    Public Property C() As Short
        Get
            Return _c
        End Get
        Set(ByVal value As Short)
            _c = value
        End Set
    End Property

    Private _h2 As Short
    Public Property H2() As Short
        Get
            Return _h2
        End Get
        Set(ByVal value As Short)
            _h2 = value
        End Set
    End Property

    Private _h3 As Short
    Public Property H3() As Short
        Get
            Return _h3
        End Get
        Set(ByVal value As Short)
            _h3 = value
        End Set
    End Property

    Private _hr As Short
    Public Property HR() As Short
        Get
            Return _hr
        End Get
        Set(ByVal value As Short)
            _hr = value
        End Set
    End Property

    Private _sh As Short
    Public Property SH() As Short
        Get
            Return _sh
        End Get
        Set(ByVal value As Short)
            _sh = value
        End Set
    End Property

    Private _sf As Short
    Public Property SF() As Short
        Get
            Return _sf
        End Get
        Set(ByVal value As Short)
            _sf = value
        End Set
    End Property

    Private _b As Short
    Public Property B() As Short
        Get
            Return _b
        End Get
        Set(ByVal value As Short)
            _b = value
        End Set
    End Property

    Private _bi As Short
    Public Property BI() As Short
        Get
            Return _bi
        End Get
        Set(ByVal value As Short)
            _bi = value
        End Set
    End Property

    Private _gl As Short
    Public Property GL() As Short
        Get
            Return _gl
        End Get
        Set(ByVal value As Short)
            _gl = value
        End Set
    End Property

    Private _io As Short
    Public Property IO() As Short
        Get
            Return _io
        End Get
        Set(ByVal value As Short)
            _io = value
        End Set
    End Property

    Private _r As Short
    Public Property R() As Short
        Get
            Return _r
        End Get
        Set(ByVal value As Short)
            _r = value
        End Set
    End Property

    Private _cr As Short
    Public Property CR() As Short
        Get
            Return _cr
        End Get
        Set(ByVal value As Short)
            _cr = value
        End Set
    End Property

    Private _k As Short
    Public Property K() As Short
        Get
            Return _k
        End Get
        Set(ByVal value As Short)
            _k = value
        End Set
    End Property

    Private _ci As Short
    Public Property CI() As Short
        Get
            Return _ci
        End Get
        Set(ByVal value As Short)
            _ci = value
        End Set
    End Property


    '**************** Estadísticas ****************
    Private _tb As Short
    Public Property TB() As Short
        Get
            Return _tb
        End Get
        Set(ByVal value As Short)
            _tb = value
        End Set
    End Property

    Private _v As Short
    Public Property V() As Short
        Get
            Return _v
        End Get
        Set(ByVal value As Short)
            _v = value
        End Set
    End Property

    Private _h1 As Short
    Public Property H1() As Short
        Get
            Return _h1
        End Get
        Set(ByVal value As Short)
            _h1 = value
        End Set
    End Property

    Public ReadOnly Property AVG() As Single
        Get
            Dim res As Single = 0
            If (V > 0) Then res = H1 / V
            Return res
        End Get
    End Property

    'Slugging
    Public ReadOnly Property SLG() As Single
        Get
            Dim res As Single = 0
            If (V > 0) Then res = BH / V
            Return res
        End Get
    End Property

    Private _bh As Short
    Public Property BH() As Short
        Get
            Return _bh
        End Get
        Set(ByVal value As Short)
            _bh = value
        End Set
    End Property


End Class
