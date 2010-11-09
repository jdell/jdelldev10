Imports baseball.lib.vo
Imports System.Data.Common

Namespace hojaanotacionplayer.DAO
    Friend Class hojaanotacionplayerDAO
        Inherits _template.objectDAO

        Public Sub New()
            _selectQry = "select * from hojaanotacionplayer h  left join jugador j on j.id_jugador = h.id_jugador"
        End Sub

        '*********************************
        Protected Overrides Function dataReaderToList(ByVal reader As System.Data.Common.DbDataReader) As Object
            Try
                Dim res As New List(Of baseball.lib.vo.HojaAnotacionPlayer)

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
                Dim res As baseball.lib.vo.HojaAnotacionPlayer = Nothing
                If (Not reader Is Nothing) Then
                    Dim ccollections As New List(Of String)
                    For i As Integer = 0 To reader.FieldCount - 1
                        ccollections.Add(reader.GetName(i))
                    Next
                    Dim col As String = String.Empty

                    res = New baseball.lib.vo.HojaAnotacionPlayer

                    res.Id = Convert.ToInt16(reader("id_hojaanotacionplayer"))
                    res.A = Convert.ToInt16(reader("a_hojaanotacionplayer"))
                    res.B = Convert.ToInt16(reader("b_hojaanotacionplayer"))
                    res.BH = Convert.ToInt16(reader("bh_hojaanotacionplayer"))
                    res.BI = Convert.ToInt16(reader("bi_hojaanotacionplayer"))
                    res.C = Convert.ToInt16(reader("c_hojaanotacionplayer"))
                    res.CI = Convert.ToInt16(reader("ci_hojaanotacionplayer"))
                    res.CR = Convert.ToInt16(reader("cr_hojaanotacionplayer"))
                    res.DP = Convert.ToInt16(reader("dp_hojaanotacionplayer"))
                    res.DP_Def = Convert.ToInt16(reader("dp_def_hojaanotacionplayer"))
                    res.E = Convert.ToInt16(reader("e_hojaanotacionplayer"))
                    res.EJ = Convert.ToInt16(reader("ej_hojaanotacionplayer"))
                    res.GL = Convert.ToInt16(reader("gl_hojaanotacionplayer"))
                    res.H1 = Convert.ToInt16(reader("h1_hojaanotacionplayer"))
                    res.H2 = Convert.ToInt16(reader("h2_hojaanotacionplayer"))
                    res.H3 = Convert.ToInt16(reader("h3_hojaanotacionplayer"))
                    res.HojaAnotacion = New baseball.lib.vo.HojaAnotacion
                    res.HojaAnotacion.Id = Convert.ToInt16(reader("id_hojaanotacion"))
                    res.HR = Convert.ToInt16(reader("hr_hojaanotacionplayer"))
                    res.IO = Convert.ToInt16(reader("io_hojaanotacionplayer"))
                    res.Jugador = New baseball.lib.vo.Jugador
                    res.Jugador.Id = Convert.ToInt16(reader("id_jugador"))
                    res.Jugador.Apellido1 = Convert.ToString(reader("apellido1_jugador"))
                    res.Jugador.Apellido2 = Convert.ToString(reader("apellido2_jugador"))
                    res.Jugador.Nombre = Convert.ToString(reader("nombre_jugador"))

                    res.K = Convert.ToInt16(reader("k_hojaanotacionplayer"))
                    res.O = Convert.ToInt16(reader("o_hojaanotacionplayer"))
                    res.R = Convert.ToInt16(reader("r_hojaanotacionplayer"))
                    res.SF = Convert.ToInt16(reader("sf_hojaanotacionplayer"))
                    res.SH = Convert.ToInt16(reader("sh_hojaanotacionplayer"))
                    res.TB = Convert.ToInt16(reader("tb_hojaanotacionplayer"))
                    res.V = Convert.ToInt16(reader("v_hojaanotacionplayer"))
                End If
                Return res

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Friend Overrides Function checkIfExists(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Boolean
            Try
                Dim objVO As baseball.lib.vo.HojaAnotacionPlayer = obj

                Dim strQuery As String = _
                _selectQry _
                & " where " _
                & " id_hojaanotacionplayer=@id_hojaanotacionplayer"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacionplayer", objVO.Id, command))

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
                Dim objVO As baseball.lib.vo.HojaAnotacionPlayer = obj

                Dim strQuery As String = _
                _selectQry _
                & " where " _
                & " id_hojaanotacionplayer=@id_hojaanotacionplayer"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacionplayer", objVO.Id, command))

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As baseball.lib.vo.HojaAnotacionPlayer = Nothing
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
                & " order by id_hojaanotacionplayer desc"
                command.CommandText = strQuery

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As List(Of baseball.lib.vo.HojaAnotacionPlayer) = dataReaderToList(reader)
                reader.Close()

                Return res
            Catch ex As Exception
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function
        Friend Overloads Function getAll(ByVal command As System.Data.Common.DbCommand, ByVal hojaAnotacion As vo.HojaAnotacion) As List(Of baseball.lib.vo.HojaAnotacionPlayer)
            Try
                Dim strQuery As String = _selectQry _
                & " where " _
                & " id_hojaanotacion=@id_hojaanotacion" _
                & " order by id_hojaanotacionplayer desc"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacion", hojaAnotacion.Id, command))

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As List(Of baseball.lib.vo.HojaAnotacionPlayer) = dataReaderToList(reader)
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
                Dim objVO As baseball.lib.vo.HojaAnotacionPlayer = obj

                Dim strQuery As String = _
                " update hojaanotacionplayer" _
                & " set " _
                & "  a_hojaanotacionplayer = @a_hojaanotacionplayer" _
                & " ,b_hojaanotacionplayer = @b_hojaanotacionplayer" _
                & " ,bh_hojaanotacionplayer= @bh_hojaanotacionplayer" _
                & " ,bi_hojaanotacionplayer= @bi_hojaanotacionplayer" _
                & " ,c_hojaanotacionplayer= @c_hojaanotacionplayer" _
                & " ,ci_hojaanotacionplayer= @ci_hojaanotacionplayer" _
                & " ,cr_hojaanotacionplayer= @cr_hojaanotacionplayer" _
                & " ,dp_hojaanotacionplayer= @dp_hojaanotacionplayer" _
                & " ,dp_def_hojaanotacionplayer= @dp_def_hojaanotacionplayer" _
                & " ,e_hojaanotacionplayer= @e_hojaanotacionplayer" _
                & " ,ej_hojaanotacionplayer= @ej_hojaanotacionplayer" _
                & " ,gl_hojaanotacionplayer= @gl_hojaanotacionplayer" _
                & " ,h1_hojaanotacionplayer= @h1_hojaanotacionplayer" _
                & " ,h2_hojaanotacionplayer= @h2_hojaanotacionplayer" _
                & " ,h3_hojaanotacionplayer= @h3_hojaanotacionplayer" _
                & " ,id_hojaanotacion= @id_hojaanotacion" _
                & " ,hr_hojaanotacionplayer= @hr_hojaanotacionplayer" _
                & " ,io_hojaanotacionplayer= @io_hojaanotacionplayer" _
                & " ,id_jugador= @id_jugador" _
                & " ,k_hojaanotacionplayer= @k_hojaanotacionplayer" _
                & " ,o_hojaanotacionplayer= @o_hojaanotacionplayer" _
                & " ,r_hojaanotacionplayer= @r_hojaanotacionplayer" _
                & " ,sf_hojaanotacionplayer= @sf_hojaanotacionplayer" _
                & " ,sh_hojaanotacionplayer= @sh_hojaanotacionplayer" _
                & " ,tb_hojaanotacionplayer= @tb_hojaanotacionplayer" _
                & " ,v_hojaanotacionplayer= @v_hojaanotacionplayer" _
                & " where " _
                & " id_hojaanotacionplayer = @id_hojaanotacionplayer"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@a_hojaanotacionplayer", objVO.A, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@b_hojaanotacionplayer", objVO.B, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@bh_hojaanotacionplayer", objVO.BH, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@bi_hojaanotacionplayer", objVO.BI, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@c_hojaanotacionplayer", objVO.C, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@ci_hojaanotacionplayer", objVO.CI, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@cr_hojaanotacionplayer", objVO.CR, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@dp_hojaanotacionplayer", objVO.DP, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@dp_def_hojaanotacionplayer", objVO.DP_Def, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@e_hojaanotacionplayer", objVO.E, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@ej_hojaanotacionplayer", objVO.EJ, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@gl_hojaanotacionplayer", objVO.GL, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@h1_hojaanotacionplayer", objVO.H1, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@h2_hojaanotacionplayer", objVO.H2, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@h3_hojaanotacionplayer", objVO.H3, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacion", objVO.HojaAnotacion.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@hr_hojaanotacionplayer", objVO.HR, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@io_hojaanotacionplayer", objVO.IO, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_jugador", objVO.Jugador.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@k_hojaanotacionplayer", objVO.K, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@o_hojaanotacionplayer", objVO.O, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@r_hojaanotacionplayer", objVO.R, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@sf_hojaanotacionplayer", objVO.SF, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@sh_hojaanotacionplayer", objVO.SH, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@tb_hojaanotacionplayer", objVO.TB, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@v_hojaanotacionplayer", objVO.V, command))

                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacionplayer", objVO.Id, command))

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
                Dim objVO As baseball.lib.vo.HojaAnotacionPlayer = obj

                Dim strQuery As String = _
                " insert into hojaanotacionplayer" _
                & " (a_hojaanotacionplayer, b_hojaanotacionplayer, bh_hojaanotacionplayer, bi_hojaanotacionplayer, c_hojaanotacionplayer, ci_hojaanotacionplayer, cr_hojaanotacionplayer, dp_hojaanotacionplayer, dp_def_hojaanotacionplayer, e_hojaanotacionplayer, ej_hojaanotacionplayer, gl_hojaanotacionplayer, h1_hojaanotacionplayer, h2_hojaanotacionplayer, h3_hojaanotacionplayer, id_hojaanotacion, hr_hojaanotacionplayer, io_hojaanotacionplayer, id_jugador, k_hojaanotacionplayer, o_hojaanotacionplayer, r_hojaanotacionplayer, sf_hojaanotacionplayer, sh_hojaanotacionplayer, tb_hojaanotacionplayer, v_hojaanotacionplayer) " _
                & " values " _
                & " (@a_hojaanotacionplayer, @b_hojaanotacionplayer, @bh_hojaanotacionplayer, @bi_hojaanotacionplayer, @c_hojaanotacionplayer, @ci_hojaanotacionplayer, @cr_hojaanotacionplayer, @dp_hojaanotacionplayer, @dp_def_hojaanotacionplayer, @e_hojaanotacionplayer, @ej_hojaanotacionplayer, @gl_hojaanotacionplayer, @h1_hojaanotacionplayer, @h2_hojaanotacionplayer, @h3_hojaanotacionplayer, @id_hojaanotacion, @hr_hojaanotacionplayer, @io_hojaanotacionplayer, @id_jugador, @k_hojaanotacionplayer, @o_hojaanotacionplayer, @r_hojaanotacionplayer, @sf_hojaanotacionplayer, @sh_hojaanotacionplayer, @tb_hojaanotacionplayer, @v_hojaanotacionplayer) " _
                & "; select @id = SCOPE_IDENTITY()"

                command.CommandText = strQuery

                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@a_hojaanotacionplayer", objVO.A, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@b_hojaanotacionplayer", objVO.B, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@bh_hojaanotacionplayer", objVO.BH, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@bi_hojaanotacionplayer", objVO.BI, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@c_hojaanotacionplayer", objVO.C, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@ci_hojaanotacionplayer", objVO.CI, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@cr_hojaanotacionplayer", objVO.CR, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@dp_hojaanotacionplayer", objVO.DP, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@dp_def_hojaanotacionplayer", objVO.DP_Def, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@e_hojaanotacionplayer", objVO.E, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@ej_hojaanotacionplayer", objVO.EJ, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@gl_hojaanotacionplayer", objVO.GL, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@h1_hojaanotacionplayer", objVO.H1, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@h2_hojaanotacionplayer", objVO.H2, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@h3_hojaanotacionplayer", objVO.H3, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacion", objVO.HojaAnotacion.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@hr_hojaanotacionplayer", objVO.HR, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@io_hojaanotacionplayer", objVO.IO, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_jugador", objVO.Jugador.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@k_hojaanotacionplayer", objVO.K, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@o_hojaanotacionplayer", objVO.O, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@r_hojaanotacionplayer", objVO.R, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@sf_hojaanotacionplayer", objVO.SF, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@sh_hojaanotacionplayer", objVO.SH, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@tb_hojaanotacionplayer", objVO.TB, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@v_hojaanotacionplayer", objVO.V, command))

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
                Dim objVO As baseball.lib.vo.HojaAnotacionPlayer = obj

                Dim strQuery As String = _
                " delete hojaanotacionplayer" _
                & " where " _
                & " id_hojaanotacionplayer = @id_hojaanotacionplayer"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_hojaanotacionplayer", objVO.Id, command))

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
