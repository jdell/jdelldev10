Namespace frm.competicion
    Public Class frmCompeticionEdit
        Inherits _template.edicion.editform

        Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label


        Public Sub New()
            InitializeComponent()

            Dim ctrl As New ctrl.ctrlCompeticionEdit
            ctrl.inicializarForm(Me)
            ctrl.cargarDatos(Me, ctrl.getNewObject())
        End Sub
        Public Sub New(ByVal obj As baseball.lib.vo.Competicion)
            InitializeComponent()

            Dim ctrl As New ctrl.ctrlCompeticionEdit
            ctrl.inicializarForm(Me)
            ctrl.cargarDatos(Me, obj)
        End Sub

        Public Sub New(ByVal obj As baseball.lib.vo.Competicion, ByVal soloconsulta As Boolean)
            MyBase.New(soloconsulta)

            InitializeComponent()

            newRecord = False

            Dim ctrl As New ctrl.ctrlCompeticionEdit
            ctrl.inicializarForm(Me)
            ctrl.cargarDatos(Me, obj)
        End Sub

        Protected Overrides Sub btAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim ctrl As New ctrl.ctrlCompeticionEdit
                ctrl.guardarDatos(Me, newRecord)

                MyBase.btAceptar_Click(sender, e)
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub InitializeComponent()
            Me.Label1 = New System.Windows.Forms.Label
            Me.txtDescripcion = New System.Windows.Forms.TextBox
            CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panFooter.SuspendLayout()
            Me.SuspendLayout()
            '
            'btAceptar
            '
            Me.btAceptar.BackColor = System.Drawing.Color.PaleGreen
            '
            'btCancelar
            '
            Me.btCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
            '
            'panFooter
            '
            Me.panFooter.Location = New System.Drawing.Point(0, 106)
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(32, 45)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(68, 14)
            Me.Label1.TabIndex = 9
            Me.Label1.Text = "Descripcion"
            '
            'txtDescripcion
            '
            Me.txtDescripcion.Location = New System.Drawing.Point(106, 42)
            Me.txtDescripcion.Name = "txtDescripcion"
            Me.txtDescripcion.Size = New System.Drawing.Size(309, 22)
            Me.txtDescripcion.TabIndex = 10
            '
            'frmCompeticionEdit
            '
            Me.ClientSize = New System.Drawing.Size(470, 149)
            Me.Controls.Add(Me.txtDescripcion)
            Me.Controls.Add(Me.Label1)
            Me.Name = "frmCompeticionEdit"
            Me.Text = "Competicion"
            Me.Controls.SetChildIndex(Me.Label1, 0)
            Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
            Me.Controls.SetChildIndex(Me.panFooter, 0)
            CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panFooter.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
    End Class
End Namespace

