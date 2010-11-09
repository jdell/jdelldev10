Namespace _events
    ''' <summary>
    ''' En ciertas ocasiones la BL necesita enviar a las vistas mensajes para informar de que ciertas
    ''' cosas van a ocurrir en la BL (por ejemplo el cierre de la BL por mantenimiento). Esta clase 
    ''' permite definir esos eventos de forma homogénea.
    ''' </summary>
    ''' <remarks>
    ''' Incluye un campo que permite indicar el tiempo que transcurrirá
    ''' desde la notificación hasta que se ejecuta la acción descrita por el evento.
    ''' </remarks>
    Public Class NotificationEventArgs
        Inherits BaseBallEventArgs

        Private _mensaje As String
        Private _detalleMensaje As String
        Private _tiempoEspera As Int32

        ''' <summary>
        ''' Constructor del evento.
        ''' </summary>
        ''' <param name="tiempoEspera">Indica el tiempo -expresado en segundos- que transcurrirá desde que se lanza el evento
        ''' hasta que se ejecuta la acción que provoca el evento.</param>
        ''' <param name="mensaje">Mensaje para avisar al usuario de que se cierra la BL.</param>
        ''' <param name="detalle">Detalles. Por ejemplo, cuánto tiempo se tardará en volver a abrir la BL
        ''' o motivo por el que se cierra.</param>
        Public Sub New(ByVal mensaje As String, ByVal detalle As String, Optional ByVal tiempoEspera As Int32 = 0)
            Me._tiempoEspera = tiempoEspera
            Me._mensaje = mensaje
            Me._detalleMensaje = detalle
        End Sub

        '
        Public ReadOnly Property mensaje() As String
            Get
                Return Me._mensaje
            End Get
        End Property

        '
        Public ReadOnly Property detalle() As String
            Get
                Return Me._detalleMensaje
            End Get
        End Property

        ''' <summary>
        ''' Expresado en segundos
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property tiempoEspera() As Int32
            Get
                Return Me._tiempoEspera
            End Get
        End Property

    End Class
End Namespace

