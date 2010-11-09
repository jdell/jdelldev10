Namespace frm.partido
    Public Class frmPartidoEdit
        Inherits _template.edicion.editform

        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cmbCategoria As System.Windows.Forms.ComboBox
        Friend WithEvents txtDivision As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents cmbModalidad As System.Windows.Forms.ComboBox
        Friend WithEvents txtLocalidad As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents dateFecha As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtTerreno As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents cmbHomeClub As System.Windows.Forms.ComboBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents cmbVisitante As System.Windows.Forms.ComboBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents cmbArbitro1 As System.Windows.Forms.ComboBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents cmbArbitro2 As System.Windows.Forms.ComboBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents cmbArbitro3 As System.Windows.Forms.ComboBox
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents cmbArbitro4 As System.Windows.Forms.ComboBox
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents cmbAnotador As System.Windows.Forms.ComboBox
        Friend WithEvents txtAmonestaciones As System.Windows.Forms.TextBox
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents txtExpulsiones As System.Windows.Forms.TextBox
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents cmbCompeticion As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label


        Public Sub New()
            InitializeComponent()

            Dim ctrl As New ctrl.ctrlPartidoEdit
            ctrl.inicializarForm(Me)
            ctrl.cargarDatos(Me, ctrl.getNewObject())
        End Sub
        Public Sub New(ByVal obj As baseball.lib.vo.Partido)
            InitializeComponent()

            Dim ctrl As New ctrl.ctrlPartidoEdit
            ctrl.inicializarForm(Me)
            ctrl.cargarDatos(Me, obj)
        End Sub

        Public Sub New(ByVal obj As baseball.lib.vo.Partido, ByVal soloconsulta As Boolean)
            MyBase.New(soloconsulta)

            InitializeComponent()

            newRecord = False

            Dim ctrl As New ctrl.ctrlPartidoEdit
            ctrl.inicializarForm(Me)
            ctrl.cargarDatos(Me, obj)
        End Sub

        Protected Overrides Sub btAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim ctrl As New ctrl.ctrlPartidoEdit
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
            Me.Label4 = New System.Windows.Forms.Label
            Me.cmbCategoria = New System.Windows.Forms.ComboBox
            Me.txtDivision = New System.Windows.Forms.TextBox
            Me.Label2 = New System.Windows.Forms.Label
            Me.Label3 = New System.Windows.Forms.Label
            Me.cmbModalidad = New System.Windows.Forms.ComboBox
            Me.txtLocalidad = New System.Windows.Forms.TextBox
            Me.Label5 = New System.Windows.Forms.Label
            Me.dateFecha = New System.Windows.Forms.DateTimePicker
            Me.Label6 = New System.Windows.Forms.Label
            Me.txtTerreno = New System.Windows.Forms.TextBox
            Me.Label7 = New System.Windows.Forms.Label
            Me.Label8 = New System.Windows.Forms.Label
            Me.cmbHomeClub = New System.Windows.Forms.ComboBox
            Me.Label9 = New System.Windows.Forms.Label
            Me.cmbVisitante = New System.Windows.Forms.ComboBox
            Me.Label10 = New System.Windows.Forms.Label
            Me.cmbArbitro1 = New System.Windows.Forms.ComboBox
            Me.Label11 = New System.Windows.Forms.Label
            Me.cmbArbitro2 = New System.Windows.Forms.ComboBox
            Me.Label12 = New System.Windows.Forms.Label
            Me.cmbArbitro3 = New System.Windows.Forms.ComboBox
            Me.Label13 = New System.Windows.Forms.Label
            Me.cmbArbitro4 = New System.Windows.Forms.ComboBox
            Me.Label14 = New System.Windows.Forms.Label
            Me.cmbAnotador = New System.Windows.Forms.ComboBox
            Me.txtAmonestaciones = New System.Windows.Forms.TextBox
            Me.Label15 = New System.Windows.Forms.Label
            Me.txtExpulsiones = New System.Windows.Forms.TextBox
            Me.Label16 = New System.Windows.Forms.Label
            Me.txtObservaciones = New System.Windows.Forms.TextBox
            Me.Label17 = New System.Windows.Forms.Label
            Me.cmbCompeticion = New System.Windows.Forms.ComboBox
            CType(Me.errProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panFooter.SuspendLayout()
            Me.SuspendLayout()
            '
            'btAceptar
            '
            Me.btAceptar.BackColor = System.Drawing.Color.PaleGreen
            Me.btAceptar.Location = New System.Drawing.Point(501, 8)
            '
            'btCancelar
            '
            Me.btCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.btCancelar.Location = New System.Drawing.Point(582, 8)
            '
            'panFooter
            '
            Me.panFooter.Location = New System.Drawing.Point(0, 480)
            Me.panFooter.Size = New System.Drawing.Size(669, 43)
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(18, 49)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(74, 14)
            Me.Label1.TabIndex = 9
            Me.Label1.Text = "Competicion"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(18, 77)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(58, 14)
            Me.Label4.TabIndex = 18
            Me.Label4.Text = "Categoria"
            '
            'cmbCategoria
            '
            Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCategoria.FormattingEnabled = True
            Me.cmbCategoria.Location = New System.Drawing.Point(92, 74)
            Me.cmbCategoria.Name = "cmbCategoria"
            Me.cmbCategoria.Size = New System.Drawing.Size(134, 22)
            Me.cmbCategoria.TabIndex = 17
            '
            'txtDivision
            '
            Me.txtDivision.Location = New System.Drawing.Point(294, 74)
            Me.txtDivision.Name = "txtDivision"
            Me.txtDivision.Size = New System.Drawing.Size(134, 22)
            Me.txtDivision.TabIndex = 20
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(242, 77)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(46, 14)
            Me.Label2.TabIndex = 19
            Me.Label2.Text = "División"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(442, 77)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(60, 14)
            Me.Label3.TabIndex = 22
            Me.Label3.Text = "Modalidad"
            '
            'cmbModalidad
            '
            Me.cmbModalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbModalidad.FormattingEnabled = True
            Me.cmbModalidad.Location = New System.Drawing.Point(516, 74)
            Me.cmbModalidad.Name = "cmbModalidad"
            Me.cmbModalidad.Size = New System.Drawing.Size(134, 22)
            Me.cmbModalidad.TabIndex = 21
            '
            'txtLocalidad
            '
            Me.txtLocalidad.Location = New System.Drawing.Point(92, 102)
            Me.txtLocalidad.Name = "txtLocalidad"
            Me.txtLocalidad.Size = New System.Drawing.Size(336, 22)
            Me.txtLocalidad.TabIndex = 24
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(18, 105)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(56, 14)
            Me.Label5.TabIndex = 23
            Me.Label5.Text = "Localidad"
            '
            'dateFecha
            '
            Me.dateFecha.CustomFormat = "dd/MM/yyyy - HH:mm"
            Me.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dateFecha.Location = New System.Drawing.Point(516, 102)
            Me.dateFecha.Name = "dateFecha"
            Me.dateFecha.Size = New System.Drawing.Size(134, 22)
            Me.dateFecha.TabIndex = 25
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(442, 106)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(39, 14)
            Me.Label6.TabIndex = 26
            Me.Label6.Text = "Fecha"
            '
            'txtTerreno
            '
            Me.txtTerreno.Location = New System.Drawing.Point(128, 130)
            Me.txtTerreno.Name = "txtTerreno"
            Me.txtTerreno.Size = New System.Drawing.Size(522, 22)
            Me.txtTerreno.TabIndex = 28
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(18, 133)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(104, 14)
            Me.Label7.TabIndex = 27
            Me.Label7.Text = "Terreno de juego"
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(18, 161)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(62, 14)
            Me.Label8.TabIndex = 30
            Me.Label8.Text = "HomeClub"
            '
            'cmbHomeClub
            '
            Me.cmbHomeClub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbHomeClub.FormattingEnabled = True
            Me.cmbHomeClub.Location = New System.Drawing.Point(113, 158)
            Me.cmbHomeClub.Name = "cmbHomeClub"
            Me.cmbHomeClub.Size = New System.Drawing.Size(215, 22)
            Me.cmbHomeClub.TabIndex = 29
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(340, 161)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(54, 14)
            Me.Label9.TabIndex = 32
            Me.Label9.Text = "Visitante"
            '
            'cmbVisitante
            '
            Me.cmbVisitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbVisitante.FormattingEnabled = True
            Me.cmbVisitante.Location = New System.Drawing.Point(414, 158)
            Me.cmbVisitante.Name = "cmbVisitante"
            Me.cmbVisitante.Size = New System.Drawing.Size(236, 22)
            Me.cmbVisitante.TabIndex = 31
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(18, 189)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(91, 14)
            Me.Label10.TabIndex = 34
            Me.Label10.Text = "Arbitro Principal"
            '
            'cmbArbitro1
            '
            Me.cmbArbitro1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbArbitro1.FormattingEnabled = True
            Me.cmbArbitro1.Location = New System.Drawing.Point(113, 186)
            Me.cmbArbitro1.Name = "cmbArbitro1"
            Me.cmbArbitro1.Size = New System.Drawing.Size(215, 22)
            Me.cmbArbitro1.TabIndex = 33
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(340, 189)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(94, 14)
            Me.Label11.TabIndex = 36
            Me.Label11.Text = "Arbitro 1ra base"
            '
            'cmbArbitro2
            '
            Me.cmbArbitro2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbArbitro2.FormattingEnabled = True
            Me.cmbArbitro2.Location = New System.Drawing.Point(440, 186)
            Me.cmbArbitro2.Name = "cmbArbitro2"
            Me.cmbArbitro2.Size = New System.Drawing.Size(210, 22)
            Me.cmbArbitro2.TabIndex = 35
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(18, 217)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(97, 14)
            Me.Label12.TabIndex = 38
            Me.Label12.Text = "Arbitro 2da base"
            '
            'cmbArbitro3
            '
            Me.cmbArbitro3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbArbitro3.FormattingEnabled = True
            Me.cmbArbitro3.Location = New System.Drawing.Point(113, 214)
            Me.cmbArbitro3.Name = "cmbArbitro3"
            Me.cmbArbitro3.Size = New System.Drawing.Size(215, 22)
            Me.cmbArbitro3.TabIndex = 37
            '
            'Label13
            '
            Me.Label13.AutoSize = True
            Me.Label13.Location = New System.Drawing.Point(340, 217)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(94, 14)
            Me.Label13.TabIndex = 40
            Me.Label13.Text = "Arbitro 3ra base"
            '
            'cmbArbitro4
            '
            Me.cmbArbitro4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbArbitro4.FormattingEnabled = True
            Me.cmbArbitro4.Location = New System.Drawing.Point(440, 214)
            Me.cmbArbitro4.Name = "cmbArbitro4"
            Me.cmbArbitro4.Size = New System.Drawing.Size(210, 22)
            Me.cmbArbitro4.TabIndex = 39
            '
            'Label14
            '
            Me.Label14.AutoSize = True
            Me.Label14.Location = New System.Drawing.Point(18, 245)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(58, 14)
            Me.Label14.TabIndex = 42
            Me.Label14.Text = "Anotador"
            '
            'cmbAnotador
            '
            Me.cmbAnotador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbAnotador.FormattingEnabled = True
            Me.cmbAnotador.Location = New System.Drawing.Point(113, 242)
            Me.cmbAnotador.Name = "cmbAnotador"
            Me.cmbAnotador.Size = New System.Drawing.Size(215, 22)
            Me.cmbAnotador.TabIndex = 41
            '
            'txtAmonestaciones
            '
            Me.txtAmonestaciones.Location = New System.Drawing.Point(113, 270)
            Me.txtAmonestaciones.Multiline = True
            Me.txtAmonestaciones.Name = "txtAmonestaciones"
            Me.txtAmonestaciones.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.txtAmonestaciones.Size = New System.Drawing.Size(537, 57)
            Me.txtAmonestaciones.TabIndex = 44
            '
            'Label15
            '
            Me.Label15.AutoSize = True
            Me.Label15.Location = New System.Drawing.Point(18, 273)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(96, 14)
            Me.Label15.TabIndex = 43
            Me.Label15.Text = "Amonestaciones"
            '
            'txtExpulsiones
            '
            Me.txtExpulsiones.Location = New System.Drawing.Point(113, 333)
            Me.txtExpulsiones.Multiline = True
            Me.txtExpulsiones.Name = "txtExpulsiones"
            Me.txtExpulsiones.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.txtExpulsiones.Size = New System.Drawing.Size(537, 57)
            Me.txtExpulsiones.TabIndex = 46
            '
            'Label16
            '
            Me.Label16.AutoSize = True
            Me.Label16.Location = New System.Drawing.Point(18, 336)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(69, 14)
            Me.Label16.TabIndex = 45
            Me.Label16.Text = "Expulsiones"
            '
            'txtObservaciones
            '
            Me.txtObservaciones.Location = New System.Drawing.Point(113, 400)
            Me.txtObservaciones.Multiline = True
            Me.txtObservaciones.Name = "txtObservaciones"
            Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.txtObservaciones.Size = New System.Drawing.Size(537, 57)
            Me.txtObservaciones.TabIndex = 48
            '
            'Label17
            '
            Me.Label17.AutoSize = True
            Me.Label17.Location = New System.Drawing.Point(18, 403)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(85, 14)
            Me.Label17.TabIndex = 47
            Me.Label17.Text = "Observaciones"
            '
            'cmbCompeticion
            '
            Me.cmbCompeticion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCompeticion.FormattingEnabled = True
            Me.cmbCompeticion.Location = New System.Drawing.Point(92, 46)
            Me.cmbCompeticion.Name = "cmbCompeticion"
            Me.cmbCompeticion.Size = New System.Drawing.Size(558, 22)
            Me.cmbCompeticion.TabIndex = 49
            '
            'frmPartidoEdit
            '
            Me.ClientSize = New System.Drawing.Size(669, 523)
            Me.Controls.Add(Me.cmbCompeticion)
            Me.Controls.Add(Me.cmbArbitro3)
            Me.Controls.Add(Me.txtObservaciones)
            Me.Controls.Add(Me.Label17)
            Me.Controls.Add(Me.txtExpulsiones)
            Me.Controls.Add(Me.Label16)
            Me.Controls.Add(Me.txtAmonestaciones)
            Me.Controls.Add(Me.Label15)
            Me.Controls.Add(Me.Label14)
            Me.Controls.Add(Me.cmbAnotador)
            Me.Controls.Add(Me.Label13)
            Me.Controls.Add(Me.cmbArbitro4)
            Me.Controls.Add(Me.Label12)
            Me.Controls.Add(Me.Label11)
            Me.Controls.Add(Me.cmbArbitro2)
            Me.Controls.Add(Me.Label10)
            Me.Controls.Add(Me.cmbArbitro1)
            Me.Controls.Add(Me.Label9)
            Me.Controls.Add(Me.cmbVisitante)
            Me.Controls.Add(Me.Label8)
            Me.Controls.Add(Me.cmbHomeClub)
            Me.Controls.Add(Me.txtTerreno)
            Me.Controls.Add(Me.Label7)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.dateFecha)
            Me.Controls.Add(Me.txtLocalidad)
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.cmbModalidad)
            Me.Controls.Add(Me.txtDivision)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.cmbCategoria)
            Me.Controls.Add(Me.Label1)
            Me.Name = "frmPartidoEdit"
            Me.Text = "Partido"
            Me.Controls.SetChildIndex(Me.Label1, 0)
            Me.Controls.SetChildIndex(Me.panFooter, 0)
            Me.Controls.SetChildIndex(Me.cmbCategoria, 0)
            Me.Controls.SetChildIndex(Me.Label4, 0)
            Me.Controls.SetChildIndex(Me.Label2, 0)
            Me.Controls.SetChildIndex(Me.txtDivision, 0)
            Me.Controls.SetChildIndex(Me.cmbModalidad, 0)
            Me.Controls.SetChildIndex(Me.Label3, 0)
            Me.Controls.SetChildIndex(Me.Label5, 0)
            Me.Controls.SetChildIndex(Me.txtLocalidad, 0)
            Me.Controls.SetChildIndex(Me.dateFecha, 0)
            Me.Controls.SetChildIndex(Me.Label6, 0)
            Me.Controls.SetChildIndex(Me.Label7, 0)
            Me.Controls.SetChildIndex(Me.txtTerreno, 0)
            Me.Controls.SetChildIndex(Me.cmbHomeClub, 0)
            Me.Controls.SetChildIndex(Me.Label8, 0)
            Me.Controls.SetChildIndex(Me.cmbVisitante, 0)
            Me.Controls.SetChildIndex(Me.Label9, 0)
            Me.Controls.SetChildIndex(Me.cmbArbitro1, 0)
            Me.Controls.SetChildIndex(Me.Label10, 0)
            Me.Controls.SetChildIndex(Me.cmbArbitro2, 0)
            Me.Controls.SetChildIndex(Me.Label11, 0)
            Me.Controls.SetChildIndex(Me.Label12, 0)
            Me.Controls.SetChildIndex(Me.cmbArbitro4, 0)
            Me.Controls.SetChildIndex(Me.Label13, 0)
            Me.Controls.SetChildIndex(Me.cmbAnotador, 0)
            Me.Controls.SetChildIndex(Me.Label14, 0)
            Me.Controls.SetChildIndex(Me.Label15, 0)
            Me.Controls.SetChildIndex(Me.txtAmonestaciones, 0)
            Me.Controls.SetChildIndex(Me.Label16, 0)
            Me.Controls.SetChildIndex(Me.txtExpulsiones, 0)
            Me.Controls.SetChildIndex(Me.Label17, 0)
            Me.Controls.SetChildIndex(Me.txtObservaciones, 0)
            Me.Controls.SetChildIndex(Me.cmbArbitro3, 0)
            Me.Controls.SetChildIndex(Me.cmbCompeticion, 0)
            CType(Me.errProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panFooter.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

    End Class
End Namespace

