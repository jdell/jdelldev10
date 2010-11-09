Namespace frm._principal.ctrl
    Public Class ctrlPrincipal
        Inherits baseball.app.pc._template.baseballctrl

        Dim _vista As frmPrincipal

        Public Overrides Sub inicializarForm(ByRef frm As repsol.forms.template.BaseForm)
            Try
                _vista = frm

                _vista.XmlDocHelpPath = _common.variables.cache.ENTORNO.PathOnlineHelpFile

                'Style
                _vista.WindowState = FormWindowState.Maximized
                _vista.sbar.RenderMode = ToolStripRenderMode.System

                'MdiWindowListItem
                _vista.MenuStrip1.MdiWindowListItem = _vista.VentanaToolStripMenuItem

                'Status Bar
                Dim titem As ToolStripLabel

                titem = New ToolStripLabel(Application.ProductName & " v" & Application.ProductVersion)
                _vista.sbar.Items.Add(titem)

#If DEBUG Then
                titem = New ToolStripLabel("Debug")
                _vista.sbar.Items.Add(titem)

                _vista.TestToolStripMenuItem.Visible = True
                _vista.VersionToolStripMenuItem.Visible = True
                _vista.AyudaEnLíneaToolStripMenuItem.Visible = True
                _vista.MejorasVersinoToolStripMenuItem.Visible = True
#Else
                titem = New ToolStripLabel("Release")
                _vista.sbar.Items.Add(titem)
#End If
                titem = New ToolStripLabel(baseball.lib.bl._common.cache.USUARIO.ToString)
                titem.Name = "baseballbl._common.cache.USUARIO"
                _vista.sbar.Items.Add(titem)
                titem.Alignment = ToolStripItemAlignment.Right

                _common.variables.cache.MdiForm = _vista

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#Region "20071226: Impresión resumen de equipos"

        <Obsolete("En total desuso..", True)> _
        Public Sub prepareRPTResumenEquipos(ByRef viewer As Microsoft.Reporting.WinForms.ReportViewer)
            'Try
            '    Dim informe As New baseball.lib.bl._common.informes.rptResumenEquipos
            '    informe.setInformeIntoViewer(viewer)

            'Catch ex As Exception
            '    Throw ex
            'End Try
        End Sub

        Public Sub prepareRPTEstadoEquipos(ByRef viewer As Microsoft.Reporting.WinForms.ReportViewer)
            Try
                'Dim informe As New baseball.lib.bl._common.informes.rptEstadoEquipos(Nothing, Nothing, Nothing)
                'informe.setInformeIntoViewer(viewer)

            Catch ex As Exception
                Throw ex
            End Try
        End Sub
#End Region

    End Class
End Namespace


