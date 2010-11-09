Namespace frm._estadistica.ctrl

    Public Class ctrlEstadisticaPrint
        Inherits _template.impresion.ctrl.printctrl

        Private _vista As frmEstadisticaPrint

        Public Overrides Sub inicializarForm(ByRef frm As repsol.forms.template.BaseForm)
            Try
                _vista = frm

                '*****************************************
                'Cargamos las competiciones
                '*****************************************
                Dim doSelCompeticions As New baseball.lib.bl.competicion.doGetAll
                Dim aTmpCompeticions As List(Of baseball.lib.vo.Competicion) = doSelCompeticions.execute
                aTmpCompeticions.Insert(0, New baseball.lib.vo.Competicion)
                _vista.cmbCompeticion.DataSource = aTmpCompeticions
                _vista.cmbCompeticion.DisplayMember = "Descripcion"
                _vista.cmbCompeticion.ValueMember = "Id"

                AddHandler _vista.cmbCompeticion.SelectedIndexChanged, AddressOf cmbCompeticion_SelectedIndexChanged

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub cmbCompeticion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

            '*****************************************
            'Cargamos los partidos
            '*****************************************
            Dim doSelPartidos As New baseball.lib.bl.partido.doGetAllByCompeticion(_vista.cmbCompeticion.SelectedItem)
            Dim aTmpPartidos As List(Of baseball.lib.vo.Partido) = doSelPartidos.execute
            aTmpPartidos.Insert(0, New baseball.lib.vo.Partido)
            _vista.cmbPartido.DataSource = aTmpPartidos

        End Sub

        Public Overrides Sub imprimir(ByRef frm As repsol.forms.template.informe.ReportForm)
            Try
                _vista = frm

                Dim filtro As New [lib].vo.FiltroEstadistica
                If (_vista.dateFechaDesde.Checked) Then filtro.Fecha.Desde = _vista.dateFechaDesde.Value
                If (_vista.dateFechaHasta.Checked) Then filtro.Fecha.Hasta = _vista.dateFechaHasta.Value
                If (Not _vista.cmbCompeticion.SelectedItem Is Nothing) AndAlso (Not baseball.lib.common.funciones.getinfo.IsEmpty(CType(_vista.cmbCompeticion.SelectedItem, baseball.lib.vo.Competicion).Id)) Then filtro.Competicion = _vista.cmbCompeticion.SelectedItem
                If (Not _vista.cmbPartido.SelectedItem Is Nothing) AndAlso (Not baseball.lib.common.funciones.getinfo.IsEmpty(CType(_vista.cmbPartido.SelectedItem, baseball.lib.vo.Partido).Id)) Then filtro.Partido = _vista.cmbPartido.SelectedItem

                Dim informe As baseball.lib.bl._reports.Estadistica = Nothing
                Select Case True
                    Case _vista.rbInformeBatting.Checked
                        informe = New baseball.lib.bl._reports.EstadisticaBaseRunning.rptEstadisticaBaseRunning(filtro)

                    Case _vista.rbInformeCatching.Checked
                        informe = New baseball.lib.bl._reports.EstadisticaBaseRunning.rptEstadisticaBaseRunning(filtro)

                    Case _vista.rbInformeFielding.Checked
                        informe = New baseball.lib.bl._reports.EstadisticaBaseRunning.rptEstadisticaBaseRunning(filtro)

                    Case _vista.rbInformePitching.Checked
                        informe = New baseball.lib.bl._reports.EstadisticaBaseRunning.rptEstadisticaBaseRunning(filtro)

                    Case _vista.rbInformeBaseRunning.Checked
                        informe = New baseball.lib.bl._reports.EstadisticaBaseRunning.rptEstadisticaBaseRunning(filtro)

                    Case Else
                        informe = New baseball.lib.bl._reports.EstadisticaBaseRunning.rptEstadisticaBaseRunning(filtro)
                End Select
                informe.setInformeIntoViewer(_vista.viewer)
                _vista.viewer.RefreshReport()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class

End Namespace
