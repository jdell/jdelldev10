Namespace _template._controls
    Public Class HojaAnotacionPitcher
        Inherits FormatoHoja


        Private Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'HojaAnotacionPitcher
            '
            Me.Name = "HojaAnotacionPitcher"
            Me.Size = New System.Drawing.Size(1274, 675)
            Me.ResumeLayout(False)

        End Sub

        Public Sub New()
            InitializeComponent()
        End Sub

#Region "Controller"
        Public Overloads Property DataSource() As List(Of [lib].vo.HojaAnotacionPitcher)
            Get
                Return MyBase.DataSource
            End Get
            Set(ByVal value As List(Of [lib].vo.HojaAnotacionPitcher))
                MyBase.DataSource = value
            End Set
        End Property
        Protected Overrides Sub SetGridStyle()
            Try
                Dim list As List(Of [lib].vo.HojaAnotacionPitcher) = Me._datasource
                If (list Is Nothing) Then list = New List(Of [lib].vo.HojaAnotacionPitcher)

                Me.dg.DataSource = ListVOToDataView(list)
                setEstiloGridRegistros()

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.ParentForm.Text)
            End Try
        End Sub

        Protected Overrides Function ListVOToDataView(ByVal listObject As Object) As System.Data.DataView
            Try
                Dim res As New DataView

                Dim dt As New DataTable(GetType(baseball.lib.vo.HojaAnotacionPitcher).FullName)
                dt.Columns.Add("Id", GetType(Int16))
                dt.Columns.Add("Jugador", GetType(baseball.lib.vo.Jugador))
                dt.Columns.Add("Labor", GetType(String))
                dt.Columns.Add("BE", GetType(Int16))
                dt.Columns.Add("V", GetType(Int16))
                dt.Columns.Add("C", GetType(Int16))
                dt.Columns.Add("CL", GetType(Int16))
                dt.Columns.Add("H1", GetType(Int16))
                dt.Columns.Add("H2", GetType(Int16))
                dt.Columns.Add("H3", GetType(Int16))
                dt.Columns.Add("HR", GetType(Int16))
                dt.Columns.Add("SH", GetType(Int16))
                dt.Columns.Add("SF", GetType(Int16))
                dt.Columns.Add("B", GetType(Int16))
                dt.Columns.Add("BI", GetType(Int16))
                dt.Columns.Add("GL", GetType(Int16))
                dt.Columns.Add("IO", GetType(Int16))
                dt.Columns.Add("K", GetType(Int16))
                dt.Columns.Add("WP", GetType(Int16))
                dt.Columns.Add("BK", GetType(Int16))

                dt.Columns.Add("objVO", GetType(baseball.lib.vo.HojaAnotacionPitcher))

                For Each obj As baseball.lib.vo.HojaAnotacionPitcher In listObject
                    Dim dr As DataRow = dt.NewRow

                    dr("Id") = obj.Id
                    dr("Jugador") = obj.Jugador
                    dr("Labor") = obj.Labor
                    dr("BE") = obj.BE
                    dr("V") = obj.V
                    dr("C") = obj.C
                    dr("CL") = obj.CL
                    dr("H1") = obj.H1
                    dr("H2") = obj.H2
                    dr("H3") = obj.H3
                    dr("HR") = obj.HR
                    dr("SH") = obj.SH
                    dr("SF") = obj.SF
                    dr("B") = obj.B
                    dr("BI") = obj.BI
                    dr("GL") = obj.GL
                    dr("IO") = obj.IO
                    dr("K") = obj.K
                    dr("WP") = obj.WP
                    dr("BK") = obj.BK
                    dr("objVO") = obj

                    dt.Rows.Add(dr)
                Next

                res.Table = dt

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Protected Overrides Sub setEstiloGridRegistros()
            Try
                Me.dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

                Me.dg.Columns("objVO").Visible = False
                Me.dg.Columns("Id").Visible = False

                Dim cname As String = String.Empty

                cname = "Jugador"
                Me.dg.Columns(cname).HeaderText = "Jugador"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                'Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Me.dg.Columns(cname).Width = 250
                Me.dg.Columns(cname).ReadOnly = True

                cname = "Labor"
                Me.dg.Columns(cname).HeaderText = "Labor"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Me.dg.Columns(cname).Visible = False

                cname = "BE"
                Me.dg.Columns(cname).HeaderText = "BE"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "V"
                Me.dg.Columns(cname).HeaderText = "V"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "C"
                Me.dg.Columns(cname).HeaderText = "C"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "CL"
                Me.dg.Columns(cname).HeaderText = "CL"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "H1"
                Me.dg.Columns(cname).HeaderText = "H"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "H2"
                Me.dg.Columns(cname).HeaderText = "2H"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "H3"
                Me.dg.Columns(cname).HeaderText = "3H"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "HR"
                Me.dg.Columns(cname).HeaderText = "HR"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "SH"
                Me.dg.Columns(cname).HeaderText = "SH"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "SF"
                Me.dg.Columns(cname).HeaderText = "SF"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "B"
                Me.dg.Columns(cname).HeaderText = "B"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "BI"
                Me.dg.Columns(cname).HeaderText = "BI"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "GL"
                Me.dg.Columns(cname).HeaderText = "GL"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "IO"
                Me.dg.Columns(cname).HeaderText = "IO"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "K"
                Me.dg.Columns(cname).HeaderText = "K"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "WP"
                Me.dg.Columns(cname).HeaderText = "WP"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "BK"
                Me.dg.Columns(cname).HeaderText = "BK"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells


            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Protected Overrides Function DataViewToListVO(ByVal dvObject As System.Data.DataView) As Object
            Try
                Dim res As New List(Of [lib].vo.HojaAnotacionPitcher)
                Dim tipo As Type = GetType(baseball.lib.vo.HojaAnotacionPitcher)
                For Each dr As DataGridViewRow In Me.dg.Rows
                    Dim pitcher As New [lib].vo.HojaAnotacionPitcher
                    For Each dc As DataGridViewColumn In Me.dg.Columns
                        Dim prop As Reflection.PropertyInfo = tipo.GetProperty(dc.Name)
                        If (Not prop Is Nothing) Then
                            If (dc.Name <> "Labor") Then
                                prop.SetValue(pitcher, dr.Cells(dc.Name).Value, Nothing)
                            Else
                                Dim en As [lib].vo.tLABORPITCHER = System.Enum.Parse(GetType([lib].vo.tLABORPITCHER), dr.Cells(dc.Name).Value)
                                prop.SetValue(pitcher, en, Nothing)
                            End If
                        End If
                    Next
                    res.Add(pitcher)
                Next
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

    End Class
End Namespace
