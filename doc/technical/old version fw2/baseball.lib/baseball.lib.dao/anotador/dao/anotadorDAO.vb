Imports baseball.lib.vo
Imports System.Data.Common

Namespace anotador.DAO
    Friend Class anotadorDAO
        Inherits _template.objectDAO

        Public Sub New()
            _selectQry = "select * from anotador a"
        End Sub

        '*********************************
        Protected Overrides Function dataReaderToList(ByVal reader As System.Data.Common.DbDataReader) As Object
            Try
                Dim res As New List(Of baseball.lib.vo.Anotador)

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
                Dim res As baseball.lib.vo.Anotador = Nothing
                If (Not reader Is Nothing) Then
                    Dim ccollections As New List(Of String)
                    For i As Integer = 0 To reader.FieldCount - 1
                        ccollections.Add(reader.GetName(i))
                    Next
                    Dim col As String = String.Empty

                    res = New baseball.lib.vo.Anotador

                    res.Id = Convert.ToInt16(reader("id_anotador"))
                    res.Apellido1 = Convert.ToString(reader("apellido1_anotador"))
                    res.Apellido2 = Convert.ToString(reader("apellido2_anotador"))
                    res.Nombre = Convert.ToString(reader("nombre_anotador"))
                End If
                Return res

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Friend Overrides Function checkIfExists(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Boolean
            Try
                Dim objVO As baseball.lib.vo.Anotador = obj

                Dim strQuery As String = _
                _selectQry _
                & " where " _
                & " id_anotador=@id_anotador"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_anotador", objVO.Id, command))

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
                Dim objVO As baseball.lib.vo.Anotador = obj

                Dim strQuery As String = _
                _selectQry _
                & " where " _
                & " id_anotador=@id_anotador"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_anotador", objVO.Id, command))

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As baseball.lib.vo.Anotador = Nothing
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
                & " order by id_anotador desc"
                command.CommandText = strQuery

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As List(Of baseball.lib.vo.Anotador) = dataReaderToList(reader)
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
                Dim objVO As baseball.lib.vo.Anotador = obj

                Dim strQuery As String = _
                " update anotador" _
                & " set " _
                & " nombre_anotador = @nombre_anotador" _
                & ",apellido1_anotador = @apellido1_anotador" _
                & ",apellido2_anotador = @apellido2_anotador" _
                & " where " _
                & " id_anotador = @id_anotador"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_anotador", objVO.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@nombre_anotador", objVO.Nombre, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@apellido1_anotador", objVO.Apellido1, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@apellido2_anotador", objVO.Apellido2, command))
          
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
                Dim objVO As baseball.lib.vo.Anotador = obj

                Dim strQuery As String = _
                " insert into anotador" _
                & " (nombre_anotador, apellido1_anotador, apellido2_anotador) " _
                & " values " _
                & " (@nombre_anotador, @apellido1_anotador, @apellido2_anotador) " _
                & "; select @id = SCOPE_IDENTITY()"

                command.CommandText = strQuery

                command.Parameters.Add(Me.CreateParameter(DbType.String, "@nombre_anotador", objVO.Nombre, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@apellido1_anotador", objVO.Apellido1, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@apellido2_anotador", objVO.Apellido2, command))
           
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
                Dim objVO As baseball.lib.vo.Anotador = obj

                Dim strQuery As String = _
                " delete anotador" _
                & " where " _
                & " id_anotador = @id_anotador"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_anotador", objVO.Id, command))

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
