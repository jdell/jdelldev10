Namespace frm.partido.hojaanotacion
    Public Class frmHojaAnotacionEdit
        Inherits _template.edicion.editform



        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents haHomeClub As baseball.app.pc._template._controls.HojaAnotacion
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents haVisitante As baseball.app.pc._template._controls.HojaAnotacion
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Public Sub New(ByVal obj As baseball.lib.vo.Partido)
            InitializeComponent()

            Dim ctrl As New ctrl.ctrlHojaAnotacionEdit
            ctrl.inicializarForm(Me)
            ctrl.cargarDatos(Me, obj)
        End Sub
        'Public Sub New(ByVal obj As baseball.lib.vo.HojaAnotacion)
        '    InitializeComponent()

        '    Dim ctrl As New ctrl.ctrlHojaAnotacionEdit
        '    ctrl.inicializarForm(Me)
        '    ctrl.cargarDatos(Me, obj)
        'End Sub

        'Public Sub New(ByVal obj As baseball.lib.vo.HojaAnotacion, ByVal soloconsulta As Boolean)
        '    MyBase.New(soloconsulta)

        '    InitializeComponent()

        '    newRecord = False

        '    Dim ctrl As New ctrl.ctrlHojaAnotacionEdit
        '    ctrl.inicializarForm(Me)
        '    ctrl.cargarDatos(Me, obj)
        'End Sub

        Public ReadOnly Property Aceptar() As Button
            Get
                Return Me.btAceptar
            End Get
        End Property
        Public ReadOnly Property Cancelar() As Button
            Get
                Return Me.btCancelar
            End Get
        End Property

        Protected Overrides Sub btAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim ctrl As New ctrl.ctrlHojaAnotacionEdit
                ctrl.guardarDatos(Me, newRecord)

                MyBase.btAceptar_Click(sender, e)
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub InitializeComponent()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.TabControl1 = New System.Windows.Forms.TabControl
            Me.TabPage1 = New System.Windows.Forms.TabPage
            Me.haHomeClub = New baseball.app.pc._template._controls.HojaAnotacion
            Me.TabPage2 = New System.Windows.Forms.TabPage
            Me.haVisitante = New baseball.app.pc._template._controls.HojaAnotacion
            CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panFooter.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            Me.SuspendLayout()
            '
            'btAceptar
            '
            Me.btAceptar.BackColor = System.Drawing.Color.PaleGreen
            Me.btAceptar.Location = New System.Drawing.Point(726, 11)
            '
            'btCancelar
            '
            Me.btCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.btCancelar.Location = New System.Drawing.Point(807, 11)
            '
            'panFooter
            '
            Me.panFooter.Location = New System.Drawing.Point(0, 525)
            Me.panFooter.Size = New System.Drawing.Size(894, 43)
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.TabControl1)
            Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(894, 525)
            Me.GroupBox1.TabIndex = 9
            Me.GroupBox1.TabStop = False
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.TabPage1)
            Me.TabControl1.Controls.Add(Me.TabPage2)
            Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControl1.Location = New System.Drawing.Point(3, 18)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(888, 504)
            Me.TabControl1.TabIndex = 0
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.haHomeClub)
            Me.TabPage1.Location = New System.Drawing.Point(4, 23)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(880, 477)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "HomeClub"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'haHomeClub
            '
            Me.haHomeClub.DataSource = Nothing
            Me.haHomeClub.Dock = System.Windows.Forms.DockStyle.Fill
            Me.haHomeClub.Location = New System.Drawing.Point(3, 3)
            Me.haHomeClub.Name = "haHomeClub"
            Me.haHomeClub.Size = New System.Drawing.Size(874, 471)
            Me.haHomeClub.TabIndex = 0
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.haVisitante)
            Me.TabPage2.Location = New System.Drawing.Point(4, 23)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(880, 477)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Visitante"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'haVisitante
            '
            Me.haVisitante.DataSource = Nothing
            Me.haVisitante.Dock = System.Windows.Forms.DockStyle.Fill
            Me.haVisitante.Location = New System.Drawing.Point(3, 3)
            Me.haVisitante.Name = "haVisitante"
            Me.haVisitante.Size = New System.Drawing.Size(874, 471)
            Me.haVisitante.TabIndex = 0
            '
            'frmHojaAnotacionEdit
            '
            Me.ClientSize = New System.Drawing.Size(894, 568)
            Me.Controls.Add(Me.GroupBox1)
            Me.Name = "frmHojaAnotacionEdit"
            Me.Text = "Estadísticas"
            Me.Controls.SetChildIndex(Me.panFooter, 0)
            Me.Controls.SetChildIndex(Me.GroupBox1, 0)
            CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panFooter.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.TabPage2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private Sub frmHojaAnotacionEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.Text = "Estadísticas"
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub
    End Class
End Namespace

