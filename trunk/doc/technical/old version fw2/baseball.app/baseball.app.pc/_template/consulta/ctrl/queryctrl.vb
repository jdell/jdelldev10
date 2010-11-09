Namespace _template.consulta.ctrl
    Public MustInherit Class queryctrl
        Inherits repsol.forms.template.consulta.ctrl.QueryFormCtrl

        Public Function getRegistrosSeleccionados(ByRef frm As repsol.forms.template.consulta.QueryForm) As Object
            Try
                '_vista = frm
                Dim res As Object() = Nothing

                If (Not frm.dgConsulta.SelectedRows Is Nothing) Then
                    ReDim res(frm.dgConsulta.SelectedRows.Count - 1)
                    Dim i As Integer = 0
                    For Each dr As DataGridViewRow In frm.dgConsulta.SelectedRows
                        res(i) = DataGridViewRowToVO(dr)
                        i += 1
                    Next
                End If

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function getRegistrosTodos(ByRef frm As repsol.forms.template.consulta.QueryForm) As Object
            Try
                '_vista = frm
                Dim res As Object() = Nothing

                If (Not frm.dgConsulta.Rows Is Nothing) Then
                    ReDim res(frm.dgConsulta.Rows.Count - 1)
                    Dim i As Integer = 0
                    For Each dr As DataGridViewRow In frm.dgConsulta.Rows
                        res(i) = DataGridViewRowToVO(dr)
                        i += 1
                    Next
                End If

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function

#Region "SelectedRow"
        Protected _objVO As Object = Nothing
        Protected _columnNameToRemember As String = "Id"
        Protected _propertyNameToRemember As String = "Id"

        Public Sub saveSelectedRow(ByVal frm As _template.consulta.queryform)
            _objVO = Me.getRegistroSeleccionado(frm)
        End Sub

        Public Sub loadSelectedRow(ByVal frm As _template.consulta.queryform)
            If (Not _objVO Is Nothing) Then
                For Each dr As DataGridViewRow In frm.dgConsulta.Rows
                    If (dr.Cells(_columnNameToRemember).Value = _objVO.GetType().GetProperty(_propertyNameToRemember).GetValue(_objVO, Nothing)) Then
                        frm.dgConsulta.CurrentCell = dr.Cells(frm.dgConsulta.CurrentCell.ColumnIndex)
                        Exit For
                    End If
                Next
            End If
        End Sub
#End Region

        <Obsolete("Obsoleto", True)> _
        Protected Overrides Function ArrayVOToDataView(ByVal aObject() As Object) As System.Data.DataView
            Return Nothing
        End Function

        Protected MustOverride Function ListVOToDataView(ByVal listObject As Object) As System.Data.DataView
    End Class
End Namespace


