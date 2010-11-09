Namespace frm._estadistica
    Public Class frmEstadisticaPrint
        Inherits _template.impresion.printform

        Public WithEvents dateFechaDesde As System.Windows.Forms.DateTimePicker
        Public WithEvents Label3 As System.Windows.Forms.Label
        Public WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cmbCompeticion As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents rbInformeBaseRunning As System.Windows.Forms.RadioButton
        Friend WithEvents rbInformeFielding As System.Windows.Forms.RadioButton
        Friend WithEvents rbInformeCatching As System.Windows.Forms.RadioButton
        Friend WithEvents rbInformePitching As System.Windows.Forms.RadioButton
        Friend WithEvents rbInformeBatting As System.Windows.Forms.RadioButton
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents cmbPartido As System.Windows.Forms.ComboBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Public WithEvents dateFechaHasta As System.Windows.Forms.DateTimePicker
        Public Sub New()
            MyBase.New(True)
            InitializeComponent()
        End Sub

        Protected Overrides Sub initForm()
            MyBase.initForm()
        End Sub

        Private Sub frmAtaquePrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.Text &= " - Estadísticas"

                Dim ctrl As New ctrl.ctrlEstadisticaPrint
                ctrl.inicializarForm(Me)
                ctrl.imprimir(Me)
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Protected Overrides Sub VerInforme()
            Try
                Dim ctrl As New ctrl.ctrlEstadisticaPrint
                ctrl.imprimir(Me)
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub InitializeComponent()
            Me.dateFechaHasta = New System.Windows.Forms.DateTimePicker
            Me.Label2 = New System.Windows.Forms.Label
            Me.Label3 = New System.Windows.Forms.Label
            Me.dateFechaDesde = New System.Windows.Forms.DateTimePicker
            Me.cmbCompeticion = New System.Windows.Forms.ComboBox
            Me.Label1 = New System.Windows.Forms.Label
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.rbInformeBaseRunning = New System.Windows.Forms.RadioButton
            Me.rbInformeFielding = New System.Windows.Forms.RadioButton
            Me.rbInformeCatching = New System.Windows.Forms.RadioButton
            Me.rbInformePitching = New System.Windows.Forms.RadioButton
            Me.rbInformeBatting = New System.Windows.Forms.RadioButton
            Me.GroupBox2 = New System.Windows.Forms.GroupBox
            Me.cmbPartido = New System.Windows.Forms.ComboBox
            Me.Label4 = New System.Windows.Forms.Label
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
            Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
            Me.SplitContainer1.Size = New System.Drawing.Size(792, 541)
            '
            'viewer
            '
            Me.viewer.Size = New System.Drawing.Size(792, 541)
            '
            'dateFechaHasta
            '
            Me.dateFechaHasta.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.dateFechaHasta.Checked = False
            Me.dateFechaHasta.CustomFormat = "dd/MM/yyyy HH:mm"
            Me.dateFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dateFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dateFechaHasta.Location = New System.Drawing.Point(371, 19)
            Me.dateFechaHasta.Name = "dateFechaHasta"
            Me.dateFechaHasta.ShowCheckBox = True
            Me.dateFechaHasta.Size = New System.Drawing.Size(134, 20)
            Me.dateFechaHasta.TabIndex = 65
            '
            'Label2
            '
            Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(321, 23)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(35, 13)
            Me.Label2.TabIndex = 64
            Me.Label2.Text = "Hasta"
            '
            'Label3
            '
            Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(31, 23)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(71, 13)
            Me.Label3.TabIndex = 63
            Me.Label3.Text = "Fecha Desde"
            '
            'dateFechaDesde
            '
            Me.dateFechaDesde.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.dateFechaDesde.Checked = False
            Me.dateFechaDesde.CustomFormat = "dd/MM/yyyy HH:mm"
            Me.dateFechaDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dateFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dateFechaDesde.Location = New System.Drawing.Point(124, 19)
            Me.dateFechaDesde.Name = "dateFechaDesde"
            Me.dateFechaDesde.ShowCheckBox = True
            Me.dateFechaDesde.Size = New System.Drawing.Size(134, 20)
            Me.dateFechaDesde.TabIndex = 62
            '
            'cmbCompeticion
            '
            Me.cmbCompeticion.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.cmbCompeticion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCompeticion.FormattingEnabled = True
            Me.cmbCompeticion.Location = New System.Drawing.Point(124, 45)
            Me.cmbCompeticion.Name = "cmbCompeticion"
            Me.cmbCompeticion.Size = New System.Drawing.Size(381, 21)
            Me.cmbCompeticion.TabIndex = 66
            '
            'Label1
            '
            Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.Label1.AutoSize = True
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Location = New System.Drawing.Point(31, 48)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(65, 13)
            Me.Label1.TabIndex = 67
            Me.Label1.Text = "Competición"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.rbInformeBaseRunning)
            Me.GroupBox1.Controls.Add(Me.rbInformeFielding)
            Me.GroupBox1.Controls.Add(Me.rbInformeCatching)
            Me.GroupBox1.Controls.Add(Me.rbInformePitching)
            Me.GroupBox1.Controls.Add(Me.rbInformeBatting)
            Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(222, 105)
            Me.GroupBox1.TabIndex = 68
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Informe"
            '
            'rbInformeBaseRunning
            '
            Me.rbInformeBaseRunning.AutoSize = True
            Me.rbInformeBaseRunning.Checked = True
            Me.rbInformeBaseRunning.Location = New System.Drawing.Point(24, 67)
            Me.rbInformeBaseRunning.Name = "rbInformeBaseRunning"
            Me.rbInformeBaseRunning.Size = New System.Drawing.Size(97, 17)
            Me.rbInformeBaseRunning.TabIndex = 4
            Me.rbInformeBaseRunning.TabStop = True
            Me.rbInformeBaseRunning.Text = "Robos de base"
            Me.rbInformeBaseRunning.UseVisualStyleBackColor = True
            '
            'rbInformeFielding
            '
            Me.rbInformeFielding.AutoSize = True
            Me.rbInformeFielding.Enabled = False
            Me.rbInformeFielding.Location = New System.Drawing.Point(134, 21)
            Me.rbInformeFielding.Name = "rbInformeFielding"
            Me.rbInformeFielding.Size = New System.Drawing.Size(65, 17)
            Me.rbInformeFielding.TabIndex = 3
            Me.rbInformeFielding.Text = "Defensa"
            Me.rbInformeFielding.UseVisualStyleBackColor = True
            '
            'rbInformeCatching
            '
            Me.rbInformeCatching.AutoSize = True
            Me.rbInformeCatching.Enabled = False
            Me.rbInformeCatching.Location = New System.Drawing.Point(134, 44)
            Me.rbInformeCatching.Name = "rbInformeCatching"
            Me.rbInformeCatching.Size = New System.Drawing.Size(62, 17)
            Me.rbInformeCatching.TabIndex = 2
            Me.rbInformeCatching.Text = "Catcher"
            Me.rbInformeCatching.UseVisualStyleBackColor = True
            '
            'rbInformePitching
            '
            Me.rbInformePitching.AutoSize = True
            Me.rbInformePitching.Enabled = False
            Me.rbInformePitching.Location = New System.Drawing.Point(24, 44)
            Me.rbInformePitching.Name = "rbInformePitching"
            Me.rbInformePitching.Size = New System.Drawing.Size(58, 17)
            Me.rbInformePitching.TabIndex = 1
            Me.rbInformePitching.Text = "Pitcher"
            Me.rbInformePitching.UseVisualStyleBackColor = True
            '
            'rbInformeBatting
            '
            Me.rbInformeBatting.AutoSize = True
            Me.rbInformeBatting.Enabled = False
            Me.rbInformeBatting.Location = New System.Drawing.Point(24, 21)
            Me.rbInformeBatting.Name = "rbInformeBatting"
            Me.rbInformeBatting.Size = New System.Drawing.Size(59, 17)
            Me.rbInformeBatting.TabIndex = 0
            Me.rbInformeBatting.Text = "Ataque"
            Me.rbInformeBatting.UseVisualStyleBackColor = True
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.cmbPartido)
            Me.GroupBox2.Controls.Add(Me.Label4)
            Me.GroupBox2.Controls.Add(Me.dateFechaHasta)
            Me.GroupBox2.Controls.Add(Me.Label3)
            Me.GroupBox2.Controls.Add(Me.cmbCompeticion)
            Me.GroupBox2.Controls.Add(Me.Label2)
            Me.GroupBox2.Controls.Add(Me.Label1)
            Me.GroupBox2.Controls.Add(Me.dateFechaDesde)
            Me.GroupBox2.Location = New System.Drawing.Point(243, 12)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(537, 105)
            Me.GroupBox2.TabIndex = 69
            Me.GroupBox2.TabStop = False
            '
            'cmbPartido
            '
            Me.cmbPartido.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.cmbPartido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbPartido.FormattingEnabled = True
            Me.cmbPartido.Location = New System.Drawing.Point(124, 72)
            Me.cmbPartido.Name = "cmbPartido"
            Me.cmbPartido.Size = New System.Drawing.Size(381, 21)
            Me.cmbPartido.TabIndex = 68
            '
            'Label4
            '
            Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.Label4.AutoSize = True
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Location = New System.Drawing.Point(31, 75)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(40, 13)
            Me.Label4.TabIndex = 69
            Me.Label4.Text = "Partido"
            '
            'frmEstadisticaPrint
            '
            Me.ClientSize = New System.Drawing.Size(792, 566)
            Me.Name = "frmEstadisticaPrint"
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            Me.SplitContainer1.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
    End Class
End Namespace

