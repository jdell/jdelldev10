Namespace partido

    Public Class doGetAll
        Inherits _template.ActionBL

        Private accionpartido As New baseball.lib.dao.partido.fachada
        Public Shadows Function execute() As List(Of baseball.lib.vo.Partido)
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Dim res As List(Of baseball.lib.vo.Partido)
            Try
                res = accionpartido.getAll()
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace