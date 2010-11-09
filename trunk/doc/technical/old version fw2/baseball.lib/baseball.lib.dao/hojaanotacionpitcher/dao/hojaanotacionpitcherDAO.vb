Imports baseball.lib.vo
Imports System.Data.Common

Namespace hojaanotacionpitcher.DAO
    Friend Class hojaanotacionpitcherDAO
        Inherits _template.objectDAO

        Public Sub New()
            _selectQry = "select * from hojaanotacionpitcher h  left join jugador j on j.id_jugador = h.id_jugador"
        End Sub

        '*********************************
        Protected Overrides Function dataReaderToList(ByVal reader As System.Data.Common.DbDataReader) As Object
            Try
                Dim res As New List(Of baseball.lib.vo.HojaAnotacionPitcher)

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
                Dim res As baseball.lib.vo.HojaAnotacionPitcher = Nothing
                If (Not reader Is Nothing) Then
                    Dim ccollections As New List(Of String)
                    For i As Integer = 0 To reader.FieldCount - 1
                        ccollections.Add(reader.GetName(i))
                    Next
                    Dim col As String = String.Empty

                    res = New baseball.lib.vo.HojaAnotacionPitcher

                    res.Id = Convert.ToInt16(reader("id_hojaanotacionpitcher"))
                    res.B = Convert.ToInt16(reader("b_hojaanotacionpitcher"))
                    res.BE = Convert.ToInt16(reader("be_hojaanotacionpitcher"))
                    res.BI = Convert.ToInt16(reader("bi_hojaanotacionpitcher"))
                    res.BK = Convert.ToInt16(reader("bk_hojaanotacionpitcher"))
                    res.C = Convert.ToInt16(reader("c_hojaanotacionpitcher"))
                    res.CL = Convert.ToInt16(reader("cl_hojaanotacionpitcher"))
                    res.GL = Convert.ToInt16(reader("gl_hojaanotacionpitcher"))
                    res.H1 = Convert.ToInt16(reader("h1_hojaanotacionpitcher"))
                    res.H2 = Convert.ToInt16(reader("h2_hojaanotacionpitcher"))
                    res.H3 = Convert.ToInt16(reader("h3_hojaanotacionpitcher"))
                    res.HojaAnotacion = New baseball.lib.vo.HojaAnotacion
                    res.HojaAnotacion.Id = Convert.ToInt16(reader("id_hojaanotacion"))
                    res.HR = Convert.ToInt16(reader("hr_hojaanotacionpitcher"))
                    res.IO = Convert.ToInt16(reader("io_hojaanotacionpitcher"))
                    res.Jugador = New baseball.lib.vo.Jugador
                    res.Jugador.Id = Convert.ToInt16(reader("id_jugador"))
                    res.Jugador.Apellido1 = Convert.ToString(reader("apellido1_jugador"))
                    res.Jugador.Apellido2 = Convert.ToString(reader("apellido2_jugador"))
                    res.Jugador.Nombre = Convert.ToString(reader("nombre_jugador"))

                    res.K = Convert.ToInt16(reader("k_hojaanotacionpitcher"))
                    res.Labor = System.Enum.Parse(GetType(vo.tLABORPITCHER), Convert.ToString(reader("labor_hojaanotacionpitcher")))
                    res.SF = Convert.ToInt16(reader("sf_hojaanotacionpitcher"))
                    res.SH = Convert.ToInt16(reader("sh_hojaanotacionpitcher"))
                    res.V = Convert.ToInt16(reader("v_hojaanotacionpitcher"))
                    res.WP = Convert.ToInt16(reader("wp_hojaanotacionpitcher"))
                End If
                Return res

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Friend Overrides Function checkIfExists(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Boolean
            Try
                Dim objVO As baseball.lib.vo.HojaAnotacionPitcher = obj

                Dim strQuery As String = _
                "select * from hojaanotacionpitcher" _
                & " where " _
                & " id_hojaanotacionpitcher=@id_hojaanotacionpitcher"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacionpitcher", objVO.Id, command))

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
                Dim objVO As baseball.lib.vo.HojaAnotacionPitcher = obj

                Dim strQuery As String = _
                _selectQry _
                & " where " _
                & " id_hojaanotacionpitcher=@id_hojaanotacionpitcher"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacionpitcher", objVO.Id, command))

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As baseball.lib.vo.HojaAnotacionPitcher = Nothing
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
                & " order by id_hojaanotacionpitcher desc"
                command.CommandText = strQuery

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As List(Of baseball.lib.vo.HojaAnotacionPitcher) = dataReaderToList(reader)
                reader.Close()

                Return res
            Catch ex As Exception
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function
        Friend Overloads Function getAll(ByVal command As System.Data.Common.DbCommand, ByVal hojaAnotacion As vo.HojaAnotacion) As List(Of baseball.lib.vo.HojaAnotacionPitcher)
            Try
                Dim strQuery As String = _selectQry _
                & " where " _
                & " id_hojaanotacion=@id_hojaanotacion" _
                & " order by id_hojaanotacionpitcher desc"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacion", hojaAnotacion.Id, command))

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As List(Of baseball.lib.vo.HojaAnotacionPitcher) = dataReaderToList(reader)
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
                Dim objVO As baseball.lib.vo.HojaAnotacionPitcher = obj

                Dim strQuery As String = _
                " update hojaanotacionpitcher" _
                & " set " _
                & "  b_hojaanotacionpitcher = @b_hojaanotacionpitcher" _
                & " ,be_hojaanotacionpitcher= @be_hojaanotacionpitcher" _
                & " ,bi_hojaanotacionpitcher= @bi_hojaanotacionpitcher" _
                & " ,bk_hojaanotacionpitcher= @bk_hojaanotacionpitcher" _
                & " ,c_hojaanotacionpitcher= @c_hojaanotacionpitcher" _
                & " ,cl_hojaanotacionpitcher= @cl_hojaanotacionpitcher" _
                & " ,gl_hojaanotacionpitcher= @gl_hojaanotacionpitcher" _
                & " ,h1_hojaanotacionpitcher= @h1_hojaanotacionpitcher" _
                & " ,h2_hojaanotacionpitcher= @h2_hojaanotacionpitcher" _
                & " ,h3_hojaanotacionpitcher= @h3_hojaanotacionpitcher" _
                & " ,id_hojaanotacion= @id_hojaanotacion" _
                & " ,hr_hojaanotacionpitcher= @hr_hojaanotacionpitcher" _
                & " ,io_hojaanotacionpitcher= @io_hojaanotacionpitcher" _
                & " ,id_jugador= @id_jugador" _
                & " ,k_hojaanotacionpitcher= @k_hojaanotacionpitcher" _
                & " ,labor_hojaanotacionpitcher= @labor_hojaanotacionpitcher" _
                & " ,sf_hojaanotacionpitcher= @sf_hojaanotacionpitcher" _
                & " ,sh_hojaanotacionpitcher= @sh_hojaanotacionpitcher" _
                & " ,v_hojaanotacionpitcher= @v_hojaanotacionpitcher" _
                & " ,wp_hojaanotacionpitcher= @wp_hojaanotacionpitcher" _
                & " where " _
                & " id_hojaanotacionpitcher = @id_hojaanotacionpitcher"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@b_hojaanotacionpitcher", objVO.B, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@be_hojaanotacionpitcher", objVO.BE, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@bi_hojaanotacionpitcher", objVO.BI, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@bk_hojaanotacionpitcher", objVO.BK, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@c_hojaanotacionpitcher", objVO.C, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@cl_hojaanotacionpitcher", objVO.CL, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@gl_hojaanotacionpitcher", objVO.GL, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@h1_hojaanotacionpitcher", objVO.H1, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@h2_hojaanotacionpitcher", objVO.H2, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@h3_hojaanotacionpitcher", objVO.H3, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacion", objVO.HojaAnotacion.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@hr_hojaanotacionpitcher", objVO.HR, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@io_hojaanotacionpitcher", objVO.IO, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_jugador", objVO.Jugador.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@k_hojaanotacionpitcher", objVO.K, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@labor_hojaanotacionpitcher", objVO.Labor.ToString, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@sf_hojaanotacionpitcher", objVO.SF, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@sh_hojaanotacionpitcher", objVO.SH, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@v_hojaanotacionpitcher", objVO.V, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@wp_hojaanotacionpitcher", objVO.WP, command))

                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacionpitcher", objVO.Id, command))

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
                Dim objVO As baseball.lib.vo.HojaAnotacionPitcher = obj

                Dim strQuery As String = _
                " insert into hojaanotacionpitcher" _
                & " (b_hojaanotacionpitcher, be_hojaanotacionpitcher, bi_hojaanotacionpitcher, bk_hojaanotacionpitcher, c_hojaanotacionpitcher, cl_hojaanotacionpitcher, gl_hojaanotacionpitcher, h1_hojaanotacionpitcher, h2_hojaanotacionpitcher, h3_hojaanotacionpitcher, id_hojaanotacion, hr_hojaanotacionpitcher, io_hojaanotacionpitcher, id_jugador, k_hojaanotacionpitcher, labor_hojaanotacionpitcher, sf_hojaanotacionpitcher, sh_hojaanotacionpitcher, v_hojaanotacionpitcher, wp_hojaanotacionpitcher) " _
                & " values " _
                & " (@b_hojaanotacionpitcher, @be_hojaanotacionpitcher, @bi_hojaanotacionpitcher, @bk_hojaanotacionpitcher, @c_hojaanotacionpitcher, @cl_hojaanotacionpitcher, @gl_hojaanotacionpitcher, @h1_hojaanotacionpitcher, @h2_hojaanotacionpitcher, @h3_hojaanotacionpitcher, @id_hojaanotacion, @hr_hojaanotacionpitcher, @io_hojaanotacionpitcher, @id_jugador, @k_hojaanotacionpitcher, @labor_hojaanotacionpitcher, @sf_hojaanotacionpitcher, @sh_hojaanotacionpitcher, @v_hojaanotacionpitcher, @wp_hojaanotacionpitcher) " _
                & "; select @id = SCOPE_IDENTITY()"

                command.CommandText = strQuery

                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@b_hojaanotacionpitcher", objVO.B, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@be_hojaanotacionpitcher", objVO.BE, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@bi_hojaanotacionpitcher", objVO.BI, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@bk_hojaanotacionpitcher", objVO.BK, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@c_hojaanotacionpitcher", objVO.C, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@cl_hojaanotacionpitcher", objVO.CL, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@gl_hojaanotacionpitcher", objVO.GL, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@h1_hojaanotacionpitcher", objVO.H1, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@h2_hojaanotacionpitcher", objVO.H2, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@h3_hojaanotacionpitcher", objVO.H3, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacion", objVO.HojaAnotacion.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@hr_hojaanotacionpitcher", objVO.HR, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@io_hojaanotacionpitcher", objVO.IO, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_jugador", objVO.Jugador.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@k_hojaanotacionpitcher", objVO.K, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@labor_hojaanotacionpitcher", objVO.Labor.ToString, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@sf_hojaanotacionpitcher", objVO.SF, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@sh_hojaanotacionpitcher", objVO.SH, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@v_hojaanotacionpitcher", objVO.V, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@wp_hojaanotacionpitcher", objVO.WP, command))

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
                Dim objVO As baseball.lib.vo.HojaAnotacionPitcher = obj

                Dim strQuery As String = _
                " delete hojaanotacionpitcher" _
                & " where " _
                & " id_hojaanotacionpitcher = @id_hojaanotacionpitcher"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacionpitcher", objVO.Id, command))

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
