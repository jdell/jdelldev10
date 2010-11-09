Namespace frm._principal
    Public Class frmPrincipal
        Inherits baseball.app.pc._template.principal.mainform

        Friend WithEvents VersionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents GeneralToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents AdministracionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents VentanaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents CascadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents HorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents VerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents AyudaEnLíneaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents sbar As System.Windows.Forms.ToolStrip
        Friend WithEvents tbar As System.Windows.Forms.ToolStrip
        Friend WithEvents btEquipoQry As System.Windows.Forms.ToolStripButton
        Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
        Private components As System.ComponentModel.IContainer
        Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents AbrirAplicaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents SalirToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents MejorasVersinoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents EquiposToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents PartidosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents JugadoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents ArbitrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents AnotadoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents TestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents PruebasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents CompeticionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents CategoriasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents DatosDePruebaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents InformesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip


        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
            Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
            Me.GeneralToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.PartidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.InformesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
            Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.AdministracionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.EquiposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.JugadoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
            Me.ArbitrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.AnotadoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator
            Me.CompeticionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.CategoriasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.VentanaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.CascadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.HorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.VerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.AyudaEnLíneaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator
            Me.MejorasVersinoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.VersionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.PruebasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.DatosDePruebaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.sbar = New System.Windows.Forms.ToolStrip
            Me.tbar = New System.Windows.Forms.ToolStrip
            Me.btEquipoQry = New System.Windows.Forms.ToolStripButton
            Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
            Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.AbrirAplicaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.SalirToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
            Me.MenuStrip1.SuspendLayout()
            Me.tbar.SuspendLayout()
            Me.ContextMenuStrip1.SuspendLayout()
            Me.SuspendLayout()
            '
            'OnLineHelp1
            '
            Me.OnLineHelp1.Location = New System.Drawing.Point(0, 425)
            Me.OnLineHelp1.Size = New System.Drawing.Size(790, 121)
            Me.OnLineHelp1.Visible = False
            '
            'MenuStrip1
            '
            Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GeneralToolStripMenuItem, Me.AdministracionToolStripMenuItem, Me.VentanaToolStripMenuItem, Me.AyudaToolStripMenuItem, Me.TestToolStripMenuItem})
            Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
            Me.MenuStrip1.Name = "MenuStrip1"
            Me.MenuStrip1.Size = New System.Drawing.Size(790, 24)
            Me.MenuStrip1.TabIndex = 1
            Me.MenuStrip1.Text = "MenuStrip1"
            '
            'GeneralToolStripMenuItem
            '
            Me.GeneralToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PartidosToolStripMenuItem, Me.InformesToolStripMenuItem, Me.ToolStripMenuItem1, Me.SalirToolStripMenuItem})
            Me.GeneralToolStripMenuItem.Name = "GeneralToolStripMenuItem"
            Me.GeneralToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
            Me.GeneralToolStripMenuItem.Text = "General"
            '
            'PartidosToolStripMenuItem
            '
            Me.PartidosToolStripMenuItem.Name = "PartidosToolStripMenuItem"
            Me.PartidosToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
            Me.PartidosToolStripMenuItem.Text = "Partidos"
            '
            'InformesToolStripMenuItem
            '
            Me.InformesToolStripMenuItem.Name = "InformesToolStripMenuItem"
            Me.InformesToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
            Me.InformesToolStripMenuItem.Text = "Informes Estadística"
            '
            'ToolStripMenuItem1
            '
            Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
            Me.ToolStripMenuItem1.Size = New System.Drawing.Size(168, 6)
            '
            'SalirToolStripMenuItem
            '
            Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
            Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
            Me.SalirToolStripMenuItem.Text = "Salir"
            '
            'AdministracionToolStripMenuItem
            '
            Me.AdministracionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EquiposToolStripMenuItem, Me.JugadoresToolStripMenuItem, Me.ToolStripMenuItem2, Me.ArbitrosToolStripMenuItem, Me.AnotadoresToolStripMenuItem, Me.ToolStripMenuItem3, Me.CompeticionesToolStripMenuItem, Me.CategoriasToolStripMenuItem})
            Me.AdministracionToolStripMenuItem.Name = "AdministracionToolStripMenuItem"
            Me.AdministracionToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
            Me.AdministracionToolStripMenuItem.Text = "Administracion"
            '
            'EquiposToolStripMenuItem
            '
            Me.EquiposToolStripMenuItem.Name = "EquiposToolStripMenuItem"
            Me.EquiposToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
            Me.EquiposToolStripMenuItem.Text = "Equipos"
            '
            'JugadoresToolStripMenuItem
            '
            Me.JugadoresToolStripMenuItem.Name = "JugadoresToolStripMenuItem"
            Me.JugadoresToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
            Me.JugadoresToolStripMenuItem.Text = "Jugadores"
            '
            'ToolStripMenuItem2
            '
            Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
            Me.ToolStripMenuItem2.Size = New System.Drawing.Size(140, 6)
            '
            'ArbitrosToolStripMenuItem
            '
            Me.ArbitrosToolStripMenuItem.Name = "ArbitrosToolStripMenuItem"
            Me.ArbitrosToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
            Me.ArbitrosToolStripMenuItem.Text = "Arbitros"
            '
            'AnotadoresToolStripMenuItem
            '
            Me.AnotadoresToolStripMenuItem.Name = "AnotadoresToolStripMenuItem"
            Me.AnotadoresToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
            Me.AnotadoresToolStripMenuItem.Text = "Anotadores"
            '
            'ToolStripMenuItem3
            '
            Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
            Me.ToolStripMenuItem3.Size = New System.Drawing.Size(140, 6)
            '
            'CompeticionesToolStripMenuItem
            '
            Me.CompeticionesToolStripMenuItem.Name = "CompeticionesToolStripMenuItem"
            Me.CompeticionesToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
            Me.CompeticionesToolStripMenuItem.Text = "Competiciones"
            '
            'CategoriasToolStripMenuItem
            '
            Me.CategoriasToolStripMenuItem.Name = "CategoriasToolStripMenuItem"
            Me.CategoriasToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
            Me.CategoriasToolStripMenuItem.Text = "Categorias"
            '
            'VentanaToolStripMenuItem
            '
            Me.VentanaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CascadaToolStripMenuItem, Me.HorizontalToolStripMenuItem, Me.VerticalToolStripMenuItem})
            Me.VentanaToolStripMenuItem.Name = "VentanaToolStripMenuItem"
            Me.VentanaToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
            Me.VentanaToolStripMenuItem.Text = "Ventana"
            '
            'CascadaToolStripMenuItem
            '
            Me.CascadaToolStripMenuItem.Image = CType(resources.GetObject("CascadaToolStripMenuItem.Image"), System.Drawing.Image)
            Me.CascadaToolStripMenuItem.Name = "CascadaToolStripMenuItem"
            Me.CascadaToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
            Me.CascadaToolStripMenuItem.Text = "Cascada"
            '
            'HorizontalToolStripMenuItem
            '
            Me.HorizontalToolStripMenuItem.Image = CType(resources.GetObject("HorizontalToolStripMenuItem.Image"), System.Drawing.Image)
            Me.HorizontalToolStripMenuItem.Name = "HorizontalToolStripMenuItem"
            Me.HorizontalToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
            Me.HorizontalToolStripMenuItem.Text = "Mosaico Horizontal"
            '
            'VerticalToolStripMenuItem
            '
            Me.VerticalToolStripMenuItem.Image = CType(resources.GetObject("VerticalToolStripMenuItem.Image"), System.Drawing.Image)
            Me.VerticalToolStripMenuItem.Name = "VerticalToolStripMenuItem"
            Me.VerticalToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
            Me.VerticalToolStripMenuItem.Text = "Mosaico Vertical"
            '
            'AyudaToolStripMenuItem
            '
            Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AcercaDeToolStripMenuItem, Me.AyudaEnLíneaToolStripMenuItem, Me.ToolStripMenuItem9, Me.MejorasVersinoToolStripMenuItem, Me.VersionToolStripMenuItem})
            Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
            Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
            Me.AyudaToolStripMenuItem.Text = "Ayuda"
            '
            'AcercaDeToolStripMenuItem
            '
            Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
            Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
            Me.AcercaDeToolStripMenuItem.Text = "acerca de"
            '
            'AyudaEnLíneaToolStripMenuItem
            '
            Me.AyudaEnLíneaToolStripMenuItem.CheckOnClick = True
            Me.AyudaEnLíneaToolStripMenuItem.Name = "AyudaEnLíneaToolStripMenuItem"
            Me.AyudaEnLíneaToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
            Me.AyudaEnLíneaToolStripMenuItem.Text = "ayuda en línea"
            Me.AyudaEnLíneaToolStripMenuItem.Visible = False
            '
            'ToolStripMenuItem9
            '
            Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
            Me.ToolStripMenuItem9.Size = New System.Drawing.Size(188, 6)
            Me.ToolStripMenuItem9.Visible = False
            '
            'MejorasVersinoToolStripMenuItem
            '
            Me.MejorasVersinoToolStripMenuItem.Name = "MejorasVersinoToolStripMenuItem"
            Me.MejorasVersinoToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
            Me.MejorasVersinoToolStripMenuItem.Text = "novedades de la version"
            Me.MejorasVersinoToolStripMenuItem.Visible = False
            '
            'VersionToolStripMenuItem
            '
            Me.VersionToolStripMenuItem.Name = "VersionToolStripMenuItem"
            Me.VersionToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
            Me.VersionToolStripMenuItem.Text = "version"
            Me.VersionToolStripMenuItem.Visible = False
            '
            'TestToolStripMenuItem
            '
            Me.TestToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PruebasToolStripMenuItem, Me.DatosDePruebaToolStripMenuItem})
            Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
            Me.TestToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
            Me.TestToolStripMenuItem.Text = "_Test_"
            Me.TestToolStripMenuItem.Visible = False
            '
            'PruebasToolStripMenuItem
            '
            Me.PruebasToolStripMenuItem.Name = "PruebasToolStripMenuItem"
            Me.PruebasToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
            Me.PruebasToolStripMenuItem.Text = "Pruebas"
            '
            'DatosDePruebaToolStripMenuItem
            '
            Me.DatosDePruebaToolStripMenuItem.Name = "DatosDePruebaToolStripMenuItem"
            Me.DatosDePruebaToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
            Me.DatosDePruebaToolStripMenuItem.Text = "Datos de prueba"
            '
            'sbar
            '
            Me.sbar.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.sbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.sbar.Location = New System.Drawing.Point(0, 546)
            Me.sbar.Name = "sbar"
            Me.sbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
            Me.sbar.Size = New System.Drawing.Size(790, 25)
            Me.sbar.TabIndex = 3
            Me.sbar.Text = "StatusStrip1"
            '
            'tbar
            '
            Me.tbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.tbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btEquipoQry})
            Me.tbar.Location = New System.Drawing.Point(0, 24)
            Me.tbar.Name = "tbar"
            Me.tbar.Size = New System.Drawing.Size(792, 25)
            Me.tbar.TabIndex = 5
            Me.tbar.Text = "ToolStrip1"
            Me.tbar.Visible = False
            '
            'btEquipoQry
            '
            Me.btEquipoQry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btEquipoQry.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btEquipoQry.Name = "btEquipoQry"
            Me.btEquipoQry.Size = New System.Drawing.Size(23, 22)
            Me.btEquipoQry.Text = "ToolStripButton1"
            '
            'NotifyIcon1
            '
            Me.NotifyIcon1.BalloonTipTitle = "BaseBall"
            Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
            Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
            Me.NotifyIcon1.Text = "NotifyIcon1"
            '
            'ContextMenuStrip1
            '
            Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirAplicaciónToolStripMenuItem, Me.SalirToolStripMenuItem1})
            Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
            Me.ContextMenuStrip1.Size = New System.Drawing.Size(147, 48)
            '
            'AbrirAplicaciónToolStripMenuItem
            '
            Me.AbrirAplicaciónToolStripMenuItem.Name = "AbrirAplicaciónToolStripMenuItem"
            Me.AbrirAplicaciónToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
            Me.AbrirAplicaciónToolStripMenuItem.Text = "Abrir aplicación"
            '
            'SalirToolStripMenuItem1
            '
            Me.SalirToolStripMenuItem1.Name = "SalirToolStripMenuItem1"
            Me.SalirToolStripMenuItem1.Size = New System.Drawing.Size(146, 22)
            Me.SalirToolStripMenuItem1.Text = "Salir"
            '
            'frmPrincipal
            '
            Me.ClientSize = New System.Drawing.Size(790, 571)
            Me.Controls.Add(Me.tbar)
            Me.Controls.Add(Me.sbar)
            Me.Controls.Add(Me.MenuStrip1)
            Me.MainMenuStrip = Me.MenuStrip1
            Me.Name = "frmPrincipal"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Baseball"
            Me.Controls.SetChildIndex(Me.MenuStrip1, 0)
            Me.Controls.SetChildIndex(Me.sbar, 0)
            Me.Controls.SetChildIndex(Me.tbar, 0)
            Me.Controls.SetChildIndex(Me.OnLineHelp1, 0)
            Me.MenuStrip1.ResumeLayout(False)
            Me.MenuStrip1.PerformLayout()
            Me.tbar.ResumeLayout(False)
            Me.tbar.PerformLayout()
            Me.ContextMenuStrip1.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Public Sub New()
            Me.InitializeComponent()
            Try
                Dim ctrl As New ctrl.ctrlPrincipal
                ctrl.inicializarForm(Me)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
            Try
                Dim vVen As New _acercade.frmAcercaDe
                vVen.ShowDialog(Me)
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub


        Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub CascadaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CascadaToolStripMenuItem.Click
            Try
                Me.LayoutMdi(MdiLayout.Cascade)
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
            Try
                Me.Close()
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub HorizontalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem.Click
            Try
                Me.LayoutMdi(MdiLayout.TileHorizontal)
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub VerticalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem.Click
            Try
                Me.LayoutMdi(MdiLayout.TileVertical)
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub frmPrincipal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
            Try
                If (e.KeyCode = Keys.Escape) Then
                    Me.Close()
                End If
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub SalirToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem1.Click
            Me.SalirToolStripMenuItem_Click(Nothing, Nothing)
        End Sub

        Private Sub AbrirAplicaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirAplicaciónToolStripMenuItem.Click
            Me.WindowState = FormWindowState.Normal
        End Sub

        Private Sub AyudaEnLíneaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AyudaEnLíneaToolStripMenuItem.Click
            Try
                Me.OnLineHelp1.Visible = Not Me.OnLineHelp1.Visible
                If (Me.OnLineHelp1.Visible) Then Me.RefreshOnLineHelp()
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub EquiposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EquiposToolStripMenuItem.Click
            Try
                Dim vVen As New equipo.frmEquipoQry
                vVen.MdiParent = Me
                vVen.Show()
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub JugadoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JugadoresToolStripMenuItem.Click
            Try
                Dim vVen As New jugador.frmJugadorQry
                vVen.MdiParent = Me
                vVen.Show()
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub ArbitrosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArbitrosToolStripMenuItem.Click
            Try
                Dim vVen As New arbitro.frmArbitroQry
                vVen.MdiParent = Me
                vVen.Show()
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub AnotadoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnotadoresToolStripMenuItem.Click
            Try
                Dim vVen As New anotador.frmAnotadorQry
                vVen.MdiParent = Me
                vVen.Show()
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub PartidosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartidosToolStripMenuItem.Click
            Try
                Dim vVen As New partido.frmPartidoQry
                vVen.MdiParent = Me
                vVen.Show()
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub PruebasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PruebasToolStripMenuItem.Click
            Try
                Dim vVen As New __test.frmTest
                vVen.MdiParent = Me
                vVen.Show()
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub CompeticionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompeticionesToolStripMenuItem.Click
            Try
                Dim vVen As New competicion.frmCompeticionQry
                vVen.MdiParent = Me
                vVen.Show()
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub CategoriasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoriasToolStripMenuItem.Click
            Try
                Dim vVen As New categoria.frmCategoriaQry
                vVen.MdiParent = Me
                vVen.Show()
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub

        Private Sub DatosDePruebaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DatosDePruebaToolStripMenuItem.Click
            Try
                '****************** EQUIPOS ********************
                Dim equipobl As [lib].bl.equipo.doAdd
                Dim equipo As [lib].vo.Equipo
                '****************** JUGADORES ********************
                Dim jugadorbl As [lib].bl.jugador.doAdd
                Dim jugador As [lib].vo.Jugador

                equipo = New [lib].vo.Equipo
                equipo.Descripcion = String.Format("{0}-{1}", equipo.GetType.Name, 1)
                equipobl = New [lib].bl.equipo.doAdd(equipo)
                equipo = equipobl.execute()

                jugador = New [lib].vo.Jugador
                jugador.Nombre = String.Format("{0}-{1}", jugador.GetType.Name, 1)
                jugador.Equipo = equipo
                jugadorbl = New [lib].bl.jugador.doAdd(jugador)
                jugadorbl.execute()

                jugador = New [lib].vo.Jugador
                jugador.Nombre = String.Format("{0}-{1}", jugador.GetType.Name, 2)
                jugador.Equipo = equipo
                jugadorbl = New [lib].bl.jugador.doAdd(jugador)
                jugadorbl.execute()


                equipo = New [lib].vo.Equipo
                equipo.Descripcion = String.Format("{0}-{1}", equipo.GetType.Name, 2)
                equipobl = New [lib].bl.equipo.doAdd(equipo)
                equipobl.execute()

                jugador = New [lib].vo.Jugador
                jugador.Nombre = String.Format("{0}-{1}", jugador.GetType.Name, 3)
                jugador.Equipo = equipo
                jugadorbl = New [lib].bl.jugador.doAdd(jugador)
                jugadorbl.execute()

                jugador = New [lib].vo.Jugador
                jugador.Nombre = String.Format("{0}-{1}", jugador.GetType.Name, 4)
                jugador.Equipo = equipo
                jugadorbl = New [lib].bl.jugador.doAdd(jugador)
                jugadorbl.execute()


                '****************** ARBITROS ********************
                Dim arbitrobl As [lib].bl.arbitro.doAdd
                Dim arbitro As [lib].vo.Arbitro

                arbitro = New [lib].vo.Arbitro
                arbitro.Nombre = String.Format("{0}-{1}", arbitro.GetType.Name, 1)
                arbitrobl = New [lib].bl.arbitro.doAdd(arbitro)
                arbitrobl.execute()

                arbitro = New [lib].vo.Arbitro
                arbitro.Nombre = String.Format("{0}-{1}", arbitro.GetType.Name, 2)
                arbitrobl = New [lib].bl.arbitro.doAdd(arbitro)
                arbitrobl.execute()

                '****************** ANOTADORES ********************
                Dim anotadorbl As [lib].bl.anotador.doAdd
                Dim anotador As [lib].vo.Anotador

                anotador = New [lib].vo.Anotador
                anotador.Nombre = String.Format("{0}-{1}", anotador.GetType.Name, 1)
                anotadorbl = New [lib].bl.anotador.doAdd(anotador)
                anotadorbl.execute()

                anotador = New [lib].vo.Anotador
                anotador.Nombre = String.Format("{0}-{1}", anotador.GetType.Name, 2)
                anotadorbl = New [lib].bl.anotador.doAdd(anotador)
                anotadorbl.execute()

                '****************** COMPETICION ********************
                Dim competicionbl As [lib].bl.competicion.doAdd
                Dim competicion As [lib].vo.Competicion

                competicion = New [lib].vo.Competicion
                competicion.Descripcion = String.Format("{0}-{1}", competicion.GetType.Name, 1)
                competicionbl = New [lib].bl.competicion.doAdd(competicion)
                competicionbl.execute()

                competicion = New [lib].vo.Competicion
                competicion.Descripcion = String.Format("{0}-{1}", competicion.GetType.Name, 2)
                competicionbl = New [lib].bl.competicion.doAdd(competicion)
                competicionbl.execute()

                '****************** CATEGORIA ********************
                Dim categoriabl As [lib].bl.categoria.doAdd
                Dim categoria As [lib].vo.Categoria

                categoria = New [lib].vo.Categoria
                categoria.Descripcion = String.Format("{0}-{1}", categoria.GetType.Name, 1)
                categoriabl = New [lib].bl.categoria.doAdd(categoria)
                categoriabl.execute()

                categoria = New [lib].vo.Categoria
                categoria.Descripcion = String.Format("{0}-{1}", categoria.GetType.Name, 2)
                categoriabl = New [lib].bl.categoria.doAdd(categoria)
                categoriabl.execute()




            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub


        Private Sub InformesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InformesToolStripMenuItem.Click
            Try
                Dim vVen As New _estadistica.frmEstadisticaPrint
                vVen.MdiParent = Me
                vVen.Show()
            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.Text)
            End Try
        End Sub
    End Class
End Namespace

