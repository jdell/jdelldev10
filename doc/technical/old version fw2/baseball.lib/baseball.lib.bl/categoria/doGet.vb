Namespace categoria

    Public Class doGet
        Inherits _template.ActionBL

        Private accioncategoria As New baseball.lib.dao.categoria.fachada
        Private _categoria As baseball.lib.vo.Categoria

        Public Sub New(ByVal categoria As baseball.lib.vo.Categoria)
            _categoria = categoria
        End Sub

        Public Shadows Function execute() As baseball.lib.vo.Categoria
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Try
                If (_categoria Is Nothing) Then
                    Throw New _exceptions._common.NullReferenceException()
                End If

                Return accioncategoria.get(_categoria)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace

