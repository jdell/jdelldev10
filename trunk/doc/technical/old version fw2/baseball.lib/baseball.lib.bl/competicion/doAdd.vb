Namespace competicion

    Public Class doAdd
        Inherits _template.ActionBL

        Private accioncompeticion As New baseball.lib.dao.competicion.fachada
        Private _competicion As baseball.lib.vo.Competicion

        Public Sub New(ByVal competicion As baseball.lib.vo.Competicion)
            _competicion = competicion
        End Sub
        Public Shadows Function execute() As baseball.lib.vo.Competicion
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Try
                If (_competicion Is Nothing) Then
                    Throw New _exceptions._common.NullReferenceException()
                End If

                Return accioncompeticion.add(_competicion)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace
