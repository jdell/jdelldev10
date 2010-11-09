Namespace _template.principal
    Public Class mainform
        'Inherits baseballform
        Inherits repsol.forms.template.principal.MainForm


        Public Sub New()
            InitializeComponent()

            'Me.menuPrincipal.MdiWindowListItem = Me.VentanaToolStripMenuItem
            'Me.Text = Application.ProductName

            'Dim titem As New ToolStripLabel(Application.ProductName & " v" & Application.ProductVersion)
            'Me.sbar.Items.Add(titem)
            'Me.OnLineHelp1.Size = New Size(300, Me.OnLineHelp1.Height)
            'Me.OnLineHelp1.Dock = DockStyle.Right
        End Sub

        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainform))
            Me.SuspendLayout()
            '
            'mainform
            '
            Me.ClientSize = New System.Drawing.Size(538, 441)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "mainform"
            Me.ResumeLayout(False)

        End Sub

        Private Sub AyudaEnLíneaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Try
                'Me.AyudaEnLíneaToolStripMenuItem.Checked = Not Me.AyudaEnLíneaToolStripMenuItem.Checked
                'Me.Helponline1.Visible = Me.AyudaEnLíneaToolStripMenuItem.Checked
                'If (Me.Helponline1.Visible) Then
                '    Me.WindowState = FormWindowState.Maximized
                '    Me.Helponline1.Size = New Size(Me.Size.Width / 3, Me.Helponline1.Size.Height)
                'End If
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Try
                Me.Close()
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Try
                Dim vVen As New acercade.aboutform
                vVen.StartPosition = FormStartPosition.CenterParent
                vVen.ShowDialog()
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        'Public Overloads Sub RefreshOnLineHelp(ByVal frmname As String)
        '    Try
        '        Me.OnLineHelp1.LoadHelp(frmname, Me.XmlDocHelpPath)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Sub
    End Class
End Namespace

