Public Class FiltroEstadistica
    Private _fecha As common.tipos.ParDateTime
    Private _competicion As Competicion
    Private _partido As Partido

    Public Sub New()
        Me._competicion = Nothing
        Me._fecha = New common.tipos.ParDateTime
        Me._partido = Nothing
    End Sub

    Public ReadOnly Property Fecha() As common.tipos.ParDateTime
        Get
            Return _fecha
        End Get
    End Property
    Public Property Competicion() As Competicion
        Get
            Return _competicion
        End Get
        Set(ByVal value As Competicion)
            _competicion = value
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

End Class
