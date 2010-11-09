Namespace Ineficiencia
    Public Class doCambiarEstadoIneficiencia
        Inherits _template.ActionBL

        Private accionIneficiencia As New baseball.lib.dao.Ineficiencia.fachada
        Private _ineficiencia As baseball.lib.vo.ineficiencia.IneficienciaVO
        Private _estado As String

        Public Event AvisoAsincrono(ByVal mensaje As String)

        Public Sub New(ByVal ineficiencia As baseball.lib.vo.ineficiencia.IneficienciaVO, ByVal estado As String)
            _ineficiencia = ineficiencia
            _estado = estado
        End Sub
        Public Shadows Function execute() As Object
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Try
                Dim res As String = String.Empty

                If (_ineficiencia Is Nothing) Then
                    Throw New _exceptions._common.NullReferenceException()
                End If

                Select Case _estado
                    Case baseball.lib.vo.ineficiencia.IneficienciaVO.INEFICIENCIA_ABIERTA
                        _ineficiencia.Cerrada = baseball.lib.vo.ineficiencia.IneficienciaVO.INEFICIENCIA_ABIERTA
                        _ineficiencia.Fin = baseball.lib.common.constantes.vacio.FECHA
                        Dim accionUpd As New baseball.lib.bl.Ineficiencia.doActualizarIneficienciaCab(_ineficiencia)
                        accionUpd.execute()
                    Case baseball.lib.vo.ineficiencia.IneficienciaVO.INEFICIENCIA_CERRADA
                        If (Not _ineficiencia.PteValidar) Then
                            Dim accComprobar As New baseball.lib.bl.Ineficiencia.doPuedeCerrarIneficiencia(_ineficiencia)
                            Dim sePuede As Boolean = accComprobar.execute
                            If (sePuede) Then
                                _ineficiencia.Cerrada = baseball.lib.vo.ineficiencia.IneficienciaVO.INEFICIENCIA_CERRADA
                                If (baseball.lib.common.funciones.getinfo.IsEmpty(_ineficiencia.Fin)) Then
                                    _ineficiencia.Fin = DateTime.Now
                                    RaiseEvent AvisoAsincrono(String.Format("No ha establecido la fecha de fin de ineficiencia. Se establecerá la fecha de hoy [{0}].", DateTime.Now.ToString(baseball.lib.common.constantes.formato.FECHAHORA)))
                                End If
                                Dim accionUpd As New baseball.lib.bl.Ineficiencia.doActualizarIneficienciaCab(_ineficiencia)
                                accionUpd.execute()
                            Else
                                Throw New _exceptions.ineficiencia.MAXIMOPendingException
                            End If
                        Else
                            Throw New _exceptions.ineficiencia.ValidatePendingException
                        End If
                    Case baseball.lib.vo.ineficiencia.IneficienciaVO.INEFICIENCIA_ESTRUCTURAL
                        _ineficiencia.Cerrada = baseball.lib.vo.ineficiencia.IneficienciaVO.INEFICIENCIA_ESTRUCTURAL
                        Dim accionUpd As New baseball.lib.bl.Ineficiencia.doActualizarIneficienciaCab(_ineficiencia)
                        accionUpd.execute()
                End Select

                Return res

            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace
