Namespace Ineficiencia

    Public Class doSeleccionarIneficiencias
        Inherits _template.ActionBL

        Private accionIneficiencia As New baseball.lib.dao.Ineficiencia.fachada
        Public Shadows Function execute() As Object
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Dim res As baseball.lib.vo.ineficiencia.IneficienciaVO()
            Try
                res = accionIneficiencia.SeleccionarIneficiencias()
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace