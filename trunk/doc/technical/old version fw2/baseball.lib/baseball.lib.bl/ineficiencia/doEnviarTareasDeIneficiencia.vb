Namespace Ineficiencia

    Friend Class doEnviarTareasDeIneficiencia
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
                Return _ineficiencia
                Exit Function


                'If (Not Me._ineficiencia.PteValidar) AndAlso (Not Me._ineficiencia.IsCerrada) Then
                '    '20070906: Tareas. Envío de avisos a los usuarios
                '    If (Not Me._ineficiencia.Acciones Is Nothing) Then
                '        'Create an instance of the application
                '        Dim appolApp As New Microsoft.Office.Interop.Outlook.Application
                '        Dim olApptItem As Microsoft.Office.Interop.Outlook.TaskItem = Nothing
                '        Dim TaskFolder As Microsoft.Office.Interop.Outlook.MAPIFolder
                '        Dim olns As Microsoft.Office.Interop.Outlook.NameSpace = appolApp.GetNamespace("MAPI")
                '        TaskFolder = olns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderTasks)

                '        For Each accion As baseball.lib.vo.accion.AccionVO In Me._ineficiencia.Acciones
                '            If (Not accion.Tareas Is Nothing) Then
                '                For Each tarea As baseball.lib.vo.tarea.TareaVO In accion.Tareas
                '                    olApptItem = appolApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olTaskItem)
                '                    '
                '                    olApptItem.PercentComplete = "0"
                '                    '
                '                    olApptItem.Body = accion.Descripcion
                '                    olApptItem.Status = baseball.lib.vo.tarea.TareaVO.EstadoAccionToEstadoOutlook(accion.Estado)

                '                    olApptItem.UserProperties.Add(_util.constantes.TaskProperties.myAPPNAME, Microsoft.Office.Interop.Outlook.OlUserPropertyType.olText).Value = _util.constantes.TaskProperties.myAPPVALUE
                '                    olApptItem.UserProperties.Add(_util.constantes.TaskProperties.myTASKIDNAME, Microsoft.Office.Interop.Outlook.OlUserPropertyType.olText).Value = tarea.Id

                '                    olApptItem.Subject = "GesInef: Ineficiencia " & Me._ineficiencia.Codigo & " - Accion a realizar"
                '                    If (accion.FechaEstimada < DateTime.Now) Then
                '                        olApptItem.StartDate = _ineficiencia.Fecha
                '                    Else
                '                        olApptItem.StartDate = accion.FechaEstimada
                '                    End If
                '                    If (olApptItem.StartDate > accion.FechaEstimada) Then
                '                        olApptItem.DueDate = olApptItem.StartDate
                '                    Else
                '                        olApptItem.DueDate = accion.FechaEstimada
                '                    End If
                '                    If (accion.Notificar) Then
                '                        olApptItem.ReminderTime = accion.FechaAntelacion
                '                    Else
                '                        olApptItem.ReminderTime = accion.FechaEstimada
                '                    End If

                '                    '20070510: Comprobación de existencia de destinatarios
                '                    'para que controle cuando enviamos un mail a un buzon
                '                    'desconocido
                '                    Dim msg As String = String.Empty
                '                    For Each recipiente As Microsoft.Office.Interop.Outlook.Recipient In olApptItem.Recipients
                '                        recipiente.Resolve()
                '                        If (Not recipiente.Resolved) Then
                '                            msg += Chr(13) & "-- Recipiente incorrecto : " & recipiente.Name & " --"
                '                            recipiente.Delete()
                '                        End If
                '                    Next
                '                    '*****************************************************
                '                    '

                '                    '<20070808> Incidencia! El tipo de datos Outlook.TaskItem NO tiene
                '                    'la propiedad .To ni la .CC
                '                    'Dim oldTask As Outlook.TaskItem = buscarTarea(olApptItem)

                '                    Dim oldTask As Microsoft.Office.Interop.Outlook.TaskItem = Nothing
                '                    For i As Integer = 1 To TaskFolder.Items.Count
                '                        Dim olTask As Microsoft.Office.Interop.Outlook.TaskItem = CType(TaskFolder.Items(i), Outlook.TaskItem)
                '                        If (Not olTask.UserProperties.Find(_util.constantes.TaskProperties.myAPPNAME) Is Nothing) _
                '                        AndAlso (olTask.UserProperties.Find(_util.constantes.TaskProperties.myAPPNAME).Value = olApptItem.UserProperties.Find(_util.constantes.TaskProperties.myAPPNAME).Value) _
                '                        AndAlso (Not olTask.UserProperties.Find(_util.constantes.TaskProperties.myTASKIDNAME) Is Nothing) _
                '                        AndAlso (olTask.UserProperties.Find(_util.constantes.TaskProperties.myTASKIDNAME).Value = olApptItem.UserProperties.Find(_util.constantes.TaskProperties.myTASKIDNAME).Value) _
                '                        Then
                '                            oldTask = olTask
                '                            Exit For
                '                        End If
                '                    Next

                '                    '*************
                '                    Dim existeTarea As Boolean = Not oldTask Is Nothing
                '                    If (accion.Responsable.Codigo.Trim.ToLower <> _ineficiencia.Usuario.Codigo.Trim.ToLower) AndAlso (accion.Responsable.Codigo.ToLower <> Environment.UserName.ToLower) Then
                '                        '<20070917> NO enviamos la tarea...cada outlook se busca la vida
                '                        'If (Not tarea.Notificada) Then
                '                        '    'If (Not existeTarea) Then
                '                        '    olApptItem.Assign()
                '                        '    Dim recip As Outlook.Recipient = olApptItem.Recipients.Add(accion.Responsable.Codigo)
                '                        '    recip.Resolve()
                '                        '    If (recip.Resolved) Then
                '                        '        olApptItem.Send()

                '                        '        tarea.Notificada = True
                '                        '        Dim accTarea As New baseball.lib.dao.Tarea.fachada
                '                        '        accTarea.ActualizarTarea(tarea)
                '                        '    End If
                '                        '    'olApptItem.UserProperties.Find(_util.constantes.TaskProperties.myAPPNAME, Outlook.OlUserPropertyType.olText) = Nothing
                '                        '    'olApptItem.Delete()
                '                        'End If
                '                        '</20070917> ******************
                '                    Else
                '                        'If (existeTarea) Then
                '                        '    'La modificamos...
                '                        '    'MsgBox("funcion de modificar tareas en el outlook NO implementada. <Pulse aceptar para continuar>")
                '                        '    oldTask.Status = olApptItem.Status
                '                        '    oldTask.Save()
                '                        'Else
                '                        '    MsgBox("añadiendo...")
                '                        '    olApptItem.Recipients.Add(accion.Responsable.Codigo)
                '                        '    'olApptItem.Save()
                '                        '    TaskFolder.Items.Add(olApptItem)
                '                        'End If
                '                    End If
                '                    '</20070808> *****************************************************
                '                Next
                '            End If
                '        Next

                '    End If
                '    '************************************************
                'End If
                'Return _ineficiencia
                ' ''**************************
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        'Private Function buscarTarea(ByVal task As Outlook.TaskItem) As Outlook.TaskItem
        '    Dim res As Outlook.TaskItem = Nothing

        '    Dim appolApp As New Outlook.Application
        '    Dim TaskFolder As Outlook.MAPIFolder
        '    Dim olns As Outlook.NameSpace = appolApp.GetNamespace("MAPI")
        '    TaskFolder = olns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderTasks)

        '    For i As Integer = 1 To TaskFolder.Items.Count
        '        Dim olTask As Outlook.TaskItem = CType(TaskFolder.Items(i), Outlook.TaskItem)
        '        If (Not olTask.UserProperties.Find(_util.constantes.TaskProperties.myAPPNAME) Is Nothing) _
        '        AndAlso (olTask.UserProperties.Find(_util.constantes.TaskProperties.myAPPNAME).Value = task.UserProperties.Find(_util.constantes.TaskProperties.myAPPNAME).Value) _
        '        AndAlso (Not olTask.UserProperties.Find(_util.constantes.TaskProperties.myTASKIDNAME) Is Nothing) _
        '        AndAlso (olTask.UserProperties.Find(_util.constantes.TaskProperties.myTASKIDNAME).Value = task.UserProperties.Find(_util.constantes.TaskProperties.myTASKIDNAME).Value) _
        '        Then
        '            res = olTask
        '            Exit For
        '        End If
        '    Next

        '    Return res
        'End Function

    End Class

End Namespace
