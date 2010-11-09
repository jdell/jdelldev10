Namespace _events
    Public Class ProgressEventArgs
        Inherits BaseBallEventArgs

        Private _infoprocess As String
        Private _currentprocess As Int32
        Private _totalprocess As Int32

        Public Sub New(ByVal info As String, ByVal current As Int32, ByVal total As Int32)
            _infoprocess = info
            _currentprocess = current
            _totalprocess = total
        End Sub

        ''' <summary>
        ''' Información del proceso que se está ejecutando actualmente.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Info() As String
            Get
                Return _infoprocess
            End Get
        End Property

        ''' <summary>
        ''' Número de proceso que se está ejecutando actualmente.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Current() As Int32
            Get
                Return _currentprocess
            End Get
        End Property

        ''' <summary>
        ''' Número total de procesos a ejecutar.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Total() As Int32
            Get
                Return _totalprocess
            End Get
        End Property


    End Class
End Namespace

