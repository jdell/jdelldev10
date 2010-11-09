Public Class EstadisticaBaseRunning
    Private _r As Int16
    Private _cr As Int16
    Private _o2 As Int16
    Private _c As Int16
    Private _jugador As Jugador

    Public Sub New()
        Me._c = 0
        Me._cr = 0
        Me._o2 = 0
        Me._r = 0
    End Sub

    Public Property R() As Int16
        Get
            Return _r
        End Get
        Set(ByVal value As Int16)
            _r = value
        End Set
    End Property
    Public Property CR() As Int16
        Get
            Return _cr
        End Get
        Set(ByVal value As Int16)
            _cr = value
        End Set
    End Property
    Private Property O2() As Int16
        Get
            Return _o2
        End Get
        Set(ByVal value As Int16)
            _o2 = value
        End Set
    End Property
    Public Property C() As Int16
        Get
            Return _c
        End Get
        Set(ByVal value As Int16)
            _c = value
        End Set
    End Property
    Public Property Jugador() As Jugador
        Get
            Return _jugador
        End Get
        Set(ByVal value As Jugador)
            _jugador = value
        End Set
    End Property

    Public ReadOnly Property SBP() As Single
        Get
            Dim res As Single = 0
            If (CR + R > 0) Then res = R / (CR + R)
            Return res
        End Get
    End Property

    Public ReadOnly Property SBR() As Single
        Get
            Dim res As Single = 0
            res = (0.3 * R - 0.6 * CR)
            Return res
        End Get
    End Property


End Class
