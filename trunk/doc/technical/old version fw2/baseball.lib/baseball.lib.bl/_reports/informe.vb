Namespace _reports
    Public MustInherit Class informe
        Protected MustOverride Function getDataSource() As Object
        Protected MustOverride Function getEmbeddedReport() As String

        Public Function getInformePDF() As IO.MemoryStream
            Try

                Dim res As IO.MemoryStream

                Dim warnings As Microsoft.Reporting.WinForms.Warning() = Nothing
                Dim streamids As String() = Nothing
                Dim mimeType As String = String.Empty
                Dim encoding As String = String.Empty
                Dim extension As String = String.Empty

                Dim viewer As New Microsoft.Reporting.WinForms.ReportViewer
                setInformeIntoViewer(viewer)
                res = New IO.MemoryStream(viewer.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamids, warnings))
                res.Seek(0, IO.SeekOrigin.Begin)

                Return res

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public MustOverride Sub setInformeIntoViewer(ByRef viewer As Microsoft.Reporting.WinForms.ReportViewer)

        Public MustOverride Sub setInformeIntoViewer(ByRef viewer As Microsoft.Reporting.WebForms.ReportViewer)

    End Class
End Namespace
