Namespace _common
    <Obsolete("Obsoleto", True)> _
    Friend MustInherit Class util

        Public Shared Function CreateParameter(ByVal type As DbType, ByVal parameterName As String, ByVal command As Data.common.DbCommand) As Data.Common.DbParameter
            Dim res As Data.Common.DbParameter = command.CreateParameter
            res.DbType = type
            res.ParameterName = parameterName
            res.Direction = ParameterDirection.Output
            Return res
        End Function

        Public Shared Function CreateParameter(ByVal type As DbType, ByVal parameterName As String, ByVal objectValue As Object, ByVal command As Data.Common.DbCommand) As Data.Common.DbParameter
            Dim res As Data.Common.DbParameter = command.CreateParameter
            res.DbType = type
            res.ParameterName = parameterName
            res.Value = objectValue
            Return res
        End Function

        Public Shared Function DBValueToObject(ByVal dbvalue As Object) As Object
            Dim res As Object = Nothing

            If (Not Convert.IsDBNull(dbvalue)) Then
                res = dbvalue
            End If

            Return res
        End Function

    End Class
End Namespace