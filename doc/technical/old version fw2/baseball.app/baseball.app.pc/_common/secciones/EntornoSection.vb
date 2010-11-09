Namespace _common.secciones
    Public Class EntornoSection
        Inherits baseball.lib.bl._common.secciones.section

        Private _pathOnlineHelpFile As String
        Private _pathImprovementFile As String
        Private _showImprovementMsg As Boolean

        Public Sub New()
            Me._name = "Entorno"
            Me._pathOnlineHelpFile = IO.Path.GetFullPath("_help/BaseBallonLineHelp.xml")
            Me._pathImprovementFile = IO.Path.GetFullPath("_help/version.html")
            Me._showImprovementMsg = True
        End Sub

        Public Property PathOnlineHelpFile() As String
            Get
                Return _pathOnlineHelpFile
            End Get
            Set(ByVal value As String)
                _pathOnlineHelpFile = value
            End Set
        End Property

        Public Property PathImprovementFile() As String
            Get
                Return _pathImprovementFile
            End Get
            Set(ByVal value As String)
                _pathImprovementFile = value
            End Set
        End Property

        Public Property ShowImprovementMsg() As Boolean
            Get
                Return _showImprovementMsg
            End Get
            Set(ByVal value As Boolean)
                _showImprovementMsg = value
            End Set
        End Property

    End Class
End Namespace


