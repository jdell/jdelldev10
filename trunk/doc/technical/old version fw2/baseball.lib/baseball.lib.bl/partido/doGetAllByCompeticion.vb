Namespace partido

    Public Class doGetAllByCompeticion
        Inherits _template.ActionBL

        Private accionpartido As New baseball.lib.dao.partido.fachada

        Private _competicion As vo.Competicion
        Public Sub New(ByVal competicion As vo.Competicion)
            _competicion = competicion
        End Sub

        Public Shadows Function execute() As List(Of baseball.lib.vo.Partido)
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Dim res As List(Of baseball.lib.vo.Partido)
            Try
                res = accionpartido.getAllByCompeticion(_competicion)
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace