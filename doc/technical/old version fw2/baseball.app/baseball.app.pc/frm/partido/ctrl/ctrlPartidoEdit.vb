Namespace frm.partido.ctrl
    Public Class ctrlPartidoEdit
        Inherits baseball.app.pc._template.edicion.ctrl.editctrl

        Private _vista As frmPartidoEdit

        Public Overrides Sub cargarDatos(ByRef frm As repsol.forms.template.edicion.EditForm, ByVal obj As Object)
            Try
                Dim objVO As baseball.lib.vo.Partido = obj
                _vista = frm

                _vista.InnerVO = objVO
                If (Not objVO.Competicion Is Nothing) Then _vista.cmbCompeticion.SelectedValue = objVO.Competicion.Id
                If (Not objVO.Categoria Is Nothing) Then _vista.cmbCategoria.SelectedValue = objVO.Categoria.Id
                _vista.txtDivision.Text = objVO.Division
                _vista.cmbModalidad.SelectedItem = objVO.Modalidad
                _vista.txtLocalidad.Text = objVO.Localidad
                _vista.txtTerreno.Text = objVO.Terreno
                _vista.dateFecha.Value = objVO.Fecha
                If (Not objVO.HomeClub Is Nothing) Then _vista.cmbHomeClub.SelectedValue = objVO.HomeClub.Id
                If (Not objVO.Visitante Is Nothing) Then _vista.cmbVisitante.SelectedValue = objVO.Visitante.Id
                If (Not objVO.Arbitro1 Is Nothing) Then _vista.cmbArbitro1.SelectedValue = objVO.Arbitro1.Id
                If (Not objVO.Arbitro2 Is Nothing) Then _vista.cmbArbitro2.SelectedValue = objVO.Arbitro2.Id
                If (Not objVO.Arbitro3 Is Nothing) Then _vista.cmbArbitro3.SelectedValue = objVO.Arbitro3.Id
                If (Not objVO.Arbitro4 Is Nothing) Then _vista.cmbArbitro4.SelectedValue = objVO.Arbitro4.Id
                If (Not objVO.Anotador Is Nothing) Then _vista.cmbAnotador.SelectedValue = objVO.Anotador.Id
                _vista.txtAmonestaciones.Text = objVO.Amonestaciones
                _vista.txtExpulsiones.Text = objVO.Expulsiones
                _vista.txtObservaciones.Text = objVO.Observaciones

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overrides Sub guardarDatos(ByRef frm As repsol.forms.template.edicion.EditForm, ByVal newRecord As Boolean)
            Try
                _vista = frm

                Dim obj As baseball.lib.vo.Partido = getObject(_vista)

                If (newRecord) Then
                    Dim accion As New baseball.lib.bl.partido.doAdd(obj)
                    _vista.InnerVO = accion.execute()
                Else
                    Dim accion As New baseball.lib.bl.partido.doUpdate(obj)
                    _vista.InnerVO = accion.execute()
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overrides Sub inicializarForm(ByRef frm As repsol.forms.template.BaseForm)
            Try
                _vista = frm

                'Competicion
                Dim doSelCompeticions As New baseball.lib.bl.competicion.doGetAll
                Dim aTmpCompeticions As List(Of baseball.lib.vo.Competicion) = doSelCompeticions.execute
                aTmpCompeticions.Insert(0, New baseball.lib.vo.Competicion)
                _vista.cmbCompeticion.DataSource = aTmpCompeticions
                _vista.cmbCompeticion.DisplayMember = "Descripcion"
                _vista.cmbCompeticion.ValueMember = "Id"

                'Categoria
                Dim doSelCategorias As New baseball.lib.bl.categoria.doGetAll
                Dim aTmpCategorias As List(Of baseball.lib.vo.Categoria) = doSelCategorias.execute
                aTmpCategorias.Insert(0, New baseball.lib.vo.Categoria)
                _vista.cmbCategoria.DataSource = aTmpCategorias
                _vista.cmbCategoria.DisplayMember = "Descripcion"
                _vista.cmbCategoria.ValueMember = "Id"

                'Modalidad
                _vista.cmbModalidad.DataSource = System.Enum.GetValues(GetType(baseball.lib.vo.tMODALIDADPARTIDO))

                'HomeClub
                Dim doSelHomeClub As New baseball.lib.bl.equipo.doGetAll
                Dim aTmpHomeClub As List(Of baseball.lib.vo.Equipo) = doSelHomeClub.execute
                aTmpHomeClub.Insert(0, New baseball.lib.vo.Equipo)
                _vista.cmbHomeClub.DataSource = aTmpHomeClub
                _vista.cmbHomeClub.DisplayMember = "Descripcion"
                _vista.cmbHomeClub.ValueMember = "Id"

                'Visitante
                Dim doSelVisitante As New baseball.lib.bl.equipo.doGetAll
                Dim aTmpVisitante As List(Of baseball.lib.vo.Equipo) = doSelVisitante.execute
                aTmpVisitante.Insert(0, New baseball.lib.vo.Equipo)
                _vista.cmbVisitante.DataSource = aTmpVisitante
                _vista.cmbVisitante.DisplayMember = "Descripcion"
                _vista.cmbVisitante.ValueMember = "Id"

                'Arbitro1
                Dim doSelArbitro1 As New baseball.lib.bl.arbitro.doGetAll
                Dim aTmpArbitro1 As List(Of baseball.lib.vo.Arbitro) = doSelArbitro1.execute
                aTmpArbitro1.Insert(0, New baseball.lib.vo.Arbitro)
                _vista.cmbArbitro1.DataSource = aTmpArbitro1
                _vista.cmbArbitro1.DisplayMember = "FullName"
                _vista.cmbArbitro1.ValueMember = "Id"

                'Arbitro2
                Dim doSelArbitro2 As New baseball.lib.bl.arbitro.doGetAll
                Dim aTmpArbitro2 As List(Of baseball.lib.vo.Arbitro) = doSelArbitro2.execute
                aTmpArbitro2.Insert(0, New baseball.lib.vo.Arbitro)
                _vista.cmbArbitro2.DataSource = aTmpArbitro2
                _vista.cmbArbitro2.DisplayMember = "FullName"
                _vista.cmbArbitro2.ValueMember = "Id"

                'Arbitro3
                Dim doSelArbitro3 As New baseball.lib.bl.arbitro.doGetAll
                Dim aTmpArbitro3 As List(Of baseball.lib.vo.Arbitro) = doSelArbitro3.execute
                aTmpArbitro3.Insert(0, New baseball.lib.vo.Arbitro)
                _vista.cmbArbitro3.DataSource = aTmpArbitro3
                _vista.cmbArbitro3.DisplayMember = "FullName"
                _vista.cmbArbitro3.ValueMember = "Id"

                'Arbitro4
                Dim doSelArbitro4 As New baseball.lib.bl.arbitro.doGetAll
                Dim aTmpArbitro4 As List(Of baseball.lib.vo.Arbitro) = doSelArbitro4.execute
                aTmpArbitro4.Insert(0, New baseball.lib.vo.Arbitro)
                _vista.cmbArbitro4.DataSource = aTmpArbitro4
                _vista.cmbArbitro4.DisplayMember = "FullName"
                _vista.cmbArbitro4.ValueMember = "Id"

                'Anotador
                Dim doSelAnotador As New baseball.lib.bl.anotador.doGetAll
                Dim aTmpAnotador As List(Of baseball.lib.vo.Anotador) = doSelAnotador.execute
                aTmpAnotador.Insert(0, New baseball.lib.vo.Anotador)
                _vista.cmbAnotador.DataSource = aTmpAnotador
                _vista.cmbAnotador.DisplayMember = "FullName"
                _vista.cmbAnotador.ValueMember = "Id"


            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overrides Function getObject(ByVal frm As repsol.forms.template.edicion.EditForm) As Object
            Try
                _vista = frm
                Dim obj As baseball.lib.vo.Partido = _vista.InnerVO
                obj.Fecha = _vista.dateFecha.Value
                obj.Competicion = _vista.cmbCompeticion.SelectedItem
                obj.Categoria = _vista.cmbCategoria.SelectedItem
                obj.Division = _vista.txtDivision.Text
                obj.Modalidad = _vista.cmbModalidad.SelectedItem
                obj.Localidad = _vista.txtLocalidad.Text
                obj.Terreno = _vista.txtTerreno.Text
                obj.HomeClub = _vista.cmbHomeClub.SelectedItem
                obj.Visitante = _vista.cmbVisitante.SelectedItem
                obj.Arbitro1 = _vista.cmbArbitro1.SelectedItem
                If (Not baseball.lib.common.funciones.getinfo.IsEmpty(CType(_vista.cmbArbitro2.SelectedItem, baseball.lib.vo.Arbitro).Id)) Then obj.Arbitro2 = _vista.cmbArbitro2.SelectedItem
                If (Not baseball.lib.common.funciones.getinfo.IsEmpty(CType(_vista.cmbArbitro3.SelectedItem, baseball.lib.vo.Arbitro).Id)) Then obj.Arbitro3 = _vista.cmbArbitro3.SelectedItem
                If (Not baseball.lib.common.funciones.getinfo.IsEmpty(CType(_vista.cmbArbitro4.SelectedItem, baseball.lib.vo.Arbitro).Id)) Then obj.Arbitro4 = _vista.cmbArbitro4.SelectedItem
                If (Not baseball.lib.common.funciones.getinfo.IsEmpty(CType(_vista.cmbAnotador.SelectedItem, baseball.lib.vo.Anotador).Id)) Then obj.Anotador = _vista.cmbAnotador.SelectedItem
                obj.Amonestaciones = _vista.txtAmonestaciones.Text
                obj.Expulsiones = _vista.txtExpulsiones.Text
                obj.Observaciones = _vista.txtObservaciones.Text

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

