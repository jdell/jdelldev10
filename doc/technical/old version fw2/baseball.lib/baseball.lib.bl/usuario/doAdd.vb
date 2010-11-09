Namespace usuario

    Public Class doAdd
        Inherits _template.ActionBL

        Private accionusuario As New baseball.lib.dao.usuario.fachada
        Private _usuario As baseball.lib.vo.Usuario

        Public Sub New(ByVal usuario As baseball.lib.vo.Usuario)
            _usuario = usuario
        End Sub
        Public Shadows Function execute() As baseball.lib.vo.Usuario
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Try
                If (_usuario Is Nothing) Then
                    Throw New _exceptions._common.NullReferenceException()
                End If

                Return accionusuario.add(_usuario)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace
