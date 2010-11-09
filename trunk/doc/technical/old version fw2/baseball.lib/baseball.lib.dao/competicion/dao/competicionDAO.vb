Imports baseball.lib.vo
Imports System.Data.Common

Namespace competicion.DAO
    Friend Class competicionDAO
        Inherits _template.objectDAO

        '*********************************
        Protected Overrides Function dataReaderToList(ByVal reader As System.Data.Common.DbDataReader) As Object
            Try
                Dim res As New List(Of baseball.lib.vo.Competicion)

                If (Not reader Is Nothing) Then
                    While (reader.Read)
                        res.Add(dataReaderToVO(reader))
                    End While
                    reader.Close()
                End If

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Protected Overrides Function dataReaderToVO(ByVal reader As System.Data.Common.DbDataReader) As Object
            Try
                Dim res As baseball.lib.vo.Competicion = Nothing
                If (Not reader Is Nothing) Then
                    Dim ccollections As New List(Of String)
                    For i As Integer = 0 To reader.FieldCount - 1
                        ccollections.Add(reader.GetName(i))
                    Next
                    Dim col As String = String.Empty

                    res = New baseball.lib.vo.Competicion

                    res.Id = Convert.ToInt16(reader("id_competicion"))
                    res.Descripcion = Convert.ToString(reader("descripcion_competicion"))
                End If
                Return res

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Friend Overrides Function checkIfExists(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Boolean
            Try
                Dim objVO As baseball.lib.vo.Competicion = obj

                Dim strQuery As String = _
                "select * from competicion" _
                & " where " _
                & " id_competicion=@id_competicion"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_competicion", objVO.Id, command))

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As Boolean = reader.Read
                reader.Close()

                Return res

            Catch ex As Data.Common.DbException
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function

        Friend Overrides Function [get](ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Object
            Try
                Dim objVO As baseball.lib.vo.Competicion = obj

                Dim strQuery As String = _
                "select * from competicion" _
                & " where " _
                & " id_competicion=@id_competicion"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_competicion", objVO.Id, command))

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As baseball.lib.vo.Competicion = Nothing
                If (reader.Read) Then
                    res = dataReaderToVO(reader)
                End If
                reader.Close()

                Return res

            Catch ex As Data.Common.DbException
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function

        Friend Overrides Function getAll(ByVal command As System.Data.Common.DbCommand) As Object
            Try
                Dim strQuery As String = "SELECT * FROM competicion " _
                & " order by id_competicion desc"
                command.CommandText = strQuery

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As List(Of baseball.lib.vo.Competicion) = dataReaderToList(reader)
                reader.Close()

                Return res
            Catch ex As Exception
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function

        Friend Overrides Function update(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Object
            Try
                Dim objVO As baseball.lib.vo.Competicion = obj

                Dim strQuery As String = _
                " update competicion" _
                & " set " _
                & "  descripcion_competicion = @descripcion_competicion" _
                & " where " _
                & " id_competicion = @id_competicion"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_competicion", objVO.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@descripcion_competicion", objVO.Descripcion, command))

                command.ExecuteNonQuery()

                Return objVO
            Catch ex As Data.Common.DbException
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function

        Friend Overrides Function add(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Object
            Try
                Dim objVO As baseball.lib.vo.Competicion = obj

                Dim strQuery As String = _
                " insert into competicion" _
                & " (descripcion_competicion) " _
                & " values " _
                & " (@descripcion_competicion) " _
                & "; select @id = SCOPE_IDENTITY()"

                command.CommandText = strQuery

                command.Parameters.Add(Me.CreateParameter(DbType.String, "@descripcion_competicion", objVO.Descripcion, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id", command))
                command.ExecuteNonQuery()

                Dim res As Int16
                res = Convert.ToInt16(command.Parameters("@id").Value)

                Return res

            Catch ex As Data.Common.DbException
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function

        Friend Overrides Function remove(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Object
            Try
                Dim objVO As baseball.lib.vo.Competicion = obj

                Dim strQuery As String = _
                " delete competicion" _
                & " where " _
                & " id_competicion = @id_competicion"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_competicion", objVO.Id, command))

                command.ExecuteNonQuery()

                Return True

            Catch ex As Data.Common.DbException
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function
    End Class
End Namespace
