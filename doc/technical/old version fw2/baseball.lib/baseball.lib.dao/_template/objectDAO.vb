Imports System.Data.Common

Namespace _template

    Friend MustInherit Class objectDAO
        Protected _selectQry As String = String.Empty

        Friend MustOverride Function getAll(ByVal command As DbCommand) As Object
        Friend MustOverride Function [get](ByVal command As DbCommand, ByVal obj As Object) As Object

        Friend MustOverride Function checkIfExists(ByVal command As DbCommand, ByVal obj As Object) As Boolean

        Friend MustOverride Function add(ByVal command As DbCommand, ByVal obj As Object) As Object
        Friend MustOverride Function update(ByVal command As DbCommand, ByVal obj As Object) As Object
        Friend MustOverride Function remove(ByVal command As DbCommand, ByVal obj As Object) As Object

        Protected MustOverride Function dataReaderToList(ByVal reader As Data.Common.DbDataReader) As Object
        Protected MustOverride Function dataReaderToVO(ByVal reader As Data.Common.DbDataReader) As Object

        Protected Function CreateParameter(ByVal type As DbType, ByVal parameterName As String, ByVal command As Data.Common.DbCommand) As Data.Common.DbParameter
            Dim res As Data.Common.DbParameter = command.CreateParameter
            res.DbType = type
            res.ParameterName = parameterName
            res.Direction = ParameterDirection.Output
            Return res
        End Function

        Protected Function CreateParameter(ByVal type As DbType, ByVal parameterName As String, ByVal objectValue As Object, ByVal command As Data.Common.DbCommand) As Data.Common.DbParameter
            Dim res As Data.Common.DbParameter = command.CreateParameter
            res.DbType = type
            res.ParameterName = parameterName
            res.Value = objectValue
            Return res
        End Function

        Protected Function DBValueToObject(ByVal dbvalue As Object) As Object
            Dim res As Object = Nothing

            If (Not Convert.IsDBNull(dbvalue)) Then
                res = dbvalue
            End If

            Return res
        End Function

    End Class

End Namespace


