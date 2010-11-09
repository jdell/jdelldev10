Namespace partido
    Public Class doRemove
        Inherits _template.ActionBL

        Private accionpartido As New baseball.lib.dao.partido.fachada
        Private _partido As baseball.lib.vo.Partido

        Public Sub New(ByVal partido As baseball.lib.vo.Partido)
            _partido = partido
        End Sub
        Public Shadows Function execute() As Object
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Try
                If (_partido Is Nothing) Then
                    Throw New _exceptions._common.NullReferenceException()
                End If

                Return accionpartido.remove(_partido)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace
