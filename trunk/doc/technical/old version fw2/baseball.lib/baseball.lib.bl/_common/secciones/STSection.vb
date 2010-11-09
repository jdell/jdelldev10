Namespace _common.secciones
    Public Class STSection
        Inherits section

        Private _costeTipo As Integer
        Private _costeEstado As Integer
        Private _unidadMedida As Integer

        Public Sub New()
            Me._name = "ST"
            Me._costeTipo = 3
            Me._costeEstado = 1
            Me._unidadMedida = 9
        End Sub

        Public Property CosteTipo() As Integer
            Get
                Return _costeTipo
            End Get
            Set(ByVal value As Integer)
                _costeTipo = value
            End Set
        End Property

        Public Property CosteEstado() As Integer
            Get
                Return _costeEstado
            End Get
            Set(ByVal value As Integer)
                _costeEstado = value
            End Set
        End Property

        Public Property UnidadMedida() As Integer
            Get
                Return _unidadMedida
            End Get
            Set(ByVal value As Integer)
                _unidadMedida = value
            End Set
        End Property
    End Class
End Namespace


