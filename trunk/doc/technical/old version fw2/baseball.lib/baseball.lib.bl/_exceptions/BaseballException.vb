Namespace _exceptions
    Public Class BaseballException
        Inherits repsol.exceptions.UserException

        Protected _detail As String = String.Empty

        Public Sub New(ByVal mensaje As String)
            MyBase.New(mensaje)
        End Sub
        Public Sub New(ByVal mensaje As String, ByVal ex As BaseballException)
            MyBase.New(mensaje, ex)
            Me._detail = ex.FullMessage
        End Sub

        Public Sub New(ByVal mensaje As String, ByVal detalle As String)
            MyBase.New(mensaje)
            Me._detail = detalle
        End Sub

        Public ReadOnly Property Detail() As String
            Get
                Return Me._detail
            End Get
        End Property

        Public ReadOnly Property FullMessage() As String
            Get
                Return String.Format("{0} {1}", Me.Message, Me._detail).Trim
            End Get
        End Property


    End Class

End Namespace
