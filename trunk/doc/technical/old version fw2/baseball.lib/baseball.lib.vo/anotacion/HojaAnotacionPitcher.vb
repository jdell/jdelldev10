Public Class HojaAnotacionPitcher

    Public Sub New()

    End Sub
    Public Sub New(ByVal jugador As Jugador)
        _jugador = jugador
    End Sub

    Private _id As Int16
    Public Property Id() As Short
        Get
            Return _id
        End Get
        Set(ByVal value As Short)
            _id = value
        End Set
    End Property

    Private _jugador As Jugador
    Public Property Jugador() As Jugador
        Get
            Return _jugador
        End Get
        Set(ByVal value As Jugador)
            _jugador = value
        End Set
    End Property

    Private _hojaAnotacion As HojaAnotacion
    Public Property HojaAnotacion() As HojaAnotacion
        Get
            Return _hojaAnotacion
        End Get
        Set(ByVal value As HojaAnotacion)
            _hojaAnotacion = value
        End Set
    End Property


    'Datos del pitcher
    Private _labor As tLABORPITCHER
    Public Property Labor() As tLABORPITCHER
        Get
            Return _labor
        End Get
        Set(ByVal value As tLABORPITCHER)
            _labor = value
        End Set
    End Property

    Private _be As Short
    Public Property BE() As Short
        Get
            Return _be
        End Get
        Set(ByVal value As Short)
            _be = value
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

    Private _c As Short
    Public Property C() As Short
        Get
            Return _c
        End Get
        Set(ByVal value As Short)
            _c = value
        End Set
    End Property

    Private _cl As Short
    Public Property CL() As Short
        Get
            Return _cl
        End Get
        Set(ByVal value As Short)
            _cl = value
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

    Private _k As Short
    Public Property K() As Short
        Get
            Return _k
        End Get
        Set(ByVal value As Short)
            _k = value
        End Set
    End Property

    Private _wp As Short
    Public Property WP() As Short
        Get
            Return _wp
        End Get
        Set(ByVal value As Short)
            _wp = value
        End Set
    End Property

    Private _bk As Short
    Public Property BK() As Short
        Get
            Return _bk
        End Get
        Set(ByVal value As Short)
            _bk = value
        End Set
    End Property

End Class
