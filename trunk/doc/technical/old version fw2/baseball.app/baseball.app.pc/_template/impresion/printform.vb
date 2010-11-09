Namespace _template.impresion
    Public Class printform
        'Inherits baseballform
        Inherits repsol.forms.template.informe.ReportForm

        'Protected WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
        'Public WithEvents viewer As Microsoft.Reporting.WinForms.ReportViewer

        Private _hasParameters As Boolean

        Public Sub New()
            MyBase.New()
            InitializeComponent()

            Me.RememberUserPreferences = True
        End Sub
        Public Sub New(ByVal hasParameters As Boolean)
            MyBase.New(hasParameters)
            InitializeComponent()

            Me.RememberUserPreferences = True
        End Sub

        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(printform))
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
            Me.SplitContainer1.Size = New System.Drawing.Size(792, 541)
            '
            'viewer
            '
            Me.viewer.ShowPrintButton = False
            Me.viewer.Size = New System.Drawing.Size(792, 541)
            '
            'printform
            '
            Me.ClientSize = New System.Drawing.Size(792, 566)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "printform"
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            Me.SplitContainer1.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Private Sub btRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Cursor = Cursors.WaitCursor
            VerInforme()
            Cursor = Cursors.Default
        End Sub

#Region "AppSetting"

        Protected Overrides Function getUserPreferences() As repsol.util.setting.userpreferences
            Dim res As New _common.settings.AppPreferences(MyBase.getUserPreferences())

            Return res
        End Function

#End Region

    End Class
End Namespace

