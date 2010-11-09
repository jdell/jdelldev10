Namespace funciones
    Public MustInherit Class Eval
        Public Shared Function execute(ByVal expresion As String) As Single
            Try
                Dim dt As New DataTable
                Return dt.Compute(expresion.Replace(",", "."), Nothing)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace
