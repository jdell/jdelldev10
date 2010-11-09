Namespace frm.equipo
    Public Class frmEquipoQry
        Inherits _template.consulta.queryform

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Me.panInfo.SuspendLayout()
            CType(Me.dvConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
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
            'frmEquipoQry
            '
            Me.ClientSize = New System.Drawing.Size(792, 573)
            Me.Name = "frmEquipoQry"
            Me.Text = "Equipos"
            Me.Controls.SetChildIndex(Me.panHead, 0)
            Me.Controls.SetChildIndex(Me.panInfo, 0)
            Me.Controls.SetChildIndex(Me.panDetail, 0)
            Me.panInfo.ResumeLayout(False)
            Me.panInfo.PerformLayout()
            CType(Me.dvConsulta, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Protected Overrides Sub btNuevo_record()
            Try
                Dim vVen As New frmEquipoEdit
                Dim res As DialogResult = vVen.ShowDialog(Me)
                If (res = Windows.Forms.DialogResult.OK) Then btRefresh_record()

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Protected Overrides Sub btduplicar_record()
            Try
                Dim ctrl As New ctrl.ctrlEquipoQry
                If (ctrl.getRegistroSeleccionado(Me) Is Nothing) Then
                    repsol.util.messages.ShowWarning(_common.constantes.mensaje.NO_RECORD_SELECTED, Me.Text)
                    Return
                End If

                Dim vVen As New frmEquipoEdit(ctrl.getRegistroSeleccionado(Me))
                Dim res As DialogResult = vVen.ShowDialog(Me)
                If (res = Windows.Forms.DialogResult.OK) Then btRefresh_record()

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Protected Overrides Sub btconsulta_record()
            Try
                Dim ctrl As New ctrl.ctrlEquipoQry
                If (ctrl.getRegistroSeleccionado(Me) Is Nothing) Then
                    repsol.util.messages.ShowWarning(_common.constantes.mensaje.NO_RECORD_SELECTED, Me.Text)
                    Return
                End If

                Dim vVen As New frmEquipoEdit(ctrl.getRegistroSeleccionado(Me), True)
                Dim res As DialogResult = vVen.ShowDialog(Me)
                If (res = Windows.Forms.DialogResult.OK) Then btRefresh_record()

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Protected Overrides Sub btModificar_record()
            Try
                Dim ctrl As New ctrl.ctrlEquipoQry
                If (ctrl.getRegistroSeleccionado(Me) Is Nothing) Then
                    repsol.util.messages.ShowWarning(_common.constantes.mensaje.NO_RECORD_SELECTED, Me.Text)
                    Return
                End If

                Dim vVen As New frmEquipoEdit(ctrl.getRegistroSeleccionado(Me), False)
                Dim res As DialogResult = vVen.ShowDialog(Me)
                If (res = Windows.Forms.DialogResult.OK) Then btRefresh_record()

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Protected Overrides Sub btBorrar_record()
            Try
                Dim ctrl As New ctrl.ctrlEquipoQry
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
                Dim ctrl As New ctrl.ctrlEquipoQry
                ctrl.saveSelectedRow(Me)
                ctrl.ConsultaRegistros(Me)
                ctrl.loadSelectedRow(Me)

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub frmEquipoQry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Dim ctrl As New ctrl.ctrlEquipoQry
                ctrl.inicializarForm(Me)
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub
    End Class
End Namespace
