Namespace Ineficiencia

    Public Class doNotificarIneficiencia
        Inherits _template.ActionBL

        Private accionIneficiencia As New baseball.lib.dao.Ineficiencia.fachada
        Private _ineficiencia As baseball.lib.vo.ineficiencia.IneficienciaVO
        Private _solocomision As Boolean = False

        Public Sub New(ByVal ineficiencia As baseball.lib.vo.ineficiencia.IneficienciaVO, ByVal solocomision As Boolean)
            _ineficiencia = ineficiencia
            _solocomision = solocomision
        End Sub

        Public Shadows Function execute() As Object
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Try

                If (Me._ineficiencia.PteValidar) Then
                    If (Not _solocomision) Then

                        Dim notificacion As New baseball.lib.vo.notificacion.NotificacionVO
                        Dim accNotificacionGenerar As New Notificacion.doGenerarNotificacion(_ineficiencia)
                        notificacion = accNotificacionGenerar.execute

                        Dim integrantes_grpValidador As List(Of String) = baseball.lib.bl._common.cache.GRUPOS.GrupoValidador()
                        If (Not integrantes_grpValidador Is Nothing) Then
                            notificacion.DestinatarioCopia = ""
                            For Each integrante As String In integrantes_grpValidador
                                notificacion.DestinatarioCopia += integrante & ";"
                            Next
                        End If

                        Dim accNotificacionEnviar As New Notificacion.doEnviarNotificacion(notificacion)
                        accNotificacionEnviar.execute()
                    End If
                Else
                    If (Me._ineficiencia.Notificar) Then
                        Dim notificacion As New baseball.lib.vo.notificacion.NotificacionVO

                        Dim accNotificacionGenerar As New Notificacion.doGenerarNotificacion(_ineficiencia, False)
                        notificacion = accNotificacionGenerar.execute

                        Dim accNotificacionEnviar As New Notificacion.doEnviarNotificacion(notificacion)
                        notificacion = accNotificacionEnviar.execute()

                        notificacion.Enviado = True
                        Dim accNotificacionInsertar As New Notificacion.doInsertarNotificacion(notificacion)
                        accNotificacionInsertar.execute()
                    End If
                End If
                Return _ineficiencia

            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace

