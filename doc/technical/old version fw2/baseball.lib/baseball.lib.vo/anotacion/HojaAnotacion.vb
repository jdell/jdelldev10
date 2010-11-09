Public Class HojaAnotacion
    Private _id As Int16
    Private _partido As Partido
    Private _equipo As Equipo

    Public Sub New()

    End Sub

    Public Sub New(ByVal partido As vo.Partido, ByVal equipo As Equipo)
        _partido = partido
        _equipo = equipo

        generateHoja()
    End Sub

    Private Sub generateHoja()
        If (Not _equipo Is Nothing) Then
            For Each jugador As Jugador In _equipo.Jugadores
                Dim haPlayer As New HojaAnotacionPlayer(jugador)
                ListaPlayer.Add(haPlayer)

                Dim haPitcher As New HojaAnotacionPitcher(jugador)
                ListaPitcher.Add(haPitcher)

                Dim haCatcher As New HojaAnotacionCatcher(jugador)
                ListaCatcher.Add(haCatcher)
            Next
        End If
    End Sub

    Public Property Id() As Short
        Get
            Return _id
        End Get
        Set(ByVal value As Short)
            _id = value
        End Set
    End Property

    Public Property Partido() As Partido
        Get
            Return _partido
        End Get
        Set(ByVal value As Partido)
            _partido = value
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

    Private _listaPlayer As New List(Of HojaAnotacionPlayer)
    Public ReadOnly Property ListaPlayer() As List(Of HojaAnotacionPlayer)
        Get
            Return _listaPlayer
        End Get
    End Property

    Private _listaPitcher As New List(Of HojaAnotacionPitcher)
    Public ReadOnly Property ListaPitcher() As List(Of HojaAnotacionPitcher)
        Get
            Return _listaPitcher
        End Get
    End Property

    Private _listaCatcher As New List(Of HojaAnotacionCatcher)
    Public ReadOnly Property ListaCatcher() As List(Of HojaAnotacionCatcher)
        Get
            Return _listaCatcher
        End Get
    End Property


End Class
