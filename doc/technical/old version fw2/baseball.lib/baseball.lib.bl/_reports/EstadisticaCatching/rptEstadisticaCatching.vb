Namespace _reports.EstadisticaCatching
    Public Class rptEstadisticaCatching
        Inherits Estadistica


        Public Sub New(ByVal filtro As vo.FiltroEstadistica)
            MyBase.New(filtro)
        End Sub

        Protected Overrides Function getEmbeddedReport() As String
            Try
                Dim res As String = String.Empty

                res = "baseball.lib.bl.rdlEstadisticaCatching.rdlc"

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Protected Overrides Function getDataSource() As Object
            Try
                Dim res As List(Of vo.EstadisticaCatcher) = Nothing
                Dim doSel As New _estadistica.doGetAllForCatcher(Me._filtro)
                res = doSel.execute

                If (res Is Nothing) Then res = New List(Of vo.EstadisticaCatcher)
                Return res.ToArray
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Overloads Overrides Sub setInformeIntoViewer(ByRef viewer As Microsoft.Reporting.WinForms.ReportViewer)
            Try
                Dim aObjVO As vo.EstadisticaCatcher() = getDataSource()

                Dim rptDataSourceEstadistica As New Microsoft.Reporting.WinForms.ReportDataSource
                rptDataSourceEstadistica.Name = GetType(vo.EstadisticaCatcher).FullName.Replace(".", "_")
                rptDataSourceEstadistica.Value = aObjVO

                viewer.LocalReport.DataSources.Clear()
                viewer.LocalReport.DataSources.Add(rptDataSourceEstadistica)
                viewer.LocalReport.ReportEmbeddedResource = getEmbeddedReport()

                If (Not Me._filtro Is Nothing) Then
                    Dim param As Microsoft.Reporting.WinForms.ReportParameter
                    Dim list As New List(Of Microsoft.Reporting.WinForms.ReportParameter)

                    If (Not Me._filtro.Competicion Is Nothing) Then
                        param = New Microsoft.Reporting.WinForms.ReportParameter("competicion", Me._filtro.Competicion.ToString)
                        list.Add(param)
                    Else
                        param = New Microsoft.Reporting.WinForms.ReportParameter("competicion", "Todas")
                        list.Add(param)
                    End If
                    If (Not Me._filtro.Partido Is Nothing) Then
                        param = New Microsoft.Reporting.WinForms.ReportParameter("partido", Me._filtro.Partido.ToString)
                        list.Add(param)
                    Else
                        param = New Microsoft.Reporting.WinForms.ReportParameter("partido", "Todos")
                        list.Add(param)
                    End If
                    If (Not Me._filtro.Fecha Is Nothing) Then
                        param = New Microsoft.Reporting.WinForms.ReportParameter("fecha", Me._filtro.Fecha.ToString)
                        list.Add(param)
                    End If
                    If (list.Count > 0) Then viewer.LocalReport.SetParameters(list.ToArray)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Overloads Overrides Sub setInformeIntoViewer(ByRef viewer As Microsoft.Reporting.WebForms.ReportViewer)
            Try
                Dim aObjVO As vo.EstadisticaCatcher() = getDataSource()
                Throw New Exception("No implementado")
                ''Estadistica
                'Dim rptDataSourceEstadistica As New Microsoft.Reporting.WebForms.ReportDataSource
                'rptDataSourceEstadistica.Name = GetType(vo.EstadisticaCatcher).FullName.Replace(".", "_")
                'rptDataSourceEstadistica.Value = aObjVO

                'viewer.LocalReport.DataSources.Clear()
                'viewer.LocalReport.DataSources.Add(rptDataSourceEstadistica)
                'viewer.LocalReport.ReportEmbeddedResource = getEmbeddedReport()

                'If (Not Me._filtro Is Nothing) Then
                '    Dim param As Microsoft.Reporting.WebForms.ReportParameter
                '    Dim list As New List(Of Microsoft.Reporting.WebForms.ReportParameter)

                '    If (Not Me._filtro.Competicion Is Nothing) Then
                '        param = New Microsoft.Reporting.WebForms.ReportParameter("competicion", Me._filtro.Competicion.ToString)
                '        list.Add(param)
                '    End If
                '    If (Not Me._filtro.Partido Is Nothing) Then
                '        param = New Microsoft.Reporting.WebForms.ReportParameter("partido", Me._filtro.Partido.ToString)
                '        list.Add(param)
                '    End If
                '    If (Not Me._filtro.Fecha Is Nothing) Then
                '        param = New Microsoft.Reporting.WebForms.ReportParameter("fecha", Me._filtro.Fecha.ToString)
                '        list.Add(param)
                '    End If
                '    If (list.Count > 0) Then viewer.LocalReport.SetParameters(list.ToArray)
                'End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace

