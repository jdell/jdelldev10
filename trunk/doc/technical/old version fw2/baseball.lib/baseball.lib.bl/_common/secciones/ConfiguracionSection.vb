Namespace _common.secciones
    Public Class ConfiguracionSection
        Inherits section

        Private _helpFile As String
        Private _maxSizeFile As Integer
        Private _urlInformes As String

        Public Sub New()
            Me._name = "Configuracion"
            Me._helpFile = "baseball.chm"
            Me._maxSizeFile = 1
            Me._urlInformes = "http://sslcg04app2/Reports/Pages/Folder.aspx?ItemPath=%2fGesti%c3%b3n+de+ineficiencias&amp;ViewMode=List"
        End Sub

        Public Property HelpFile() As String
            Get
                Return _helpFile
            End Get
            Set(ByVal value As String)
                _helpFile = value
            End Set
        End Property

        Public Property MaxSizeFile() As Integer
            Get
                Return _maxSizeFile
            End Get
            Set(ByVal value As Integer)
                _maxSizeFile = value
            End Set
        End Property

        Public Property UrlInformes() As String
            Get
                Return _urlInformes
            End Get
            Set(ByVal value As String)
                _urlInformes = value
            End Set
        End Property

    End Class
End Namespace


