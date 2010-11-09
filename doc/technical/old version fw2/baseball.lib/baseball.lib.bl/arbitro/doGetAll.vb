Namespace arbitro

    Public Class doGetAll
        Inherits _template.ActionBL

        Private accionarbitro As New baseball.lib.dao.arbitro.fachada
        Public Shadows Function execute() As List(Of baseball.lib.vo.Arbitro)
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Dim res As List(Of baseball.lib.vo.Arbitro)
            Try
                res = accionarbitro.getAll()
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace