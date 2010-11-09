Namespace _estadistica

    Friend Class doGetAllForCatcher
        Inherits _template.ActionBL

        Private accionestadistica As New baseball.lib.dao.estadistica.fachada

        Dim _filtro As vo.FiltroEstadistica
        Public Sub New(ByVal filtro As vo.FiltroEstadistica)
            _filtro = filtro
        End Sub

        Public Shadows Function execute() As List(Of baseball.lib.vo.EstadisticaCatcher)
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Dim res As List(Of baseball.lib.vo.EstadisticaCatcher)
            Try
                res = accionestadistica.getAllForCatcher(_filtro)
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace