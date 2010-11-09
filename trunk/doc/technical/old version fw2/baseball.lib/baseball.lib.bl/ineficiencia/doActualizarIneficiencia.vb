Namespace Ineficiencia

    Public Class doActualizarIneficiencia
        Inherits _template.ActionBL

        Private accionIneficiencia As New baseball.lib.dao.Ineficiencia.fachada
        Private _ineficiencia As baseball.lib.vo.ineficiencia.IneficienciaVO

        'Public Event AvisoAsincrono(ByVal mensaje As String)
        Public Event AvisoSincrono(ByVal mensaje As String, ByRef e As System.ComponentModel.CancelEventArgs)

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

                    If (Not baseball.lib.common.funciones.getinfo.IsEmpty(_ineficiencia.Fin)) Then
                        If (Not _ineficiencia.PteValidar) Then

                            Dim accCanClose As New baseball.lib.bl.Ineficiencia.doPuedeCerrarIneficiencia(_ineficiencia)
                            Dim sePuede As Boolean = accCanClose.execute
                            If (sePuede) Then
                                Dim e As New System.ComponentModel.CancelEventArgs
                                RaiseEvent AvisoSincrono("Ha establecido la fecha de fin de ineficiencia. ¿Desea cerrarla?", e)
                                sePuede = Not e.Cancel
                            End If

                            If (sePuede) Then
                                _ineficiencia.Cerrada = baseball.lib.vo.ineficiencia.IneficienciaVO.INEFICIENCIA_CERRADA
                            End If

                        Else
                        End If
                    End If

                    Dim ee As New System.ComponentModel.CancelEventArgs
                    ee.Cancel = False
                    If (Not _ineficiencia.PteValidar) Then
                        RaiseEvent AvisoSincrono("¿desea enviar el correo de notificación a la comisión gestora?", ee)
                    End If
                    _ineficiencia.Notificar = Not ee.Cancel

                    Dim ineficienciaCambio As baseball.lib.vo.ineficiencia.IneficienciaVO = accionIneficiencia.ActualizarIneficiencia(_ineficiencia)
                    ineficienciaCambio.Notificar = _ineficiencia.Notificar
                    ineficienciaCambio.PteValidar = _ineficiencia.PteValidar
                    ineficienciaCambio.IntegrantesComision = _ineficiencia.IntegrantesComision

                    Dim doNotificar As New doNotificarIneficiencia(ineficienciaCambio, True)
                    doNotificar.execute()
                End If

                Return _ineficiencia
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace
