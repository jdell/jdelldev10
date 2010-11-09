Namespace _template._controls
    Public Class HojaAnotacion
        Inherits UserControl

        Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents haPlayer As baseball.app.pc._template._controls.HojaAnotacionPlayer
        Friend WithEvents haPitcher As baseball.app.pc._template._controls.HojaAnotacionPitcher
        Friend WithEvents haCatcher As baseball.app.pc._template._controls.HojaAnotacionCatcher

        Friend WithEvents tabHojaAnotacion As System.Windows.Forms.TabControl

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Me.tabHojaAnotacion = New System.Windows.Forms.TabControl
            Me.TabPage1 = New System.Windows.Forms.TabPage
            Me.TabPage2 = New System.Windows.Forms.TabPage
            Me.TabPage3 = New System.Windows.Forms.TabPage
            Me.haPlayer = New baseball.app.pc._template._controls.HojaAnotacionPlayer
            Me.haPitcher = New baseball.app.pc._template._controls.HojaAnotacionPitcher
            Me.haCatcher = New baseball.app.pc._template._controls.HojaAnotacionCatcher
            Me.tabHojaAnotacion.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            Me.TabPage3.SuspendLayout()
            Me.SuspendLayout()
            '
            'tabHojaAnotacion
            '
            Me.tabHojaAnotacion.Controls.Add(Me.TabPage1)
            Me.tabHojaAnotacion.Controls.Add(Me.TabPage2)
            Me.tabHojaAnotacion.Controls.Add(Me.TabPage3)
            Me.tabHojaAnotacion.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tabHojaAnotacion.Location = New System.Drawing.Point(0, 0)
            Me.tabHojaAnotacion.Name = "tabHojaAnotacion"
            Me.tabHojaAnotacion.SelectedIndex = 0
            Me.tabHojaAnotacion.Size = New System.Drawing.Size(720, 571)
            Me.tabHojaAnotacion.TabIndex = 0
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.haPlayer)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(712, 545)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Hoja Anotacion"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.haPitcher)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(712, 545)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Pitcher"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'TabPage3
            '
            Me.TabPage3.Controls.Add(Me.haCatcher)
            Me.TabPage3.Location = New System.Drawing.Point(4, 22)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage3.Size = New System.Drawing.Size(712, 545)
            Me.TabPage3.TabIndex = 2
            Me.TabPage3.Text = "Catcher"
            Me.TabPage3.UseVisualStyleBackColor = True
            '
            'HojaAnotacionPlayer1
            '
            Me.haPlayer.DataSource = Nothing
            Me.haPlayer.Dock = System.Windows.Forms.DockStyle.Fill
            Me.haPlayer.Location = New System.Drawing.Point(3, 3)
            Me.haPlayer.Name = "HojaAnotacionPlayer1"
            Me.haPlayer.Size = New System.Drawing.Size(706, 539)
            Me.haPlayer.TabIndex = 0
            '
            'HojaAnotacionPitcher1
            '
            Me.haPitcher.Dock = System.Windows.Forms.DockStyle.Fill
            Me.haPitcher.Location = New System.Drawing.Point(3, 3)
            Me.haPitcher.Name = "HojaAnotacionPitcher1"
            Me.haPitcher.Size = New System.Drawing.Size(706, 539)
            Me.haPitcher.TabIndex = 0
            '
            'HojaAnotacionCatcher1
            '
            Me.haCatcher.Dock = System.Windows.Forms.DockStyle.Fill
            Me.haCatcher.Location = New System.Drawing.Point(3, 3)
            Me.haCatcher.Name = "HojaAnotacionCatcher1"
            Me.haCatcher.Size = New System.Drawing.Size(706, 539)
            Me.haCatcher.TabIndex = 0
            '
            'HojaAnotacion
            '
            Me.Controls.Add(Me.tabHojaAnotacion)
            Me.Name = "HojaAnotacion"
            Me.Size = New System.Drawing.Size(720, 571)
            Me.tabHojaAnotacion.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.TabPage2.ResumeLayout(False)
            Me.TabPage3.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private Sub HojaAnotacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.Dock = DockStyle.Fill
        End Sub

#Region "Controller"
        Private _hoja As baseball.lib.vo.HojaAnotacion = Nothing
        Public Property DataSource() As [lib].vo.HojaAnotacion
            Get
                getNestedDataSource()
                Return _hoja
            End Get
            Set(ByVal value As [lib].vo.HojaAnotacion)
                _hoja = value
                setNestedDataSource()
            End Set
        End Property
        Private Sub setNestedDataSource()
            If (Not _hoja Is Nothing) Then
                haPlayer.DataSource = _hoja.ListaPlayer
                haPitcher.DataSource = _hoja.ListaPitcher
                haCatcher.DataSource = _hoja.ListaCatcher
            End If
        End Sub
        Private Sub getNestedDataSource()
            If (Not _hoja Is Nothing) Then
                _hoja.ListaPlayer.Clear()
                _hoja.ListaPlayer.AddRange(haPlayer.DataSource)

                _hoja.ListaPitcher.Clear()
                _hoja.ListaPitcher.AddRange(haPitcher.DataSource)

                _hoja.ListaCatcher.Clear()
                _hoja.ListaCatcher.AddRange(haCatcher.DataSource)
            End If
        End Sub
#End Region

    End Class
End Namespace
