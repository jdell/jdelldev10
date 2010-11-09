Namespace tipos
    <Serializable()> _
    Public Class ParDateTime
        Inherits ParObject

        Public Sub New()

        End Sub

        Public Property Desde() As Nullable(Of DateTime)
            Get
                Return Me.Object1
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                Me.Object1 = value
            End Set
        End Property
        Public Property Hasta() As Nullable(Of DateTime)
            Get
                Return Me.Object2
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                Me.Object2 = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Dim res As String = String.Empty
            Dim fechaDesde As String = [lib].common.funciones.getinfo.FECHA([lib].common.constantes.vacio.FECHA)
            Dim fechaHasta As String = [lib].common.funciones.getinfo.FECHA([lib].common.constantes.vacio.FECHA)

            If Me.Desde.HasValue Then fechaDesde = [lib].common.funciones.getinfo.FECHA(Me.Desde.Value)
            If Me.Hasta.HasValue Then fechaHasta = [lib].common.funciones.getinfo.FECHA(Me.Desde.Value)

            res = String.Format("{0} - {1}", fechaDesde, fechaHasta)

            Return res
        End Function

    End Class
End Namespace

