Namespace _estadistica

    Friend Class doGetAllForBatting
        Inherits _template.ActionBL

        Private accionestadistica As New baseball.lib.dao.estadistica.fachada

        Dim _filtro As vo.FiltroEstadistica
        Public Sub New(ByVal filtro As vo.FiltroEstadistica)
            _filtro = filtro
        End Sub

        Public Shadows Function execute() As List(Of baseball.lib.vo.EstadisticaBatting)
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Dim res As List(Of baseball.lib.vo.EstadisticaBatting)
            Try
                res = accionestadistica.getAllForBatting(_filtro)
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace