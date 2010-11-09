Imports baseball.lib.vo
Imports System.Data.Common

Namespace arbitro.DAO
    Friend Class arbitroDAO
        Inherits _template.objectDAO

        Public Sub New()
            _selectQry = "select * from arbitro a"
        End Sub

        '*********************************
        Protected Overrides Function dataReaderToList(ByVal reader As System.Data.Common.DbDataReader) As Object
            Try
                Dim res As New List(Of baseball.lib.vo.Arbitro)

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
                Dim res As baseball.lib.vo.Arbitro = Nothing
                If (Not reader Is Nothing) Then
                    Dim ccollections As New List(Of String)
                    For i As Integer = 0 To reader.FieldCount - 1
                        ccollections.Add(reader.GetName(i))
                    Next
                    Dim col As String = String.Empty

                    res = New baseball.lib.vo.Arbitro

                    res.Id = Convert.ToInt16(reader("id_arbitro"))
                    res.Apellido1 = Convert.ToString(reader("apellido1_arbitro"))
                    res.Apellido2 = Convert.ToString(reader("apellido2_arbitro"))
                    res.Nombre = Convert.ToString(reader("nombre_arbitro"))
                End If
                Return res

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Friend Overrides Function checkIfExists(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Boolean
            Try
                Dim objVO As baseball.lib.vo.Arbitro = obj

                Dim strQuery As String = _
                _selectQry _
                & " where " _
                & " id_arbitro=@id_arbitro"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_arbitro", objVO.Id, command))

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
                Dim objVO As baseball.lib.vo.Arbitro = obj

                Dim strQuery As String = _
                _selectQry _
                & " where " _
                & " id_arbitro=@id_arbitro"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_arbitro", objVO.Id, command))

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As baseball.lib.vo.Arbitro = Nothing
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
                Dim strQuery As String = _
                _selectQry _
                & " order by id_arbitro desc"
                command.CommandText = strQuery

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As List(Of baseball.lib.vo.Arbitro) = dataReaderToList(reader)
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
                Dim objVO As baseball.lib.vo.Arbitro = obj

                Dim strQuery As String = _
                " update arbitro" _
                & " set " _
                & " nombre_arbitro = @nombre_arbitro" _
                & ",apellido1_arbitro = @apellido1_arbitro" _
                & ",apellido2_arbitro = @apellido2_arbitro" _
                & " where " _
                & " id_arbitro = @id_arbitro"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_arbitro", objVO.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@nombre_arbitro", objVO.Nombre, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@apellido1_arbitro", objVO.Apellido1, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@apellido2_arbitro", objVO.Apellido2, command))

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
                Dim objVO As baseball.lib.vo.Arbitro = obj

                Dim strQuery As String = _
                " insert into arbitro" _
                & " (nombre_arbitro, apellido1_arbitro, apellido2_arbitro) " _
                & " values " _
                & " (@nombre_arbitro, @apellido1_arbitro, @apellido2_arbitro) " _
                & "; select @id = SCOPE_IDENTITY()"

                command.CommandText = strQuery

                command.Parameters.Add(Me.CreateParameter(DbType.String, "@nombre_arbitro", objVO.Nombre, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@apellido1_arbitro", objVO.Apellido1, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@apellido2_arbitro", objVO.Apellido2, command))

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
                Dim objVO As baseball.lib.vo.Arbitro = obj

                Dim strQuery As String = _
                " delete arbitro" _
                & " where " _
                & " id_arbitro = @id_arbitro"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_arbitro", objVO.Id, command))

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
