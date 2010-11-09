Namespace competicion

    Public Class doGetAll
        Inherits _template.ActionBL

        Private accioncompeticion As New baseball.lib.dao.competicion.fachada
        Public Shadows Function execute() As List(Of baseball.lib.vo.Competicion)
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Dim res As List(Of baseball.lib.vo.Competicion)
            Try
                res = accioncompeticion.getAll()
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace