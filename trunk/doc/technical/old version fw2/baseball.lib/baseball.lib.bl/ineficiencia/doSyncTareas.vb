Imports Microsoft.Office.Interop
Namespace Ineficiencia

    Public Class doSyncTareas
        Inherits _template.ActionBL

        Private _usuario As baseball.lib.vo.UsuarioVO

        Public Sub New(ByVal usuario As baseball.lib.vo.UsuarioVO)
            _usuario = usuario
        End Sub
        Public Shadows Function execute() As Object
            Return MyBase.execute
        End Function

        Protected Overrides Function accion() As Object
            Try
                Dim facAccion As New baseball.lib.dao.Accion.fachada
                Dim acciones As baseball.lib.vo.AccionVO() = facAccion.SeleccionarAccionesPdteTareaPorUsuario(_usuario)

                If (Not acciones Is Nothing) Then
                    'Create an instance of the application
                    Dim appolApp As New Outlook.Application
                    Dim olApptItem As Outlook.TaskItem = Nothing
                    Dim TaskFolder As Outlook.MAPIFolder
                    Dim olns As Outlook.NameSpace = appolApp.GetNamespace("MAPI")
                    TaskFolder = olns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderTasks)

                    For Each accionOBJ As baseball.lib.vo.AccionVO In acciones

                        Dim tareas As New baseball.lib.dao.Tarea.fachada
                        accionOBJ.Tareas = tareas.SeleccionarTareasPorAccion(accion)
                        If (Not accionOBJ.Tareas Is Nothing) Then
                            For Each tarea As baseball.lib.vo.TareaVO In accionOBJ.Tareas
                                olApptItem = appolApp.CreateItem(Outlook.OlItemType.olTaskItem)
                                '
                                olApptItem.PercentComplete = "0"
                                '
                                olApptItem.Body = accionOBJ.Descripcion
                                olApptItem.Status = baseball.lib.vo.TareaVO.EstadoAccionToEstadoOutlook(accionOBJ.Estado)

                                olApptItem.UserProperties.Add(_util.constantes.TaskProperties.myAPPNAME, Outlook.OlUserPropertyType.olText).Value = _util.constantes.TaskProperties.myAPPVALUE
                                olApptItem.UserProperties.Add(_util.constantes.TaskProperties.myTASKIDNAME, Outlook.OlUserPropertyType.olText).Value = tarea.Id

                                Dim facIneficiencia As New baseball.lib.dao.Ineficiencia.fachada
                                accionOBJ.Ineficiencia = facIneficiencia.SeleccionarIneficiencia(accionOBJ.Ineficiencia)

                                olApptItem.Subject = "GesInef: Ineficiencia " & accionOBJ.Ineficiencia.Codigo & " - Accion a realizar"
                                If (accionOBJ.FechaEstimada < DateTime.Now) Then
                                    olApptItem.StartDate = accionOBJ.Ineficiencia.Fecha
                                Else
                                    olApptItem.StartDate = accionOBJ.FechaEstimada
                                End If
                                If (olApptItem.StartDate > accionOBJ.FechaEstimada) Then
                                    olApptItem.DueDate = olApptItem.StartDate
                                Else
                                    olApptItem.DueDate = accionOBJ.FechaEstimada
                                End If
                                If (accionOBJ.Notificar) Then
                                    olApptItem.ReminderTime = accionOBJ.FechaAntelacion
                                Else
                                    olApptItem.ReminderTime = accionOBJ.FechaEstimada
                                End If

                                '20070510: Comprobación de existencia de destinatarios
                                'para que controle cuando enviamos un mail a un buzon
                                'desconocido
                                Dim msg As String = String.Empty
                                For Each recipiente As Outlook.Recipient In olApptItem.Recipients
                                    recipiente.Resolve()
                                    If (Not recipiente.Resolved) Then
                                        msg += Chr(13) & "-- Recipiente incorrecto : " & recipiente.Name & " --"
                                        recipiente.Delete()
                                    End If
                                Next
                                '*****************************************************
                                '

                                '<20070808> Incidencia! El tipo de datos Outlook.TaskItem NO tiene
                                'la propiedad .To ni la .CC
                                'Dim oldTask As Outlook.TaskItem = buscarTarea(olApptItem)

                                Dim oldTask As Outlook.TaskItem = Nothing
                                For i As Integer = 1 To TaskFolder.Items.Count
                                    Dim olTask As Outlook.TaskItem = CType(TaskFolder.Items(i), Outlook.TaskItem)
                                    If (Not olTask.UserProperties.Find(_util.constantes.TaskProperties.myAPPNAME) Is Nothing) _
                                    AndAlso (olTask.UserProperties.Find(_util.constantes.TaskProperties.myAPPNAME).Value = olApptItem.UserProperties.Find(_util.constantes.TaskProperties.myAPPNAME).Value) _
                                    AndAlso (Not olTask.UserProperties.Find(_util.constantes.TaskProperties.myTASKIDNAME) Is Nothing) _
                                    AndAlso (olTask.UserProperties.Find(_util.constantes.TaskProperties.myTASKIDNAME).Value = olApptItem.UserProperties.Find(_util.constantes.TaskProperties.myTASKIDNAME).Value) _
                                    Then
                                        oldTask = olTask
                                        Exit For
                                    End If
                                Next

                                '*************
                                Dim existeTarea As Boolean = Not oldTask Is Nothing

                                If (existeTarea) Then
                                    'La modificamos...
                                    oldTask.Status = olApptItem.Status
                                    oldTask.Save()
                                Else
                                    olApptItem.Recipients.Add(accionOBJ.Responsable.Codigo)
                                    olApptItem.Save()
                                End If

                                tarea.Notificada = True
                                Dim accTarea As New baseball.lib.dao.Tarea.fachada
                                accTarea.ActualizarTarea(tarea)
                                '</20070808> *****************************************************
                            Next
                        End If
                    Next

                End If
                '************************************************
                Return _usuario
                ''**************************
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class

End Namespace
