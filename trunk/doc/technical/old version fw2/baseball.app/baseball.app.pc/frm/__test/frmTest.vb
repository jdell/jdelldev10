Namespace frm.__test
    Public Class frmTest
        Inherits _template.baseballform

        Friend WithEvents HojaAnotacion1 As baseball.app.pc._template._controls.HojaAnotacion


        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Me.HojaAnotacion1 = New baseball.app.pc._template._controls.HojaAnotacion
            Me.SuspendLayout()
            '
            'HojaAnotacion1
            '
            Me.HojaAnotacion1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.HojaAnotacion1.Location = New System.Drawing.Point(0, 25)
            Me.HojaAnotacion1.Name = "HojaAnotacion1"
            Me.HojaAnotacion1.Size = New System.Drawing.Size(670, 450)
            Me.HojaAnotacion1.TabIndex = 1
            '
            'frmTest
            '
            Me.ClientSize = New System.Drawing.Size(670, 475)
            Me.Controls.Add(Me.HojaAnotacion1)
            Me.Name = "frmTest"
            Me.Controls.SetChildIndex(Me.HojaAnotacion1, 0)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
    End Class

End Namespace
