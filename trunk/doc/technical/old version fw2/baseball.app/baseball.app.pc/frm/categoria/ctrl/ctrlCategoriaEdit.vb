Namespace frm.categoria.ctrl
    Public Class ctrlCategoriaEdit
        Inherits baseball.app.pc._template.edicion.ctrl.editctrl

        Private _vista As frmCategoriaEdit

        Public Overrides Sub cargarDatos(ByRef frm As repsol.forms.template.edicion.EditForm, ByVal obj As Object)
            Try
                Dim objVO As baseball.lib.vo.Categoria = obj
                _vista = frm

                _vista.InnerVO = objVO
                _vista.txtDescripcion.Text = objVO.Descripcion

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overrides Sub guardarDatos(ByRef frm As repsol.forms.template.edicion.EditForm, ByVal newRecord As Boolean)
            Try
                _vista = frm

                Dim obj As baseball.lib.vo.Categoria = getObject(_vista)

                If (newRecord) Then
                    Dim accion As New baseball.lib.bl.categoria.doAdd(obj)
                    _vista.InnerVO = accion.execute()
                Else
                    Dim accion As New baseball.lib.bl.categoria.doUpdate(obj)
                    _vista.InnerVO = accion.execute()
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overrides Sub inicializarForm(ByRef frm As repsol.forms.template.BaseForm)
            Try
                _vista = frm

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overrides Function getObject(ByVal frm As repsol.forms.template.edicion.EditForm) As Object
            Try
                _vista = frm
                Dim obj As baseball.lib.vo.Categoria = _vista.InnerVO
                obj.Descripcion = _vista.txtDescripcion.Text

                Return obj
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Overrides Function getNewObject() As Object
            Try
                Dim res As New baseball.lib.vo.Categoria

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace

