Imports baseball.lib.vo
Imports System.Data.Common

Namespace partido.DAO
    Friend Class partidoDAO
        Inherits _template.objectDAO

        Public Sub New()
            _selectQry = "select p.*" _
            & ", arbitro1.nombre_arbitro as arbitro1_nombre, arbitro1.apellido1_arbitro as arbitro1_apellido1, arbitro1.apellido2_arbitro as arbitro1_apellido2" _
            & ", arbitro2.nombre_arbitro as arbitro2_nombre, arbitro2.apellido1_arbitro as arbitro2_apellido1, arbitro2.apellido2_arbitro as arbitro2_apellido2" _
            & ", arbitro3.nombre_arbitro as arbitro3_nombre, arbitro3.apellido1_arbitro as arbitro3_apellido1, arbitro3.apellido2_arbitro as arbitro3_apellido2" _
            & ", arbitro4.nombre_arbitro as arbitro4_nombre, arbitro4.apellido1_arbitro as arbitro4_apellido1, arbitro4.apellido2_arbitro as arbitro4_apellido2" _
            & ", anotador.nombre_anotador as anotador_nombre, anotador.apellido1_anotador as anotador_apellido1, anotador.apellido2_anotador as anotador_apellido2" _
            & ", ehome.descripcion_equipo as ehome_descripcion" _
            & ", evisitante.descripcion_equipo as evisitante_descripcion" _
            & ", competicion.descripcion_competicion as competicion_descripcion" _
            & ", categoria.descripcion_categoria as categoria_descripcion" _
            & " from partido p" _
            & " left join equipo ehome on p.idhomeclub_equipo = ehome.id_equipo " _
            & " left join equipo evisitante on p.idvisitante_equipo = evisitante.id_equipo " _
            & " left join arbitro arbitro1 on p.idarbitro1_arbitro = arbitro1.id_arbitro " _
            & " left join arbitro arbitro2 on p.idarbitro2_arbitro = arbitro2.id_arbitro " _
            & " left join arbitro arbitro3 on p.idarbitro3_arbitro = arbitro3.id_arbitro " _
            & " left join arbitro arbitro4 on p.idarbitro4_arbitro = arbitro4.id_arbitro " _
            & " left join anotador anotador on p.id_anotador = anotador.id_anotador " _
            & " left join competicion competicion on p.id_competicion = competicion.id_competicion " _
            & " left join categoria categoria on p.id_categoria = categoria.id_categoria "
        End Sub

        '*********************************
        Protected Overrides Function dataReaderToList(ByVal reader As System.Data.Common.DbDataReader) As Object
            Try
                Dim res As New List(Of baseball.lib.vo.Partido)

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
                Dim res As baseball.lib.vo.Partido = Nothing
                If (Not reader Is Nothing) Then
                    Dim ccollections As New List(Of String)
                    For i As Integer = 0 To reader.FieldCount - 1
                        ccollections.Add(reader.GetName(i))
                    Next
                    Dim col As String = String.Empty

                    res = New baseball.lib.vo.Partido

                    res.Id = Convert.ToInt16(reader("id_partido"))
                    res.HomeClub = New baseball.lib.vo.Equipo
                    res.HomeClub.Id = Convert.ToInt16(reader("idhomeclub_equipo"))
                    res.HomeClub.Descripcion = Convert.ToString(reader("ehome_descripcion"))

                    res.Visitante = New baseball.lib.vo.Equipo
                    res.Visitante.Id = Convert.ToInt16(reader("idvisitante_equipo"))
                    res.Visitante.Descripcion = Convert.ToString(reader("evisitante_descripcion"))

                    res.Estado = System.Enum.Parse(GetType(vo.tESTADOPARTIDO), Convert.ToString(reader("estado_partido")))
                    res.Fecha = Convert.ToDateTime(reader("fecha_partido"))

                    res.Arbitro1 = New vo.Arbitro
                    res.Arbitro1.Id = Convert.ToInt16(reader("idarbitro1_arbitro"))
                    res.Arbitro1.Nombre = Convert.ToString(reader("arbitro1_nombre"))
                    res.Arbitro1.Apellido1 = Convert.ToString(reader("arbitro1_apellido1"))
                    res.Arbitro1.Apellido2 = Convert.ToString(reader("arbitro1_apellido2"))

                    col = "idarbitro2_arbitro"
                    If (Not Convert.IsDBNull(reader(col))) Then
                        res.Arbitro2 = New vo.Arbitro
                        res.Arbitro2.Id = Convert.ToInt16(reader(col))
                        res.Arbitro2.Nombre = Convert.ToString(reader("arbitro2_nombre"))
                        res.Arbitro2.Apellido1 = Convert.ToString(reader("arbitro2_apellido1"))
                        res.Arbitro2.Apellido2 = Convert.ToString(reader("arbitro2_apellido2"))
                    End If
                    col = "idarbitro3_arbitro"
                    If (Not Convert.IsDBNull(reader(col))) Then
                        res.Arbitro3 = New vo.Arbitro
                        res.Arbitro3.Id = Convert.ToInt16(reader(col))
                        res.Arbitro3.Nombre = Convert.ToString(reader("arbitro3_nombre"))
                        res.Arbitro3.Apellido1 = Convert.ToString(reader("arbitro3_apellido1"))
                        res.Arbitro3.Apellido2 = Convert.ToString(reader("arbitro3_apellido2"))
                    End If
                    col = "idarbitro4_arbitro"
                    If (Not Convert.IsDBNull(reader(col))) Then
                        res.Arbitro4 = New vo.Arbitro
                        res.Arbitro4.Id = Convert.ToInt16(reader(col))
                        res.Arbitro4.Nombre = Convert.ToString(reader("arbitro4_nombre"))
                        res.Arbitro4.Apellido1 = Convert.ToString(reader("arbitro4_apellido1"))
                        res.Arbitro4.Apellido2 = Convert.ToString(reader("arbitro4_apellido2"))
                    End If
                    col = "id_anotador"
                    If (Not Convert.IsDBNull(reader(col))) Then
                        res.Anotador = New vo.Anotador
                        res.Anotador.Id = Convert.ToInt16(reader(col))
                        res.Anotador.Nombre = Convert.ToString(reader("anotador_nombre"))
                        res.Anotador.Apellido1 = Convert.ToString(reader("anotador_apellido1"))
                        res.Anotador.Apellido2 = Convert.ToString(reader("anotador_apellido2"))
                    End If
                    res.Competicion = New baseball.lib.vo.Competicion
                    res.Competicion.Id = Convert.ToInt16(reader("id_competicion"))
                    res.Competicion.Descripcion = Convert.ToString(reader("competicion_descripcion"))

                    res.Categoria = New vo.Categoria
                    res.Categoria.Id = Convert.ToInt16(reader("id_categoria"))
                    res.Categoria.Descripcion = Convert.ToString(reader("categoria_descripcion"))

                    res.Modalidad = System.Enum.Parse(GetType(vo.tMODALIDADPARTIDO), Convert.ToString(reader("modalidad_partido")))
                    res.Terreno = Convert.ToString(reader("terrenojuego_partido"))
                    res.Division = Convert.ToString(reader("division_partido"))
                    res.Amonestaciones = Convert.ToString(reader("amonestaciones_partido"))
                    res.Expulsiones = Convert.ToString(reader("expulsiones_partido"))
                    res.Observaciones = Convert.ToString(reader("observaciones_partido"))
                    res.Localidad = Convert.ToString(reader("localidad_partido"))

                End If
                Return res

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Friend Overrides Function checkIfExists(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Boolean
            Try
                Dim objVO As baseball.lib.vo.Partido = obj

                Dim strQuery As String = _
                _selectQry _
                & " where " _
                & " id_partido=@id_partido"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_partido", objVO.Id, command))

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
                Dim objVO As baseball.lib.vo.Partido = obj

                Dim strQuery As String = _
                _selectQry _
                & " where " _
                & " id_partido=@id_partido"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_partido", objVO.Id, command))

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As baseball.lib.vo.Partido = Nothing
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
                & " order by fecha_partido desc"
                command.CommandText = strQuery

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As List(Of baseball.lib.vo.Partido) = dataReaderToList(reader)
                reader.Close()

                Return res
            Catch ex As Exception
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function

        Friend Overloads Function getAll(ByVal command As System.Data.Common.DbCommand, ByVal competicion As vo.Competicion) As List(Of baseball.lib.vo.Partido)
            Try
                Dim strQuery As String = _
                _selectQry _
                & " where " _
                & " p.id_competicion=@id_competicion" _
                & " order by fecha_partido desc"
                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_competicion", competicion.Id, command))

                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As List(Of baseball.lib.vo.Partido) = dataReaderToList(reader)
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
                Dim objVO As baseball.lib.vo.Partido = obj
                Dim strQuery As String = _
                " update partido" _
                & " set " _
                & "  idhomeclub_equipo = @idhomeclub_equipo" _
                & " ,idvisitante_equipo = @idvisitante_equipo" _
                & " ,estado_partido = @estado_partido" _
                & " ,fecha_partido = @fecha_partido" _
                & " ,idarbitro1_arbitro = @idarbitro1_arbitro" _
                & " ,idarbitro2_arbitro = @idarbitro2_arbitro" _
                & " ,idarbitro3_arbitro = @idarbitro3_arbitro" _
                & " ,idarbitro4_arbitro = @idarbitro4_arbitro" _
                & " ,id_anotador = @id_anotador" _
                & " ,id_competicion = @id_competicion" _
                & " ,id_categoria = @id_categoria" _
                & " ,modalidad_partido = @modalidad_partido" _
                & " ,terrenojuego_partido = @terrenojuego_partido" _
                & " ,division_partido = @division_partido" _
                & " ,amonestaciones_partido = @amonestaciones_partido" _
                & " ,expulsiones_partido = @expulsiones_partido" _
                & " ,observaciones_partido = @observaciones_partido" _
                & " ,localidad_partido = @localidad_partido" _
                & " where " _
                & " id_partido = @id_partido"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_partido", objVO.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@idhomeclub_equipo", objVO.HomeClub.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@idvisitante_equipo", objVO.Visitante.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@estado_partido", objVO.Estado.ToString, command))
                command.Parameters.Add(Me.CreateParameter(DbType.DateTime, "@fecha_partido", objVO.Fecha, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@idarbitro1_arbitro", objVO.Arbitro1.Id, command))
                If (Not objVO.Arbitro2 Is Nothing) Then
                    command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@idarbitro2_arbitro", objVO.Arbitro2.Id, command))
                Else
                    command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@idarbitro2_arbitro", Convert.DBNull, command))
                End If
                If (Not objVO.Arbitro3 Is Nothing) Then
                    command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@idarbitro3_arbitro", objVO.Arbitro3.Id, command))
                Else
                    command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@idarbitro3_arbitro", Convert.DBNull, command))
                End If
                If (Not objVO.Arbitro4 Is Nothing) Then
                    command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@idarbitro4_arbitro", objVO.Arbitro4.Id, command))
                Else
                    command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@idarbitro4_arbitro", Convert.DBNull, command))
                End If
                If (Not objVO.Anotador Is Nothing) Then
                    command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_anotador", objVO.Anotador.Id, command))
                Else
                    command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_anotador", Convert.DBNull, command))
                End If
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_competicion", objVO.Competicion.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_categoria", objVO.Categoria.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@modalidad_partido", objVO.Modalidad.ToString, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@terrenojuego_partido", objVO.Terreno, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@division_partido", objVO.Division, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@amonestaciones_partido", objVO.Amonestaciones, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@expulsiones_partido", objVO.Expulsiones, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@observaciones_partido", objVO.Observaciones, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@localidad_partido", objVO.Localidad, command))

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
                Dim objVO As baseball.lib.vo.Partido = obj

                Dim strQuery As String = _
                " insert into partido" _
                & " (idhomeclub_equipo, idvisitante_equipo, estado_partido, fecha_partido, idarbitro1_arbitro, idarbitro2_arbitro, idarbitro3_arbitro, idarbitro4_arbitro, id_anotador, id_competicion, id_categoria, modalidad_partido, terrenojuego_partido, amonestaciones_partido, expulsiones_partido, observaciones_partido, localidad_partido, division_partido) " _
                & " values " _
                & " (@idhomeclub_equipo, @idvisitante_equipo, @estado_partido, @fecha_partido, @idarbitro1_arbitro, @idarbitro2_arbitro, @idarbitro3_arbitro, @idarbitro4_arbitro, @id_anotador, @id_competicion, @id_categoria, @modalidad_partido, @terrenojuego_partido, @amonestaciones_partido, @expulsiones_partido, @observaciones_partido, @localidad_partido, @division_partido) " _
                & "; select @id = SCOPE_IDENTITY()"

                command.CommandText = strQuery

                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@idhomeclub_equipo", objVO.HomeClub.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@idvisitante_equipo", objVO.Visitante.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@estado_partido", objVO.Estado.ToString, command))
                command.Parameters.Add(Me.CreateParameter(DbType.DateTime, "@fecha_partido", objVO.Fecha, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@idarbitro1_arbitro", objVO.Arbitro1.Id, command))
                If (Not objVO.Arbitro2 Is Nothing) Then
                    command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@idarbitro2_arbitro", objVO.Arbitro2.Id, command))
                Else
                    command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@idarbitro2_arbitro", Convert.DBNull, command))
                End If
                If (Not objVO.Arbitro3 Is Nothing) Then
                    command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@idarbitro3_arbitro", objVO.Arbitro3.Id, command))
                Else
                    command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@idarbitro3_arbitro", Convert.DBNull, command))
                End If
                If (Not objVO.Arbitro4 Is Nothing) Then
                    command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@idarbitro4_arbitro", objVO.Arbitro4.Id, command))
                Else
                    command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@idarbitro4_arbitro", Convert.DBNull, command))
                End If
                If (Not objVO.Anotador Is Nothing) Then
                    command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_anotador", objVO.Anotador.Id, command))
                Else
                    command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_anotador", Convert.DBNull, command))
                End If
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_competicion", objVO.Competicion.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_categoria", objVO.Categoria.Id, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@modalidad_partido", objVO.Modalidad.ToString, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@terrenojuego_partido", objVO.Terreno, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@division_partido", objVO.Division, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@amonestaciones_partido", objVO.Amonestaciones, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@expulsiones_partido", objVO.Expulsiones, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@observaciones_partido", objVO.Observaciones, command))
                command.Parameters.Add(Me.CreateParameter(DbType.String, "@localidad_partido", objVO.Localidad, command))

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
                Dim objVO As baseball.lib.vo.Partido = obj

                Dim strQuery As String = _
                " delete partido" _
                & " where " _
                & " id_partido = @id_partido"

                command.CommandText = strQuery
                command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_partido", objVO.Id, command))

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
