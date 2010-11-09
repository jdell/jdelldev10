Namespace _common.secciones
    Public Class MantenimientoSection
        Inherits section

        Private _enMantenimiento As Boolean
        Private _tiempoEspera As Integer
        Private _mensaje As String
        Private _detalle As String
        Private _debugMode As Boolean


        Public Sub New()
            Me._name = "Mantenimiento"
            Me._enMantenimiento = False
            Me._tiempoEspera = 1
            Me._mensaje = "Aplicación en mantenimiento"
            Me._detalle = "La aplicación se cerrará automáticamente dentro de 1 minuto para pasar a mantenimiento. En aproximadamente 30 minutos, la aplicación estará de nuevo disponible. Disculpe las molestias."
            Me._debugMode = False
        End Sub


        Public Property EnMantenimiento() As Boolean
            Get
                Return _enMantenimiento
            End Get
            Set(ByVal value As Boolean)
                _enMantenimiento = value
            End Set
        End Property
        Public Property TiempoEspera() As Integer
            Get
                Return _tiempoEspera
            End Get
            Set(ByVal value As Integer)
                _tiempoEspera = value
            End Set
        End Property
        Public Property Mensaje() As String
            Get
                Return _mensaje
            End Get
            Set(ByVal value As String)
                _mensaje = value
            End Set
        End Property
        Public Property Detalle() As String
            Get
                Return _detalle
            End Get
            Set(ByVal value As String)
                _detalle = value
            End Set
        End Property
        Public Property DebugMode() As Boolean
            Get
                Return _debugMode
            End Get
            Set(ByVal value As Boolean)
                _debugMode = value
            End Set
        End Property


        Public Function getMiliseguntosEspera() As Integer
            Return _tiempoEspera * 60 * 1000
        End Function
        Public Function getSeguntosEspera() As Integer
            Return _tiempoEspera * 60
        End Function

    End Class
End Namespace


