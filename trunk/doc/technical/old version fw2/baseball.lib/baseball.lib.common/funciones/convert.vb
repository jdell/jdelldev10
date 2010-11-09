Namespace funciones

    Public MustInherit Class conversion
        Public Shared Function ToaByte(ByVal ms As IO.MemoryStream) As Byte()
            Try
                If (ms Is Nothing) Then Return Nothing

                ms.Seek(0, IO.SeekOrigin.Begin)
                Dim b As Byte()
                ReDim b(ms.Length - 1)
                ms.Read(b, 0, ms.Length)
                ms.Close()
                Return b

            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace
