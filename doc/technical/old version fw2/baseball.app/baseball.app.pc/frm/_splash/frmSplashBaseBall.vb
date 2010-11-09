Namespace frm._splash
    Public Class frmSplashBaseBall
        Inherits repsol.forms.SplashScreen

        Public Sub New()
            MyBase.New()
            InitializeComponent()



            Dim ctrl As New ctrl.ctrlSplashBaseBall
            ctrl.inicializarForm(Me)
        End Sub

        Private Sub InitializeComponent()
            CType(Me.iconoEspera, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'GroupBox1
            '
            Me.GroupBox1.Location = New System.Drawing.Point(-20, 237)
            '
            'frmSplashBaseBall
            '
            Me.ClientSize = New System.Drawing.Size(499, 291)
            Me.Name = "frmSplashBaseBall"
            CType(Me.iconoEspera, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Public Event x()

        Public Sub Avanza(ByVal e As baseball.lib.bl._events.ProgressEventArgs)
            Me.Current = Me.Max * e.Current / e.Total
            Me.StatusDetails = e.Info
            Me.Refresh()
        End Sub

    End Class
End Namespace

