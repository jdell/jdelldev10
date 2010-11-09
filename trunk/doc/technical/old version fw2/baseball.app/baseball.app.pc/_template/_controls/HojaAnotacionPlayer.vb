Namespace _template._controls
    Public Class HojaAnotacionPlayer
        Inherits FormatoHoja

        Public Sub New()
            InitializeComponent()
        End Sub


        Private Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'HojaAnotacionPlayer
            '
            Me.Name = "HojaAnotacionPlayer"
            Me.Size = New System.Drawing.Size(1274, 675)
            Me.ResumeLayout(False)

        End Sub

#Region "Controller"
        Public Overloads Property DataSource() As List(Of [lib].vo.HojaAnotacionPlayer)
            Get
                Return MyBase.DataSource
            End Get
            Set(ByVal value As List(Of [lib].vo.HojaAnotacionPlayer))
                MyBase.DataSource = value
            End Set
        End Property
        Protected Overrides Sub SetGridStyle()
            Try
                Dim list As List(Of [lib].vo.HojaAnotacionPlayer) = Me._datasource
                If (list Is Nothing) Then list = New List(Of [lib].vo.HojaAnotacionPlayer)

                Me.dg.DataSource = ListVOToDataView(list)
                setEstiloGridRegistros()

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.ParentForm.Text)
            End Try
        End Sub

        Protected Overrides Function ListVOToDataView(ByVal listObject As Object) As System.Data.DataView
            Try
                Dim res As New DataView

                Dim dt As New DataTable(GetType(baseball.lib.vo.HojaAnotacionPlayer).FullName)
                dt.Columns.Add("Id", GetType(Int16))
                dt.Columns.Add("O", GetType(Int16))
                dt.Columns.Add("A", GetType(Int16))
                dt.Columns.Add("E", GetType(Int16))
                dt.Columns.Add("DP_Def", GetType(Int16))
                dt.Columns.Add("EJ", GetType(Int16))
                dt.Columns.Add("Jugador", GetType(baseball.lib.vo.Jugador))
                dt.Columns.Add("TB", GetType(Int16))
                dt.Columns.Add("V", GetType(Int16))
                dt.Columns.Add("C", GetType(Int16))
                dt.Columns.Add("H1", GetType(Int16))
                dt.Columns.Add("H2", GetType(Int16))
                dt.Columns.Add("H3", GetType(Int16))
                dt.Columns.Add("HR", GetType(Int16))
                dt.Columns.Add("BH", GetType(Int16))
                dt.Columns.Add("DP", GetType(Int16))
                dt.Columns.Add("SH", GetType(Int16))
                dt.Columns.Add("SF", GetType(Int16))
                dt.Columns.Add("B", GetType(Int16))
                dt.Columns.Add("BI", GetType(Int16))
                dt.Columns.Add("GL", GetType(Int16))
                dt.Columns.Add("IO", GetType(Int16))
                dt.Columns.Add("R", GetType(Int16))
                dt.Columns.Add("CR", GetType(Int16))
                dt.Columns.Add("K", GetType(Int16))
                dt.Columns.Add("CI", GetType(Int16))

                dt.Columns.Add("objVO", GetType(baseball.lib.vo.HojaAnotacionPlayer))

                For Each obj As baseball.lib.vo.HojaAnotacionPlayer In listObject
                    Dim dr As DataRow = dt.NewRow

                    dr("Id") = obj.Id
                    dr("O") = obj.O
                    dr("A") = obj.A
                    dr("E") = obj.E
                    dr("DP_Def") = obj.DP_Def
                    dr("EJ") = obj.EJ
                    dr("Jugador") = obj.Jugador
                    dr("TB") = obj.TB
                    dr("V") = obj.V
                    dr("C") = obj.C
                    dr("H1") = obj.H1
                    dr("H2") = obj.H2
                    dr("H3") = obj.H3
                    dr("HR") = obj.HR
                    dr("BH") = obj.BH
                    dr("DP") = obj.DP
                    dr("SH") = obj.SH
                    dr("SF") = obj.SF
                    dr("B") = obj.B
                    dr("BI") = obj.BI
                    dr("GL") = obj.GL
                    dr("IO") = obj.IO
                    dr("R") = obj.R
                    dr("CR") = obj.CR
                    dr("K") = obj.K
                    dr("CI") = obj.CI
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

                cname = "O"
                Me.dg.Columns(cname).HeaderText = "O"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "A"
                Me.dg.Columns(cname).HeaderText = "A"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "E"
                Me.dg.Columns(cname).HeaderText = "E"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "EJ"
                Me.dg.Columns(cname).HeaderText = "EJ"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "DP_Def"
                Me.dg.Columns(cname).HeaderText = "DP"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "Jugador"
                Me.dg.Columns(cname).HeaderText = "Jugador"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                'Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Me.dg.Columns(cname).Width = 250
                Me.dg.Columns(cname).ReadOnly = True

                cname = "TB"
                Me.dg.Columns(cname).HeaderText = "TB"
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

                cname = "BH"
                Me.dg.Columns(cname).HeaderText = "BH"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "DP"
                Me.dg.Columns(cname).HeaderText = "DP"
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

                cname = "R"
                Me.dg.Columns(cname).HeaderText = "R"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "CR"
                Me.dg.Columns(cname).HeaderText = "CR"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "K"
                Me.dg.Columns(cname).HeaderText = "K"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                cname = "CI"
                Me.dg.Columns(cname).HeaderText = "CI"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells


            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Protected Overrides Function DataViewToListVO(ByVal dvObject As System.Data.DataView) As Object
            Try
                Dim res As New List(Of [lib].vo.HojaAnotacionPlayer)
                Dim tipo As Type = GetType(baseball.lib.vo.HojaAnotacionPlayer)
                For Each dr As DataGridViewRow In Me.dg.Rows
                    Dim player As New [lib].vo.HojaAnotacionPlayer
                    For Each dc As DataGridViewColumn In Me.dg.Columns
                        Dim prop As Reflection.PropertyInfo = tipo.GetProperty(dc.Name)
                        If (Not prop Is Nothing) Then prop.SetValue(player, dr.Cells(dc.Name).Value, Nothing)
                    Next
                    res.Add(player)
                Next
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

    End Class
End Namespace
