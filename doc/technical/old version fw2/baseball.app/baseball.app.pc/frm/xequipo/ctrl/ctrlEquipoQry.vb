Namespace frm.equipo.ctrl
    Public Class ctrlEquipoQry
        Inherits baseball.app.pc._template.consulta.ctrl.queryctrl

        Private _vista As equipo.frmEquipoQry

        Public Sub New()
            _columnNameToRemember = "Id"
            _propertyNameToRemember = "Id"
        End Sub

        Public Overrides Function BorrarRegistro(ByRef frm As repsol.forms.template.consulta.QueryForm) As Object
            Try
                _vista = frm

                Dim obj As baseball.lib.vo.Equipo = Me.DataGridViewRowToVO(Me._vista.dgConsulta.CurrentRow)

                Dim acc As New baseball.lib.bl.equipo.doRemove(obj)
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


                Dim aTmp As List(Of baseball.lib.vo.Equipo) = Nothing

                Dim acc As New baseball.lib.bl.equipo.doGetAll
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

        Public Overrides Sub filtrarRegistros(ByRef frm As repsol.forms.template.consulta.QueryForm)
            Try
                _vista = frm

                Dim filtro As String = "(1=1)"

                If (Not _vista._frmFiltro Is Nothing) Then
                    '******** Código **********
                    Dim codigo As String = baseball.lib.common.funciones.filter.parseString(_vista._frmFiltro.txtCodigo.Text.Trim)
                    filtro &= String.Format(" AND ((Codigo like '%{0}%') or (''='{0}'))", codigo)

                    '******* Situación ********
                    If (Not _vista._frmFiltro.lboxSituacion.SelectedItems Is Nothing) AndAlso (_vista._frmFiltro.lboxSituacion.SelectedItems.Count > 0) Then
                        filtro &= " AND ( (1=0) "
                        For Each obj As Object In _vista._frmFiltro.lboxSituacion.SelectedItems
                            Dim vo As String = obj
                            filtro &= String.Format(" OR ((situacion like '%{0}%') or (''='{0}')) ", vo)
                        Next
                        filtro &= " )"
                    End If

                    '******* Fecha Ocurrencia ********
                    If (_vista._frmFiltro.dateFechaOcurrenciaDesde.Checked) Then
                        Dim fecha As String = _vista._frmFiltro.dateFechaOcurrenciaDesde.Value.ToString
                        filtro &= String.Format(" AND (filtrofecOcurrencia >= '{0}')", fecha)
                    End If
                    If (_vista._frmFiltro.dateFechaOcurrenciaHasta.Checked) Then
                        Dim fecha As String = _vista._frmFiltro.dateFechaOcurrenciaHasta.Value.ToString
                        filtro &= String.Format(" AND (filtrofecOcurrencia <= '{0}')", fecha)
                    End If

                    '******* Fecha Cierre Invest. ********
                    If (_vista._frmFiltro.dateFechaCierreInvestDesde.Checked) Then
                        Dim fecha As String = _vista._frmFiltro.dateFechaCierreInvestDesde.Value.ToString
                        filtro &= String.Format(" AND (filtrofecInvestigacion >= '{0}')", fecha)
                    End If
                    If (_vista._frmFiltro.dateFechaOcurrenciaHasta.Checked) Then
                        Dim fecha As String = _vista._frmFiltro.dateFechaCierreInvestHasta.Value.ToString
                        filtro &= String.Format(" AND (filtrofecInvestigacion <= '{0}')", fecha)
                    End If

                    '******* Fecha Cierre ********
                    If (_vista._frmFiltro.dateFechaCierreDesde.Checked) Then
                        Dim fecha As String = _vista._frmFiltro.dateFechaCierreDesde.Value.ToString
                        filtro &= String.Format(" AND (filtrofecCierre >= '{0}')", fecha)
                    End If
                    If (_vista._frmFiltro.dateFechaCierreHasta.Checked) Then
                        Dim fecha As String = _vista._frmFiltro.dateFechaCierreHasta.Value.ToString
                        filtro &= String.Format(" AND (filtrofecCierre <= '{0}')", fecha)
                    End If

                    '******* Fecha Anulacion ********
                    If (_vista._frmFiltro.dateFechaAnulacionDesde.Checked) Then
                        Dim fecha As String = _vista._frmFiltro.dateFechaAnulacionDesde.Value.ToString
                        filtro &= String.Format(" AND (filtrofecCierre >= '{0}')", fecha)
                    End If
                    If (_vista._frmFiltro.dateFechaAnulacionHasta.Checked) Then
                        Dim fecha As String = _vista._frmFiltro.dateFechaAnulacionHasta.Value.ToString
                        filtro &= String.Format(" AND (filtrofecCierre <= '{0}')", fecha)
                    End If

                    '******* Área ********
                    If (Not _vista._frmFiltro.lboxArea.SelectedItems Is Nothing) AndAlso (_vista._frmFiltro.lboxArea.SelectedItems.Count > 0) Then
                        filtro &= " AND ( (1=0) "
                        For Each obj As Object In _vista._frmFiltro.lboxArea.SelectedItems
                            Dim vo As String = CType(obj, baseball.lib.vo.area.areaVO).Codigo
                            filtro &= String.Format(" OR ((filtroArea like '%{0}%') or (''='{0}')) ", vo)
                        Next
                        filtro &= " )"
                    End If

                    '******* Unidad ********
                    If (Not _vista._frmFiltro.lboxUnidad.SelectedItems Is Nothing) AndAlso (_vista._frmFiltro.lboxUnidad.SelectedItems.Count > 0) Then
                        filtro &= " AND ( (1=0) "
                        For Each obj As Object In _vista._frmFiltro.lboxUnidad.SelectedItems
                            Dim vo As String = CType(obj, baseball.lib.vo.unidad.unidadVO).Codigo
                            filtro &= String.Format(" OR ((filtroUnidad like '%{0}%') or (''='{0}')) ", vo)
                        Next
                        filtro &= " )"
                    End If

                    '******* Tipo Equipo ********
                    If (Not _vista._frmFiltro.lboxTipoEquipo.SelectedItems Is Nothing) AndAlso (_vista._frmFiltro.lboxTipoEquipo.SelectedItems.Count > 0) Then
                        filtro &= " AND ( (1=0) "
                        For Each obj As Object In _vista._frmFiltro.lboxTipoEquipo.SelectedItems
                            Dim vo As String = CType(obj, baseball.lib.vo.tipoequipo.tipoequipoVO).Codigo
                            filtro &= String.Format(" OR ((filtroTipoEquipo like '%{0}%') or (''='{0}')) ", vo)
                        Next
                        filtro &= " )"
                    End If

                    '******* Equipo ********
                    If (Not _vista._frmFiltro.lboxEquipo.SelectedItems Is Nothing) AndAlso (_vista._frmFiltro.lboxEquipo.SelectedItems.Count > 0) Then
                        filtro &= " AND ( (1=0) "
                        For Each obj As Object In _vista._frmFiltro.lboxEquipo.SelectedItems
                            Dim vo As String = CType(obj, baseball.lib.vo.Equipo).Codigo
                            filtro &= String.Format(" OR ((filtroEquipo like '%{0}%') or (''='{0}')) ", vo)
                        Next
                        filtro &= " )"
                    End If

                    '******* Tipo Equipo********
                    If (Not _vista._frmFiltro.lboxTipoEquipo.SelectedItems Is Nothing) AndAlso (_vista._frmFiltro.lboxTipoEquipo.SelectedItems.Count > 0) Then
                        filtro &= " AND ( (1=0) "
                        For Each obj As Object In _vista._frmFiltro.lboxTipoEquipo.SelectedItems
                            Dim vo As String = CType(obj, baseball.lib.vo.tipoequipo.tipoequipoVO).Id.ToString
                            filtro &= String.Format(" OR ((filtroTipo = '{0}') or (''='{0}')) ", vo)
                        Next
                        filtro &= " )"
                    End If

                    '******* Clase Equipo ********
                    If (Not _vista._frmFiltro.lboxClaseEquipo.SelectedItems Is Nothing) AndAlso (_vista._frmFiltro.lboxClaseEquipo.SelectedItems.Count > 0) Then
                        filtro &= " AND ( (1=0) "
                        For Each obj As Object In _vista._frmFiltro.lboxClaseEquipo.SelectedItems
                            Dim vo As String = CType(obj, baseball.lib.vo.claseequipo.claseequipoVO).Id.ToString
                            filtro &= String.Format(" OR ((filtroClase = '{0}') or (''='{0}')) ", vo)
                        Next
                        filtro &= " )"
                    End If

                    '******* Tipo Lesión ********
                    If (Not _vista._frmFiltro.lboxTipoLesion.SelectedItems Is Nothing) AndAlso (_vista._frmFiltro.lboxTipoLesion.SelectedItems.Count > 0) Then
                        filtro &= " AND ( (1=0) "
                        For Each obj As Object In _vista._frmFiltro.lboxTipoLesion.SelectedItems
                            Dim vo As String = CType(obj, baseball.lib.vo.tipolesion.tipolesionVO).Id
                            filtro &= String.Format(" OR ((filtroLesion = '{0}') or (''='{0}')) ", vo)
                        Next
                        filtro &= " )"
                    End If

                    '******* Tipo Daño ********
                    'If (Not _vista._frmFiltro.lboxTipoDaño.SelectedItems Is Nothing) AndAlso (_vista._frmFiltro.lboxTipoDaño.SelectedItems.Count > 0) Then
                    '    filtro &= " AND ( (1=0) "
                    '    'For Each obj As Object In _vista._frmFiltro.lboxTipoDaño.SelectedItems
                    '    '    Dim vo As String = CType(obj, baseball.lib.vo.tipoevaluacion.tipoevaluacionVO).Id
                    '    '    filtro &= String.Format(" OR ((filtroEvaluacion like '%{0}%') or (''='{0}')) ", vo)
                    '    'Next
                    '    filtro &= " )"
                    'End If

                    If (_vista._frmFiltro.chkHorasDiferencia.Checked) Then
                        Dim valor As String = _vista._frmFiltro.txtHorasDiferencia.Value.ToString
                        Dim minimo As String = _vista._frmFiltro.txtHorasDiferencia.Minimum.ToString
                        filtro &= String.Format(" AND (filtroHorasDiferencia >= {0})", valor) ', minimo)
                    End If

                    If (_vista._frmFiltro.chkDiasDiferencia.Checked) Then
                        Dim valor As String = _vista._frmFiltro.txtDiasDiferencia.Value.ToString
                        Dim minimo As String = _vista._frmFiltro.txtHorasDiferencia.Minimum.ToString
                        filtro &= String.Format(" AND (filtroDiasDiferencia >= {0})", valor) ', minimo)
                    End If

                    If (_vista._frmFiltro.chkCosteTotalDsd.Checked) Then
                        Dim valor As String = _vista._frmFiltro.txtCosteTotalDsd.Value.ToString
                        Dim minimo As String = _vista._frmFiltro.txtCosteTotalDsd.Minimum.ToString
                        filtro &= String.Format(" AND (Total >= {0})", valor) ', minimo)
                    End If

                    If (_vista._frmFiltro.chkCosteTotalHst.Checked) Then
                        Dim valor As String = _vista._frmFiltro.txtCosteTotalHst.Value.ToString
                        Dim minimo As String = _vista._frmFiltro.txtCosteTotalHst.Minimum.ToString
                        filtro &= String.Format(" AND (Total <= {0})", valor) ', minimo)
                    End If


                    '******* Usuario Creador ********
                    If (Not _vista._frmFiltro.cmbUsuarioCreador.SelectedItem Is Nothing) Then
                        Dim vo As String = CType(_vista._frmFiltro.cmbUsuarioCreador.SelectedItem, baseball.lib.vo.Usuario).Codigo
                        filtro &= String.Format(" AND ((filtroUsuarioCreador like '%{0}%') or (''='{0}')) ", vo)
                    End If

                    '******* Usuario Líder ********
                    If (Not _vista._frmFiltro.cmbUsuarioLider.SelectedItem Is Nothing) Then
                        Dim vo As String = CType(_vista._frmFiltro.cmbUsuarioLider.SelectedItem, baseball.lib.vo.Usuario).Codigo
                        filtro &= String.Format(" AND ((filtroUsuarioLider like '%{0}%') or (''='{0}')) ", vo)
                    End If
                End If

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

        Private Sub DataGridViewToolTip(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellToolTipTextNeededEventArgs)
            Try
                Dim dgv As DataGridView = sender
                If (e.RowIndex <> -1) Then e.ToolTipText = dgv.Rows(e.RowIndex).Cells("DescResumen").Value
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overloads Overrides Sub inicializarForm(ByRef frm As repsol.forms.template.BaseForm)
            Try
                _vista = frm
                _vista.chkVerFiltro.Checked = False
                _vista.chkVerFiltro.Visible = False
                _vista.ColumnNameToolTip = "DescResumen"

                _vista.ToolStripButton1.Visible = False
                _vista.ToolStripSeparator3.Visible = False

