Namespace frm.jugador.ctrl
    Public Class ctrlJugadorEdit
        Inherits baseball.app.pc._template.edicion.ctrl.editctrl

        Private _vista As frmJugadorEdit

        Public Overrides Sub cargarDatos(ByRef frm As repsol.forms.template.edicion.EditForm, ByVal obj As Object)
            Try
                Dim objVO As baseball.lib.vo.Jugador = obj
                _vista = frm

                _vista.InnerVO = objVO
                _vista.txtApellido1.Text = objVO.Apellido1
                _vista.txtApellido2.Text = objVO.Apellido2
                _vista.txtNombre.Text = objVO.Nombre
                If (Not objVO.Equipo Is Nothing) Then _vista.cmbEquipo.SelectedValue = objVO.Equipo.Id

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overrides Sub guardarDatos(ByRef frm As repsol.forms.template.edicion.EditForm, ByVal newRecord As Boolean)
            Try
                _vista = frm

                Dim obj As baseball.lib.vo.Jugador = getObject(_vista)

                If (newRecord) Then
                    Dim accion As New baseball.lib.bl.jugador.doAdd(obj)
                    _vista.InnerVO = accion.execute()
                Else
                    Dim accion As New baseball.lib.bl.jugador.doUpdate(obj)
                    _vista.InnerVO = accion.execute()
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overrides Sub inicializarForm(ByRef frm As repsol.forms.template.BaseForm)
            Try
                _vista = frm

                Dim doSelEquipos As New baseball.lib.bl.equipo.doGetAll
                Dim aTmp As List(Of baseball.lib.vo.Equipo) = doSelEquipos.execute
                aTmp.Insert(0, New baseball.lib.vo.Equipo)
                _vista.cmbEquipo.DataSource = aTmp
                _vista.cmbEquipo.DisplayMember = "Descripcion"
                _vista.cmbEquipo.ValueMember = "Id"

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overrides Function getObject(ByVal frm As repsol.forms.template.edicion.EditForm) As Object
            Try
                _vista = frm
                Dim obj As baseball.lib.vo.Jugador = _vista.InnerVO
                obj.Apellido1 = _vista.txtApellido1.Text
                obj.Apellido2 = _vista.txtApellido2.Text
                obj.Nombre = _vista.txtNombre.Text
                obj.Equipo = _vista.cmbEquipo.SelectedItem

                Return obj
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Overrides Function getNewObject() As Object
            Try
                Dim res As New baseball.lib.vo.Jugador

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace

