Namespace Ineficiencia

    Public Class doSeleccionarIneficienciasPorAreasUsuario
        Inherits _template.ActionBL

        Private accionIneficiencia As New baseball.lib.dao.Ineficiencia.fachada
        Private _usuario As baseball.lib.vo.Usuario

        Public Sub New(ByVal _usuario As baseball.lib.vo.Usuario)
            Me._usuario = _usuario
        End Sub
        Public Shadows Function execute() As Object
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Dim res As baseball.lib.vo.ineficiencia.IneficienciaVO()
            Try
                res = accionIneficiencia.SeleccionarIneficienciasPorAreasUsuario(Me._usuario)
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace