Imports Microsoft.Office.Interop
Namespace Ineficiencia

    Public Class doInsertarIneficiencia
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
                Dim doCanSave As New doCanSaveIneficiencia(_ineficiencia)
                If (doCanSave.execute) Then

                    accionIneficiencia.InsertarIneficiencia(_ineficiencia)

                    Dim doNotificar As New doNotificarIneficiencia(_ineficiencia, False)
                    doNotificar.execute()

                End If

                Return _ineficiencia
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace
