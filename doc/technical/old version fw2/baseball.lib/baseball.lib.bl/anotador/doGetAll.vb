Namespace anotador

    Public Class doGetAll
        Inherits _template.ActionBL

        Private accionanotador As New baseball.lib.dao.anotador.fachada
        Public Shadows Function execute() As List(Of baseball.lib.vo.Anotador)
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Dim res As List(Of baseball.lib.vo.Anotador)
            Try
                res = accionanotador.getAll()
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace