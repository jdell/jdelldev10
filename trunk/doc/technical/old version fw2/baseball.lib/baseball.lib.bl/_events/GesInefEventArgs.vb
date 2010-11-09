Namespace _events
    Public MustInherit Class BaseBallEventArgs
        Inherits EventArgs

        Protected _app As String

        Public Sub New()
            _app = _common.cache.APPNAME
        End Sub

        Public ReadOnly Property AppHost() As String
            Get
                Return _app
            End Get
        End Property

    End Class
End Namespace

