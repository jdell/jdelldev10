Namespace frm.equipo
    Public Class frmEquipoEdit
        Inherits baseball.app.pc._template.edicion.editform

        Public WithEvents _frmCausaQry As causa.frmCausaQry
        Public WithEvents _frmAccionQry As accion.frmAccionQry
        Public WithEvents _frmEvaluacionQry As evaluacion.frmEvaluacionQry
        Public WithEvents _frmIntegranteQry As integrante.frmIntegranteQry
        Public WithEvents _frmMedidaAdoptadaQry As medidaadoptada.frmMedidaAdoptadaQry
        Public WithEvents _frmFicheroQry As fichero.frmFicheroQry

        Friend WithEvents gboxEvaluaciones As System.Windows.Forms.Panel
        Public WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btCerrarInvestigacion As System.Windows.Forms.ToolStripButton
        Friend WithEvents cmbEquipo As baseball.app.pc._template._controles.OutlookTextBox.OutlookTextBox
        Friend WithEvents btExaminar As System.Windows.Forms.Button
        Friend WithEvents tTip As System.Windows.Forms.ToolTip
        Private components As System.ComponentModel.IContainer
        Friend WithEvents btImprimirDetalle As System.Windows.Forms.Button
        Public WithEvents txtTotalEvaluacion As repsol.forms.controls.TextBoxColor


        Public Sub New()
            InitializeComponent()

            _frmCausaQry = New causa.frmCausaQry()
            _frmAccionQry = New accion.frmAccionQry
            _frmEvaluacionQry = New evaluacion.frmEvaluacionQry
            _frmFicheroQry = New fichero.frmFicheroQry
            _frmIntegranteQry = New integrante.frmIntegranteQry
            _frmMedidaAdoptadaQry = New medidaadoptada.frmMedidaAdoptadaQry

            Dim ctrl As New ctrl.ctrlEquipoEdit
            ctrl.inicializarForm(Me)
            ctrl.cargarDatos(Me, ctrl.getNuevoRegistro())
            ctrl.setOriginalVO(Me, Me.OnlineVO)
            Me.EsLider = True 'ctrl.canModify(Me)
        End Sub
        Public Sub New(ByVal obj As baseball.lib.vo.Equipo)
            InitializeComponent()

            newRecord = False

            _frmCausaQry = New causa.frmCausaQry
            _frmAccionQry = New accion.frmAccionQry
            _frmEvaluacionQry = New evaluacion.frmEvaluacionQry
            _frmFicheroQry = New fichero.frmFicheroQry
            _frmIntegranteQry = New integrante.frmIntegranteQry
            _frmMedidaAdoptadaQry = New medidaadoptada.frmMedidaAdoptadaQry

            Dim ctrl As New ctrl.ctrlEquipoEdit
            ctrl.inicializarForm(Me)
            ctrl.cargarDatos(Me, obj)
            ctrl.setOriginalVO(Me, Me.OnlineVO)
            Me.EsLider = True 'ctrl.canModify(Me)
        End Sub

        Public Sub New(ByVal obj As baseball.lib.vo.Equipo, ByVal soloconsulta As Boolean)
            MyBase.New(soloconsulta)

            InitializeComponent()

            newRecord = False

            Dim ctrl As New ctrl.ctrlEquipoEdit
            Me.OnlineVO = obj
            Me.EsLider = ctrl.canModify(Me)

            If (Not soloconsulta) Then
                Dim modoSoloConsulta As Boolean
                modoSoloConsulta = Not ((Me.EsLider) OrElse (baseballbl._common.cache.USUARIO.Perfil.Admin))

                _frmCausaQry = New causa.frmCausaQry(modoSoloConsulta)
                _frmAccionQry = New accion.frmAccionQry(modoSoloConsulta)
                '_frmEvaluacionQry = New evaluacion.frmEvaluacionQry(modoSoloConsulta, String.Empty)
                _frmEvaluacionQry = New evaluacion.frmEvaluacionQry(soloconsulta)
                _frmFicheroQry = New fichero.frmFicheroQry(modoSoloConsulta)
                _frmIntegranteQry = New integrante.frmIntegranteQry(modoSoloConsulta)
                _frmMedidaAdoptadaQry = New medidaadoptada.frmMedidaAdoptadaQry(modoSoloConsulta, String.Empty)

                Me.chkImpacto.Enabled = modoSoloConsulta

                Me.btCerrarInvestigacion.Enabled = Not modoSoloConsulta
                Me.btCerrar.Enabled = Not modoSoloConsulta
                Me.btReabrir.Enabled = Not modoSoloConsulta
                Me.btLeccionAprendida.Enabled = Not modoSoloConsulta
                Me.btAnular.Enabled = Not modoSoloConsulta

                '*****
                Me.cmbClaseEquipo.Enabled = Not modoSoloConsulta
                Me.cmbEquipo.Enabled = Not modoSoloConsulta
                Me.cmbTipoEquipo.Enabled = Not modoSoloConsulta
                Me.cmbTipoLesion.Enabled = Not modoSoloConsulta
                Me.cmbUnidad.Enabled = Not modoSoloConsulta

                Me.dateFechaOcurrencia.Enabled = Not modoSoloConsulta
                Me.txtConsecuencias.Enabled = Not modoSoloConsulta
                Me.txtDescrDetalle.Enabled = Not modoSoloConsulta
                Me.txtDescrResumen.Enabled = Not modoSoloConsulta

                Me.chkImpacto.Enabled = Not modoSoloConsulta
                Me.btExaminar.Enabled = Not modoSoloConsulta
                '*****

            Else
                _frmCausaQry = New causa.frmCausaQry(soloconsulta)
                _frmAccionQry = New accion.frmAccionQry(soloconsulta)
                _frmEvaluacionQry = New evaluacion.frmEvaluacionQry(soloconsulta)
                _frmFicheroQry = New fichero.frmFicheroQry(soloconsulta)
                _frmIntegranteQry = New integrante.frmIntegranteQry(soloconsulta)
                _frmMedidaAdoptadaQry = New medidaadoptada.frmMedidaAdoptadaQry(soloconsulta)

                'Me.txtDescripcion.Enabled = Not Me.onlyView
                'Me.txtCodigo.Enabled = False
                'Me.cmbResponsable.Enabled = Not Me.onlyView
                'Me.chkActivo.Enabled = Not Me.onlyView
                Me.chkImpacto.Enabled = Not Me.OnlyView
                Me.cmbEquipo.Enabled = Not Me.OnlyView
                Me.btExaminar.Enabled = Not Me.OnlyView

                Me.btCerrarInvestigacion.Enabled = Not Me.OnlyView
                Me.btCerrar.Enabled = Not Me.OnlyView
                Me.btReabrir.Enabled = Not Me.OnlyView
                Me.btLeccionAprendida.Enabled = Not Me.OnlyView
                Me.btAnular.Enabled = Not Me.OnlyView
            End If

            ctrl.inicializarForm(Me)
            ctrl.cargarDatos(Me, obj)
            ctrl.setOriginalVO(Me, Me.OnlineVO)
            'If (Not Me.EsLider) Then
            '    MsgBox("No es el líder de la comisión, sólo ")
            'End If
        End Sub

        Protected Overrides Sub btAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim ctrl As New ctrl.ctrlEquipoEdit
                If (ctrl.canAccept(Me)) Then
                    ctrl.guardarDatos(Me, newRecord)
                    MsgBox("Operación completada", MsgBoxStyle.Information)
                    MyBase.btAceptar_Click(sender, e)
                End If
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End Sub


        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEquipoEdit))
            Me.Label11 = New System.Windows.Forms.Label
            Me.Label3 = New System.Windows.Forms.Label
            Me.txtUsuario = New repsol.forms.controls.TextBoxColor
            Me.txtFecha = New repsol.forms.controls.TextBoxColor
            Me.txtCodigo = New repsol.forms.controls.TextBoxColor
            Me.TabControl1 = New System.Windows.Forms.TabControl
            Me.TabPage4 = New System.Windows.Forms.TabPage
            Me.txtDescrDetalle = New repsol.forms.controls.TextBoxColor
            Me.tpageCausas = New System.Windows.Forms.TabPage
            Me.TabPage6 = New System.Windows.Forms.TabPage
            Me.Label1 = New System.Windows.Forms.Label
            Me.txtTotalEvaluacion = New repsol.forms.controls.TextBoxColor
            Me.gboxEvaluaciones = New System.Windows.Forms.Panel
            Me.TabPage7 = New System.Windows.Forms.TabPage
            Me.txtConsecuencias = New repsol.forms.controls.TextBoxColor
            Me.tpageAcciones = New System.Windows.Forms.TabPage
            Me.tpageIntegrantes = New System.Windows.Forms.TabPage
            Me.tpageMedidasAdoptadas = New System.Windows.Forms.TabPage
            Me.tpageFicheros = New System.Windows.Forms.TabPage
            Me.GroupBox2 = New System.Windows.Forms.GroupBox
            Me.btExaminar = New System.Windows.Forms.Button
            Me.cmbEquipo = New baseball.app.pc._template._controles.OutlookTextBox.OutlookTextBox
            Me.txtFechaAnulacion = New repsol.forms.controls.TextBoxColor
            Me.txtFechaCierre = New repsol.forms.controls.TextBoxColor
            Me.txtFechaCierreInvest = New repsol.forms.controls.TextBoxColor
            Me.chkImpacto = New System.Windows.Forms.CheckedListBox
            Me.txtDescrResumen = New repsol.forms.controls.TextBoxColor
            Me.Label10 = New System.Windows.Forms.Label
            Me.Label9 = New System.Windows.Forms.Label
            Me.cmbTipoLesion = New System.Windows.Forms.ComboBox
            Me.cmbClaseEquipo = New System.Windows.Forms.ComboBox
            Me.cmbTipoEquipo = New System.Windows.Forms.ComboBox
            Me.Label6 = New System.Windows.Forms.Label
            Me.dateFechaOcurrencia = New System.Windows.Forms.DateTimePicker
            Me.Label4 = New System.Windows.Forms.Label
            Me.cmbUnidad = New System.Windows.Forms.ComboBox
            Me.Label8 = New System.Windows.Forms.Label
            Me.Label18 = New System.Windows.Forms.Label
            Me.Label17 = New System.Windows.Forms.Label
            Me.Label16 = New System.Windows.Forms.Label
            Me.Label5 = New System.Windows.Forms.Label
            Me.Label7 = New System.Windows.Forms.Label
            Me.Label14 = New System.Windows.Forms.Label
            Me.txtSituacion = New repsol.forms.controls.TextBoxColor
            Me.tbar = New System.Windows.Forms.ToolStrip
            Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
            Me.btCerrarInvestigacion = New System.Windows.Forms.ToolStripButton
            Me.btCerrar = New System.Windows.Forms.ToolStripButton
            Me.btReabrir = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
            Me.btAnular = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me.btImprimir = New System.Windows.Forms.ToolStripButton
            Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
            Me.btAnexar = New System.Windows.Forms.ToolStripButton
            Me.btLeccionAprendida = New System.Windows.Forms.ToolStripButton
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.Label12 = New System.Windows.Forms.Label
            Me.tTip = New System.Windows.Forms.ToolTip(Me.components)
            Me.btImprimirDetalle = New System.Windows.Forms.Button
            CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panFooter.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabPage4.SuspendLayout()
            Me.TabPage6.SuspendLayout()
            Me.TabPage7.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.tbar.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'btAceptar
            '
            Me.btAceptar.BackColor = System.Drawing.Color.PaleGreen
            Me.btAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btAceptar.Location = New System.Drawing.Point(634, 12)
            '
            'btCancelar
            '
            Me.btCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.btCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btCancelar.Location = New System.Drawing.Point(715, 12)
            '
            'chkCerrar
            '
            Me.chkCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkCerrar.Location = New System.Drawing.Point(8, 16)
            '
            'panFooter
            '
            Me.panFooter.Controls.Add(Me.btImprimirDetalle)
            Me.panFooter.Location = New System.Drawing.Point(0, 547)
            Me.panFooter.Size = New System.Drawing.Size(800, 43)
            Me.panFooter.Controls.SetChildIndex(Me.btCancelar, 0)
            Me.panFooter.Controls.SetChildIndex(Me.chkCerrar, 0)
            Me.panFooter.Controls.SetChildIndex(Me.btAceptar, 0)
            Me.panFooter.Controls.SetChildIndex(Me.btImprimirDetalle, 0)
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaption
            Me.Label11.Location = New System.Drawing.Point(8, 22)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(52, 15)
            Me.Label11.TabIndex = 6
            Me.Label11.Text = "Código"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
            Me.Label3.Location = New System.Drawing.Point(400, 22)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(57, 15)
            Me.Label3.TabIndex = 5
            Me.Label3.Text = "Usuario"
            '
            'txtUsuario
            '
            Me.txtUsuario.ActivateStyle = False
            Me.txtUsuario.BackColor = System.Drawing.Color.Honeydew
            Me.txtUsuario.ColorEnter = System.Drawing.Color.LightYellow
            Me.txtUsuario.ColorLeave = System.Drawing.Color.White
            Me.txtUsuario.Location = New System.Drawing.Point(456, 20)
            Me.txtUsuario.Name = "txtUsuario"
            Me.txtUsuario.ReadOnly = True
            Me.txtUsuario.Size = New System.Drawing.Size(110, 21)
            Me.txtUsuario.TabIndex = 4
            Me.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'txtFecha
            '
            Me.txtFecha.ActivateStyle = False
            Me.txtFecha.BackColor = System.Drawing.Color.Honeydew
            Me.txtFecha.ColorEnter = System.Drawing.Color.LightYellow
            Me.txtFecha.ColorLeave = System.Drawing.Color.White
            Me.txtFecha.Location = New System.Drawing.Point(256, 20)
            Me.txtFecha.Name = "txtFecha"
            Me.txtFecha.ReadOnly = True
            Me.txtFecha.Size = New System.Drawing.Size(138, 21)
            Me.txtFecha.TabIndex = 2
            Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'txtCodigo
            '
            Me.txtCodigo.ActivateStyle = False
            Me.txtCodigo.BackColor = System.Drawing.Color.Honeydew
            Me.txtCodigo.ColorEnter = System.Drawing.Color.LightYellow
            Me.txtCodigo.ColorLeave = System.Drawing.Color.White
            Me.txtCodigo.Location = New System.Drawing.Point(60, 20)
            Me.txtCodigo.Name = "txtCodigo"
            Me.txtCodigo.ReadOnly = True
            Me.txtCodigo.Size = New System.Drawing.Size(110, 21)
            Me.txtCodigo.TabIndex = 0
            Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.TabPage4)
            Me.TabControl1.Controls.Add(Me.tpageCausas)
            Me.TabControl1.Controls.Add(Me.TabPage6)
            Me.TabControl1.Controls.Add(Me.TabPage7)
            Me.TabControl1.Controls.Add(Me.tpageAcciones)
            Me.TabControl1.Controls.Add(Me.tpageIntegrantes)
            Me.TabControl1.Controls.Add(Me.tpageMedidasAdoptadas)
            Me.TabControl1.Controls.Add(Me.tpageFicheros)
            Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TabControl1.Location = New System.Drawing.Point(8, 298)
            Me.TabControl1.Multiline = True
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(786, 244)
            Me.TabControl1.TabIndex = 14
            '
            'TabPage4
            '
            Me.TabPage4.Controls.Add(Me.txtDescrDetalle)
            Me.TabPage4.Location = New System.Drawing.Point(4, 44)
            Me.TabPage4.Name = "TabPage4"
            Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage4.Size = New System.Drawing.Size(778, 196)
            Me.TabPage4.TabIndex = 3
            Me.TabPage4.Text = "Descripción detallada"
            Me.TabPage4.UseVisualStyleBackColor = True
            '
            'txtDescrDetalle
            '
            Me.txtDescrDetalle.ActivateStyle = True
            Me.txtDescrDetalle.BackColor = System.Drawing.Color.White
            Me.txtDescrDetalle.ColorEnter = System.Drawing.Color.LightYellow
            Me.txtDescrDetalle.ColorLeave = System.Drawing.Color.White
            Me.txtDescrDetalle.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtDescrDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDescrDetalle.Location = New System.Drawing.Point(3, 3)
            Me.txtDescrDetalle.MaxLength = 2000
            Me.txtDescrDetalle.Multiline = True
            Me.txtDescrDetalle.Name = "txtDescrDetalle"
            Me.txtDescrDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.txtDescrDetalle.Size = New System.Drawing.Size(772, 190)
            Me.txtDescrDetalle.TabIndex = 5
            '
            'tpageCausas
            '
            Me.tpageCausas.Location = New System.Drawing.Point(4, 44)
            Me.tpageCausas.Name = "tpageCausas"
            Me.tpageCausas.Padding = New System.Windows.Forms.Padding(3)
            Me.tpageCausas.Size = New System.Drawing.Size(778, 196)
            Me.tpageCausas.TabIndex = 0
            Me.tpageCausas.Text = "Causas"
            Me.tpageCausas.UseVisualStyleBackColor = True
            '
            'TabPage6
            '
            Me.TabPage6.Controls.Add(Me.Label1)
            Me.TabPage6.Controls.Add(Me.txtTotalEvaluacion)
            Me.TabPage6.Controls.Add(Me.gboxEvaluaciones)
            Me.TabPage6.Location = New System.Drawing.Point(4, 44)
            Me.TabPage6.Name = "TabPage6"
            Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage6.Size = New System.Drawing.Size(778, 196)
            Me.TabPage6.TabIndex = 5
            Me.TabPage6.Text = "Evaluación de daños"
            Me.TabPage6.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(616, 172)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(39, 15)
            Me.Label1.TabIndex = 16
            Me.Label1.Text = "Total"
            '
            'txtTotalEvaluacion
            '
            Me.txtTotalEvaluacion.ActivateStyle = False
            Me.txtTotalEvaluacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtTotalEvaluacion.BackColor = System.Drawing.Color.Honeydew
            Me.txtTotalEvaluacion.ColorEnter = System.Drawing.Color.LightYellow
            Me.txtTotalEvaluacion.ColorLeave = System.Drawing.Color.White
            Me.txtTotalEvaluacion.Location = New System.Drawing.Point(663, 169)
            Me.txtTotalEvaluacion.Name = "txtTotalEvaluacion"
            Me.txtTotalEvaluacion.ReadOnly = True
            Me.txtTotalEvaluacion.Size = New System.Drawing.Size(109, 21)
            Me.txtTotalEvaluacion.TabIndex = 15
            Me.txtTotalEvaluacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'gboxEvaluaciones
            '
            Me.gboxEvaluaciones.Dock = System.Windows.Forms.DockStyle.Top
            Me.gboxEvaluaciones.Location = New System.Drawing.Point(3, 3)
            Me.gboxEvaluaciones.Name = "gboxEvaluaciones"
            Me.gboxEvaluaciones.Size = New System.Drawing.Size(772, 160)
            Me.gboxEvaluaciones.TabIndex = 0
            '
            'TabPage7
            '
            Me.TabPage7.Controls.Add(Me.txtConsecuencias)
            Me.TabPage7.Location = New System.Drawing.Point(4, 44)
            Me.TabPage7.Name = "TabPage7"
            Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage7.Size = New System.Drawing.Size(778, 196)
            Me.TabPage7.TabIndex = 6
            Me.TabPage7.Text = "Consecuencias"
            Me.TabPage7.UseVisualStyleBackColor = True
            '
            'txtConsecuencias
            '
            Me.txtConsecuencias.ActivateStyle = True
            Me.txtConsecuencias.BackColor = System.Drawing.Color.LightYellow
            Me.txtConsecuencias.ColorEnter = System.Drawing.Color.LightYellow
            Me.txtConsecuencias.ColorLeave = System.Drawing.Color.White
            Me.txtConsecuencias.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtConsecuencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtConsecuencias.Location = New System.Drawing.Point(3, 3)
            Me.txtConsecuencias.MaxLength = 2000
            Me.txtConsecuencias.Multiline = True
            Me.txtConsecuencias.Name = "txtConsecuencias"
            Me.txtConsecuencias.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.txtConsecuencias.Size = New System.Drawing.Size(772, 190)
            Me.txtConsecuencias.TabIndex = 6
            '
            'tpageAcciones
            '
            Me.tpageAcciones.Location = New System.Drawing.Point(4, 44)
            Me.tpageAcciones.Name = "tpageAcciones"
            Me.tpageAcciones.Padding = New System.Windows.Forms.Padding(3)
            Me.tpageAcciones.Size = New System.Drawing.Size(778, 196)
            Me.tpageAcciones.TabIndex = 1
            Me.tpageAcciones.Text = "Acciones"
            Me.tpageAcciones.UseVisualStyleBackColor = True
            '
            'tpageIntegrantes
            '
            Me.tpageIntegrantes.Location = New System.Drawing.Point(4, 44)
            Me.tpageIntegrantes.Name = "tpageIntegrantes"
            Me.tpageIntegrantes.Padding = New System.Windows.Forms.Padding(3)
            Me.tpageIntegrantes.Size = New System.Drawing.Size(778, 196)
            Me.tpageIntegrantes.TabIndex = 4
            Me.tpageIntegrantes.Text = "Comisión"
            Me.tpageIntegrantes.UseVisualStyleBackColor = True
            '
            'tpageMedidasAdoptadas
            '
            Me.tpageMedidasAdoptadas.Location = New System.Drawing.Point(4, 44)
            Me.tpageMedidasAdoptadas.Name = "tpageMedidasAdoptadas"
            Me.tpageMedidasAdoptadas.Padding = New System.Windows.Forms.Padding(3)
            Me.tpageMedidasAdoptadas.Size = New System.Drawing.Size(778, 196)
            Me.tpageMedidasAdoptadas.TabIndex = 2
            Me.tpageMedidasAdoptadas.Text = "Medidas adoptadas"
            Me.tpageMedidasAdoptadas.UseVisualStyleBackColor = True
            '
            'tpageFicheros
            '
            Me.tpageFicheros.Location = New System.Drawing.Point(4, 44)
            Me.tpageFicheros.Name = "tpageFicheros"
            Me.tpageFicheros.Padding = New System.Windows.Forms.Padding(3)
            Me.tpageFicheros.Size = New System.Drawing.Size(778, 196)
            Me.tpageFicheros.TabIndex = 7
            Me.tpageFicheros.Text = "Anexos"
            Me.tpageFicheros.UseVisualStyleBackColor = True
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.btExaminar)
            Me.GroupBox2.Controls.Add(Me.cmbEquipo)
            Me.GroupBox2.Controls.Add(Me.txtFechaAnulacion)
            Me.GroupBox2.Controls.Add(Me.txtFechaCierre)
            Me.GroupBox2.Controls.Add(Me.txtFechaCierreInvest)
            Me.GroupBox2.Controls.Add(Me.chkImpacto)
            Me.GroupBox2.Controls.Add(Me.txtDescrResumen)
            Me.GroupBox2.Controls.Add(Me.Label10)
            Me.GroupBox2.Controls.Add(Me.Label9)
            Me.GroupBox2.Controls.Add(Me.cmbTipoLesion)
            Me.GroupBox2.Controls.Add(Me.cmbClaseEquipo)
            Me.GroupBox2.Controls.Add(Me.cmbTipoEquipo)
            Me.GroupBox2.Controls.Add(Me.Label6)
            Me.GroupBox2.Controls.Add(Me.dateFechaOcurrencia)
            Me.GroupBox2.Controls.Add(Me.Label4)
            Me.GroupBox2.Controls.Add(Me.cmbUnidad)
            Me.GroupBox2.Controls.Add(Me.Label8)
            Me.GroupBox2.Controls.Add(Me.Label18)
            Me.GroupBox2.Controls.Add(Me.Label17)
            Me.GroupBox2.Controls.Add(Me.Label16)
            Me.GroupBox2.Controls.Add(Me.Label5)
            Me.GroupBox2.Controls.Add(Me.Label7)
            Me.GroupBox2.Location = New System.Drawing.Point(8, 56)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(786, 239)
            Me.GroupBox2.TabIndex = 13
            Me.GroupBox2.TabStop = False
            '
            'btExaminar
            '
            Me.btExaminar.BackColor = System.Drawing.Color.White
            Me.btExaminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.btExaminar.FlatAppearance.BorderSize = 0
            Me.btExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btExaminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btExaminar.Image = CType(resources.GetObject("btExaminar.Image"), System.Drawing.Image)
            Me.btExaminar.Location = New System.Drawing.Point(485, 40)
            Me.btExaminar.Name = "btExaminar"
            Me.btExaminar.Size = New System.Drawing.Size(17, 17)
            Me.btExaminar.TabIndex = 42
            Me.tTip.SetToolTip(Me.btExaminar, "Importación de equipos")
            Me.btExaminar.UseVisualStyleBackColor = False
            '
            'cmbEquipo
            '
            Me.cmbEquipo.ActivateStyle = True
            Me.cmbEquipo.BackColor = System.Drawing.Color.White
            Me.cmbEquipo.ColorEnter = System.Drawing.Color.LightYellow
            Me.cmbEquipo.ColorLeave = System.Drawing.Color.White
            Me.cmbEquipo.KDB = New Object(-1) {}
            Me.cmbEquipo.Location = New System.Drawing.Point(116, 39)
            Me.cmbEquipo.Name = "cmbEquipo"
            Me.cmbEquipo.Size = New System.Drawing.Size(386, 21)
            Me.cmbEquipo.TabIndex = 41
            Me.cmbEquipo.VisibleCount = 6
            '
            'txtFechaAnulacion
            '
            Me.txtFechaAnulacion.ActivateStyle = False
            Me.txtFechaAnulacion.BackColor = System.Drawing.Color.Honeydew
            Me.txtFechaAnulacion.ColorEnter = System.Drawing.Color.LightYellow
            Me.txtFechaAnulacion.ColorLeave = System.Drawing.Color.White
            Me.txtFechaAnulacion.Location = New System.Drawing.Point(654, 96)
            Me.txtFechaAnulacion.Name = "txtFechaAnulacion"
            Me.txtFechaAnulacion.ReadOnly = True
            Me.txtFechaAnulacion.Size = New System.Drawing.Size(124, 21)
            Me.txtFechaAnulacion.TabIndex = 40
            Me.txtFechaAnulacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'txtFechaCierre
            '
            Me.txtFechaCierre.ActivateStyle = False
            Me.txtFechaCierre.BackColor = System.Drawing.Color.Honeydew
            Me.txtFechaCierre.ColorEnter = System.Drawing.Color.LightYellow
            Me.txtFechaCierre.ColorLeave = System.Drawing.Color.White
            Me.txtFechaCierre.Location = New System.Drawing.Point(654, 69)
            Me.txtFechaCierre.Name = "txtFechaCierre"
            Me.txtFechaCierre.ReadOnly = True
            Me.txtFechaCierre.Size = New System.Drawing.Size(124, 21)
            Me.txtFechaCierre.TabIndex = 39
            Me.txtFechaCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'txtFechaCierreInvest
            '
            Me.txtFechaCierreInvest.ActivateStyle = False
            Me.txtFechaCierreInvest.BackColor = System.Drawing.Color.Honeydew
            Me.txtFechaCierreInvest.ColorEnter = System.Drawing.Color.LightYellow
            Me.txtFechaCierreInvest.ColorLeave = System.Drawing.Color.White
            Me.txtFechaCierreInvest.Location = New System.Drawing.Point(654, 40)
            Me.txtFechaCierreInvest.Name = "txtFechaCierreInvest"
            Me.txtFechaCierreInvest.ReadOnly = True
            Me.txtFechaCierreInvest.Size = New System.Drawing.Size(124, 21)
            Me.txtFechaCierreInvest.TabIndex = 38
            Me.txtFechaCierreInvest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'chkImpacto
            '
            Me.chkImpacto.BackColor = System.Drawing.SystemColors.Control
            Me.chkImpacto.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.chkImpacto.CheckOnClick = True
            Me.chkImpacto.FormattingEnabled = True
            Me.chkImpacto.Location = New System.Drawing.Point(545, 152)
            Me.chkImpacto.Name = "chkImpacto"
            Me.chkImpacto.Size = New System.Drawing.Size(233, 80)
            Me.chkImpacto.TabIndex = 31
            '
            'txtDescrResumen
            '
            Me.txtDescrResumen.ActivateStyle = True
            Me.txtDescrResumen.BackColor = System.Drawing.Color.White
            Me.txtDescrResumen.ColorEnter = System.Drawing.Color.LightYellow
            Me.txtDescrResumen.ColorLeave = System.Drawing.Color.White
            Me.txtDescrResumen.Location = New System.Drawing.Point(116, 153)
            Me.txtDescrResumen.MaxLength = 500
            Me.txtDescrResumen.Multiline = True
            Me.txtDescrResumen.Name = "txtDescrResumen"
            Me.txtDescrResumen.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.txtDescrResumen.Size = New System.Drawing.Size(386, 79)
            Me.txtDescrResumen.TabIndex = 13
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(6, 156)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(61, 15)
            Me.Label10.TabIndex = 14
            Me.Label10.Text = "Resumen"
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(4, 127)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(67, 15)
            Me.Label9.TabIndex = 12
            Me.Label9.Text = "Tipo lesión"
            '
            'cmbTipoLesion
            '
            Me.cmbTipoLesion.BackColor = System.Drawing.SystemColors.Window
            Me.cmbTipoLesion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbTipoLesion.FormattingEnabled = True
            Me.cmbTipoLesion.Location = New System.Drawing.Point(116, 124)
            Me.cmbTipoLesion.Name = "cmbTipoLesion"
            Me.cmbTipoLesion.Size = New System.Drawing.Size(386, 23)
            Me.cmbTipoLesion.TabIndex = 11
            '
            'cmbClaseEquipo
            '
            Me.cmbClaseEquipo.BackColor = System.Drawing.SystemColors.Window
            Me.cmbClaseEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbClaseEquipo.FormattingEnabled = True
            Me.cmbClaseEquipo.Location = New System.Drawing.Point(116, 95)
            Me.cmbClaseEquipo.Name = "cmbClaseEquipo"
            Me.cmbClaseEquipo.Size = New System.Drawing.Size(386, 23)
            Me.cmbClaseEquipo.TabIndex = 9
            '
            'cmbTipoEquipo
            '
            Me.cmbTipoEquipo.BackColor = System.Drawing.SystemColors.Window
            Me.cmbTipoEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbTipoEquipo.FormattingEnabled = True
            Me.cmbTipoEquipo.Location = New System.Drawing.Point(116, 66)
            Me.cmbTipoEquipo.Name = "cmbTipoEquipo"
            Me.cmbTipoEquipo.Size = New System.Drawing.Size(386, 23)
            Me.cmbTipoEquipo.TabIndex = 7
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(6, 42)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(46, 15)
            Me.Label6.TabIndex = 6
            Me.Label6.Text = "Equipo"
            '
            'dateFechaOcurrencia
            '
            Me.dateFechaOcurrencia.CustomFormat = "dd/MM/yyyy HH:mm"
            Me.dateFechaOcurrencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dateFechaOcurrencia.Location = New System.Drawing.Point(654, 11)
            Me.dateFechaOcurrencia.Name = "dateFechaOcurrencia"
            Me.dateFechaOcurrencia.Size = New System.Drawing.Size(125, 21)
            Me.dateFechaOcurrencia.TabIndex = 3
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(6, 14)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(47, 15)
            Me.Label4.TabIndex = 2
            Me.Label4.Text = "Unidad"
            '
            'cmbUnidad
            '
            Me.cmbUnidad.BackColor = System.Drawing.SystemColors.Window
            Me.cmbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbUnidad.FormattingEnabled = True
            Me.cmbUnidad.Location = New System.Drawing.Point(116, 10)
            Me.cmbUnidad.Name = "cmbUnidad"
            Me.cmbUnidad.Size = New System.Drawing.Size(386, 23)
            Me.cmbUnidad.TabIndex = 0
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(6, 100)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(91, 15)
            Me.Label8.TabIndex = 10
            Me.Label8.Text = "Clase equipo"
            '
            'Label18
            '
            Me.Label18.AutoSize = True
            Me.Label18.BackColor = System.Drawing.Color.Transparent
            Me.Label18.Location = New System.Drawing.Point(542, 99)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(98, 15)
            Me.Label18.TabIndex = 37
            Me.Label18.Text = "Fecha Anulación"
            '
            'Label17
            '
            Me.Label17.AutoSize = True
            Me.Label17.BackColor = System.Drawing.Color.Transparent
            Me.Label17.Location = New System.Drawing.Point(542, 41)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(114, 15)
            Me.Label17.TabIndex = 35
            Me.Label17.Text = "Fecha Cierre Invest."
            '
            'Label16
            '
            Me.Label16.AutoSize = True
            Me.Label16.BackColor = System.Drawing.Color.Transparent
            Me.Label16.Location = New System.Drawing.Point(542, 72)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(77, 15)
            Me.Label16.TabIndex = 33
            Me.Label16.Text = "Fecha Cierre"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Location = New System.Drawing.Point(542, 14)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(104, 15)
            Me.Label5.TabIndex = 4
            Me.Label5.Text = "Fecha Ocurrencia"
            '
            'Label7
            '
            Me.Label7.Location = New System.Drawing.Point(6, 64)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(121, 37)
            Me.Label7.TabIndex = 8
            Me.Label7.Text = "Tipo de Accidente / Equipo"
            '
            'Label14
            '
            Me.Label14.AutoSize = True
            Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.Location = New System.Drawing.Point(582, 23)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(67, 15)
            Me.Label14.TabIndex = 14
            Me.Label14.Text = "Situación"
            '
            'txtSituacion
            '
            Me.txtSituacion.ActivateStyle = False
            Me.txtSituacion.BackColor = System.Drawing.Color.Honeydew
            Me.txtSituacion.ColorEnter = System.Drawing.Color.LightYellow
            Me.txtSituacion.ColorLeave = System.Drawing.Color.White
            Me.txtSituacion.Location = New System.Drawing.Point(655, 20)
            Me.txtSituacion.Name = "txtSituacion"
            Me.txtSituacion.ReadOnly = True
            Me.txtSituacion.Size = New System.Drawing.Size(124, 21)
            Me.txtSituacion.TabIndex = 13
            Me.txtSituacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'tbar
            '
            Me.tbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.tbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.btCerrarInvestigacion, Me.btCerrar, Me.btReabrir, Me.ToolStripSeparator1, Me.btAnular, Me.ToolStripSeparator2, Me.btImprimir, Me.ToolStripSeparator3, Me.btAnexar, Me.btLeccionAprendida})
            Me.tbar.Location = New System.Drawing.Point(0, 0)
            Me.tbar.Name = "tbar"
            Me.tbar.Size = New System.Drawing.Size(800, 25)
            Me.tbar.TabIndex = 15
            Me.tbar.Text = "ToolStrip1"
            Me.tbar.Visible = False
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
            'ToolStripSeparator2
            '
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
            '
            'btImprimir
            '
            Me.btImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btImprimir.Image = CType(resources.GetObject("btImprimir.Image"), System.Drawing.Image)
            Me.btImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btImprimir.Name = "btImprimir"
            Me.btImprimir.Size = New System.Drawing.Size(23, 22)
            Me.btImprimir.Text = "Imprimir"
            '
            'ToolStripSeparator3
            '
            Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
            Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
            'GroupBox1
            '
            Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
            Me.GroupBox1.Controls.Add(Me.txtUsuario)
            Me.GroupBox1.Controls.Add(Me.Label12)
            Me.GroupBox1.Controls.Add(Me.txtFecha)
            Me.GroupBox1.Controls.Add(Me.Label11)
            Me.GroupBox1.Controls.Add(Me.txtCodigo)
            Me.GroupBox1.Controls.Add(Me.txtSituacion)
            Me.GroupBox1.Controls.Add(Me.Label14)
            Me.GroupBox1.Controls.Add(Me.Label3)
            Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption
            Me.GroupBox1.Location = New System.Drawing.Point(8, 1)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(786, 53)
            Me.GroupBox1.TabIndex = 16
            Me.GroupBox1.TabStop = False
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaption
            Me.Label12.Location = New System.Drawing.Point(176, 22)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(74, 15)
            Me.Label12.TabIndex = 10
            Me.Label12.Text = "Fecha Alta"
            '
            'tTip
            '
            Me.tTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
            '
            'btImprimirDetalle
            '
            Me.btImprimirDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.btImprimirDetalle.Image = CType(resources.GetObject("btImprimirDetalle.Image"), System.Drawing.Image)
            Me.btImprimirDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btImprimirDetalle.Location = New System.Drawing.Point(8, 12)
            Me.btImprimirDetalle.Name = "btImprimirDetalle"
            Me.btImprimirDetalle.Size = New System.Drawing.Size(75, 23)
            Me.btImprimirDetalle.TabIndex = 9
            Me.btImprimirDetalle.Text = "Imprimir"
            Me.btImprimirDetalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.btImprimirDetalle.UseVisualStyleBackColor = False
            '
            'frmEquipoEdit
            '
            Me.ClientSize = New System.Drawing.Size(800, 590)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.tbar)
            Me.Controls.Add(Me.TabControl1)
            Me.Controls.Add(Me.GroupBox2)
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "frmEquipoEdit"
            Me.Text = "Equipo"
            Me.Controls.SetChildIndex(Me.panFooter, 0)
            Me.Controls.SetChildIndex(Me.GroupBox2, 0)
            Me.Controls.SetChildIndex(Me.TabControl1, 0)
            Me.Controls.SetChildIndex(Me.tbar, 0)
            Me.Controls.SetChildIndex(Me.GroupBox1, 0)
            CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panFooter.ResumeLayout(False)
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage4.ResumeLayout(False)
            Me.TabPage4.PerformLayout()
            Me.TabPage6.ResumeLayout(False)
            Me.TabPage6.PerformLayout()
            Me.TabPage7.ResumeLayout(False)
            Me.TabPage7.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.tbar.ResumeLayout(False)
            Me.tbar.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Public WithEvents Label8 As System.Windows.Forms.Label
        Public WithEvents cmbUnidad As System.Windows.Forms.ComboBox
        Public WithEvents Label4 As System.Windows.Forms.Label
        Public WithEvents dateFechaOcurrencia As System.Windows.Forms.DateTimePicker
        Public WithEvents Label5 As System.Windows.Forms.Label
        Public WithEvents Label6 As System.Windows.Forms.Label
        Public WithEvents cmbTipoEquipo As System.Windows.Forms.ComboBox
        Public WithEvents Label7 As System.Windows.Forms.Label
        Public WithEvents cmbClaseEquipo As System.Windows.Forms.ComboBox
        Public WithEvents cmbTipoLesion As System.Windows.Forms.ComboBox
        Public WithEvents Label9 As System.Windows.Forms.Label
        Public WithEvents Label10 As System.Windows.Forms.Label
        Public WithEvents txtDescrResumen As repsol.forms.controls.TextBoxColor
        Public WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Public WithEvents txtDescrDetalle As repsol.forms.controls.TextBoxColor
        Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
        Friend WithEvents tpageMedidasAdoptadas As System.Windows.Forms.TabPage
        Friend WithEvents tpageIntegrantes As System.Windows.Forms.TabPage
        Friend WithEvents tpageAcciones As System.Windows.Forms.TabPage
        Friend WithEvents tpageCausas As System.Windows.Forms.TabPage
        Public WithEvents TabControl1 As System.Windows.Forms.TabControl
        Public WithEvents txtCodigo As repsol.forms.controls.TextBoxColor
        Public WithEvents txtFecha As repsol.forms.controls.TextBoxColor
        Public WithEvents txtUsuario As repsol.forms.controls.TextBoxColor
        Public WithEvents Label3 As System.Windows.Forms.Label
        Public WithEvents Label11 As System.Windows.Forms.Label
        Protected WithEvents tbar As System.Windows.Forms.ToolStrip
        Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
        Friend WithEvents btCerrar As System.Windows.Forms.ToolStripButton
        Friend WithEvents btReabrir As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents btAnular As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents btImprimir As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents btAnexar As System.Windows.Forms.ToolStripButton
        Friend WithEvents btLeccionAprendida As System.Windows.Forms.ToolStripButton
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Public WithEvents txtSituacion As repsol.forms.controls.TextBoxColor
        Public WithEvents Label14 As System.Windows.Forms.Label
        Public WithEvents Label12 As System.Windows.Forms.Label
        Public WithEvents Label17 As System.Windows.Forms.Label
        Public WithEvents Label16 As System.Windows.Forms.Label
        Public WithEvents Label18 As System.Windows.Forms.Label
        Public WithEvents txtFechaAnulacion As repsol.forms.controls.TextBoxColor
        Public WithEvents txtFechaCierre As repsol.forms.controls.TextBoxColor
        Public WithEvents txtFechaCierreInvest As repsol.forms.controls.TextBoxColor
        Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
        Friend WithEvents tpageFicheros As System.Windows.Forms.TabPage
        Public WithEvents txtConsecuencias As repsol.forms.controls.TextBoxColor
        Public WithEvents chkImpacto As System.Windows.Forms.CheckedListBox

        Private Sub frmEquipoEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                'Dim ctrl As New ctrl.ctrlEquipoEdit
                'ctrl.inicializarForm(Me)
                'MsgBox(Me.Label1.Font.FontFamily.Name & " - " & Me.ToolStripLabel1.Font.FontFamily.Name)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub


