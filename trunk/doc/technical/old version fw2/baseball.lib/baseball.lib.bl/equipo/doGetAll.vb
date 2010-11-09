Namespace equipo

    Public Class doGetAll
        Inherits _template.ActionBL

        Private accionequipo As New baseball.lib.dao.equipo.fachada
        Public Shadows Function execute() As List(Of baseball.lib.vo.Equipo)
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Dim res As List(Of baseball.lib.vo.Equipo)
            Try
                res = accionequipo.getAll()
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace