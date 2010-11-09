Namespace frm.partido
    Public Class frmPartidoQry
        Inherits _template.consulta.queryform

        Friend WithEvents EstadisticasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents CambiarEstadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents tsbSeparador As System.Windows.Forms.ToolStripSeparator
        Private components As System.ComponentModel.IContainer
        Friend WithEvents contextMenuAux As System.Windows.Forms.ContextMenuStrip
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.contextMenuAux = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.tsbSeparador = New System.Windows.Forms.ToolStripSeparator
            Me.CambiarEstadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.EstadisticasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.panInfo.SuspendLayout()
            CType(Me.dvConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.contextMenuAux.SuspendLayout()
            Me.SuspendLayout()
            '
            'panDetail
            '
            Me.panDetail.Location = New System.Drawing.Point(0, 152)
            Me.panDetail.Size = New System.Drawing.Size(792, 421)
            '
            'panInfo
            '
            Me.panInfo.Location = New System.Drawing.Point(0, 127)
            '
            'contextMenuAux
            '
            Me.contextMenuAux.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSeparador, Me.CambiarEstadoToolStripMenuItem, Me.EstadisticasToolStripMenuItem})
            Me.contextMenuAux.Name = "contextMenuAux"
            Me.contextMenuAux.Size = New System.Drawing.Size(153, 76)
            '
            'tsbSeparador
            '
            Me.tsbSeparador.Name = "tsbSeparador"
            Me.tsbSeparador.Size = New System.Drawing.Size(149, 6)
            '
            'CambiarEstadoToolStripMenuItem
            '
            Me.CambiarEstadoToolStripMenuItem.Name = "CambiarEstadoToolStripMenuItem"
            Me.CambiarEstadoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.CambiarEstadoToolStripMenuItem.Text = "Cambiar Estado"
            Me.CambiarEstadoToolStripMenuItem.Visible = False
            '
            'EstadisticasToolStripMenuItem
            '
            Me.EstadisticasToolStripMenuItem.Name = "EstadisticasToolStripMenuItem"
            Me.EstadisticasToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.EstadisticasToolStripMenuItem.Text = "Estadisticas"
            '
            'frmPartidoQry
            '
            Me.ClientSize = New System.Drawing.Size(792, 573)
            Me.Name = "frmPartidoQry"
            Me.Text = "Partidos"
            Me.Controls.SetChildIndex(Me.panHead, 0)
            Me.Controls.SetChildIndex(Me.panInfo, 0)
            Me.Controls.SetChildIndex(Me.panDetail, 0)
            Me.panInfo.ResumeLayout(False)
            Me.panInfo.PerformLayout()
            CType(Me.dvConsulta, System.ComponentModel.ISupportInitialize).EndInit()
            Me.contextMenuAux.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Protected Overrides Sub btNuevo_record()
            Try
                Dim vVen As New frmPartidoEdit
                Dim res As DialogResult = vVen.ShowDialog(Me)
                If (res = Windows.Forms.DialogResult.OK) Then btRefresh_record()

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Protected Overrides Sub btduplicar_record()
            Try
                Dim ctrl As New ctrl.ctrlPartidoQry
                If (ctrl.getRegistroSeleccionado(Me) Is Nothing) Then
                    repsol.util.messages.ShowWarning(_common.constantes.mensaje.NO_RECORD_SELECTED, Me.Text)
                    Return
                End If

                Dim vVen As New frmPartidoEdit(ctrl.getRegistroSeleccionado(Me))
                Dim res As DialogResult = vVen.ShowDialog(Me)
                If (res = Windows.Forms.DialogResult.OK) Then btRefresh_record()

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Protected Overrides Sub btconsulta_record()
            Try
                Dim ctrl As New ctrl.ctrlPartidoQry
                If (ctrl.getRegistroSeleccionado(Me) Is Nothing) Then
                    repsol.util.messages.ShowWarning(_common.constantes.mensaje.NO_RECORD_SELECTED, Me.Text)
                    Return
                End If

                Dim vVen As New frmPartidoEdit(ctrl.getRegistroSeleccionado(Me), True)
                Dim res As DialogResult = vVen.ShowDialog(Me)
                If (res = Windows.Forms.DialogResult.OK) Then btRefresh_record()

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Protected Overrides Sub btModificar_record()
            Try
                Dim ctrl As New ctrl.ctrlPartidoQry
                If (ctrl.getRegistroSeleccionado(Me) Is Nothing) Then
                    repsol.util.messages.ShowWarning(_common.constantes.mensaje.NO_RECORD_SELECTED, Me.Text)
                    Return
                End If

                Dim vVen As New frmPartidoEdit(ctrl.getRegistroSeleccionado(Me), False)
                Dim res As DialogResult = vVen.ShowDialog(Me)
                If (res = Windows.Forms.DialogResult.OK) Then btRefresh_record()

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Protected Overrides Sub btBorrar_record()
            Try
                Dim ctrl As New ctrl.ctrlPartidoQry
                If (ctrl.getRegistroSeleccionado(Me) Is Nothing) Then
                    repsol.util.messages.ShowWarning(_common.constantes.mensaje.NO_RECORD_SELECTED, Me.Text)
                    Return
                End If

                If (System.Windows.Forms.DialogResult.Yes = MessageBox.Show("¿Está seguro de borrar este registro?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) Then
                    If (ctrl.BorrarRegistro(Me)) Then
                        btRefresh_record()
                    End If
                End If

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Public Overrides Sub btRefresh_record()
            Try
                Dim ctrl As New ctrl.ctrlPartidoQry
                ctrl.saveSelectedRow(Me)
                ctrl.ConsultaRegistros(Me)
                ctrl.loadSelectedRow(Me)

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub frmPartidoQry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Dim ctrl As New ctrl.ctrlPartidoQry
                ctrl.inicializarForm(Me)
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub EstadisticasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadisticasToolStripMenuItem.Click
            Try
                Dim ctrl As New ctrl.ctrlPartidoQry
                If (ctrl.getRegistroSeleccionado(Me) Is Nothing) Then
                    repsol.util.messages.ShowWarning(_common.constantes.mensaje.NO_RECORD_SELECTED, Me.Text)
                    Return
                End If

                Dim vVen As New hojaanotacion.frmHojaAnotacionEdit(ctrl.getRegistroSeleccionado(Me))
                vVen.ShowDialog()
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub
    End Class
End Namespace