#If Not Debug Then
                _vista.btLeccionAprendida.Visible = False
#End If

                AddHandler _vista.dgConsulta.CellToolTipTextNeeded, AddressOf DataGridViewToolTip

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overloads Overrides Sub setEstiloGridRegistros(ByRef frm As repsol.forms.template.consulta.QueryForm)
            Try
                _vista = frm

                _vista.dgConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                If (_vista.dgConsulta.DataSource Is Nothing) Then
                    _vista.dgConsulta.Columns.Add("Id", "Id")
                    _vista.dgConsulta.Columns.Add("Descripcion", "Descripción")

                    _vista.dgConsulta.Columns.Add("objVO", "objVO")
                End If

                _vista.dgConsulta.Columns("objVO").Visible = False

                Dim cname As String = String.Empty

                cname = "Id"
                _vista.dgConsulta.Columns(cname).HeaderText = "Id"
                _vista.dgConsulta.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                _vista.dgConsulta.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader

                cname = "Descripcion"
                _vista.dgConsulta.Columns(cname).HeaderText = "Descripción"
                _vista.dgConsulta.Columns(cname).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                _vista.dgConsulta.Columns(cname).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader


            Catch ex As Exception
                Throw ex
            End Try
        End Sub


        Protected Overrides Function DataGridViewRowToVO(ByVal dr As System.Windows.Forms.DataGridViewRow) As Object
            Try
                Return dr.Cells("objVO").Value
            Catch ex As Exception
                Throw ex
            End Try
        End Function