#Region "Tratamiento Online"

        Private _isLoading As Boolean = False

        Public Property IsLoading() As Boolean
            Get
                Return _isLoading
            End Get
            Set(ByVal value As Boolean)
                _isLoading = value
            End Set
        End Property

        Private _voOnline As baseball.lib.vo.Equipo

        Public Property OnlineVO() As baseball.lib.vo.Equipo
            Get
                Return _voOnline
            End Get
            Set(ByVal value As baseball.lib.vo.Equipo)
                _voOnline = value
            End Set
        End Property

        'Private Sub guardarDatosOnline(ByVal sender As Object, ByVal e As EventArgs) Handles cmbUnidad.SelectedIndexChanged, cmbClaseEquipo.SelectedIndexChanged, cmbTipoEquipo.SelectedIndexChanged, txtDescrResumen.Validated, chkImpacto.SelectedValueChanged, TabControl1.SelectedIndexChanged, txtConsecuencias.Validated, txtDescrDetalle.Validated, txtFechaAnulacion.TextChanged
        Private Sub guardarDatosOnline(ByVal sender As Object, ByVal e As EventArgs) Handles cmbUnidad.SelectedIndexChanged, cmbClaseEquipo.SelectedIndexChanged, cmbTipoEquipo.SelectedIndexChanged, txtDescrResumen.Validated, chkImpacto.SelectedValueChanged, _frmAccionQry.hasChanged, _frmCausaQry.hasChanged, _frmEvaluacionQry.hasChanged, _frmFicheroQry.hasChanged, _frmIntegranteQry.hasChanged, _frmMedidaAdoptadaQry.hasChanged, txtConsecuencias.Validated, txtDescrDetalle.Validated, txtFechaAnulacion.TextChanged
            Try
                If (Me.IsLoading) Then
                    Exit Sub
                End If
                If (Not Me.OnlyView) Then
                    If (OnlineVO Is Nothing) Then
                        Exit Sub
                    End If

                    Dim ctrl As New ctrl.ctrlEquipoEdit
                    If (ctrl.hasChanged(Me, sender)) Then
                        ctrl.guardarDatos(Me, Me.IsNewRecord)
                        ctrl.setToolTipTipoEquipo(Me)
                        If (ctrl.canSave(Me.OnlineVO)) Then
                            Me.newRecord = False
                        End If
                    End If
                End If
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub restablecerDatosOnline(ByVal sender As Object, ByVal e As EventArgs)
            Try
                If (Not Me.OnlyView) Then
                    If (OnlineVO Is Nothing) Then
                        Exit Sub
                    End If

                    Dim vCambio As New _cambio.frmCambio(Me.InnerVO, Me.OnlineVO)
                    vCambio.StartPosition = FormStartPosition.CenterParent
                    If (Windows.Forms.DialogResult.Yes = vCambio.ShowDialog(Me)) Then
                        Dim ctrl As New ctrl.ctrlEquipoEdit
                        ctrl.restablecerDatosEquipo(Me)
                        Me.Close()
                    End If
                Else
                    MyBase.btCancelar_Click(sender, e)
                End If
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Protected Overrides Sub btCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                restablecerDatosOnline(sender, e)
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
            'MyBase.btCancelar_Click(sender, e)
        End Sub

