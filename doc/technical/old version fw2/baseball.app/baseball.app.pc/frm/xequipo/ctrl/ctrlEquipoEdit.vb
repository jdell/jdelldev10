Namespace frm.equipo.ctrl
    Public Class ctrlEquipoEdit
        Inherits baseball.app.pc._template.edicion.ctrl.editctrl

        Private _vista As frmEquipoEdit

        Public Overrides Function canAccept(ByRef frm As repsol.forms.template.edicion.EditForm) As Boolean
            Try
                Dim res As Boolean = True
                _vista = frm

                Return res

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Overrides Sub cargarDatos(ByRef frm As repsol.forms.template.edicion.EditForm, ByVal obj As Object)
            Try
                Dim objVO As baseball.lib.vo.Equipo = obj
                _vista = frm

                _vista.IsLoading = True

                _vista.txtFecha.Text = objVO.Fecha.ToString(baseball.lib.common.constantes.formato.FECHAHORA)
                If (objVO.Usuario Is Nothing) Then
                    objVO.Usuario = baseball.lib.bl._common.cache.USUARIO
                End If
                _vista.txtUsuario.Text = objVO.Usuario.Codigo
                If (Not objVO.Unidad Is Nothing) Then
                    If (_vista.cmbUnidad.FindString(objVO.Unidad.Codigo) <> -1) Then
                        _vista.cmbUnidad.SelectedIndex = _vista.cmbUnidad.FindString(objVO.Unidad.Codigo)
                    Else
                        Dim aTmpUnidad As baseball.lib.vo.unidad.unidadVO() = _vista.cmbUnidad.DataSource
                        Dim list As New List(Of baseball.lib.vo.unidad.unidadVO)
                        If (Not aTmpUnidad Is Nothing) Then list.AddRange(aTmpUnidad)
                        list.Add(objVO.Unidad)
                        _vista.cmbUnidad.DataSource = list.ToArray
                        _vista.cmbUnidad.SelectedIndex = _vista.cmbUnidad.FindString(objVO.Unidad.Codigo)
                    End If
                End If
                If (Not objVO.Equipo Is Nothing) Then
                    'If (_vista.cmbEquipo.KDB.BinarySearch(.FindString(objVO.Equipo.Codigo) <> -1) Then _vista.cmbEquipo.SelectedIndex = _vista.cmbEquipo.FindString(objVO.Equipo.Codigo)
                    'AQUI: Esto hay que arreglarlo
                    _vista.cmbEquipo.Text = objVO.Equipo.ToString
                    _vista.cmbEquipo.Tag = objVO.Equipo
                End If
                If (Not objVO.TipoEquipo Is Nothing) Then
                    'If (_vista.cmbTipoEquipo.(objVO.TipoEquipo.Descripcion) <> -1) Then _vista.cmbTipoEquipo.SelectedIndex = _vista.cmbTipoEquipo.FindString(objVO.TipoEquipo.Descripcion)
                    _vista.cmbTipoEquipo.SelectedValue = objVO.TipoEquipo.Id
                    'Esto hay que ponerlo de otra forma...
                    If (_vista.cmbTipoEquipo.SelectedValue Is Nothing) Then
                        Dim aTmpTipo As baseball.lib.vo.tipoequipo.tipoequipoVO() = _vista.cmbTipoEquipo.DataSource
                        Dim list As New List(Of baseball.lib.vo.tipoequipo.tipoequipoVO)
                        If (Not aTmpTipo Is Nothing) Then list.AddRange(aTmpTipo)
                        list.Add(objVO.TipoEquipo)
                        _vista.cmbTipoEquipo.DataSource = list.ToArray
                        _vista.cmbTipoEquipo.SelectedValue = objVO.TipoEquipo.Id
                    End If
                End If
                If (Not objVO.ClaseEquipo Is Nothing) Then
                    'If (_vista.cmbClaseEquipo.FindString(objVO.ClaseEquipo.Descripcion) <> -1) Then _vista.cmbClaseEquipo.SelectedIndex = _vista.cmbClaseEquipo.FindString(objVO.ClaseEquipo.Descripcion)
                    _vista.cmbClaseEquipo.SelectedValue = objVO.ClaseEquipo.Id
                End If
                If (Not objVO.TipoLesion Is Nothing) Then
                    'If (_vista.cmbTipoLesion.FindString(objVO.TipoLesion.Descripcion) <> -1) Then _vista.cmbTipoLesion.SelectedIndex = _vista.cmbTipoLesion.FindString(objVO.TipoLesion.Descripcion)
                    _vista.cmbTipoLesion.SelectedValue = objVO.TipoLesion.Id
                    'Esto hay que ponerlo de otra forma...
                    If (_vista.cmbTipoLesion.SelectedValue Is Nothing) Then
                        Dim aTmpTipo As baseball.lib.vo.tipolesion.tipolesionVO() = _vista.cmbTipoLesion.DataSource
                        Dim list As New List(Of baseball.lib.vo.tipolesion.tipolesionVO)
                        If (Not aTmpTipo Is Nothing) Then list.AddRange(aTmpTipo)
                        list.Add(objVO.TipoLesion)
                        _vista.cmbTipoLesion.DataSource = list.ToArray
                        _vista.cmbTipoLesion.SelectedValue = objVO.TipoLesion.Id
                    End If
                End If
                _vista.txtCodigo.Text = objVO.Codigo
                _vista.txtTotalEvaluacion.Text = objVO.Total.ToString(baseball.lib.common.constantes.formato.IMPORTE)
                _vista.txtDescrResumen.Text = objVO.DescResumen
                _vista.txtDescrDetalle.Text = objVO.DescDetalle
                _vista.txtConsecuencias.Text = objVO.Consecuencia

                '****************************************
                'Fechas y Estado
                '****************************************
                _vista.txtSituacion.Text = objVO.Situacion
                _vista.dateFechaOcurrencia.Value = objVO.FechaEquipo
                If (objVO.FechaAnulacion <> baseball.lib.common.constantes.vacio.FECHA) Then
                    _vista.txtFechaAnulacion.Text = objVO.FechaAnulacion.ToString(baseball.lib.common.constantes.formato.FECHAHORA)
                Else
                    _vista.txtFechaAnulacion.Text = baseball.lib.common.funciones.getinfo.FECHA(objVO.FechaAnulacion)
                End If
                If (objVO.FechaCierre <> baseball.lib.common.constantes.vacio.FECHA) Then
                    _vista.txtFechaCierre.Text = objVO.FechaCierre.ToString(baseball.lib.common.constantes.formato.FECHAHORA)
                Else
                    _vista.txtFechaCierre.Text = baseball.lib.common.funciones.getinfo.FECHA(objVO.FechaCierre)
                End If
                If (objVO.FechaInvestigacion <> baseball.lib.common.constantes.vacio.FECHA) Then
                    _vista.txtFechaCierreInvest.Text = objVO.FechaInvestigacion.ToString(baseball.lib.common.constantes.formato.FECHAHORA)
                Else
                    _vista.txtFechaCierreInvest.Text = baseball.lib.common.funciones.getinfo.FECHA(objVO.FechaInvestigacion)
                End If

                '****************************************
                '_vista.InnerVO = objVO.Clone
                _vista.OnlineVO = objVO
                '****************************************

                '****************************************
                'Ventanas
                '****************************************
                Dim accCausas As New baseball.lib.bl.causa.doSeleccionarCausasPorEquipo(objVO)
                objVO.Causas = accCausas.execute
                _vista._frmCausaQry.ShowDocked(_vista.tpageCausas)

                Dim accAcciones As New baseball.lib.bl.accion.doSeleccionarAccionesPorEquipo(objVO)
                objVO.Acciones = accAcciones.execute
                _vista._frmAccionQry.ShowDocked(_vista.tpageAcciones)

                Dim accEvaluaciones As New baseball.lib.bl.evaluacion.doSeleccionarEvaluacionesPorEquipo(objVO)
                objVO.Evaluaciones = accEvaluaciones.execute
                _vista._frmEvaluacionQry.ShowDocked(_vista.gboxEvaluaciones)

                Dim accFicheros As New baseball.lib.bl.fichero.doSeleccionarFicherosPorEquipo(objVO)
                objVO.Ficheros = accFicheros.execute
                _vista._frmFicheroQry.ShowDocked(_vista.tpageFicheros)

                Dim accComision As New baseball.lib.bl.comision.doSeleccionarComisionPorEquipo(objVO)
                objVO.Comision = accComision.execute
                If (objVO.Comision Is Nothing) Then
                    objVO.IntegrantesComision = New baseball.lib.vo.integrante.integranteVO() {New baseball.lib.vo.integrante.integranteVO(baseball.lib.bl._common.cache.USUARIO)}
                Else
                    Dim accIntegrantes As New baseball.lib.bl.integrante.doSeleccionarIntegrantesPorComision(objVO.Comision)
                    objVO.IntegrantesComision = accIntegrantes.execute
                End If



                'Dim accMedidasAdoptadas As New baseball.lib.bl.medidaadoptada.doSeleccionarMedidasAdoptadasPorEquipo(objVO)
                'objVO.MedidasAdoptadas = accMedidasAdoptadas.execute
                If (Not objVO.IntegrantesComision Is Nothing) Then
                    For Each integrante As baseball.lib.vo.integrante.integranteVO In objVO.IntegrantesComision
                        Dim accMedidasAdoptadas As New baseball.lib.bl.medidaadoptada.doSeleccionarMedidasAdoptadasPorIntegrante(integrante)
                        integrante.MedidasAdoptadas = accMedidasAdoptadas.execute
                    Next
                End If

                _vista._frmIntegranteQry.ShowDocked(_vista.tpageIntegrantes)
                _vista._frmMedidaAdoptadaQry.ShowDocked(_vista.tpageMedidasAdoptadas)

                ''*****************************************
                ''Cargamos la checklist de impacto
                ''*****************************************
                'Dim aImpacto As baseball.lib.vo.impacto.impactoVO()
                'Dim accSeleccionarsImpacto As New baseball.lib.bl.impacto.doSeleccionarImpactosPorEquipo(objVO)
                'aImpacto = accSeleccionarsImpacto.execute
                'If (Not aImpacto Is Nothing) Then
                '    For Each impact As baseball.lib.vo.impacto.impactoVO In aImpacto
                '        For Each item As Object In Me._vista.chkImpacto.Items
                '            Dim timpact As baseball.lib.vo.tipoimpacto.tipoimpactoVO = item
                '            If (timpact.Id = impact.TipoImpacto.Id) Then
                '                _vista.chkImpacto.SetItemChecked(_vista.chkImpacto.Items.IndexOf(item), True)
                '            End If
                '        Next
                '        _vista.chkImpacto.Items.Add(impact, impact.Checkeado)
                '    Next
                'End If
                '*****************************************
                'Cargamos la checklist de impacto
                '*****************************************
                Dim aImpacto As baseball.lib.vo.impacto.impactoVO()
                Dim accSeleccionarsImpacto As New baseball.lib.bl.impacto.doSeleccionarImpactosPorEquipo(objVO)
                aImpacto = accSeleccionarsImpacto.execute
                _vista.chkImpacto.Items.Clear()
                If (Not aImpacto Is Nothing) Then
                    For Each impact As baseball.lib.vo.impacto.impactoVO In aImpacto
                        _vista.chkImpacto.Items.Add(impact, impact.Checkeado)
                    Next
                End If
                objVO.Impactos = aImpacto

                _vista.IsLoading = False

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub setOriginalVO(ByRef frm As frmEquipoEdit, ByVal objVO As baseball.lib.vo.Equipo)
            Try
                _vista = frm

                _vista.InnerVO = objVO.Clone
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overrides Function EsCodigoValido(ByRef frm As repsol.forms.template.edicion.EditForm) As Boolean
            Try

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Overrides Sub guardarDatos(ByRef frm As repsol.forms.template.edicion.EditForm, ByVal newRecord As Boolean)
            Try
                _vista = frm

                Dim obj As New baseball.lib.vo.Equipo
                obj = getObject(_vista)

                If (canSave(obj)) Then

                    '<20080111> Estamos moviendo "todo lo online" hacia la BL
                    'If (newRecord) Then
                    '    Dim accion As New baseball.lib.bl.equipo.doInsertarEquipo(obj)
                    '    _vista.OnlineVO = accion.execute()
                    '    _vista.txtCodigo.Text = _vista.OnlineVO.Codigo
                    'Else
                    '    Dim accion As New baseball.lib.bl.equipo.doModificarEquipo(obj)
                    '    _vista.OnlineVO = accion.execute()
                    'End If
                    Dim doSave As New baseball.lib.bl.equipo.doSaveEquipo(obj, _vista.InnerVO)
                    _vista.OnlineVO = doSave.execute
                    _vista.txtCodigo.Text = _vista.OnlineVO.Codigo
                    '</20080111> ********************************************

                    'Mantenemos un respaldo de los datos de equipos que hay en memoria
                    _common.variables.cache.BackupAPP()

                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Function getObject(ByVal frm As frmEquipoEdit) As baseball.lib.vo.Equipo
            Try
                _vista = frm
                Dim obj As New baseball.lib.vo.Equipo
                obj.Id = CType(_vista.OnlineVO, baseball.lib.vo.Equipo).Id
                obj.Numero = CType(_vista.OnlineVO, baseball.lib.vo.Equipo).Numero
                obj.Fecha = CDate(_vista.txtFecha.Text)
                obj.Usuario = New baseball.lib.vo.Usuario(_vista.txtUsuario.Text)
                If (Not _vista.cmbUnidad.SelectedItem Is Nothing) AndAlso (_vista.cmbUnidad.Text.Trim <> String.Empty) Then
                    obj.Unidad = _vista.cmbUnidad.SelectedItem
                    obj.Area = obj.Unidad.Area
                End If
                'AQUI:Esto hay que arreglarlo. Esto vino a cuento cuando se cambió el Combo por el TextBox
                If ((Not _vista.cmbEquipo.SelectedItem Is Nothing) OrElse (Not _vista.cmbEquipo.Tag Is Nothing)) AndAlso (_vista.cmbEquipo.Text.Trim <> String.Empty) Then
                    If (Not _vista.cmbEquipo.SelectedItem Is Nothing) Then
                        obj.Equipo = _vista.cmbEquipo.SelectedItem
                    Else
                        obj.Equipo = _vista.cmbEquipo.Tag
                    End If
                End If
                '
                If (Not _vista.cmbTipoEquipo.SelectedItem Is Nothing) AndAlso (_vista.cmbTipoEquipo.Text.Trim <> String.Empty) Then obj.TipoEquipo = _vista.cmbTipoEquipo.SelectedItem
                If (Not _vista.cmbClaseEquipo.SelectedItem Is Nothing) AndAlso (_vista.cmbClaseEquipo.Text.Trim <> String.Empty) Then obj.ClaseEquipo = _vista.cmbClaseEquipo.SelectedItem
                If (Not _vista.cmbTipoLesion.SelectedItem Is Nothing) AndAlso (_vista.cmbTipoLesion.Text.Trim <> String.Empty) Then obj.TipoLesion = _vista.cmbTipoLesion.SelectedItem
                obj.FechaEquipo = _vista.dateFechaOcurrencia.Value
                If (Not DateTime.TryParse(_vista.txtFechaCierreInvest.Text, obj.FechaInvestigacion)) Then
                    obj.FechaInvestigacion = baseball.lib.common.constantes.vacio.FECHA
                End If
                If (Not DateTime.TryParse(_vista.txtFechaCierre.Text, obj.FechaCierre)) Then
                    obj.FechaCierre = baseball.lib.common.constantes.vacio.FECHA
                End If
                If (Not DateTime.TryParse(_vista.txtFechaAnulacion.Text, obj.FechaAnulacion)) Then
                    obj.FechaAnulacion = baseball.lib.common.constantes.vacio.FECHA
                End If
                obj.DescResumen = _vista.txtDescrResumen.Text
                obj.Consecuencia = _vista.txtConsecuencias.Text
                obj.DescDetalle = _vista.txtDescrDetalle.Text
                Double.TryParse(_vista.txtTotalEvaluacion.Text, obj.Total)

                obj.Causas = CType(_vista.OnlineVO, baseball.lib.vo.Equipo).Causas
                obj.Acciones = CType(_vista.OnlineVO, baseball.lib.vo.Equipo).Acciones
                obj.Evaluaciones = CType(_vista.OnlineVO, baseball.lib.vo.Equipo).Evaluaciones
                obj.Ficheros = CType(_vista.OnlineVO, baseball.lib.vo.Equipo).Ficheros
                obj.Comision = CType(_vista.OnlineVO, baseball.lib.vo.Equipo).Comision
                obj.IntegrantesComision = CType(_vista.OnlineVO, baseball.lib.vo.Equipo).IntegrantesComision
                'obj.MedidasAdoptadas = CType(_vista.OnlineVO, baseball.lib.vo.Equipo).MedidasAdoptadas

                Dim cont As Integer = 0
                For Each item As Object In _vista.chkImpacto.Items
                    ReDim Preserve obj.Impactos(cont)
                    obj.Impactos(cont) = item
                    obj.Impactos(cont).Checkeado = _vista.chkImpacto.GetItemChecked(_vista.chkImpacto.Items.IndexOf(item))
                    cont += 1
                Next

                Return obj
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Sub cargarEquipos(ByVal sender As Object, ByVal e As EventArgs)
            Try
                '_vista = frm

                '*****************************************
                'Cargamos las equipos
                '*****************************************
                Dim aEquipo As baseball.lib.vo.Equipo()
                Dim accSeleccionarEquipos As New baseball.lib.bl.equipo.doSeleccionarEquiposPorUnidad(_vista.cmbUnidad.SelectedItem)
                aEquipo = accSeleccionarEquipos.execute
                'Dim aTmpEquipo As baseball.lib.vo.Equipo() = {New baseball.lib.vo.Equipo}
                'If (Not aEquipo Is Nothing) Then
                '    ReDim Preserve aTmpEquipo(aEquipo.Length)
                '    aEquipo.CopyTo(aTmpEquipo, 1)
                'End If
                '_vista.cmbEquipo.DataSource = aTmpEquipo

                _vista.cmbEquipo.KDB = aEquipo

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overrides Sub inicializarForm(ByRef frm As repsol.forms.template.BaseForm)
            Try
                _vista = frm
                _vista.IsLoading = True

                _vista.txtUsuario.Text = baseball.lib.bl._common.cache.USUARIO.Codigo.ToUpper
                _vista.txtFecha.Text = DateTime.Now.ToShortDateString

                '_vista.txtUsuario.ReadOnly = True
                '_vista.txtFecha.ReadOnly = True
                '_vista.txtCodigo.ReadOnly = True

                '_vista.txtUsuario.BorderStyle = BorderStyle.Fixed3D
                '_vista.txtFecha.BorderStyle = BorderStyle.Fixed3D
                '_vista.txtCodigo.BorderStyle = BorderStyle.Fixed3D

                '_vista.txtDescrDetalle.BorderStyle = BorderStyle.Fixed3D
                '_vista.txtDescrResumen.BorderStyle = BorderStyle.Fixed3D

                '*****************************************
                'Cargamos las unidades
                '*****************************************
                Dim aUnidad As baseball.lib.vo.unidad.unidadVO()
                'Dim accSeleccionarUnidades As New baseball.lib.bl.unidad.doSeleccionarUnidades(baseball.lib.bl._common.constantes.tiposeleccion.SELECCION.SoloActivo)
                Dim accSeleccionarUnidades As New baseball.lib.bl.unidad.doSeleccionarUnidadesPorUsuarioIncl(baseball.lib.bl._common.cache.USUARIO, baseball.lib.bl._common.constantes.tiposeleccion.SELECCION.SoloActivo)
                aUnidad = accSeleccionarUnidades.execute
                Dim aTmpUnidad As baseball.lib.vo.unidad.unidadVO() = {New baseball.lib.vo.unidad.unidadVO}
                If (Not aUnidad Is Nothing) Then
                    ReDim Preserve aTmpUnidad(aUnidad.Length)
                    aUnidad.CopyTo(aTmpUnidad, 1)
                End If
                AddHandler _vista.cmbUnidad.SelectedIndexChanged, AddressOf cargarEquipos
                _vista.cmbUnidad.DataSource = aTmpUnidad

                ''Por el tema online!
                '_vista.cmbUnidad.DataSource = aUnidad

                'cargarEquipos(_vista)
                ''*****************************************
                ''Cargamos las equipos
                ''*****************************************
                'Dim aEquipo As baseball.lib.vo.Equipo()
                'Dim accSeleccionarEquipos As New baseball.lib.bl.equipo.doSeleccionarEquipos
                'aEquipo = accSeleccionarEquipos.execute
                'Dim aTmpEquipo As baseball.lib.vo.Equipo() = {New baseball.lib.vo.Equipo}
                'If (Not aEquipo Is Nothing) Then
                '    ReDim Preserve aTmpEquipo(aEquipo.Length)
                '    aEquipo.CopyTo(aTmpEquipo, 1)
                'End If
                '_vista.cmbEquipo.DataSource = aTmpEquipo

                ''Por el tema online!
                '_vista.cmbEquipo.DataSource = aEquipo

                '*****************************************
                'Cargamos las tiposequipo
                '*****************************************
                Dim aTipoEquipo As baseball.lib.vo.tipoequipo.tipoequipoVO()
                Dim accSeleccionarTiposEquipo As New baseball.lib.bl.tipoequipo.doSeleccionarTiposEquipo(baseball.lib.bl._common.constantes.tiposeleccion.SELECCION.SoloActivo)
                aTipoEquipo = accSeleccionarTiposEquipo.execute
                Dim aTmpTipoEquipo As baseball.lib.vo.tipoequipo.tipoequipoVO() = {New baseball.lib.vo.tipoequipo.tipoequipoVO}
                If (Not aTipoEquipo Is Nothing) Then
                    ReDim Preserve aTmpTipoEquipo(aTipoEquipo.Length)
                    aTipoEquipo.CopyTo(aTmpTipoEquipo, 1)
                End If

                _vista.cmbTipoEquipo.DataSource = aTmpTipoEquipo

                ''Por el tema online!
                '_vista.cmbTipoEquipo.DataSource = aTipoEquipo

                _vista.cmbTipoEquipo.ValueMember = "Id"
                _vista.cmbTipoEquipo.DisplayMember = "Descripcion"

                '*****************************************
                'Cargamos las clasesequipo
                '*****************************************
                Dim aClaseEquipo As baseball.lib.vo.claseequipo.claseequipoVO()
                Dim accSeleccionarClasesEquipo As New baseball.lib.bl.claseequipo.doSeleccionarClasesEquipo
                aClaseEquipo = accSeleccionarClasesEquipo.execute
                Dim aTmpClaseEquipo As baseball.lib.vo.claseequipo.claseequipoVO() = {New baseball.lib.vo.claseequipo.claseequipoVO}
                If (Not aClaseEquipo Is Nothing) Then
                    ReDim Preserve aTmpClaseEquipo(aClaseEquipo.Length)
                    aClaseEquipo.CopyTo(aTmpClaseEquipo, 1)
                End If
                _vista.cmbClaseEquipo.DataSource = aTmpClaseEquipo

                ''Por el tema online!
                '_vista.cmbClaseEquipo.DataSource = aClaseEquipo

                _vista.cmbClaseEquipo.ValueMember = "Id"
                _vista.cmbClaseEquipo.DisplayMember = "Descripcion"

                '*****************************************
                'Cargamos las tiposlesion
                '*****************************************
                Dim aTipoLesion As baseball.lib.vo.tipolesion.tipolesionVO()
                Dim accSeleccionarTiposLesion As New baseball.lib.bl.tipolesion.doSeleccionarTiposLesion(baseball.lib.bl._common.constantes.tiposeleccion.SELECCION.SoloActivo)
                aTipoLesion = accSeleccionarTiposLesion.execute
                Dim aTmpTipoLesion As baseball.lib.vo.tipolesion.tipolesionVO() = {New baseball.lib.vo.tipolesion.tipolesionVO}
                If (Not aTipoLesion Is Nothing) Then
                    ReDim Preserve aTmpTipoLesion(aTipoLesion.Length)
                    aTipoLesion.CopyTo(aTmpTipoLesion, 1)
                End If
                _vista.cmbTipoLesion.DataSource = aTmpTipoLesion

                'Por el tema online!
                _vista.cmbTipoLesion.DataSource = aTipoLesion

                _vista.cmbTipoLesion.ValueMember = "Id"
                _vista.cmbTipoLesion.DisplayMember = "Descripcion"

                ''*****************************************
                ''Cargamos las tiposevaluacion
                ''*****************************************
                'Dim aTipoEvaluacion As baseball.lib.vo.tipoevaluacion.tipoevaluacionVO()
                'Dim accSeleccionarTiposEvaluacion As New baseball.lib.bl.tipoevaluacion.doSeleccionarTiposEvaluacion
                'aTipoEvaluacion = accSeleccionarTiposEvaluacion.execute
                'Dim aTmpTipoEvaluacion As baseball.lib.vo.tipoevaluacion.tipoevaluacionVO() = {New baseball.lib.vo.tipoevaluacion.tipoevaluacionVO}
                'If (Not aTipoEvaluacion Is Nothing) Then
                '    ReDim Preserve aTmpTipoEvaluacion(aTipoEvaluacion.Length)
                '    aTipoEvaluacion.CopyTo(aTmpTipoEvaluacion, 1)
                'End If
                ''_vista.cmbtipo.DataSource = aTmpTipoEvaluacion

                ''*****************************************
                ''Cargamos la checklist de impacto
                ''*****************************************
                'Dim aTipoImpacto As baseball.lib.vo.tipoimpacto.tipoimpactoVO()
                'Dim accSeleccionarTiposImpacto As New baseball.lib.bl.tipoimpacto.doSeleccionarTiposImpacto
                'aTipoImpacto = accSeleccionarTiposImpacto.execute
                '_vista.chkImpacto.Items.Clear()
                'If (Not aTipoImpacto Is Nothing) Then
                '    For Each obj As baseball.lib.vo.tipoimpacto.tipoimpactoVO In aTipoImpacto
                '        _vista.chkImpacto.Items.Add(obj)
                '    Next
                'End If


                _vista.txtConsecuencias.MaxLength = baseball.lib.common.constantes.stringlength.INCIDENTE_CONSECUENCIA
                _vista.txtDescrDetalle.MaxLength = baseball.lib.common.constantes.stringlength.INCIDENTE_DETALLE
                _vista.txtDescrResumen.MaxLength = baseball.lib.common.constantes.stringlength.INCIDENTE_RESUMEN

                _vista.IsLoading = False

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function getNuevoRegistro() As Object
            Try
                Dim res As New baseball.lib.vo.Equipo

                res.IntegrantesComision = New baseball.lib.vo.integrante.integranteVO() {New baseball.lib.vo.integrante.integranteVO(baseball.lib.bl._common.cache.USUARIO)}

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function canModify(ByVal frm As frmEquipoEdit) As Boolean
            Try
                _vista = frm
                Dim res As Boolean = True

                res = baseball.lib.bl._common.cache.USUARIO.Perfil.Admin

                If (Not res) Then
                    Dim integranteTmp As New baseball.lib.vo.integrante.integranteVO(baseball.lib.bl._common.cache.USUARIO)
                    Dim accEsLider As New baseball.lib.bl.integrante.doEsLiderDeEquipo(integranteTmp, _vista.OnlineVO)
                    res = accEsLider.execute
                End If

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub reabrirEquipo(ByRef frm As frmEquipoEdit)
            Try
                _vista = frm

                Dim obj As baseball.lib.vo.Equipo = _vista.OnlineVO
                'obj.Id = CType(_vista.OnlineVO, baseball.lib.vo.Equipo).Id

                obj.FechaEquipo = _vista.dateFechaOcurrencia.Value
                obj.FechaInvestigacion = baseball.lib.common.constantes.vacio.FECHA
                obj.FechaCierre = baseball.lib.common.constantes.vacio.FECHA
                obj.FechaAnulacion = baseball.lib.common.constantes.vacio.FECHA
                'obj.Reaperturas = CType(_vista.OnlineVO, baseball.lib.vo.Equipo).Reaperturas

                Dim accion As New baseball.lib.bl.equipo.doModificarEstadoEquipo(obj)
                _vista.OnlineVO = accion.execute()
                Me._vista.txtSituacion.Text = _vista.OnlineVO.Situacion
                Me._vista.txtFechaCierre.Text = baseball.lib.common.funciones.getinfo.FECHA(obj.FechaCierre)
                'Me._vista.txtFechaCierreInvest.Text = baseball.lib.common.funciones.getinfo.FECHA(obj.FechaInvestigacion)
                Me._vista.txtFechaAnulacion.Text = baseball.lib.common.funciones.getinfo.FECHA(obj.FechaAnulacion)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub cambiarEstadoEquipo(ByRef frm As repsol.forms.template.edicion.EditForm)
            Try
                _vista = frm

                Dim obj As baseball.lib.vo.Equipo = _vista.OnlineVO
                'obj.Id = CType(_vista.OnlineVO, baseball.lib.vo.Equipo).Id

                obj.FechaEquipo = _vista.dateFechaOcurrencia.Value
                If (_vista.txtFechaCierreInvest.Text.Trim <> baseball.lib.common.funciones.getinfo.FECHA(baseball.lib.common.constantes.vacio.FECHA)) Then
                    obj.FechaInvestigacion = Convert.ToDateTime(_vista.txtFechaCierreInvest.Text)
                Else
                    obj.FechaInvestigacion = baseball.lib.common.constantes.vacio.FECHA
                End If
                If (_vista.txtFechaCierre.Text.Trim <> baseball.lib.common.funciones.getinfo.FECHA(baseball.lib.common.constantes.vacio.FECHA)) Then
                    obj.FechaCierre = Convert.ToDateTime(_vista.txtFechaCierre.Text)
                    If (obj.FechaInvestigacion = baseball.lib.common.constantes.vacio.FECHA) Then
                        MessageBox.Show("No se ha establecido la fecha de cierre de investigación. Se pondrá la misma que la fecha de cierre.")
                        obj.FechaInvestigacion = obj.FechaCierre
                        _vista.txtFechaCierreInvest.Text = obj.FechaInvestigacion.ToString(baseball.lib.common.constantes.formato.FECHAHORA)
                    End If
                Else
                    obj.FechaCierre = baseball.lib.common.constantes.vacio.FECHA
                End If
                If (_vista.txtFechaAnulacion.Text.Trim <> baseball.lib.common.funciones.getinfo.FECHA(baseball.lib.common.constantes.vacio.FECHA)) Then
                    obj.FechaAnulacion = Convert.ToDateTime(_vista.txtFechaAnulacion.Text)
                Else
                    obj.FechaAnulacion = baseball.lib.common.constantes.vacio.FECHA
                End If
                'obj.Reaperturas = CType(_vista.OnlineVO, baseball.lib.vo.Equipo).Reaperturas

                Dim accion As New baseball.lib.bl.equipo.doModificarEstadoEquipo(obj)
                _vista.OnlineVO = accion.execute()

                Me._vista.txtSituacion.Text = _vista.OnlineVO.Situacion

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function canReopen(ByRef frm As frmEquipoEdit) As Boolean
            Try
                Dim res As Boolean = True
                _vista = frm

                res = _vista.OnlineVO.IsCerrado OrElse _vista.OnlineVO.IsAnulado

                Return res

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub restablecerDatosEquipo(ByRef frm As repsol.forms.template.edicion.EditForm)
            Try
                _vista = frm

                Dim obj As baseball.lib.vo.Equipo = CType(_vista.InnerVO, baseball.lib.vo.Equipo).Clone
                If (obj.Id = baseball.lib.common.constantes.vacio.ID) Then
                    Dim accDelete As New baseball.lib.bl.equipo.doEliminarEquipo(_vista.OnlineVO)
                    accDelete.execute()

                    'Mantenemos un respaldo de los datos de equipos que hay en memoria
                    _common.variables.cache.BackupAPP()
                Else
                    '_vista.OnlineVO = _vista.InnerVO
                    Me.cargarDatos(_vista, _vista.InnerVO)
                    _vista.OnlineVO = obj.Clone
                    Me.guardarDatos(_vista, Me._vista.IsNewRecord)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function canSave(ByVal obj As baseball.lib.vo.Equipo) As Boolean
            Try
                Dim res As Boolean = True
                Dim acc As New baseball.lib.bl.equipo.doCanSaveEquipo(obj)

                res = acc.execute

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function hasChanged(ByVal frm As frmEquipoEdit, ByVal sender As Object) As Boolean
            Try
                _vista = frm
                Dim c As Control = sender
                Dim res As Boolean = False

                If (Not _vista.OnlineVO Is Nothing) Then
                    If (c Is _vista.cmbUnidad) Then
                        'res = Not _vista.OnlineVO.Unidad Is _vista.cmbUnidad.SelectedItem
                        res = (Not _vista.OnlineVO.Unidad Is Nothing) AndAlso Not (_vista.OnlineVO.Unidad.CompareTo(_vista.cmbUnidad.SelectedItem) = 0)
                    ElseIf c Is _vista.cmbEquipo Then
                        If (Not _vista.cmbEquipo.SelectedItem Is Nothing) Then
                            'res = Not _vista.OnlineVO.Equipo Is _vista.cmbEquipo.SelectedItem
                            res = (Not _vista.OnlineVO.Equipo Is Nothing) AndAlso Not (_vista.OnlineVO.Equipo.CompareTo(_vista.cmbEquipo.SelectedItem) = 0)
                        Else
                            'res = Not _vista.OnlineVO.Equipo Is _vista.cmbEquipo.Tag
                            res = (Not _vista.OnlineVO.Equipo Is Nothing) AndAlso Not (_vista.OnlineVO.Equipo.CompareTo(_vista.cmbEquipo.Tag) = 0)
                        End If
                    ElseIf c Is _vista.cmbTipoEquipo Then
                        'res = Not _vista.OnlineVO.TipoEquipo Is _vista.cmbTipoEquipo.SelectedItem
                        res = (Not _vista.OnlineVO.TipoEquipo Is Nothing) AndAlso Not (_vista.OnlineVO.TipoEquipo.CompareTo(_vista.cmbTipoEquipo.SelectedItem) = 0)
                    ElseIf c Is _vista.cmbClaseEquipo Then
                        'res = Not _vista.OnlineVO.ClaseEquipo Is _vista.cmbClaseEquipo.SelectedItem
                        res = (Not _vista.OnlineVO.ClaseEquipo Is Nothing) AndAlso Not (_vista.OnlineVO.ClaseEquipo.CompareTo(_vista.cmbClaseEquipo.SelectedItem) = 0)
                    ElseIf c Is _vista.cmbTipoLesion Then
                        'res = Not _vista.OnlineVO.TipoLesion Is _vista.cmbTipoLesion.SelectedItem
                        res = (Not _vista.OnlineVO.TipoLesion Is Nothing) AndAlso Not (_vista.OnlineVO.TipoLesion.CompareTo(_vista.cmbTipoLesion.SelectedItem) = 0)
                    ElseIf c Is _vista.dateFechaOcurrencia Then
                        res = Not _vista.OnlineVO.FechaEquipo = _vista.dateFechaOcurrencia.Value
                    ElseIf c Is _vista.txtDescrResumen Then
                        res = Not _vista.OnlineVO.DescResumen.Trim = _vista.txtDescrResumen.Text.Trim
                    ElseIf c Is _vista.chkImpacto Then
                        If (Not _vista.OnlineVO.Impactos Is Nothing) Then
                            For Each item As Object In _vista.chkImpacto.Items
                                Dim index As Integer = Array.IndexOf(_vista.OnlineVO.Impactos, item)
                                If (index > -1) Then
                                    res = res OrElse (Not _vista.OnlineVO.Impactos(index).Checkeado = _vista.chkImpacto.GetItemChecked(_vista.chkImpacto.Items.IndexOf(item)))
                                End If
                                If res Then Exit For
                            Next
                        Else
                            res = True
                        End If
                    ElseIf c Is _vista._frmAccionQry Then
                        '<20080110> Ahora mismo -con la funcionalidad actual- no puedo saber si se modifica algo o no. Sólo
                        'sé si se ha pulsado aceptar o cancelar en el botón de edicion de la pantalla correspondiente.
                        res = True
                        'Dim vos As Object() = _vista._frmAccionQry.getVOs
                        'If (Not vos Is Nothing) AndAlso (Not _vista.OnlineVO.Acciones Is Nothing) Then
                        '    For Each obj As Object In vos
                        '        Dim vo As baseball.lib.vo.accion.accionVO = obj
                        '        Dim index As Integer = Array.IndexOf(_vista.OnlineVO.Acciones, vo)
                        '        If (index > -1) Then
                        '            res = res OrElse (Not _vista.OnlineVO.Acciones(index).Descripcion = vo.Descripcion)
                        '            res = res OrElse (Not _vista.OnlineVO.Acciones(index).TipoAccion Is vo.TipoAccion)
                        '        End If
                        '        If res Then Exit For
                        '    Next
                        'Else
                        '    res = True
                        'End If
                    ElseIf c Is _vista._frmCausaQry Then
                        res = True
                    ElseIf c Is _vista._frmEvaluacionQry Then
                        res = True
                    ElseIf c Is _vista._frmFicheroQry Then
                        res = True
                    ElseIf c Is _vista._frmIntegranteQry Then
                        res = True
                    ElseIf c Is _vista._frmMedidaAdoptadaQry Then
                        res = True
                    ElseIf c Is _vista.txtDescrDetalle Then
                        res = Not _vista.OnlineVO.DescDetalle.Trim = _vista.txtDescrDetalle.Text.Trim
                    ElseIf c Is _vista.txtConsecuencias Then
                        res = Not _vista.OnlineVO.Consecuencia.Trim = _vista.txtConsecuencias.Text.Trim
                    End If
                End If

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub ImportarEquipo(ByRef frm As frmEquipoEdit, ByVal equipo As baseball.lib.vo.Equipo)
            Try
                _vista = frm
                If (equipo Is Nothing) Then
                    Return
                End If

                Dim acc As New baseball.lib.bl.equipo.doInsertarEquipo(equipo)
                acc.execute()
                cargarEquipos(Nothing, Nothing)

                'TODO: Revisar - Asignacion de equipos
                'AQUI: Esto hay que arreglarlo
                _vista.cmbEquipo.Text = equipo.ToString
                _vista.cmbEquipo.Tag = equipo
                '

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub setToolTipTipoEquipo(ByRef frm As System.Windows.Forms.Form)
            _vista = frm
            Dim eq As baseball.lib.vo.tipoequipo.tipoequipoVO = Me._vista.cmbTipoEquipo.SelectedItem
            If Not (eq Is Nothing) Then
                Me._vista.tTip.SetToolTip(Me._vista.cmbTipoEquipo, eq.DescripcionAmpliada)
                Me._vista.tTip.ToolTipTitle = eq.Descripcion
            End If
        End Sub

