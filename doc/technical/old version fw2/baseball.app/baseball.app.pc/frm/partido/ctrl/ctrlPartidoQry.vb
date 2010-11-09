Namespace frm.partido.ctrl
    Public Class ctrlPartidoQry
        Inherits _template.consulta.ctrl.queryctrl

        Private _vista As frmPartidoQry
        Public Overrides Function BorrarRegistro(ByRef frm As repsol.forms.template.consulta.QueryForm) As Object
            Try
                _vista = frm

                Dim obj As baseball.lib.vo.Partido = Me.DataGridViewRowToVO(Me._vista.dgConsulta.CurrentRow)

                Dim acc As New baseball.lib.bl.partido.doRemove(obj)
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


                Dim aTmp As List(Of baseball.lib.vo.Partido) = Nothing

                Dim acc As New baseball.lib.bl.partido.doGetAll
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

                _vista.dgConsulta.ContextMenuStrip.Items.Add(_vista.tsbSeparador)
                _vista.dgConsulta.ContextMenuStrip.Items.Add(_vista.EstadisticasToolStripMenuItem)
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

                Dim dt As New DataTable(GetType(baseball.lib.vo.Partido).FullName)
                dt.Columns.Add("Id", GetType(Int16))
                dt.Columns.Add("Fecha", GetType(DateTime))
                dt.Columns.Add("Competicion", GetType(String))
                dt.Columns.Add("HomeClub", GetType(baseball.lib.vo.Equipo))
                dt.Columns.Add("Visitante", GetType(baseball.lib.vo.Equipo))
                dt.Columns.Add("Arbitro1", GetType(baseball.lib.vo.Arbitro))
                dt.Columns.Add("Arbitro2", GetType(baseball.lib.vo.Arbitro))
                dt.Columns.Add("Anotador", GetType(baseball.lib.vo.Anotador))
                dt.Columns.Add("objVO", GetType(baseball.lib.vo.Partido))

                For Each obj As baseball.lib.vo.Partido In listObject
                    Dim dr As DataRow = dt.NewRow

                    dr("Id") = obj.Id
                    dr("Fecha") = obj.Fecha
                    dr("Competicion") = obj.Competicion
                    dr("HomeClub") = obj.HomeClub
                    dr("Visitante") = obj.Visitante
                    dr("Arbitro1") = obj.Arbitro1
                    dr("Arbitro2") = obj.Arbitro2
                    dr("Anotador") = obj.Anotador
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

                _vista.dgConsulta.Columns("objVO").Visible = False
                _vista.dgConsulta.Columns("Id").Visible = False

                Dim cname As String = String.Empty

                cname = "Fecha"
                _vista.dgConsulta.Columns(cname).HeaderText = "Fecha"
                _vista.dgConsulta.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                _vista.dgConsulta.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells


                cname = "Competicion"
                _vista.dgConsulta.Columns(cname).HeaderText = "Competicion"
                _vista.dgConsulta.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                _vista.dgConsulta.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


                cname = "HomeClub"
                _vista.dgConsulta.Columns(cname).HeaderText = "HomeClub"
                _vista.dgConsulta.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                _vista.dgConsulta.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells


                cname = "Visitante"
                _vista.dgConsulta.Columns(cname).HeaderText = "Visitante"
                _vista.dgConsulta.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                _vista.dgConsulta.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells


                cname = "Arbitro1"
                _vista.dgConsulta.Columns(cname).HeaderText = "Arbitro1"
                _vista.dgConsulta.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                _vista.dgConsulta.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells


                cname = "Arbitro2"
                _vista.dgConsulta.Columns(cname).HeaderText = "Arbitro2"
                _vista.dgConsulta.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                _vista.dgConsulta.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells


                cname = "Anotador"
                _vista.dgConsulta.Columns(cname).HeaderText = "Anotador"
                _vista.dgConsulta.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                _vista.dgConsulta.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace
