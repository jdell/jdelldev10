Namespace _template.consulta
    <Serializable()> _
    Public Class queryform
        Inherits repsol.forms.template.consulta.QueryForm

#Region "20080110: Para publicar los cambios"
        Public Event HasChanged(ByVal sender As Object, ByVal e As EventArgs)

        Public Overridable Function getVOs() As Object()
            Return Nothing
        End Function

        Protected Sub InvokeHasChanged()
            RaiseEvent HasChanged(Me, New EventArgs())
        End Sub

        Protected Sub EditHasChanged(ByVal sender As Object, ByVal e As EventArgs)
            InvokeHasChanged()
        End Sub
#End Region

        Public Sub New()
            MyBase.New()
            initForm()
        End Sub
        Public Sub New(ByVal soloconsulta As Boolean)
            MyBase.New(soloconsulta)
            initForm()
        End Sub

        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(queryform))
            Me.panInfo.SuspendLayout()
            CType(Me.dvConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'panDetail
            '
            Me.panDetail.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            '
            'panInfo
            '
            Me.panInfo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.panInfo.Location = New System.Drawing.Point(0, 127)
            '
            'panHead
            '
            Me.panHead.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            '
            'chkVerFiltro
            '
            Me.chkVerFiltro.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            '
            'queryform
            '
            Me.ClientSize = New System.Drawing.Size(792, 573)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "queryform"
            Me.Controls.SetChildIndex(Me.panHead, 0)
            Me.Controls.SetChildIndex(Me.panInfo, 0)
            Me.Controls.SetChildIndex(Me.panDetail, 0)
            Me.panInfo.ResumeLayout(False)
            Me.panInfo.PerformLayout()
            CType(Me.dvConsulta, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Private components As System.ComponentModel.IContainer

        Public ReadOnly Property ToolBar() As ToolStrip
            Get
                Return Me.tbar
            End Get
        End Property

        Private Sub initForm()
            InitializeComponent()
            Me.btFiltrar.Enabled = False
            Me.chkVerFiltro.Visible = False

            Me.btDuplicar.Visible = False
            Me.DuplicarToolStripMenuItem.Visible = False

            Me.btImprimir.Visible = True

            Me.dgConsulta.ColumnHeadersDefaultCellStyle.Font = New Font(Me.dgConsulta.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold)

            AddHandler Me.dgConsulta.DoubleClick, AddressOf dgConsulta_DoubleClick
            AddHandler Me.dgConsulta.MouseDown, AddressOf dgConsulta_MouseDown

            Me.RememberUserPreferences = True
        End Sub

        Public Sub dgConsulta_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.Modal) Then
                Me.btSeleccionar_record()
            Else
                Me.btConsulta_record()
            End If
        End Sub
        Public Sub dgConsulta_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim info As DataGridView.HitTestInfo = Me.dgConsulta.HitTest(e.X, e.Y)
            If (info.RowIndex > -1) AndAlso (info.ColumnIndex > -1) Then
                Me.dgConsulta.CurrentCell = Me.dgConsulta.Rows(info.RowIndex).Cells(info.ColumnIndex)
            End If
        End Sub

        Protected Overrides Sub btFiltrar_record()
            Me.chkVerFiltro.Checked = Me.btFiltrar.Checked
        End Sub
        Public Overrides Sub ShowDocked(ByRef c As System.Windows.Forms.Control)
            MyBase.ShowDocked(c)
            If ((c.BackColor = Color.Transparent) OrElse (c.BackColor = SystemColors.Control)) Then
                Me.tbar.RenderMode = ToolStripRenderMode.System
            End If
        End Sub

#Region "AppSetting"

        Protected Overrides Function getUserPreferences() As repsol.util.setting.userpreferences
            Dim res As New _common.settings.AppPreferences(MyBase.getUserPreferences())

            Return res
        End Function

#End Region

    End Class
End Namespace

