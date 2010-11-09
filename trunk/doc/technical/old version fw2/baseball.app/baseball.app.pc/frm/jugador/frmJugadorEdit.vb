Namespace frm.jugador
    Public Class frmJugadorEdit
        Inherits _template.edicion.editform

        Friend WithEvents txtNombre As System.Windows.Forms.TextBox
        Friend WithEvents txtApellido1 As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtApellido2 As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents cmbEquipo As System.Windows.Forms.ComboBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label


        Public Sub New()
            InitializeComponent()

            Dim ctrl As New ctrl.ctrlJugadorEdit
            ctrl.inicializarForm(Me)
            ctrl.cargarDatos(Me, ctrl.getNewObject())
        End Sub
        Public Sub New(ByVal obj As baseball.lib.vo.Jugador)
            InitializeComponent()

            Dim ctrl As New ctrl.ctrlJugadorEdit
            ctrl.inicializarForm(Me)
            ctrl.cargarDatos(Me, obj)
        End Sub

        Public Sub New(ByVal obj As baseball.lib.vo.Jugador, ByVal soloconsulta As Boolean)
            MyBase.New(soloconsulta)

            InitializeComponent()

            newRecord = False

            Dim ctrl As New ctrl.ctrlJugadorEdit
            ctrl.inicializarForm(Me)
            ctrl.cargarDatos(Me, obj)
        End Sub

        Protected Overrides Sub btAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim ctrl As New ctrl.ctrlJugadorEdit
                ctrl.guardarDatos(Me, newRecord)

                Dim selItem As Object = Nothing
                If (Not Me.chkCerrar.Checked) Then selItem = Me.cmbEquipo.SelectedItem
                MyBase.btAceptar_Click(sender, e)
                If (Not Me.chkCerrar.Checked) Then Me.cmbEquipo.SelectedItem = selItem

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub InitializeComponent()
            Me.Label1 = New System.Windows.Forms.Label
            Me.txtNombre = New System.Windows.Forms.TextBox
            Me.txtApellido1 = New System.Windows.Forms.TextBox
            Me.Label2 = New System.Windows.Forms.Label
            Me.txtApellido2 = New System.Windows.Forms.TextBox
            Me.Label3 = New System.Windows.Forms.Label
            Me.cmbEquipo = New System.Windows.Forms.ComboBox
            Me.Label4 = New System.Windows.Forms.Label
            CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panFooter.SuspendLayout()
            Me.SuspendLayout()
            '
            'btAceptar
            '
            Me.btAceptar.BackColor = System.Drawing.Color.PaleGreen
            Me.btAceptar.Location = New System.Drawing.Point(305, 8)
            '
            'btCancelar
            '
            Me.btCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.btCancelar.Location = New System.Drawing.Point(386, 8)
            '
            'panFooter
            '
            Me.panFooter.Location = New System.Drawing.Point(0, 176)
            Me.panFooter.Size = New System.Drawing.Size(473, 43)
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(32, 45)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(50, 14)
            Me.Label1.TabIndex = 9
            Me.Label1.Text = "Nombre"
            '
            'txtNombre
            '
            Me.txtNombre.Location = New System.Drawing.Point(106, 42)
            Me.txtNombre.Name = "txtNombre"
            Me.txtNombre.Size = New System.Drawing.Size(309, 22)
            Me.txtNombre.TabIndex = 10
            '
            'txtApellido1
            '
            Me.txtApellido1.Location = New System.Drawing.Point(106, 70)
            Me.txtApellido1.Name = "txtApellido1"
            Me.txtApellido1.Size = New System.Drawing.Size(309, 22)
            Me.txtApellido1.TabIndex = 12
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(32, 73)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(71, 14)
            Me.Label2.TabIndex = 11
            Me.Label2.Text = "1er Apellido"
            '
            'txtApellido2
            '
            Me.txtApellido2.Location = New System.Drawing.Point(106, 98)
            Me.txtApellido2.Name = "txtApellido2"
            Me.txtApellido2.Size = New System.Drawing.Size(309, 22)
            Me.txtApellido2.TabIndex = 14
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(32, 101)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(74, 14)
            Me.Label3.TabIndex = 13
            Me.Label3.Text = "2do Apellido"
            '
            'cmbEquipo
            '
            Me.cmbEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbEquipo.FormattingEnabled = True
            Me.cmbEquipo.Location = New System.Drawing.Point(106, 127)
            Me.cmbEquipo.Name = "cmbEquipo"
            Me.cmbEquipo.Size = New System.Drawing.Size(309, 22)
            Me.cmbEquipo.TabIndex = 15
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(32, 130)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(44, 14)
            Me.Label4.TabIndex = 16
            Me.Label4.Text = "Equipo"
            '
            'frmJugadorEdit
            '
            Me.ClientSize = New System.Drawing.Size(473, 219)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.cmbEquipo)
            Me.Controls.Add(Me.txtApellido2)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.txtApellido1)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.txtNombre)
            Me.Controls.Add(Me.Label1)
            Me.Name = "frmJugadorEdit"
            Me.Text = "Jugador"
            Me.Controls.SetChildIndex(Me.Label1, 0)
            Me.Controls.SetChildIndex(Me.txtNombre, 0)
            Me.Controls.SetChildIndex(Me.panFooter, 0)
            Me.Controls.SetChildIndex(Me.Label2, 0)
            Me.Controls.SetChildIndex(Me.txtApellido1, 0)
            Me.Controls.SetChildIndex(Me.Label3, 0)
            Me.Controls.SetChildIndex(Me.txtApellido2, 0)
            Me.Controls.SetChildIndex(Me.cmbEquipo, 0)
            Me.Controls.SetChildIndex(Me.Label4, 0)
            CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panFooter.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
    End Class
End Namespace

