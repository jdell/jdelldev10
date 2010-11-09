Namespace frm.partido.hojaanotacion.ctrl
    Public Class ctrlHojaAnotacionEdit
        Inherits baseball.app.pc._template.edicion.ctrl.editctrl

        Private _vista As frmHojaAnotacionEdit

        Public Overrides Sub cargarDatos(ByRef frm As repsol.forms.template.edicion.EditForm, ByVal obj As Object)
            Try
                Dim objVO As baseball.lib.vo.Partido = obj
                _vista = frm

                Dim doSel As New baseball.lib.bl.partido.doGet(objVO, True)
                _vista.InnerVO = doSel.execute

                _vista.haHomeClub.DataSource = CType(_vista.InnerVO, baseball.lib.vo.Partido).AnotacionHomeClub
                _vista.haVisitante.DataSource = CType(_vista.InnerVO, baseball.lib.vo.Partido).AnotacionVisitante

                'If (Not objVO.Competicion Is Nothing) Then _vista.cmbCompeticion.SelectedValue = objVO.Competicion.Id
                'If (Not objVO.Categoria Is Nothing) Then _vista.cmbCategoria.SelectedValue = objVO.Categoria.Id
                '_vista.txtDivision.Text = objVO.Division
                '_vista.cmbModalidad.SelectedItem = objVO.Modalidad
                '_vista.txtLocalidad.Text = objVO.Localidad
                '_vista.txtTerreno.Text = objVO.Terreno
                'If (Not objVO.HomeClub Is Nothing) Then _vista.cmbHomeClub.SelectedValue = objVO.HomeClub.Id
                'If (Not objVO.Visitante Is Nothing) Then _vista.cmbVisitante.SelectedValue = objVO.Visitante.Id
                'If (Not objVO.Arbitro1 Is Nothing) Then _vista.cmbArbitro1.SelectedValue = objVO.Arbitro1.Id
                'If (Not objVO.Arbitro2 Is Nothing) Then _vista.cmbArbitro2.SelectedValue = objVO.Arbitro2.Id
                'If (Not objVO.Arbitro3 Is Nothing) Then _vista.cmbArbitro3.SelectedValue = objVO.Arbitro3.Id
                'If (Not objVO.Arbitro4 Is Nothing) Then _vista.cmbArbitro4.SelectedValue = objVO.Arbitro4.Id
                'If (Not objVO.Anotador Is Nothing) Then _vista.cmbAnotador.SelectedValue = objVO.Anotador.Id
                '_vista.txtAmonestaciones.Text = objVO.Amonestaciones
                '_vista.txtExpulsiones.Text = objVO.Expulsiones
                '_vista.txtObservaciones.Text = objVO.Observaciones

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overrides Sub guardarDatos(ByRef frm As repsol.forms.template.edicion.EditForm, ByVal newRecord As Boolean)
            Try
                _vista = frm

                Dim obj As baseball.lib.vo.Partido = getObject(_vista)

                'If (newRecord) Then
                '    Dim accion As New baseball.lib.bl.partido.doAdd(obj)
                '    _vista.InnerVO = accion.execute()
                'Else
                Dim accion As New baseball.lib.bl.partido.doUpdate(obj)
                _vista.InnerVO = accion.execute()
                'End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overrides Sub inicializarForm(ByRef frm As repsol.forms.template.BaseForm)
            Try
                _vista = frm

                _vista.Aceptar.Location = New Point(726, 11)
                _vista.Cancelar.Location = New Point(807, 11)


            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overrides Function getObject(ByVal frm As repsol.forms.template.edicion.EditForm) As Object
            Try
                _vista = frm
                Dim obj As baseball.lib.vo.Partido = _vista.InnerVO
                obj.AnotacionHomeClub = _vista.haHomeClub.DataSource
                obj.AnotacionVisitante = _vista.haVisitante.DataSource

                'obj.Competicion = _vista.cmbCompeticion.SelectedItem
                'obj.Categoria = _vista.cmbCategoria.SelectedItem
                'obj.Division = _vista.txtDivision.Text
                'obj.Modalidad = _vista.cmbModalidad.SelectedItem
                'obj.Localidad = _vista.txtLocalidad.Text
                'obj.Terreno = _vista.txtTerreno.Text
                'obj.HomeClub = _vista.cmbHomeClub.SelectedItem
                'obj.Visitante = _vista.cmbVisitante.SelectedItem
                'obj.Arbitro1 = _vista.cmbArbitro1.SelectedItem
                'If (Not baseball.lib.common.funciones.getinfo.IsEmpty(CType(_vista.cmbArbitro2.SelectedItem, baseball.lib.vo.Arbitro).Id)) Then obj.Arbitro2 = _vista.cmbArbitro2.SelectedItem
                'If (Not baseball.lib.common.funciones.getinfo.IsEmpty(CType(_vista.cmbArbitro3.SelectedItem, baseball.lib.vo.Arbitro).Id)) Then obj.Arbitro3 = _vista.cmbArbitro3.SelectedItem
                'If (Not baseball.lib.common.funciones.getinfo.IsEmpty(CType(_vista.cmbArbitro4.SelectedItem, baseball.lib.vo.Arbitro).Id)) Then obj.Arbitro4 = _vista.cmbArbitro4.SelectedItem
                'If (Not baseball.lib.common.funciones.getinfo.IsEmpty(CType(_vista.cmbAnotador.SelectedItem, baseball.lib.vo.Anotador).Id)) Then obj.Anotador = _vista.cmbAnotador.SelectedItem
                'obj.Amonestaciones = _vista.txtAmonestaciones.Text
                'obj.Expulsiones = _vista.txtExpulsiones.Text
                'obj.Observaciones = _vista.txtObservaciones.Text

                Return obj
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Overrides Function getNewObject() As Object
            Try
                Dim res As New baseball.lib.vo.Partido

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace

