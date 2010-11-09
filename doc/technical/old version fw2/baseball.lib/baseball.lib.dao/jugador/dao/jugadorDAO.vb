Imports baseball.lib.vo
Imports System.Data.Common

Namespace jugador.DAO
    Friend Class jugadorDAO
        Inherits _template.objectDAO

        Public Sub New()
            _selectQry = "select * from jugador j left join equipo e on j.id_equipo = e.id_equipo"
        End Sub

        '*********************************
        Protected Overrides Function dataReaderToList(ByVal reader As System.Data.Common.DbDataReader) As Object
            Try
                Dim res As New List(Of baseball.lib.vo.Jugador)

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
                Dim res As baseball.lib.vo.Jugador = Nothing
                If (Not reader Is Nothing) Then
                    Dim ccollections As New List(Of String)
                    For i As Integer = 0 To reader.FieldCount - 1
                        ccollections.Add(reader.GetName(i))
                    Next
                    Dim col As String = String.Empty

                    res = New baseball.lib.vo.Jugador

                    res.Id = Convert.ToInt16(reader("id_jugador"))
                    res.Apellido1 = Convert.ToString(reader("apellido1_jugador"))
                    res.Apellido2 = Convert.ToString(reader("apellido2_jugador"))
                    If (Not Convert.IsDBNull(reader("id_equipo"))) Then
                        res.Equipo = New [lib].vo.Equipo
                        res.Equipo.Id = Convert.ToInt16(reader("id_equipo"))
                        res.Equipo.Descripcion = Convert.ToString(reader("descripcion_equipo"))
                    End If
                    res.Nombre = Convert.ToString(reader("nombre_jugador"))
                End If
                Return res

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Friend Overrides Function checkIfExists(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Boolean
            Try
                Dim objVO As baseball.lib.vo.Jugador = obj

                Dim strQuery As String = _
                _selectQry _
                & " where " _
                & " id_jugador=@id_jugador"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_jugador", objVO.Id, command))

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
                Dim objVO As baseball.lib.vo.Jugador = obj

                Dim strQuery As String = _
                _selectQry _
                & " where " _
                & " id_jugador=@id_jugador"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_jugador", objVO.Id, command))

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As baseball.lib.vo.Jugador = Nothing
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
                & " order by id_jugador desc"
                command.CommandText = strQuery

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As List(Of baseball.lib.vo.Jugador) = dataReaderToList(reader)
                reader.Close()

                Return res
            Catch ex As Exception
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function

        Friend Overloads Function getAll(ByVal command As System.Data.Common.DbCommand, ByVal equipo As [lib].vo.Equipo) As List(Of baseball.lib.vo.Jugador)
            Try
                Dim strQuery As String = _
                _selectQry _
                & " where " _
                & " j.id_equipo=@id_equipo" _
                & " order by id_jugador desc"
                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_equipo", equipo.Id, command))

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As List(Of baseball.lib.vo.Jugador) = dataReaderToList(reader)
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
                Dim objVO As baseball.lib.vo.Jugador = obj

                Dim strQuery As String = _
                " update jugador" _
                & " set " _
                & " nombre_jugador = @nombre_jugador" _
                & ",apellido1_jugador = @apellido1_jugador" _
                & ",apellido2_jugador = @apellido2_jugador" _
                & ",id_equipo = @id_equipo" _
                & " where " _
                & " id_jugador = @id_jugador"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_jugador", objVO.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@nombre_jugador", objVO.Nombre, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@apellido1_jugador", objVO.Apellido1, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@apellido2_jugador", objVO.Apellido2, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_equipo", objVO.Equipo.Id, command))

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
                Dim objVO As baseball.lib.vo.Jugador = obj

                Dim strQuery As String = _
                " insert into jugador" _
                & " (nombre_jugador, apellido1_jugador, apellido2_jugador, id_equipo) " _
                & " values " _
                & " (@nombre_jugador, @apellido1_jugador, @apellido2_jugador, @id_equipo) " _
                & "; select @id = SCOPE_IDENTITY()"

                command.CommandText = strQuery

                command.Parameters.Add(Me.CreateParameter(DbType.String, "@nombre_jugador", objVO.Nombre, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@apellido1_jugador", objVO.Apellido1, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@apellido2_jugador", objVO.Apellido2, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_equipo", objVO.Equipo.Id, command))

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
                Dim objVO As baseball.lib.vo.Jugador = obj

                Dim strQuery As String = _
                " delete jugador" _
                & " where " _
                & " id_jugador = @id_jugador"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_jugador", objVO.Id, command))

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
