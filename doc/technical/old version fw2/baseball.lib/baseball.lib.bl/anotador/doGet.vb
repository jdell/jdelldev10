Namespace anotador

    Public Class doGet
        Inherits _template.ActionBL

        Private accionanotador As New baseball.lib.dao.anotador.fachada
        Private _anotador As baseball.lib.vo.Anotador

        Public Sub New(ByVal anotador As baseball.lib.vo.Anotador)
            _anotador = anotador
        End Sub

        Public Shadows Function execute() As baseball.lib.vo.Anotador
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Try
                If (_anotador Is Nothing) Then
                    Throw New _exceptions._common.NullReferenceException()
                End If

                Return accionanotador.get(_anotador)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace

