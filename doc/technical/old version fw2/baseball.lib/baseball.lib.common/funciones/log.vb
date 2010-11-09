Namespace funciones
    Public MustInherit Class log

        Public Shared DIRECTORY As String = IO.Path.GetTempPath
        Public Shared FILE As String = String.Format("{0}{1}{2}", "SAII", DateTime.Now.ToString("yyyyMMdd"), ".log")

        Public Shared Sub Write(ByVal mensaje As String, Optional ByVal withFecha As Boolean = False)
            Try

                WriteFx(mensaje, withFecha)
            Catch ex As Exception
                'NO HACEMOS NADA, ABSOLUTAMENTE NADA.
            End Try
        End Sub

        Public Shared Sub Write(ByVal e As Exception, Optional ByVal withFecha As Boolean = False)
            Try
                Dim mensaje As String = String.Format("{0} : {1}", e.TargetSite.ToString, e.Message)
                WriteFx(mensaje, withFecha)
            Catch ex As Exception
                'NO HACEMOS NADA, ABSOLUTAMENTE NADA.
            End Try
        End Sub

        Private Shared Sub WriteFx(ByVal msg As String, Optional ByVal withFecha As Boolean = False)
            Try
                Dim mensaje As String = msg
                If Not mensaje.Trim = String.Empty Then
                    Dim ruta As String = DIRECTORY
                    Dim nombre As String = FILE
                    ruta = String.Format("{0}\{1}", ruta, nombre)
                    Dim F As IO.TextWriter
                    F = New IO.StreamWriter(ruta, True)
                    If (withFecha) Then
                        F.WriteLine(DateTime.Now.ToString("dd-MM-yyyy hh:mm") & " " & mensaje)
                    Else
                        F.WriteLine(mensaje)
                    End If
                    F.Close()
                End If

            Catch ex As Exception
                'NO HACEMOS NADA, ABSOLUTAMENTE NADA.
            End Try
        End Sub

    End Class
End Namespace