#End Region

#Region "Nivel de Acceso"

        Private _esLider As Boolean

        Public Property EsLider() As Boolean
            Get
                Return _esLider
            End Get
            Set(ByVal value As Boolean)
                _esLider = value
            End Set
        End Property

        Private Sub btImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimir.Click
            Try
                repsol.util.messages.ShowWarning(_common.constantes.mensaje.OPTION_DISABLED, Me.Text)
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub btCerrarInvestigacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCerrarInvestigacion.Click
            Try
                If (Not Me.EsLider) Then
                    repsol.util.messages.ShowWarning(baseball.lib.bl._common.constantes.mensaje.NO_ACCESS_ALLOWED, Me.Text)
                    Return
                End If

                Dim fecha As DateTime = DateTime.Now
                Dim res As Windows.Forms.DialogResult = MessageBox.Show("¿Desea establecer la fecha de cierre de invest. manualmente? Si contesta no, se establecerá la fecha de hoy automáticamente.", Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (Windows.Forms.DialogResult.Yes = res) Then
                    Dim vVen As New _fecha.frmFecha
                    vVen.ShowDialog(Me)
                    fecha = vVen.dateFechaOcurrencia.Value
                Else
                    If (res = Windows.Forms.DialogResult.Cancel) Then
                        repsol.util.messages.ShowWarning(_common.constantes.mensaje.OPERATION_CANCELED, Me.Text)
                        Return
                    End If
                End If
                Me.txtFechaCierreInvest.Text = fecha.ToString(baseball.lib.common.constantes.formato.FECHAHORA)

                Dim ctrl As New ctrl.ctrlEquipoEdit
                ctrl.cambiarEstadoEquipo(Me)

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub btCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCerrar.Click
            Try
                If (Not Me.EsLider) Then
                    repsol.util.messages.ShowWarning(baseball.lib.bl._common.constantes.mensaje.NO_ACCESS_ALLOWED, Me.Text)
                    Return
                End If

                If (Me.OnlineVO.Evaluaciones Is Nothing) OrElse (Me.OnlineVO.Evaluaciones.Length = 0) Then
                    If (Windows.Forms.DialogResult.No = MessageBox.Show("El equipo no tiene evaluación económica. ¿Desea continuar con el proceso de cierre?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) Then
                        Return
                    End If
                End If

                Dim fecha As DateTime = DateTime.Now
                Dim res As Windows.Forms.DialogResult = MessageBox.Show("¿Desea establecer la fecha de cierre manualmente? Si contesta no, se establecerá la fecha de hoy automáticamente.", Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (Windows.Forms.DialogResult.Yes = res) Then
                    Dim vVen As New _fecha.frmFecha
                    vVen.ShowDialog(Me)
                    fecha = vVen.dateFechaOcurrencia.Value
                Else
                    If (res = Windows.Forms.DialogResult.Cancel) Then
                        repsol.util.messages.ShowWarning(_common.constantes.mensaje.OPERATION_CANCELED, Me.Text)
                        Return
                    End If
                End If
                Me.txtFechaCierre.Text = fecha.ToString(baseball.lib.common.constantes.formato.FECHAHORA)

                Dim ctrl As New ctrl.ctrlEquipoEdit
                ctrl.cambiarEstadoEquipo(Me)

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub btReabrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btReabrir.Click
            Try
                If (Not baseball.lib.bl._common.cache.USUARIO.Perfil.Admin) Then
                    repsol.util.messages.ShowWarning(baseball.lib.bl._common.constantes.mensaje.NO_ACCESS_ALLOWED, Me.Text)
                    Return
                End If

                Dim ctrl As New ctrl.ctrlEquipoEdit
                If (Not ctrl.canReopen(Me)) Then
                    repsol.util.messages.ShowWarning("No se puede realizar esta acción. El equipo no está cerrado ni anulado.", Me.Text)
                    Return
                End If

                Dim vVen As New reapertura.frmReaperturaEdit
                vVen.ShowDialog(Me)
                If (Windows.Forms.DialogResult.OK = vVen.DialogResult) Then
                    ctrl.reabrirEquipo(Me)
                Else
                    repsol.util.messages.ShowWarning(_common.constantes.mensaje.OPERATION_CANCELED, Me.Text)
                End If

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub btAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAnular.Click
            Try
                If (Not baseball.lib.bl._common.cache.USUARIO.Perfil.Admin) AndAlso (Not Me.EsLider) Then
                    repsol.util.messages.ShowWarning(baseball.lib.bl._common.constantes.mensaje.NO_ACCESS_ALLOWED, Me.Text)
                    Return
                End If

                Dim fecha As DateTime = DateTime.Now
                Dim res As Windows.Forms.DialogResult = MessageBox.Show("¿Desea establecer la fecha de anulación manualmente? Si contesta no, se establecerá la fecha de hoy automáticamente.", Me.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If (Windows.Forms.DialogResult.Yes = res) Then
                    Dim vVen As New _fecha.frmFecha
                    vVen.ShowDialog(Me)
                    fecha = vVen.dateFechaOcurrencia.Value
                Else
                    If (res = Windows.Forms.DialogResult.Cancel) Then
                        repsol.util.messages.ShowWarning(_common.constantes.mensaje.OPERATION_CANCELED, Me.Text)
                        Return
                    End If
                End If
                Me.txtFechaAnulacion.Text = fecha.ToString(baseball.lib.common.constantes.formato.FECHAHORA)

                Dim ctrl As New ctrl.ctrlEquipoEdit
                ctrl.cambiarEstadoEquipo(Me)

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub btAnexar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAnexar.Click
            Try
                repsol.util.messages.ShowWarning(_common.constantes.mensaje.OPTION_DISABLED, Me.Text)
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub btLeccionAprendida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLeccionAprendida.Click
            Try
                repsol.util.messages.ShowWarning(_common.constantes.mensaje.OPTION_DISABLED, Me.Text)
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

#End Region

        Private Sub btExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExaminar.Click
            Try
                Dim vVen As New equipo.frmEquipoQry(Me.cmbUnidad.SelectedItem)
                vVen.EquipoExterno = True
                vVen.MultiSelect = False
                vVen.ShowDialog(Me)
                If (vVen.DialogResult = Windows.Forms.DialogResult.OK) Then
                    Dim ctrl As New ctrl.ctrlEquipoEdit
                    ctrl.ImportarEquipo(Me, vVen.SelectedVO)
                End If
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub


        Private Sub btImprimirDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprimirDetalle.Click
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim ctrl As New ctrl.ctrlEquipoEdit
                Dim vVen As New rptDetalleEquipo.frmDetalleEquipoPrint(ctrl.getCompleteVO(Me))
                vVen.Show()
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click

        End Sub
    End Class
End Namespace

