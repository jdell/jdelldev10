Namespace My

    ' The following events are availble for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.Devices.NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged
            Try
                If (Not e.IsNetworkAvailable) Then
                    repsol.util.messages.ShowWarning("Se han detectado problemas en la conexión de red. Espere unos minutos hasta que se restablezca la conexión o contacte con su administrador.", Application.Info.ProductName)
                    My.Application.MainForm.Enabled = False
                Else
                    repsol.util.messages.ShowInfo("Se ha restablecido la conexión de red.", Application.Info.ProductName)
                    My.Application.MainForm.Enabled = True
                End If
            Catch ex As baseball.lib.bl._exceptions.baseballException
                repsol.util.messages.ShowError(ex.FullMessage, Application.Info.ProductName)
                End
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Application.Info.ProductName)
                End
            End Try
        End Sub

        Private Sub MyApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
            Try

                Dim vVen As New frm._splash.frmSplashBaseBall
                vVen.Status = "Cerrando BaseBall"
                AddHandler baseball.lib.bl._common.cache.Processing, AddressOf vVen.Avanza
                vVen.Show(True, False, True)

                'La aplicación SIEMPRE pasa por aquí (tanto si sale bien como si sale mal...)
                baseball.lib.bl._common.cache.CerrarBaseBall()
                _common.variables.cache.CerrarAPP()

                vVen.Close()
            Catch ex As baseball.lib.bl._exceptions.baseballException
                repsol.util.messages.ShowError(ex.FullMessage, Application.Info.ProductName)
                End
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Application.Info.ProductName)
                End
            End Try
        End Sub

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Try
                Dim vVen As New frm._splash.frmSplashBaseBall
                vVen.Status = "Iniciando BaseBall"
                AddHandler baseball.lib.bl._common.cache.Processing, AddressOf vVen.Avanza
                vVen.Show(True, False, True)

                AddHandler baseball.lib.bl._common.cache.BLClosing, AddressOf Cerrando
                AddHandler baseball.lib.bl._common.cache.BLClosed, AddressOf Cerrado
                AddHandler baseball.lib.bl._common.cache.BLOpen, AddressOf Abierto

#If DEBUG Then
                baseball.lib.common.variables.configpath.DIRECTORY = "C:\Documents and Settings\Joe\Escritorio\Baseball\beta\baseball.lib\baseball.lib.bl\bin\Debug"
                'baseball.lib.common.variables.configpath.DIRECTORY = "E:\Baseball\beta\baseball.lib\baseball.lib.bl\bin\Debug"
                baseball.lib.bl._common.cache.InicializaBaseBall("JOE")
#Else
                baseball.lib.bl._common.cache.InicializaBaseBall(Environment.UserName)
#End If

                _common.variables.cache.InicializaAPP(e.CommandLine)

                Me.OnCreateMainForm()

                vVen.Close()
            Catch ex As baseball.lib.bl._exceptions._common.ConfigFileNotFoundException
                repsol.util.messages.ShowError(ex.FullMessage, Application.Info.ProductName)
                End
            Catch ex As baseball.lib.bl._exceptions._common.OutOfServiceException
                repsol.util.messages.ShowError(ex.FullMessage, Application.Info.ProductName)
                End
            Catch ex As baseball.lib.bl._exceptions.baseballException
                repsol.util.messages.ShowError(ex.FullMessage, Application.Info.ProductName)
                MyApplication_Shutdown(Nothing, Nothing)
                End
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Application.Info.ProductName)
                MyApplication_Shutdown(Nothing, Nothing)
                End
            End Try
        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Try

                repsol.util.messages.ShowInfo(String.Format("Excepción no controlada. La aplicación se cerrará. [{0}]", e.Exception.Message), Application.Info.ProductName)

            Catch ex As baseball.lib.bl._exceptions.baseballException
                repsol.util.messages.ShowError(ex.FullMessage, Application.Info.ProductName)
                End
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Application.Info.ProductName)
                End
            Finally
                MyApplication_Shutdown(Nothing, Nothing)
            End Try
        End Sub


#Region "******** Seccion Recepción Eventos BL ***********"

        Private Sub Cerrando(ByVal e As baseball.lib.bl._events.NotificationEventArgs)
            Try
                Control.CheckForIllegalCrossThreadCalls = False
                'Dim frm As frm._principal.frmPrincipal = My.Application.OpenForms(0)
                Dim frm As frm._principal.frmPrincipal = _common.variables.cache.MdiForm
                If (Not frm Is Nothing) Then
                    If (Not frm.sbar.Items("baseballbl._common.cache.AvisoSistemaSplitButton") Is Nothing) Then
                        frm.sbar.Items("baseballbl._common.cache.AvisoSistemaSplitButton").Tag = e
                        frm.sbar.Items("baseballbl._common.cache.AvisoSistemaSplitButton").Visible = True
                    End If
                    MsgBox(e.detalle, MsgBoxStyle.Exclamation, baseball.lib.bl._common.cache.APPNAME)
                End If
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Application.Info.ProductName)
            Finally
                Control.CheckForIllegalCrossThreadCalls = True
            End Try
        End Sub

        Private Sub Cerrado(ByVal e As baseball.lib.bl._events.NotificationEventArgs)
            Try
                Control.CheckForIllegalCrossThreadCalls = False
                If (My.Application.OpenForms.Count > 0) AndAlso (Not My.Application.OpenForms(0).GetType Is GetType(frm._splash.frmSplashBaseBall)) Then
                    Try
                        Dim vVen As New repsol.forms.MessageBoxCountDown
                        vVen.Show("Cierre de la aplicación por mantenimiento.", baseball.lib.bl._common.cache.APPNAME, 30, MessageBoxIcon.Information)

                    Catch ex As Exception

                    End Try
                Else
                    MsgBox(String.Format("{0}", e.mensaje), MsgBoxStyle.Exclamation, baseball.lib.bl._common.cache.APPNAME)
                End If

                MyApplication_Shutdown(Nothing, Nothing)
                End
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Application.Info.ProductName)
            Finally
                Control.CheckForIllegalCrossThreadCalls = True
            End Try
        End Sub

        Private Sub Abierto(ByVal e As baseball.lib.bl._events.NotificationEventArgs)
            Try

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Application.Info.ProductName)
            End Try
        End Sub

#End Region

    End Class

End Namespace
