Public Class HojaAnotacionCatcher

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


    'Datos del catcher
    Private _pb As Short
    Public Property PB() As Short
        Get
            Return _pb
        End Get
        Set(ByVal value As Short)
            _pb = value
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

End Class