#Region "20071221: Impresión detalle informe"

        Public Sub prepareRPT(ByVal frm As frmEquipoEdit, ByRef viewer As Microsoft.Reporting.WinForms.ReportViewer)
            Try

                _vista = frm

                Dim objVO As baseball.lib.vo.Equipo = getObject(frm)
                'Equipo
                Dim bSourceEquipo As System.Windows.Forms.BindingSource
                bSourceEquipo = New System.Windows.Forms.BindingSource
                bSourceEquipo.DataSource = objVO.GetType
                bSourceEquipo.DataSource = objVO

                Dim rptDataSourceEquipo As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
                rptDataSourceEquipo.Name = objVO.GetType.FullName.Replace(".", "_")
                rptDataSourceEquipo.Value = bSourceEquipo

                viewer.LocalReport.DataSources.Add(rptDataSourceEquipo)

                'Causa
                Dim bSourceCausa As System.Windows.Forms.BindingSource
                bSourceCausa = New System.Windows.Forms.BindingSource
                bSourceCausa.DataSource = GetType(baseball.lib.vo.causa.causaVO)
                bSourceCausa.DataSource = objVO.Causas

                Dim rptDataSourceCausa As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
                rptDataSourceCausa.Name = GetType(baseball.lib.vo.causa.causaVO).FullName.Replace(".", "_")
                rptDataSourceCausa.Value = bSourceCausa

                viewer.LocalReport.DataSources.Add(rptDataSourceCausa)

                'Acciones
                Dim bSourceAccion As System.Windows.Forms.BindingSource
                bSourceAccion = New System.Windows.Forms.BindingSource
                bSourceAccion.DataSource = GetType(baseball.lib.vo.accion.accionVO)
                bSourceAccion.DataSource = objVO.Acciones

                Dim rptDataSourceAccion As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
                rptDataSourceAccion.Name = GetType(baseball.lib.vo.accion.accionVO).FullName.Replace(".", "_")
                rptDataSourceAccion.Value = bSourceAccion

                viewer.LocalReport.DataSources.Add(rptDataSourceAccion)

                'MedidaAdoptada
                Dim bSourceMedidaAdoptada As System.Windows.Forms.BindingSource
                bSourceMedidaAdoptada = New System.Windows.Forms.BindingSource
                bSourceMedidaAdoptada.DataSource = GetType(baseball.lib.vo.medidaadoptada.medidaadoptadaVO)
                bSourceMedidaAdoptada.DataSource = objVO.MedidasAdoptadas

                Dim rptDataSourceMedidaAdoptada As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
                rptDataSourceMedidaAdoptada.Name = GetType(baseball.lib.vo.medidaadoptada.medidaadoptadaVO).FullName.Replace(".", "_")
                rptDataSourceMedidaAdoptada.Value = bSourceMedidaAdoptada

                viewer.LocalReport.DataSources.Add(rptDataSourceMedidaAdoptada)


                'EvaluacionDañoes
                Dim bSourceEvaluacionDaño As System.Windows.Forms.BindingSource
                bSourceEvaluacionDaño = New System.Windows.Forms.BindingSource
                bSourceEvaluacionDaño.DataSource = GetType(baseball.lib.vo.evaluacion.evaluacionVO)
                bSourceEvaluacionDaño.DataSource = objVO.Evaluaciones

                Dim rptDataSourceEvaluacionDaño As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
                rptDataSourceEvaluacionDaño.Name = GetType(baseball.lib.vo.evaluacion.evaluacionVO).FullName.Replace(".", "_")
                rptDataSourceEvaluacionDaño.Value = bSourceEvaluacionDaño

                viewer.LocalReport.DataSources.Add(rptDataSourceEvaluacionDaño)

                'Fichero
                Dim bSourceFichero As System.Windows.Forms.BindingSource
                bSourceFichero = New System.Windows.Forms.BindingSource
                bSourceFichero.DataSource = GetType(baseball.lib.vo.fichero.ficheroVO)
                bSourceFichero.DataSource = objVO.Ficheros

                Dim rptDataSourceFichero As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
                rptDataSourceFichero.Name = GetType(baseball.lib.vo.fichero.ficheroVO).FullName.Replace(".", "_")
                rptDataSourceFichero.Value = bSourceFichero

                viewer.LocalReport.DataSources.Add(rptDataSourceFichero)

                ''Recomendacion
                'Dim bSourceRecomendacion As System.Windows.Forms.BindingSource
                'bSourceRecomendacion = New System.Windows.Forms.BindingSource '(Me.components)
                'bSourceRecomendacion.DataSource = GetType(baseball.lib.vo.recomendacion.recomendacionVO)
                'bSourceRecomendacion.DataSource = objVO.Recomendaciones

                'Dim rptDataSourceRecomendacion As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
                'rptDataSourceRecomendacion.Name = GetType(baseball.lib.vo.recomendacion.recomendacionVO).FullName.Replace(".", "_")
                'rptDataSourceRecomendacion.Value = bSourceRecomendacion

                'viewer.LocalReport.DataSources.Add(rptDataSourceRecomendacion)


                viewer.LocalReport.ReportEmbeddedResource = "baseball.rptEquipoDetail.rdlc"


            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function getCompleteVO(ByVal frm As frmEquipoEdit) As baseball.lib.vo.Equipo
            Return getObject(frm)
        End Function
#End Region

    End Class
End Namespace

