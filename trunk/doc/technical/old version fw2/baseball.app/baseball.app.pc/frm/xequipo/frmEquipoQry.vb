Namespace frm.equipo
    Public Class frmEquipoQry
        Inherits _template.consulta.queryform

        Public Event RefreshDgFilter(ByVal sender As Object, ByVal e As EventArgs)

        Public Sub New()
            InitializeComponent()
            Me.btFiltrar.Enabled = True
            Me.btConfiguracion.Visible = True
            Me.btConfiguracionSeparador.Visible = True

            Me.Text = IIf(_historico, "Histórico de Equipos", "Seguimiento de Equipos")

            _frmFiltro = New frm.equipo.frmEquipoFilter(Me.OnlyView, Me)
        End Sub

        Public Sub New(ByVal soloconsulta As Boolean, Optional ByVal historico As Boolean = False)
            MyBase.New(soloconsulta)
            InitializeComponent()
            Me.btFiltrar.Enabled = True
            Me.btConfiguracion.Visible = True
            Me.btConfiguracionSeparador.Visible = True

            _historico = historico
            Me.Text = IIf(_historico, "Histórico de Equipos", "Seguimiento de Equipos")

            _frmFiltro = New frm.equipo.frmEquipoFilter(Me.OnlyView, Me)
        End Sub

        Private _historico As Boolean = False
        <System.ComponentModel.DefaultValue(False)> _
        Public ReadOnly Property IsHistorico() As Boolean
            Get
                Return _historico
            End Get
        End Property

        Public Overrides Sub ShowDocked(ByRef c As System.Windows.Forms.Control)
            MyBase.ShowDocked(c)
            Me.ToolStrip1.Visible = False
            Me.btFiltrar.Visible = True
            Me.btConfiguracion.Visible = False
            Me.ToolStripMenuItemSeparador.Visible = False
        End Sub

        Protected Overrides Sub btNuevo_record()
            Try
                Dim vVen As New frmEquipoEdit
                vVen.ShowDialog(Me)
                btRefresh_record()

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
                vVen.ShowDialog(Me)
                btRefresh_record()

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
                vVen.ShowDialog(Me)
                If (Not Me.IsDocked) AndAlso (Not Me.IsHistorico) Then
                    btRefresh_record()
                End If

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

                If (ctrl.canModify(Me)) Then
                    Dim vVen As New frmEquipoEdit(ctrl.getRegistroSeleccionado(Me), False)
                    vVen.ShowDialog(Me)
                    btRefresh_record()
                Else
                    repsol.util.messages.ShowWarning("El equipo no se puede modificar debido a su estado.", Me.Text)
                End If


            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Protected Overrides Sub btConfiguracion_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Dim vVen As New configuracion.frmConfiguracionEdit(GetType(baseball.lib.vo.Equipo).FullName)
                vVen.ShowDialog(Me)
                btRefresh_record()

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
        Protected WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
        Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
        Friend WithEvents btCerrarInvestigacion As System.Windows.Forms.ToolStripButton
        Friend WithEvents btCerrar As System.Windows.Forms.ToolStripButton
        Friend WithEvents btReabrir As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents btAnular As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents btAnexar As System.Windows.Forms.ToolStripButton
        Friend WithEvents btLeccionAprendida As System.Windows.Forms.ToolStripButton

        Friend _frmFiltro As frm.equipo.frmEquipoFilter
        Protected Overrides Sub btFiltrar_record()
            Try
                If (_frmFiltro Is Nothing) Then
                    _frmFiltro = New frm.equipo.frmEquipoFilter(Me)
                    _frmFiltro.TopLevel = False
                    Me.Controls.Add(_frmFiltro)
                    _frmFiltro.Dock = DockStyle.Left
                    _frmFiltro.SendToBack()
                    _frmFiltro.Show()
                    _frmFiltro.AutoScroll = True
                    AddHandler _frmFiltro.rbVerSoloLasMias.CheckedChanged, AddressOf reConsultarRegistros
                    AddHandler _frmFiltro.rbVerMigente.CheckedChanged, AddressOf reConsultarRegistros
                    AddHandler _frmFiltro.rbVerTodos.CheckedChanged, AddressOf reConsultarRegistros
                    AddHandler _frmFiltro.lboxTipoImpacto.SelectedIndexChanged, AddressOf reConsultarRegistros
                    AddHandler _frmFiltro.cambioFiltro, AddressOf filtrar
                Else
                    _frmFiltro.Visible = Not _frmFiltro.Visible
                End If

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEquipoQry))
            Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
            Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
            Me.btCerrarInvestigacion = New System.Windows.Forms.ToolStripButton
            Me.btCerrar = New System.Windows.Forms.ToolStripButton
            Me.btReabrir = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me.btAnular = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
            Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
            Me.btAnexar = New System.Windows.Forms.ToolStripButton
            Me.btLeccionAprendida = New System.Windows.Forms.ToolStripButton
            Me.panInfo.SuspendLayout()
            CType(Me.dvConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ToolStrip1.SuspendLayout()
            Me.SuspendLayout()
            '
            'panDetail
            '
            Me.panDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.panDetail.Location = New System.Drawing.Point(0, 200)
            Me.panDetail.Size = New System.Drawing.Size(792, 373)
            '
            'panInfo
            '
            Me.panInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.panInfo.Location = New System.Drawing.Point(0, 175)
            '
            'panHead
            '
            Me.panHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.panHead.Size = New System.Drawing.Size(792, 150)
            '
            'chkVerFiltro
            '
            Me.chkVerFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkVerFiltro.Size = New System.Drawing.Size(60, 17)
            '
            'ToolStrip1
            '
            Me.ToolStrip1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
            Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.btCerrarInvestigacion, Me.btCerrar, Me.btReabrir, Me.ToolStripSeparator1, Me.btAnular, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripSeparator4, Me.btAnexar, Me.btLeccionAprendida})
            Me.ToolStrip1.Location = New System.Drawing.Point(519, 0)
            Me.ToolStrip1.Name = "ToolStrip1"
            Me.ToolStrip1.Size = New System.Drawing.Size(273, 25)
            Me.ToolStrip1.TabIndex = 16
            Me.ToolStrip1.Text = "ToolStrip1"
            '
            'ToolStripLabel1
            '
            Me.ToolStripLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ToolStripLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption
            Me.ToolStripLabel1.Name = "ToolStripLabel1"
            Me.ToolStripLabel1.Size = New System.Drawing.Size(60, 22)
            Me.ToolStripLabel1.Text = "Acciones:"
            '
            'btCerrarInvestigacion
            '
            Me.btCerrarInvestigacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btCerrarInvestigacion.Image = Global.baseball.My.Resources.Resources.cerrarinvestigacion
            Me.btCerrarInvestigacion.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btCerrarInvestigacion.Name = "btCerrarInvestigacion"
            Me.btCerrarInvestigacion.Size = New System.Drawing.Size(23, 22)
            Me.btCerrarInvestigacion.Text = "Cerrar Invest."
            '
            'btCerrar
            '
            Me.btCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btCerrar.Image = Global.baseball.My.Resources.Resources.cerrar
            Me.btCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btCerrar.Name = "btCerrar"
            Me.btCerrar.Size = New System.Drawing.Size(23, 22)
            Me.btCerrar.Text = "Cerrar"
            '
            'btReabrir
            '
            Me.btReabrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btReabrir.Image = Global.baseball.My.Resources.Resources.reabrir
            Me.btReabrir.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btReabrir.Name = "btReabrir"
            Me.btReabrir.Size = New System.Drawing.Size(23, 22)
            Me.btReabrir.Text = "Reabrir"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'btAnular
            '
            Me.btAnular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btAnular.Image = Global.baseball.My.Resources.Resources.anular
            Me.btAnular.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btAnular.Name = "btAnular"
            Me.btAnular.Size = New System.Drawing.Size(23, 22)
            Me.btAnular.Text = "Anular"
            '
            'ToolStripSeparator3
            '
            Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
            Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
            '
            'ToolStripButton1
            '
            Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
            Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.ToolStripButton1.Name = "ToolStripButton1"
            Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
            Me.ToolStripButton1.Text = "Imprimir"
            '
            'ToolStripSeparator4
            '
            Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
            Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
            '
            'btAnexar
            '
            Me.btAnexar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btAnexar.Image = Global.baseball.My.Resources.Resources.anexo
            Me.btAnexar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btAnexar.Name = "btAnexar"
            Me.btAnexar.Size = New System.Drawing.Size(23, 22)
            Me.btAnexar.Text = "Anexos"
            Me.btAnexar.Visible = False
            '
            'btLeccionAprendida
            '
            Me.btLeccionAprendida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btLeccionAprendida.Image = Global.baseball.My.Resources.Resources.leccionaprendida
            Me.btLeccionAprendida.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btLeccionAprendida.Name = "btLeccionAprendida"
            Me.btLeccionAprendida.Size = New System.Drawing.Size(23, 22)
            Me.btLeccionAprendida.Text = "Lección aprendida"
            '
            'frmEquipoQry
            '
            Me.ClientSize = New System.Drawing.Size(792, 573)
            Me.Controls.Add(Me.ToolStrip1)
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "frmEquipoQry"
            Me.Text = "Consulta de Equipos"
            Me.Controls.SetChildIndex(Me.panHead, 0)
            Me.Controls.SetChildIndex(Me.panInfo, 0)
            Me.Controls.SetChildIndex(Me.panDetail, 0)
            Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
            Me.panInfo.ResumeLayout(False)
            Me.panInfo.PerformLayout()
            CType(Me.dvConsulta, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ToolStrip1.ResumeLayout(False)
            Me.ToolStrip1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

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

                _frmFiltro.TopLevel = False
                Me.Controls.Add(_frmFiltro)
                _frmFiltro.Dock = DockStyle.Left
                _frmFiltro.SendToBack()
                '_frmFiltro.Show()
                _frmFiltro.AutoScroll = True
                AddHandler _frmFiltro.rbVerSoloLasMias.CheckedChanged, AddressOf reConsultarRegistros
                AddHandler _frmFiltro.rbVerMigente.CheckedChanged, AddressOf reConsultarRegistros
                AddHandler _frmFiltro.rbVerTodos.CheckedChanged, AddressOf reConsultarRegistros
                AddHandler _frmFiltro.lboxTipoImpacto.SelectedIndexChanged, AddressOf reConsultarRegistros
                AddHandler _frmFiltro.cambioFiltro, AddressOf filtrar

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

#Region "Filtro"
        Private Sub reConsultarRegistros(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Try
                btRefresh_record()
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub filtrar(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Try
                '
                'TODO: Repito, estoy cambiando la forma de filtrar
                'REVISAR
                Dim ctrl As New ctrl.ctrlEquipoQry
                ctrl.filtrarRegistros(Me)
                RaiseEvent RefreshDgFilter(Me, New EventArgs())
                'btRefresh_record()
                '
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

#End Region


#Region "Nivel de Acceso"

        'Private _esLider As Boolean

        'Public Property EsLider() As Boolean
        '    Get
        '        Return _esLider
        '    End Get
        '    Set(ByVal value As Boolean)
        '        _esLider = value
        '    End Set
        'End Property

        'Private Sub btImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimir.Click
        '    Try
        '        Dim ctrl As New ctrl.ctrlEquipoQry

        '        If (ctrl.getRegistroSeleccionado(Me) Is Nothing) Then
        '            repsol.util.messages.ShowWarning(_common.constantes.mensaje.NO_RECORD_SELECTED, Me.Text)
        '            Return
        '        End If

        '        repsol.util.messages.ShowWarning(_common.constantes.mensaje.OPTION_DISABLED, Me.Text)
        '    Catch ex As Exception
        '        repsol.util.messages.ShowError(ex.Message, Me.Text)
        '    End Try
        'End Sub

        Private Sub btCerrarInvestigacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCerrarInvestigacion.Click
            Try
                Dim ctrl As New ctrl.ctrlEquipoQry
                If (ctrl.getRegistroSeleccionado(Me) Is Nothing) Then
                    repsol.util.messages.ShowWarning(_common.constantes.mensaje.NO_RECORD_SELECTED, Me.Text)
                    Return
                End If
                'AQUI()
                'If (Not Me.EsLider) Then
                '    repsol.util.messages.ShowWarning(baseball.lib.bl._common.constantes.mensaje.NO_ACCESS_ALLOWED, Me.Text)
                '    Return
                'End If

                Dim fecha As DateTime = DateTime.Now
                'TODO: Dar la posibilidad de que pongan la fecha
                'Dim res As Windows.Forms.DialogResult = MessageBox.Show("¿Desea establecer la fecha de cierre de invest. manualmente? Si contesta no, se establecerá la fecha de hoy automáticamente.", Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                'If (Windows.Forms.DialogResult.Yes = res) Then
                '    Dim vVen As New _fecha.frmFecha
                '    vVen.ShowDialog(Me)
                '    fecha = vVen.dateFechaOcurrencia.Value
                'Else
                '    If (res = Windows.Forms.DialogResult.Cancel) Then
                '        repsol.util.messages.ShowWarning(_common.constantes.mensaje.OPERATION_CANCELED, Me.Text)
                '        Return
                '    End If
                'End If
                'Me.txtFechaCierreInvest.Text = fecha.ToString(baseball.lib.common.constantes.formato.FECHAHORA)
                '

                'Dim ctrl As New ctrl.ctrlEquipoQry
                ctrl.cambiarEstadoEquipo(Me, equipo.ctrl.ctrlEquipoQry.ESTADOINCIDENTE.CERRARINVEST, fecha)
                btRefresh_record()

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub btCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCerrar.Click
            Try
                Dim ctrl As New ctrl.ctrlEquipoQry
                If (ctrl.getRegistroSeleccionado(Me) Is Nothing) Then
                    repsol.util.messages.ShowWarning(_common.constantes.mensaje.NO_RECORD_SELECTED, Me.Text)
                    Return
                End If

                'If (Not Me.EsLider) Then
                '    repsol.util.messages.ShowWarning(baseball.lib.bl._common.constantes.mensaje.NO_ACCESS_ALLOWED, Me.Text)
                '    Return
                'End If

                ''<Esto tiene que ir fuera!!...pero...hay prisa>
                ''Dim ctrl As New ctrl.ctrlEquipoQry
                'If (Not ctrl.hasEvaluation(Me)) Then
                '    If (Windows.Forms.DialogResult.No = MessageBox.Show("El equipo no tiene evaluación económica. ¿Desea continuar con el proceso de cierre?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) Then
                '        Return
                '    End If
                'End If

                Dim fecha As DateTime = DateTime.Now
                'TODO: Dar la posibilidad de que pongan la fecha
                'Dim res As Windows.Forms.DialogResult = MessageBox.Show("¿Desea establecer la fecha de cierre manualmente? Si contesta no, se establecerá la fecha de hoy automáticamente.", Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                'If (Windows.Forms.DialogResult.Yes = res) Then
                '    Dim vVen As New _fecha.frmFecha
                '    vVen.ShowDialog(Me)
                '    fecha = vVen.dateFechaOcurrencia.Value
                'Else
                '    If (res = Windows.Forms.DialogResult.Cancel) Then
                '        repsol.util.messages.ShowWarning(_common.constantes.mensaje.OPERATION_CANCELED, Me.Text)
                '        Return
                '    End If
                'End If
                ''Me.txtFechaCierre.Text = fecha.ToString(baseball.lib.common.constantes.formato.FECHAHORA)

                ctrl.cambiarEstadoEquipo(Me, equipo.ctrl.ctrlEquipoQry.ESTADOINCIDENTE.CERRAR, fecha)
                btRefresh_record()
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub btReabrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btReabrir.Click
            Try
                Dim ctrl As New ctrl.ctrlEquipoQry
                If (ctrl.getRegistroSeleccionado(Me) Is Nothing) Then
                    repsol.util.messages.ShowWarning(_common.constantes.mensaje.NO_RECORD_SELECTED, Me.Text)
                    Return
                End If

                If (Not baseball.lib.bl._common.cache.USUARIO.Perfil.Admin) Then
                    repsol.util.messages.ShowWarning(baseball.lib.bl._common.constantes.mensaje.NO_ACCESS_ALLOWED, Me.Text)
                    Return
                End If

                'Dim ctrl As New ctrl.ctrlEquipoQry
                If (Not ctrl.canReopen(Me)) Then
                    repsol.util.messages.ShowWarning("No se puede realizar esta acción. El equipo no está cerrado ni anulado.", Me.Text)
                    Return
                End If

                Dim vVen As New reapertura.frmReaperturaEdit
                vVen.ShowDialog(Me)
                If (Windows.Forms.DialogResult.OK = vVen.DialogResult) Then
                    ctrl.reabrirEquipo(Me, vVen.InnerVO)
                    btRefresh_record()
                Else
                    repsol.util.messages.ShowWarning(_common.constantes.mensaje.OPERATION_CANCELED, Me.Text)
                End If

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub btAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAnular.Click
            Try
                Dim ctrl As New ctrl.ctrlEquipoQry
                If (ctrl.getRegistroSeleccionado(Me) Is Nothing) Then
                    repsol.util.messages.ShowWarning(_common.constantes.mensaje.NO_RECORD_SELECTED, Me.Text)
                    Return
                End If

                'If (Not baseball.lib.bl._common.cache.USUARIO.Perfil.Admin) AndAlso (Not Me.EsLider) Then
                '    repsol.util.messages.ShowWarning(baseball.lib.bl._common.constantes.mensaje.NO_ACCESS_ALLOWED, Me.Text)
                '    Return
                'End If

                Dim fecha As DateTime = DateTime.Now
                'TODO: Dar la posibilidad de que pongan la fecha
                'Dim res As Windows.Forms.DialogResult = MessageBox.Show("¿Desea establecer la fecha de anulación manualmente? Si contesta no, se establecerá la fecha de hoy automáticamente.", Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                'If (Windows.Forms.DialogResult.Yes = res) Then
                '    Dim vVen As New _fecha.frmFecha
                '    vVen.ShowDialog(Me)
                '    fecha = vVen.dateFechaOcurrencia.Value
                'Else
                '    If (res = Windows.Forms.DialogResult.Cancel) Then
                '        repsol.util.messages.ShowWarning(_common.constantes.mensaje.OPERATION_CANCELED, Me.Text)
                '        Return
                '    End If
                'End If
                ''Me.txtFechaAnulacion.Text = fecha.ToString(baseball.lib.common.constantes.formato.FECHAHORA)

                'Dim ctrl As New ctrl.ctrlEquipoQry
                ctrl.cambiarEstadoEquipo(Me, equipo.ctrl.ctrlEquipoQry.ESTADOINCIDENTE.ANULAR, fecha)
                btRefresh_record()
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub btAnexar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAnexar.Click
            Try
                Dim ctrl As New ctrl.ctrlEquipoQry
                If (ctrl.getRegistroSeleccionado(Me) Is Nothing) Then
                    repsol.util.messages.ShowWarning(_common.constantes.mensaje.NO_RECORD_SELECTED, Me.Text)
                    Return
                End If

                repsol.util.messages.ShowWarning(_common.constantes.mensaje.OPTION_DISABLED, Me.Text)
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub btLeccionAprendida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLeccionAprendida.Click
            Try
                Dim ctrl As New ctrl.ctrlEquipoQry
                If (ctrl.getRegistroSeleccionado(Me) Is Nothing) Then
                    repsol.util.messages.ShowWarning(_common.constantes.mensaje.NO_RECORD_SELECTED, Me.Text)
                    Return
                End If

                ctrl.showLeccionAprendida(Me)
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

#End Region


#Region "AppSetting"

        Protected Overrides Function getUserPreferences() As repsol.util.setting.userpreferences
            Dim res As New _settings.EquipoQrySetting(MyBase.getUserPreferences())

            Dim ctrlFiltro As New equipo.ctrl.ctrlEquipoFilter
            res.EquipoChunk = ctrlFiltro.GetFiltro(Me._frmFiltro)

            Return res
        End Function

        Protected Overrides Sub setUserPreferences(ByVal setting As repsol.util.setting.userpreferences)
            MyBase.setUserPreferences(setting)

            Dim res As _settings.EquipoQrySetting = setting
            Dim ctrlFiltro As New equipo.ctrl.ctrlEquipoFilter
            ctrlFiltro.SetFiltro(Me._frmFiltro, res.EquipoChunk)

        End Sub

#End Region

    End Class
End Namespace