#Region "<20071023> Trasladamos las acciones desde la ventana de edición a esta"

        Public Function isLeader(ByVal frm As frmEquipoQry) As Boolean
            Try

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function hasEvaluation(ByVal frm As frmEquipoQry) As Boolean
            Try
                _vista = frm
                Dim objVO As baseball.lib.vo.Equipo = getRegistroSeleccionado(frm)

                Dim accion As New baseball.lib.bl.evaluacion.doSeleccionarEvaluacionesPorEquipo(objVO)
                objVO.Evaluaciones = accion.execute

                Dim res As Boolean
                res = (objVO.Evaluaciones Is Nothing) OrElse (objVO.Evaluaciones.Length = 0)

                Return Not res
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function canModify(ByVal frm As frmEquipoQry) As Boolean
            Try
                _vista = frm
                Dim res As Boolean = True

                'Dim integranteTmp As New baseball.lib.vo.integrante.integranteVO(baseball.lib.bl._common.cache.USUARIO)
                'Dim equipo As baseball.lib.vo.Equipo = Me.getRegistroSeleccionado(frm)
                'Dim accEsLider As New baseball.lib.bl.integrante.doEsLiderDeEquipo(integranteTmp, equipo)
                'res = accEsLider.execute
                Dim equipo As baseball.lib.vo.Equipo = Me.getRegistroSeleccionado(frm)

                res = Not (equipo.IsAnulado OrElse equipo.IsCerrado)

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub reabrirEquipo(ByRef frm As frmEquipoQry, ByVal reapertura As baseball.lib.vo.reapertura.reaperturaVO)
            Try
                _vista = frm

                Dim obj As baseball.lib.vo.Equipo = Me.getRegistroSeleccionado(frm)
                'obj.Id = CType(_vista.OnlineVO, baseball.lib.vo.Equipo).Id

                'obj.FechaEquipo = _vista.dateFechaOcurrencia.Value
                obj.FechaInvestigacion = baseball.lib.common.constantes.vacio.FECHA
                obj.FechaCierre = baseball.lib.common.constantes.vacio.FECHA
                obj.FechaAnulacion = baseball.lib.common.constantes.vacio.FECHA
                obj.Reaperturas = New baseball.lib.vo.reapertura.reaperturaVO() {reapertura}

                Dim accion As New baseball.lib.bl.equipo.doModificarEstadoEquipo(obj)
                accion.execute()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Enum ESTADOINCIDENTE
            CERRARINVEST
            CERRAR
            ANULAR
        End Enum


        Public Sub cambiarEstadoEquipo(ByRef frm As frmEquipoQry, ByVal estado As ESTADOINCIDENTE, ByVal fecha As DateTime)
            Try
                _vista = frm

                Dim obj As baseball.lib.vo.Equipo = Me.getRegistroSeleccionado(frm)

                Select Case estado
                    Case ESTADOINCIDENTE.ANULAR
                        obj.FechaAnulacion = fecha
                    Case ESTADOINCIDENTE.CERRAR
                        obj.FechaCierre = fecha
                        'If (obj.FechaInvestigacion = baseball.lib.common.constantes.vacio.FECHA) Then
                        '    'MessageBox.Show("No se ha establecido la fecha de cierre de investigación. Se pondrá la misma que la fecha de cierre.")
                        '    obj.FechaInvestigacion = obj.FechaCierre
                        'End If
                    Case ESTADOINCIDENTE.CERRARINVEST
                        obj.FechaInvestigacion = fecha
                End Select

                Dim accion As New baseball.lib.bl.equipo.doModificarEstadoEquipo(obj)
                AddHandler accion.AvisoAsincrono, AddressOf doModificarEstadoEquipo_AvisoAsincrono
                AddHandler accion.AvisoSincrono, AddressOf doModificarEstadoEquipo_AvisoSincrono
                accion.execute()

                _common.variables.cache.BackupAPP()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#Region "Eventos BL"
        Private Sub doModificarEstadoEquipo_AvisoSincrono(ByVal mensaje As String, ByRef e As System.ComponentModel.CancelEventArgs)
            Try
                If (Windows.Forms.DialogResult.No = MessageBox.Show(mensaje, Me._vista.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) Then
                    e.Cancel = True
                End If
                'repsol.util.messages.ShowWarning(mensaje, _vista.Text)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Private Sub doModificarEstadoEquipo_AvisoAsincrono(ByVal mensaje As String)
            Try
                repsol.util.messages.ShowWarning(mensaje, _vista.Text)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
#End Region


        Public Function canReopen(ByRef frm As frmEquipoQry) As Boolean
            Try
                Dim res As Boolean = True
                _vista = frm

                Dim obj As baseball.lib.vo.Equipo = Me.getRegistroSeleccionado(frm)
                res = obj.IsCerrado OrElse obj.IsAnulado

                Return res

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

#Region "20071221: Lección aprendida"
        Public Sub showLeccionAprendida(ByVal frm As frmEquipoQry)
            Try
                _vista = frm

                Dim doSel As New baseball.lib.bl.leccionaprendida.doSeleccionarLeccionesAprendidasPorEquipo(getRegistroSeleccionado(frm))
                Dim lecc As baseball.lib.vo.leccionaprendida.leccionaprendidaVO() = doSel.execute()
                If (lecc Is Nothing) OrElse (lecc.Length = 0) Then
                    Dim vVen As New leccionaprendida.frmLeccionAprendidaEdit(getRegistroSeleccionado(frm))
                    vVen.ShowDialog()
                Else
                    Dim vVen As New leccionaprendida.frmLeccionAprendidaEdit(lecc(0), False)
                    vVen.ShowDialog()
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub
#End Region

#Region "20080226: Cambio en el modo de filtrar. Ahora no lo hacemos en memoria"
        Private Function getFiltro(ByVal frm As frmEquipoQry) As baseball.lib.vo.Equipo.equipoChunk
            Try
                _vista = frm

                Dim ctrlFiltro As New equipo.ctrl.ctrlEquipoFilter
                Return ctrlFiltro.GetFiltro(_vista._frmFiltro)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

        Protected Overrides Function ListVOToDataView(ByVal listObject As Object) As System.Data.DataView
            Try
                If (listObject Is Nothing) Then
                    Return Nothing
                End If

                Dim res As New DataView

                Dim dt As New DataTable(GetType(baseball.lib.vo.Equipo).FullName)
                dt.Columns.Add("Id", GetType(Int16))
                dt.Columns.Add("Descripcion", GetType(String))
                dt.Columns.Add("objVO", GetType(baseball.lib.vo.Equipo))

                For Each obj As baseball.lib.vo.Equipo In listObject
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
    End Class

End Namespace
