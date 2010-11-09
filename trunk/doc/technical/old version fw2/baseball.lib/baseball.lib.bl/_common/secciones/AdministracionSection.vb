Namespace _common.secciones
    Public Class AdministracionSection
        Inherits section

        Private _masterUser As System.Collections.Generic.List(Of String)
        Private _systemUser As String
        Private _systemMail As String
        Private _smtpServer As String


        Public Sub New()
            Me._name = "Administracion"
            Me._masterUser = New system.Collections.Generic.List(Of String)
            Me._systemUser = "BaseBall"
            Me._systemMail = "cascoruna@repsolypf.com"
            Me._smtpServer = "sslcg04exc03"
        End Sub


        Friend Property MasterUser() As system.Collections.Generic.List(Of String)
            Get
                Return _masterUser
            End Get
            Set(ByVal value As system.Collections.Generic.List(Of String))
                _masterUser = value
            End Set
        End Property
        Friend Property SystemUser() As String
            Get
                Return _systemUser
            End Get
            Set(ByVal value As String)
                _systemUser = value
            End Set
        End Property
        Public Property SystemMail() As String
            Get
                Return _systemMail
            End Get
            Set(ByVal value As String)
                _systemMail = value
            End Set
        End Property
        Public Property SmtpServer() As String
            Get
                Return _smtpServer
            End Get
            Set(ByVal value As String)
                _smtpServer = value
            End Set
        End Property

        ''' <summary>
        ''' Establece la lista de usuarios "Master" a partir de una cadena con los 
        ''' RPs de los usuarios separados por el separador indicado (por defecto ';')
        ''' </summary>
        ''' <param name="cadena"></param>
        ''' <param name="separador"></param>
        ''' <remarks></remarks>
        Public Sub SetMasterUsers(ByVal cadena As String, ByVal separador As String)
            If (Me.MasterUser Is Nothing) Then Me.MasterUser = New system.Collections.Generic.List(Of String)

            Dim mUsers As String() = cadena.Split(New Char() {separador})
            If (Not mUsers Is Nothing) Then Me.MasterUser.AddRange(mUsers)
        End Sub

    End Class
End Namespace


