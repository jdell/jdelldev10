Namespace Ineficiencia

    Public Class doSeleccionarIneficiencia
        Inherits _template.ActionBL

        Private accionIneficiencia As New baseball.lib.dao.Ineficiencia.fachada
        Private _ineficiencia As baseball.lib.vo.ineficiencia.IneficienciaVO

        Public Sub New(ByVal ineficiencia As baseball.lib.vo.ineficiencia.IneficienciaVO)
            _ineficiencia = ineficiencia
        End Sub

        Public Shadows Function execute() As Object
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Try
                Return accionIneficiencia.SeleccionarIneficiencia(_ineficiencia)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace

