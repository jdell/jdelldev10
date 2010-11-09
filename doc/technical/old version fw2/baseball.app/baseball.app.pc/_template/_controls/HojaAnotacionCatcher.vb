Namespace _template._controls
    Public Class HojaAnotacionCatcher
        Inherits FormatoHoja

        Private Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'HojaAnotacionCatcher
            '
            Me.Name = "HojaAnotacionCatcher"
            Me.Size = New System.Drawing.Size(1274, 675)
            Me.ResumeLayout(False)

        End Sub

        Public Sub New()
            InitializeComponent()
        End Sub

#Region "Controller"
        Public Overloads Property DataSource() As List(Of [lib].vo.HojaAnotacionCatcher)
            Get
                Return MyBase.DataSource
            End Get
            Set(ByVal value As List(Of [lib].vo.HojaAnotacionCatcher))
                MyBase.DataSource = value
            End Set
        End Property
        Protected Overrides Sub SetGridStyle()
            Try
                Dim list As List(Of [lib].vo.HojaAnotacionCatcher) = Me._datasource
                If (list Is Nothing) Then list = New List(Of [lib].vo.HojaAnotacionCatcher)

                Me.dg.DataSource = ListVOToDataView(list)
                setEstiloGridRegistros()

            Catch ex As Exception
                repsol.util.messages.ShowError(ex.Message, Me.ParentForm.Text)
            End Try
        End Sub

        Protected Overrides Function ListVOToDataView(ByVal listObject As Object) As System.Data.DataView
            Try
                Dim res As New DataView

                Dim dt As New DataTable(GetType(baseball.lib.vo.HojaAnotacionCatcher).FullName)
                dt.Columns.Add("Id", GetType(Int16))
                dt.Columns.Add("Jugador", GetType(baseball.lib.vo.Jugador))
                dt.Columns.Add("PB", GetType(Int16))
                dt.Columns.Add("R", GetType(Int16))
                dt.Columns.Add("CR", GetType(Int16))


                For Each obj As baseball.lib.vo.HojaAnotacionCatcher In listObject
                    Dim dr As DataRow = dt.NewRow

                    dr("Id") = obj.Id
                    dr("PB") = obj.PB
                    dr("R") = obj.R
                    dr("CR") = obj.CR
                    dr("Jugador") = obj.Jugador

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

                Me.dg.Columns("Id").Visible = False

                Dim cname As String = String.Empty

                cname = "PB"
                Me.dg.Columns(cname).HeaderText = "PB"
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

                cname = "Jugador"
                Me.dg.Columns(cname).HeaderText = "Jugador"
                Me.dg.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Me.dg.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                'Me.dg.Columns(cname).Width = 200
                Me.dg.Columns(cname).ReadOnly = True

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Protected Overrides Function DataViewToListVO(ByVal dvObject As System.Data.DataView) As Object
            Try
                Dim res As New List(Of [lib].vo.HojaAnotacionCatcher)
                Dim tipo As Type = GetType(baseball.lib.vo.HojaAnotacionCatcher)
                For Each dr As DataGridViewRow In Me.dg.Rows
                    Dim catcher As New [lib].vo.HojaAnotacionCatcher
                    For Each dc As DataGridViewColumn In Me.dg.Columns
                        Dim prop As Reflection.PropertyInfo = tipo.GetProperty(dc.Name)
                        If (Not prop Is Nothing) Then prop.SetValue(catcher, dr.Cells(dc.Name).Value, Nothing)
                    Next
                    res.Add(catcher)
                Next
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region
    End Class
End Namespace
