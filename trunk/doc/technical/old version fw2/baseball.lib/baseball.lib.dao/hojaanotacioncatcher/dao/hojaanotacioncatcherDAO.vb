Imports baseball.lib.vo
Imports System.Data.Common

Namespace hojaanotacioncatcher.DAO
    Friend Class hojaanotacioncatcherDAO
        Inherits _template.objectDAO

        Public Sub New()
            _selectQry = "select * from hojaanotacioncatcher h  left join jugador j on j.id_jugador = h.id_jugador"
        End Sub

        '*********************************
        Protected Overrides Function dataReaderToList(ByVal reader As System.Data.Common.DbDataReader) As Object
            Try
                Dim res As New List(Of baseball.lib.vo.HojaAnotacionCatcher)

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
                Dim res As baseball.lib.vo.HojaAnotacionCatcher = Nothing
                If (Not reader Is Nothing) Then
                    Dim ccollections As New List(Of String)
                    For i As Integer = 0 To reader.FieldCount - 1
                        ccollections.Add(reader.GetName(i))
                    Next
                    Dim col As String = String.Empty

                    res = New baseball.lib.vo.HojaAnotacionCatcher

                    res.Id = Convert.ToInt16(reader("id_hojaanotacioncatcher"))
                    res.CR = Convert.ToInt16(reader("cr_hojaanotacioncatcher"))
                    res.Jugador = New baseball.lib.vo.Jugador
                    res.Jugador.Id = Convert.ToInt16(reader("id_jugador"))
                    res.Jugador.Apellido1 = Convert.ToString(reader("apellido1_jugador"))
                    res.Jugador.Apellido2 = Convert.ToString(reader("apellido2_jugador"))
                    res.Jugador.Nombre = Convert.ToString(reader("nombre_jugador"))

                    res.PB = Convert.ToInt16(reader("pb_hojaanotacioncatcher"))
                    res.R = Convert.ToInt16(reader("r_hojaanotacioncatcher"))
                    res.HojaAnotacion = New baseball.lib.vo.HojaAnotacion
                    res.HojaAnotacion.Id = Convert.ToInt16(reader("id_hojaanotacion"))
                End If
                Return res

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Friend Overrides Function checkIfExists(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Boolean
            Try
                Dim objVO As baseball.lib.vo.HojaAnotacionCatcher = obj

                Dim strQuery As String = _
                _selectQry _
                & " where " _
                & " id_hojaanotacioncatcher=@id_hojaanotacioncatcher"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacioncatcher", objVO.Id, command))

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
                Dim objVO As baseball.lib.vo.HojaAnotacionCatcher = obj

                Dim strQuery As String = _
                _selectQry _
                & " where " _
                & " id_hojaanotacioncatcher=@id_hojaanotacioncatcher"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacioncatcher", objVO.Id, command))

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As baseball.lib.vo.HojaAnotacionCatcher = Nothing
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
                Dim strQuery As String = _selectQry _
                & " order by id_hojaanotacioncatcher desc"
                command.CommandText = strQuery

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As List(Of baseball.lib.vo.HojaAnotacionCatcher) = dataReaderToList(reader)
                reader.Close()

                Return res
            Catch ex As Exception
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function
        Friend Overloads Function getAll(ByVal command As System.Data.Common.DbCommand, ByVal hojaAnotacion As vo.HojaAnotacion) As List(Of baseball.lib.vo.HojaAnotacionCatcher)
            Try
                Dim strQuery As String = _selectQry _
                & " where " _
                & " id_hojaanotacion=@id_hojaanotacion" _
                & " order by id_hojaanotacioncatcher desc"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacion", hojaAnotacion.Id, command))

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As List(Of baseball.lib.vo.HojaAnotacionCatcher) = dataReaderToList(reader)
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
                Dim objVO As baseball.lib.vo.HojaAnotacionCatcher = obj

                Dim strQuery As String = _
                " update hojaanotacioncatcher" _
                & " set " _
                & "  cr_hojaanotacioncatcher = @cr_hojaanotacioncatcher" _
                & " ,id_jugador= @id_jugador" _
                & " ,pb_hojaanotacioncatcher= @pb_hojaanotacioncatcher" _
                & " ,r_hojaanotacioncatcher= @r_hojaanotacioncatcher" _
                & " ,id_hojaanotacion= @id_hojaanotacion" _
                & " where " _
                & " id_hojaanotacioncatcher = @id_hojaanotacioncatcher"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacioncatcher", objVO.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@cr_hojaanotacioncatcher", objVO.CR, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_jugador", objVO.Jugador.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@pb_hojaanotacioncatcher", objVO.PB, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@r_hojaanotacioncatcher", objVO.R, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacion", objVO.HojaAnotacion.Id, command))

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
                Dim objVO As baseball.lib.vo.HojaAnotacionCatcher = obj

                Dim strQuery As String = _
                " insert into hojaanotacioncatcher" _
                & " (cr_hojaanotacioncatcher, id_jugador, pb_hojaanotacioncatcher, r_hojaanotacioncatcher, id_hojaanotacion) " _
                & " values " _
                & " (@cr_hojaanotacioncatcher, @id_jugador, @pb_hojaanotacioncatcher, @r_hojaanotacioncatcher, @id_hojaanotacion) " _
                & "; select @id = SCOPE_IDENTITY()"

                command.CommandText = strQuery

                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@cr_hojaanotacioncatcher", objVO.CR, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_jugador", objVO.Jugador.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@pb_hojaanotacioncatcher", objVO.PB, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@r_hojaanotacioncatcher", objVO.R, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacion", objVO.HojaAnotacion.Id, command))

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
                Dim objVO As baseball.lib.vo.HojaAnotacionCatcher = obj

                Dim strQuery As String = _
                " delete hojaanotacioncatcher" _
                & " where " _
                & " id_hojaanotacioncatcher = @id_hojaanotacioncatcher"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacioncatcher", objVO.Id, command))

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
