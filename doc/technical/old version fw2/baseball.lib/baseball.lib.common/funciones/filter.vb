Namespace funciones
    Public MustInherit Class filter
        Public Shared Function parseString(ByVal stringfilter As String) As String
            Dim res As String

            res = stringfilter.Replace("'", "").Replace("%", "").Replace("?", "").Replace("*", "")

            Return res
        End Function
    End Class

End Namespace
