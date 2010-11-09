Namespace _template.edicion
    Public Class editform
        Inherits repsol.forms.template.edicion.EditForm

#Region "20080110: Para publicar los cambios"
        Public Event HasChanged(ByVal sender As Object, ByVal e As EventArgs)

        Public Overridable Function getVO() As Object
            Return Me.InnerVO
        End Function

        Public Sub InvokeHasChanged()
            RaiseEvent HasChanged(Me, New EventArgs())
        End Sub
#End Region

        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Me.chkCerrar.Visible = True
        End Sub
        Public Sub New(ByVal soloconsulta As Boolean)
            MyBase.New(soloconsulta)
            InitializeComponent()
        End Sub

        'Public Sub New()
        '    InitializeComponent()
        '    _newRecord = True
        '    Me.Tag = " - Nuevo Registro"
        '    Me.chkCerrar.Visible = False
        '    Me.StartPosition = FormStartPosition.CenterParent
        'End Sub

        'Public Sub New(ByVal soloconsulta As Boolean)
        '    InitializeComponent()
        '    _newRecord = False
        '    Me._onlyView = soloconsulta
        '    Me.btAceptar.Visible = Not soloconsulta
        '    Me.chkCerrar.Visible = False
        '    Me.chkCerrar.Checked = True
        '    If (soloconsulta) Then
        '        Me.chkCerrar.Checked = False
        '        Me.btCancelar.Text = "Salir"
        '        Me.Tag = " - Consulta"
        '    Else
        '        Me.Tag = " - Modificación"
        '    End If

        '    Me.chkCerrar.Visible = False
        '    Me.StartPosition = FormStartPosition.CenterParent
        'End Sub

        'Public Property innerObject() As Object
        '    Get
        '        Return _object
        '    End Get
        '    Set(ByVal Value As Object)
        '        _object = Value
        '    End Set
        'End Property
        'Public ReadOnly Property isNewRecord() As Boolean
        '    Get
        '        Return _newRecord
        '    End Get
        'End Property
        'Public ReadOnly Property mustClose() As Boolean
        '    Get
        '        Return Me.chkCerrar.Checked
        '    End Get
        'End Property
        'Public ReadOnly Property onlyView() As Boolean
        '    Get
        '        Return Me._onlyView
        '    End Get
        'End Property


        'Private Sub InitializeComponent()
        '    Me.components = New System.ComponentModel.Container
        '    Me.btAceptar = New System.Windows.Forms.Button
        '    Me.btCancelar = New System.Windows.Forms.Button
        '    Me.errProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        '    Me.chkCerrar = New System.Windows.Forms.CheckBox
        '    CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        '    Me.SuspendLayout()
        '    '
        '    'btAceptar
        '    '
        '    Me.btAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '    Me.btAceptar.BackColor = System.Drawing.SystemColors.Control
        '    Me.btAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        '    Me.btAceptar.Location = New System.Drawing.Point(312, 240)
        '    Me.btAceptar.Name = "btAceptar"
        '    Me.btAceptar.Size = New System.Drawing.Size(75, 23)
        '    Me.btAceptar.TabIndex = 0
        '    Me.btAceptar.Text = "Aceptar"
        '    Me.btAceptar.UseVisualStyleBackColor = False
        '    '
        '    'btCancelar
        '    '
        '    Me.btCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '    Me.btCancelar.BackColor = System.Drawing.SystemColors.Control
        '    Me.btCancelar.Location = New System.Drawing.Point(392, 240)
        '    Me.btCancelar.Name = "btCancelar"
        '    Me.btCancelar.Size = New System.Drawing.Size(75, 23)
        '    Me.btCancelar.TabIndex = 1
        '    Me.btCancelar.Text = "Cancelar"
        '    Me.btCancelar.UseVisualStyleBackColor = False
        '    '
        '    'errProvider
        '    '
        '    Me.errProvider.ContainerControl = Me
        '    '
        '    'chkCerrar
        '    '
        '    Me.chkCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        '    Me.chkCerrar.BackColor = System.Drawing.Color.Transparent
        '    Me.chkCerrar.Checked = True
        '    Me.chkCerrar.CheckState = System.Windows.Forms.CheckState.Checked
        '    Me.chkCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        '    Me.chkCerrar.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '    Me.chkCerrar.Location = New System.Drawing.Point(8, 248)
        '    Me.chkCerrar.Name = "chkCerrar"
        '    Me.chkCerrar.Size = New System.Drawing.Size(160, 16)
        '    Me.chkCerrar.TabIndex = 7
        '    Me.chkCerrar.TabStop = False
        '    Me.chkCerrar.Text = "Cerrar ventana al aceptar"
        '    Me.chkCerrar.UseVisualStyleBackColor = False
        '    '
        '    'editform
        '    '
        '    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        '    Me.BackColor = System.Drawing.Color.LightGray
        '    Me.ClientSize = New System.Drawing.Size(474, 271)
        '    Me.ControlBox = False
        '    Me.Controls.Add(Me.chkCerrar)
        '    Me.Controls.Add(Me.btCancelar)
        '    Me.Controls.Add(Me.btAceptar)
        '    Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        '    Me.KeyPreview = True
        '    Me.MaximizeBox = False
        '    Me.MinimizeBox = False
        '    Me.Name = "editform"
        '    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        '    Me.Text = "Edición"
        '    CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        '    Me.ResumeLayout(False)

        'End Sub

        ''            CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        ''    Me.SuspendLayout()
        ' ''
        ' ''editform
        ' ''
        ''    Me.ClientSize = New System.Drawing.Size(474, 271)
        ''    Me.KeyPreview = True
        ''    Me.Name = "editform"
        ''    Me.Text = "Edición - Nuevo Registro"
        ''    CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
        ''    Me.ResumeLayout(False)

        'Protected Overridable Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        '    Dim res As DialogResult = System.Windows.Forms.DialogResult.Yes
        '    If (Me.chkCerrar.Checked) Then
        '        res = MessageBox.Show("¿Desea cancelar la operación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        '    End If
        '    If (System.Windows.Forms.DialogResult.Yes = res) Then
        '        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        '        Me.Close()
        '    End If
        'End Sub

        'Protected Overridable Sub btAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAceptar.Click
        '    If (Me.chkCerrar.Checked) Then
        '        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        '        Me.Close()
        '    Else
        '        resetForm(Me)
        '        If Not (Me.Owner Is Nothing) Then
        '            If Not (Me.Owner.ActiveMdiChild Is Nothing) Then
        '                CType(Me.Owner.ActiveMdiChild, consulta.queryform).btRefresh_record()
        '            End If
        '        End If
        '        'Me.Controls(Me.chkCerrar.Tag).Focus()
        '    End If
        'End Sub

        'Protected Sub frmEdicion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '    Me.Text += Me.Tag

        '    If (Me._onlyView) Then
        '        Me.modoConsulta(Me)
        '        Me.btCancelar.Enabled = True
        '    End If

        'End Sub

        'Private Sub editform_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        '    Try
        '        If (e.KeyCode = Keys.Escape) Then
        '            btCancelar_Click(Nothing, Nothing)
        '        End If
        '    Catch ex As Exception
        '        repsol.util.messages.ShowError(ex.Message,me.Text)
        '    End Try
        'End Sub

        'Protected Sub modoConsulta(ByRef ctrl As Control, Optional ByVal modo As Boolean = True)

        '    For Each c As Control In ctrl.Controls
        '        Select Case c.GetType.FullName
        '            Case GetType(TextBox).FullName, GetType(ComboBox).FullName, _
        '                GetType(CheckBox).FullName, GetType(RadioButton).FullName, _
        '                GetType(ListView).FullName, GetType(PictureBox).FullName, _
        '                GetType(DateTimePicker).FullName, GetType(NumericUpDown).FullName, _
        '                GetType('TODO: YPFForms.Common.Controles.YPFComboBox).FullName, _
        '                GetType(CheckedListBox).FullName, _
        '                GetType(repsol.forms.controls.TextBoxColor).FullName
        '                c.Enabled = Not modo
        '                If (c.BackColor.ToArgb() <> Color.Transparent.ToArgb()) Then
        '                    If (c.GetType.FullName = GetType(TextBox).FullName) AndAlso (CType(c, TextBox).ReadOnly) Then
        '                    Else
        '                        If (Not c.GetType Is GetType(repsol.forms.controls.TextBoxColor)) _
        '                        And _
        '                        (Not c.GetType Is GetType(CheckedListBox)) Then
        '                            c.BackColor = Color.White
        '                        End If
        '                    End If
        '                End If
        '            Case GetType(Button).FullName, GetType('TODO: YPFForms.Common.Controles.YPFRoundButton).FullName
        '                c.Enabled = Not modo
        '        End Select
        '        Me.errProvider.SetError(c, "")
        '        Me.modoConsulta(c, modo)
        '    Next
        'End Sub

        'Protected Overridable Function resetForm(ByRef winctrl As Control) As Int32
        '    Dim indiceTabMin As Int32 = 5000
        '    For Each c As Control In winctrl.Controls

        '        If ((c.TabStop) AndAlso ((c.GetType Is GetType(TextBox)) OrElse (c.GetType.BaseType Is GetType(TextBox)))) Then
        '            c.Text = ""
        '            If ((c.Enabled) AndAlso (c.Visible) AndAlso (indiceTabMin > c.TabIndex)) Then
        '                indiceTabMin = c.TabIndex
        '                Me.chkCerrar.Tag = winctrl.Controls.GetChildIndex(c)
        '            End If
        '        End If

        '        If ((c.TabStop) AndAlso (c.GetType Is GetType(ComboBox))) Then
        '            CType(c, ComboBox).SelectedIndex = -1
        '        End If

        '        If ((c.TabStop) AndAlso (c.GetType Is GetType(DateTimePicker))) Then
        '            CType(c, DateTimePicker).Value = DateTime.Now
        '        End If

        '        'If ((c.TabStop) AndAlso (c.GetType Is GetType(CheckBox))) Then
        '        '    CType(c, CheckBox).Checked = False
        '        'End If
        '        indiceTabMin = Math.Min(resetForm(c), indiceTabMin)
        '    Next
        '    Return indiceTabMin
        'End Function

        'Private Sub chkCerrar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCerrar.CheckedChanged
        '    If (chkCerrar.Checked) Then
        '        Me.btCancelar.Text = "Cancelar"
        '    Else
        '        Me.btCancelar.Text = "Salir"
        '    End If
        'End Sub

        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(editform))
            CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panFooter.SuspendLayout()
            Me.SuspendLayout()
            '
            'btAceptar
            '
            Me.btAceptar.BackColor = System.Drawing.Color.PaleGreen
            Me.btAceptar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btAceptar.Location = New System.Drawing.Point(302, 8)
            '
            'btCancelar
            '
            Me.btCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.btCancelar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btCancelar.Location = New System.Drawing.Point(383, 8)
            '
            'panFooter
            '
            Me.panFooter.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.panFooter.Location = New System.Drawing.Point(0, 198)
            Me.panFooter.Size = New System.Drawing.Size(470, 43)
            '
            'editform
            '
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.ClientSize = New System.Drawing.Size(470, 241)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "editform"
            Me.Text = "Edición - Nuevo registro"
            CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panFooter.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Protected Overrides Sub modoConsulta(ByRef ctrl As System.Windows.Forms.Control, Optional ByVal modo As Boolean = True)
            MyBase.modoConsulta(ctrl, modo)
            If (TypeOf (ctrl) Is TextBox) Then
                CType(ctrl, TextBox).Enabled = True
                CType(ctrl, TextBox).ReadOnly = modo
            End If
        End Sub

    End Class
End Namespace

