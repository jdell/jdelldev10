Namespace _template._controls
    Public MustInherit Class FormatoHoja
        Inherits UserControl

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox
            Me.dg = New System.Windows.Forms.DataGridView
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.GroupBox2.SuspendLayout()
            CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.dg)
            Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox2.Location = New System.Drawing.Point(0, 50)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(675, 464)
            Me.GroupBox2.TabIndex = 3
            Me.GroupBox2.TabStop = False
            '
            'dg
            '
            Me.dg.AllowUserToAddRows = False
            Me.dg.AllowUserToDeleteRows = False
            Me.dg.AllowUserToOrderColumns = True
            Me.dg.AllowUserToResizeColumns = False
            Me.dg.AllowUserToResizeRows = False
            Me.dg.BackgroundColor = System.Drawing.SystemColors.Control
            Me.dg.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dg.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dg.Location = New System.Drawing.Point(3, 16)
            Me.dg.Name = "dg"
            Me.dg.RowHeadersVisible = False
            Me.dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
            Me.dg.Size = New System.Drawing.Size(669, 445)
            Me.dg.TabIndex = 0
            '
            'GroupBox1
            '
            Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
            Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(675, 50)
            Me.GroupBox1.TabIndex = 2
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Visible = False
            '
            'FormatoHoja
            '
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox1)
            Me.Name = "FormatoHoja"
            Me.Size = New System.Drawing.Size(675, 514)
            Me.GroupBox2.ResumeLayout(False)
            CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents dg As System.Windows.Forms.DataGridView
        Private components As System.ComponentModel.IContainer
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox

        Private Sub FormatoHoja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.Dock = DockStyle.Fill
        End Sub

        Private Sub dg_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dg.DataError
            MsgBox("Formato incorrecto.")
        End Sub

#Region "Controller"
        Protected _datasource As Object = Nothing
        Protected Property DataSource() As Object
            Get
                _datasource = DataViewToListVO(Me.dg.DataSource)
                Return _datasource
            End Get
            Set(ByVal value As Object)
                _datasource = value
                SetGridStyle()
            End Set
        End Property

        Protected MustOverride Sub SetGridStyle()
        Protected MustOverride Function ListVOToDataView(ByVal listObject As Object) As System.Data.DataView
        Protected MustOverride Function DataViewToListVO(ByVal dvObject As System.Data.DataView) As Object
        Protected MustOverride Sub setEstiloGridRegistros()

#End Region
    End Class
End Namespace
