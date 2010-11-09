Namespace arbitro

    Public Class doGet
        Inherits _template.ActionBL

        Private accionarbitro As New baseball.lib.dao.arbitro.fachada
        Private _arbitro As baseball.lib.vo.Arbitro

        Public Sub New(ByVal arbitro As baseball.lib.vo.Arbitro)
            _arbitro = arbitro
        End Sub

        Public Shadows Function execute() As baseball.lib.vo.Arbitro
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Try
                If (_arbitro Is Nothing) Then
                    Throw New _exceptions._common.NullReferenceException()
                End If

                Return accionarbitro.get(_arbitro)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace

