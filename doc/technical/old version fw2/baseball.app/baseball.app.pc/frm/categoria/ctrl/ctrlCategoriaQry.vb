Namespace frm.categoria.ctrl
    Public Class ctrlCategoriaQry
        Inherits _template.consulta.ctrl.queryctrl

        Private _vista As frmCategoriaQry
        Public Overrides Function BorrarRegistro(ByRef frm As repsol.forms.template.consulta.QueryForm) As Object
            Try
                _vista = frm

                Dim obj As baseball.lib.vo.Categoria = Me.DataGridViewRowToVO(Me._vista.dgConsulta.CurrentRow)

                Dim acc As New baseball.lib.bl.categoria.doRemove(obj)
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


                Dim aTmp As List(Of baseball.lib.vo.Categoria) = Nothing

                Dim acc As New baseball.lib.bl.categoria.doGetAll
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

                Dim dt As New DataTable(GetType(baseball.lib.vo.Categoria).FullName)
                dt.Columns.Add("Id", GetType(Int16))
                dt.Columns.Add("Descripcion", GetType(String))
                dt.Columns.Add("objVO", GetType(baseball.lib.vo.Categoria))

                For Each obj As baseball.lib.vo.Categoria In listObject
                    Dim dr As DataRow = dt.NewRow

                    dr("Id") = obj.Id
                    dr("Descripcion") = obj.Descripcion
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
                    _vista.dgConsulta.Columns.Add("Descripcion", "Descripción")

                    _vista.dgConsulta.Columns.Add("objVO", "objVO")
                End If

                _vista.dgConsulta.Columns("objVO").Visible = False
                _vista.dgConsulta.Columns("Id").Visible = False

                Dim cname As String = String.Empty

                cname = "Id"
                _vista.dgConsulta.Columns(cname).HeaderText = "Id"
                _vista.dgConsulta.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                _vista.dgConsulta.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader

                cname = "Descripcion"
                _vista.dgConsulta.Columns(cname).HeaderText = "Descripción"
                _vista.dgConsulta.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                _vista.dgConsulta.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace
