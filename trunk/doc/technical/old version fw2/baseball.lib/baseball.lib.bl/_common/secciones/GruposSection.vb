Namespace _common.secciones
    Public Class GruposSection
        Inherits section

        Private _validador As String

        Private _grupo1 As System.Collections.Generic.List(Of String)
        Private _grupo2 As System.Collections.Generic.List(Of String)
        Private _grupo3 As System.Collections.Generic.List(Of String)
        Private _grupo4 As System.Collections.Generic.List(Of String)
        Private _grupo5 As System.Collections.Generic.List(Of String)
        Private _grupo6 As System.Collections.Generic.List(Of String)
        Private _grupo7 As System.Collections.Generic.List(Of String)

        Public Shared ReadOnly Gr1Name As String = "gr1-c+m"
        Public Shared ReadOnly Gr2Name As String = "gr2-c+m"
        Public Shared ReadOnly Gr3Name As String = "gr3-c+m"
        Public Shared ReadOnly Gr4Name As String = "gr4-c+m"
        Public Shared ReadOnly Gr5Name As String = "gr5-c+m"
        Public Shared ReadOnly Gr6Name As String = "gr6-c+m"
        Public Shared ReadOnly Gr7Name As String = "gr7-c+m"

        Public Sub New()
            Me._name = "Grupos"
            Me._validador = gr3Name
            Me._grupo1 = New System.Collections.Generic.List(Of String)
            Me._grupo2 = New System.Collections.Generic.List(Of String)
            Me._grupo3 = New System.Collections.Generic.List(Of String)
            Me._grupo4 = New System.Collections.Generic.List(Of String)
            Me._grupo5 = New System.Collections.Generic.List(Of String)
            Me._grupo6 = New System.Collections.Generic.List(Of String)
            Me._grupo7 = New System.Collections.Generic.List(Of String)
        End Sub

        Public Property Validador() As String
            Get
                Return _validador
            End Get
            Set(ByVal value As String)
                _validador = value
            End Set
        End Property
        Public Property Grupo1() As System.Collections.Generic.List(Of String)
            Get
                Return _grupo1
            End Get
            Set(ByVal value As System.Collections.Generic.List(Of String))
                _grupo1 = value
            End Set
        End Property
        Public Property Grupo2() As System.Collections.Generic.List(Of String)
            Get
                Return _grupo2
            End Get
            Set(ByVal value As System.Collections.Generic.List(Of String))
                _grupo2 = value
            End Set
        End Property
        Public Property Grupo3() As System.Collections.Generic.List(Of String)
            Get
                Return _grupo3
            End Get
            Set(ByVal value As System.Collections.Generic.List(Of String))
                _grupo3 = value
            End Set
        End Property
        Public Property Grupo4() As System.Collections.Generic.List(Of String)
            Get
                Return _grupo4
            End Get
            Set(ByVal value As System.Collections.Generic.List(Of String))
                _grupo4 = value
            End Set
        End Property
        Public Property Grupo5() As System.Collections.Generic.List(Of String)
            Get
                Return _grupo5
            End Get
            Set(ByVal value As System.Collections.Generic.List(Of String))
                _grupo5 = value
            End Set
        End Property
        Public Property Grupo6() As System.Collections.Generic.List(Of String)
            Get
                Return _grupo6
            End Get
            Set(ByVal value As System.Collections.Generic.List(Of String))
                _grupo6 = value
            End Set
        End Property
        Public Property Grupo7() As System.Collections.Generic.List(Of String)
            Get
                Return _grupo7
            End Get
            Set(ByVal value As System.Collections.Generic.List(Of String))
                _grupo7 = value
            End Set
        End Property

        Public Shared Sub SetGrupo(ByRef grupo As System.Collections.Generic.List(Of String), ByVal cadena As String, ByVal separador As String)
            If (grupo Is Nothing) Then grupo = New System.Collections.Generic.List(Of String)

            Dim mUsers As String() = cadena.Split(New Char() {separador})
            If (Not mUsers Is Nothing) Then grupo.AddRange(mUsers)
        End Sub

        Public Function GrupoValidador() As System.Collections.Generic.List(Of String)

            Return GetGrupo(Me.Validador)

        End Function

        Default Public ReadOnly Property this(ByVal grpName As String) As System.Collections.Generic.List(Of String)
            Get
                Return Me.GetGrupo(grpName)
            End Get
        End Property

        Public Function GetGrupo(ByVal grpName As String) As System.Collections.Generic.List(Of String)

            Select Case grpName
                Case GruposSection.Gr1Name
                    Return Me.Grupo1
                Case GruposSection.Gr2Name
                    Return Me.Grupo2
                Case GruposSection.Gr3Name
                    Return Me.Grupo3
                Case GruposSection.Gr4Name
                    Return Me.Grupo4
                Case GruposSection.Gr5Name
                    Return Me.Grupo5
                Case GruposSection.Gr6Name
                    Return Me.Grupo6
                Case GruposSection.Gr7Name
                    Return Me.Grupo7
                Case Else
                    Return Nothing
            End Select

        End Function

    End Class
End Namespace


