Namespace frm.jugador.ctrl
    Public Class ctrlJugadorQry
        Inherits _template.consulta.ctrl.queryctrl

        Private _vista As frmJugadorQry
        Public Overrides Function BorrarRegistro(ByRef frm As repsol.forms.template.consulta.QueryForm) As Object
            Try
                _vista = frm

                Dim obj As baseball.lib.vo.Jugador = Me.DataGridViewRowToVO(Me._vista.dgConsulta.CurrentRow)

                Dim acc As New baseball.lib.bl.jugador.doRemove(obj)
                acc.execute()

                Return True
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Overrides Sub ConsultaRegistros(ByRef frm As repsol.forms.template.consulta.QueryForm)
            Try
                frm.Cursor = Cursors.WaitCursor

                _vista = frm


                Dim aTmp As List(Of baseball.lib.vo.Jugador) = Nothing

                Dim acc As New baseball.lib.bl.jugador.doGetAll
                aTmp = acc.execute


                Me.SaveSortedColumn(frm)
                _vista.dgConsulta.Columns.Clear()
                _vista.dgConsulta.DataSource = Me.ListVOToDataView(aTmp)
                If (Not _vista.dgConsulta.DataSource Is Nothing) Then
                    _vista.dgConsulta.Select()
                End If

                Me.setEstiloGridRegistros(frm)
                Me.filtrarRegistros(frm)
                Me.ReloadSortedColumn(frm)

            Catch ex As Exception
                Throw ex
            Finally
                frm.Cursor = Cursors.Default
            End Try
        End Sub

        Protected Overrides Function DataGridViewRowToVO(ByVal dr As System.Windows.Forms.DataGridViewRow) As Object
            Try
                Return dr.Cells("objVO").Value
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Overrides Sub filtrarRegistros(ByRef frm As repsol.forms.template.consulta.QueryForm)
            Try
                _vista = frm

                Dim filtro As String = "(1=1)"

                Me.filtrarDV(frm, filtro)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overrides Function getRegistroSeleccionado(ByRef frm As repsol.forms.template.consulta.QueryForm) As Object
            Try
                _vista = frm
                If (Not _vista.dgConsulta.CurrentRow Is Nothing) Then
                    Return DataGridViewRowToVO(_vista.dgConsulta.CurrentRow)
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Overrides Sub inicializarForm(ByRef frm As repsol.forms.template.BaseForm)
            Try
                _vista = frm

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Protected Overrides Function ListVOToDataView(ByVal listObject As Object) As System.Data.DataView
            Try
                If (listObject Is Nothing) Then
                    Return Nothing
                End If

                Dim res As New DataView

                Dim dt As New DataTable(GetType(baseball.lib.vo.Jugador).FullName)
                dt.Columns.Add("Id", GetType(Int16))
                dt.Columns.Add("FullName", GetType(String))
                dt.Columns.Add("Equipo", GetType(baseball.lib.vo.Equipo))
                dt.Columns.Add("objVO", GetType(baseball.lib.vo.Jugador))

                For Each obj As baseball.lib.vo.Jugador In listObject
                    Dim dr As DataRow = dt.NewRow

                    dr("Id") = obj.Id
                    dr("FullName") = obj.FullName
                    dr("Equipo") = obj.Equipo
                    dr("objVO") = obj

                    dt.Rows.Add(dr)
                Next

                res.Table = dt

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Overrides Sub setEstiloGridRegistros(ByRef frm As repsol.forms.template.consulta.QueryForm)
            Try
                _vista = frm

                _vista.dgConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                If (_vista.dgConsulta.DataSource Is Nothing) Then
                    _vista.dgConsulta.Columns.Add("Id", "Id")
                    _vista.dgConsulta.Columns.Add("FullName", "Jugador")
                    _vista.dgConsulta.Columns.Add("Equipo", "Equipo")

                    _vista.dgConsulta.Columns.Add("objVO", "objVO")
                End If

                _vista.dgConsulta.Columns("objVO").Visible = False
                _vista.dgConsulta.Columns("Id").Visible = False

                Dim cname As String = String.Empty

                cname = "Id"
                _vista.dgConsulta.Columns(cname).HeaderText = "Id"
                _vista.dgConsulta.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                _vista.dgConsulta.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader

                cname = "FullName"
                _vista.dgConsulta.Columns(cname).HeaderText = "Jugador"
                _vista.dgConsulta.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                _vista.dgConsulta.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                cname = "Equipo"
                _vista.dgConsulta.Columns(cname).HeaderText = "Equipo"
                _vista.dgConsulta.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                _vista.dgConsulta.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells


            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace
