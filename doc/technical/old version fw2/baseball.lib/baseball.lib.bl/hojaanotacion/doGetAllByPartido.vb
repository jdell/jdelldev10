Namespace hojaanotacion

    Public Class doGetAllByPartido
        Inherits _template.ActionBL

        Private accionhojaanotacion As New baseball.lib.dao.hojaanotacion.fachada
        Private _partido As baseball.lib.vo.Partido
        Private _full As Boolean

        Public Sub New(ByVal partido As baseball.lib.vo.Partido, Optional ByVal full As Boolean = False)
            _partido = partido
            _full = full
        End Sub

        Public Shadows Function execute() As List(Of baseball.lib.vo.HojaAnotacion)
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Dim res As List(Of baseball.lib.vo.HojaAnotacion)
            Try
                res = accionhojaanotacion.getAll(_partido, _full)
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace