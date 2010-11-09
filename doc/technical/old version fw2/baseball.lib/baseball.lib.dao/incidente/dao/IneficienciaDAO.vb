Imports gesInef.lib.vo
Namespace equipo.DAO
    Friend Class equipoDAO
        Implements _template.IDAO

        Public Function getequipoAllData(ByRef command As System.Data.Common.DbCommand, ByVal equipo As baseball.lib.vo.Equipo) As baseball.lib.vo.Equipo
            Try
                Dim objVO As baseball.lib.vo.Equipo = equipo

                Dim strQuery As String = _
                "select * from equipo i" _
                & " left join zona z on z.cod_zona = i.cod_zona" _
                & " left join area a on a.cod_area = i.cod_area" _
                & " left join unidad u on u.cod_unidad = i.cod_unidad" _
                & " left join equipo e on e.cod_equipo = i.cod_equipo" _
                & " left join tipo_equipo t on t.cod_tipoinef = i.cod_tipoinef" _
                & " where " _
                & " i.id_inef=@id_inef"

                command.CommandText = strQuery
                command.Parameters.Add(_common.util.CreateParameter(DbType.Int64, "@id_inef", objVO.Id, command))

                Dim reader As Common.DbDataReader = command.ExecuteReader
                Dim res As baseball.lib.vo.Equipo = Nothing
                If (reader.Read) Then
                    res = dataReaderToObject(reader)
                End If
                reader.Close()

                Return res

            Catch ex As Common.DbException
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function

        Public Function getequiposByAreasUsuario(ByRef command As System.Data.Common.DbCommand, ByVal usuario As gesInef.lib.vo.usuario.UsuarioVO) As baseball.lib.vo.Equipo()
            Try
                Dim strQuery As String = "select *" _
                & " from equipo i" _
                & " where" _
                & " (i.cod_usr=@cod_usr or (select count(id_accion) from accion a where i.id_inef=a.id_inef and a.responsable_accion=@cod_usr)>0)" _
                & " or" _
                & " (exists (select * from r_usr_area r where r.cod_area=i.cod_area and r.cod_usr=@cod_usr and r.supervisor=1))"


                command.CommandText = strQuery
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cod_usr", usuario.Codigo, command))


                Dim reader As Common.DbDataReader = command.ExecuteReader
                Dim res As baseball.lib.vo.Equipo() = dataReaderToArray(reader)
                reader.Close()

                Return res
            Catch ex As Exception
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function

        Public Function canCloseequipo(ByRef command As System.Data.Common.DbCommand, ByVal equipo As baseball.lib.vo.Equipo) As Boolean
            Dim res As Boolean = True
            Try
                Dim objVO As baseball.lib.vo.Equipo = equipo

                Dim strTieneST As String = "select * from coste where id_inef=@id_inef and st_coste<>''"

                command.CommandText = strTieneST
                command.Parameters.Add(_common.util.CreateParameter(DbType.Int64, "@id_inef", objVO.Id, command))

                Dim reader As Common.DbDataReader = command.ExecuteReader
                If (reader.Read) Then
                    command.Parameters.Clear()
                    reader.Close()
                    Dim strQuery As String = _
                                    " select *" _
                                    & " from coste c " _
                                    & " inner join equipo i on c.id_inef = i.id_inef " _
                                    & " left join openquery(RPGMAX, 'SELECT wonum, " _
                                    & " description, status FROM MAXIMO.WORKORDER')" _
                                    & " as MAXIMO on MAXIMO.wonum=c.st_coste " _
                                    & " where " _
                                    & " c.id_inef=@id_inef and maximo.status='CM'"

                    command.CommandText = strQuery
                    command.Parameters.Add(_common.util.CreateParameter(DbType.Int64, "@id_inef", objVO.Id, command))
                    reader = command.ExecuteReader
                    res = reader.Read
                End If
                reader.Close()

                Return res

            Catch ex As Common.DbException
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function

        '*********************************************

        Public Function dataReaderToArray(ByVal reader As System.Data.Common.DbDataReader) As Object() Implements _template.IDAO.dataReaderToArray
            Try
                Dim res As baseball.lib.vo.Equipo() = Nothing

                If (Not reader Is Nothing) Then
                    Dim length As Int64 = 0
                    While (reader.Read)
                        ReDim Preserve res(length)
                        res(length) = dataReaderToObject(reader)
                        length += 1
                    End While
                    reader.Close()
                End If

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function dataReaderToObject(ByVal reader As System.Data.Common.DbDataReader) As Object Implements _template.IDAO.dataReaderToObject
            Try
                Dim res As baseball.lib.vo.Equipo = Nothing
                If (Not reader Is Nothing) Then
                    Dim ccollections As New List(Of String)
                    For i As Integer = 0 To reader.FieldCount - 1
                        ccollections.Add(reader.GetName(i))
                    Next
                    Dim col As String = String.Empty

                    res = New baseball.lib.vo.Equipo

                    res.Id = Convert.ToInt64(reader("id_inef"))
                    res.Fecha = Convert.ToDateTime(reader("fecAlta_inef"))
                    res.Usuario = New gesInef.lib.vo.usuario.UsuarioVO
                    res.Usuario.Codigo = Convert.ToString(reader("cod_usr"))
                    res.Numero = Convert.ToInt32(reader("num_inef"))
                    res.Codigo = Convert.ToString(reader("cod_inef"))

                    res.Zona = New vo.zona.ZonaVO
                    res.Zona.Codigo = Convert.ToString(reader("cod_zona"))
                    col = "descr_zona"
                    If (ccollections.Contains(col) AndAlso Not Convert.IsDBNull(reader(col))) Then res.Zona.Descripcion = Convert.ToString(reader("descr_zona"))

                    res.Area = New vo.area.AreaVO
                    res.Area.Codigo = Convert.ToString(reader("cod_area"))
                    col = "descr_area"
                    If (ccollections.Contains(col) AndAlso Not Convert.IsDBNull(reader(col))) Then res.Area.Descripcion = Convert.ToString(reader("descr_area"))
                    res.Area.Zona = res.Zona
                    col = "responsable_area"
                    If (ccollections.Contains(col) AndAlso Not Convert.IsDBNull(reader(col))) Then res.Area.Responsable = New gesInef.lib.vo.usuario.UsuarioVO(Convert.ToString(reader("responsable_area")))

                    res.Unidad = New vo.unidad.UnidadVO
                    res.Unidad.Codigo = Convert.ToString(reader("cod_unidad"))
                    res.Unidad.Area = res.Area
                    col = "descr_unidad"
                    If (ccollections.Contains(col) AndAlso Not Convert.IsDBNull(reader(col))) Then res.Unidad.Descripcion = Convert.ToString(reader("descr_unidad"))

                    If (Not Convert.IsDBNull(reader("cod_equipo"))) Then
                        res.Equipo = New vo.equipo.EquipoVO
                        res.Equipo.Codigo = Convert.ToString(reader("cod_equipo"))
                        col = "descr_equipo"
                        If (ccollections.Contains(col) AndAlso Not Convert.IsDBNull(reader(col))) Then res.Equipo.Descripcion = Convert.ToString(reader("descr_equipo"))
                        res.Equipo.Unidad = res.Unidad
                    End If

                    res.Tipo = New vo.tipoequipo.TipoequipoVO
                    res.Tipo.Codigo = Convert.ToString(reader("cod_tipoinef"))
                    col = "descr_tipoinef"
                    If (ccollections.Contains(col) AndAlso Not Convert.IsDBNull(reader(col))) Then res.Tipo.Descripcion = Convert.ToString(reader("descr_tipoinef"))

                    res.Resumen = Convert.ToString(reader("descResumida_inef"))
                    res.Detalle = Convert.ToString(reader("descDetallada_inef"))
                    res.Inicio = Convert.ToDateTime(reader("fecIni_inef"))
                    res.Fin = Convert.ToDateTime(reader("fecFin_inef"))
                    res.Causa = Convert.ToString(reader("causa_inef"))
                    res.Repeticion = Convert.ToInt16(reader("periodicidad_inef"))

                    res.equipoOriginal = New baseball.lib.vo.Equipo
                    If Not (Convert.IsDBNull(reader("idInefOriginal_inef"))) Then
                        res.equipoOriginal.Id = Convert.ToInt64(reader("idInefOriginal_inef"))
                    End If

                    res.Coste = Convert.ToDouble(reader("costeTotal_inef"))
                    res.Observaciones = Convert.ToString(reader("observaciones_inef"))
                    res.Cerrada = Convert.ToString(reader("cerrada_inef"))

                    res.PteValidar = Convert.ToString(reader("ptevalidar_inef"))
                    res.Generada = Convert.ToString(reader("generada_inef"))
                    res.Notificar = Convert.ToString(reader("notificar_inef"))

                    res.Comentario = Convert.ToString(reader("comentario_inef"))
                End If
                Return res

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function deleteRegistro(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Object Implements _template.IDAO.deleteRegistro
            Try
                Dim objVO As baseball.lib.vo.Equipo = obj

                Dim strQuery As String = _
                " delete equipo" _
                & " where " _
                & " id_inef = @id_inef"

                command.CommandText = strQuery
                command.Parameters.Add(_common.util.CreateParameter(DbType.Int64, "@id_inef", objVO.Id, command))

                command.ExecuteNonQuery()

                Return True

            Catch ex As Common.DbException
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function

        Public Function existsRegistro(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Boolean Implements _template.IDAO.existsRegistro
            Try
                Dim objVO As baseball.lib.vo.Equipo = obj

                Dim strQuery As String = _
                "select * from equipo" _
                & " where " _
                & " id_inef=@id_inef"

                command.CommandText = strQuery
                command.Parameters.Add(_common.util.CreateParameter(DbType.Int64, "@id_inef", objVO.Id, command))

                Dim reader As Common.DbDataReader = command.ExecuteReader
                Dim res As Boolean = reader.Read
                reader.Close()

                Return res

            Catch ex As Common.DbException
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function

        Public Function insertRegistro(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Object Implements _template.IDAO.insertRegistro
            Try
                Dim objVO As baseball.lib.vo.Equipo = obj

                Dim strQuery As String = _
                " insert into equipo" _
                & " (fecAlta_inef, cod_usr, num_inef, cod_inef, cod_zona, cod_area, cod_unidad, cod_equipo, cod_tipoinef, descResumida_inef, descDetallada_inef, fecIni_inef, fecFin_inef, causa_inef, periodicidad_inef, idInefOriginal_inef, costeTotal_inef, observaciones_inef, cerrada_inef, ptevalidar_inef, generada_inef, notificar_inef, comentario_inef) " _
                & " values " _
                & " (@fecAlta_inef, @cod_usr, @num_inef, @cod_inef, @cod_zona, @cod_area, @cod_unidad, @cod_equipo, @cod_tipoinef, @descResumida_inef, @descDetallada_inef, @fecIni_inef, @fecFin_inef, @causa_inef, @periodicidad_inef, @idInefOriginal_inef, @costeTotal_inef, @observaciones_inef, @cerrada_inef, @ptevalidar_inef, @generada_inef, @notificar_inef,  @comentario_inef) " _
                & "; select @id = SCOPE_IDENTITY()"

                command.CommandText = strQuery

                command.Parameters.Add(_common.util.CreateParameter(DbType.DateTime, "@fecAlta_inef", objVO.Fecha, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cod_usr", objVO.Usuario.Codigo, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.Int32, "@num_inef", objVO.Numero, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cod_inef", objVO.Codigo, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cod_zona", objVO.Zona.Codigo, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cod_area", objVO.Area.Codigo, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cod_unidad", objVO.Unidad.Codigo, command))
                If (Not objVO.Equipo Is Nothing) Then
                    command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cod_equipo", objVO.Equipo.Codigo, command))
                Else
                    command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cod_equipo", Convert.DBNull, command))
                End If
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cod_tipoinef", objVO.Tipo.Codigo, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@descResumida_inef", objVO.Resumen, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@descDetallada_inef", objVO.Detalle, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.DateTime, "@fecIni_inef", objVO.Inicio, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.DateTime, "@fecFin_inef", objVO.Fin, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@causa_inef", objVO.Causa, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.Int16, "@periodicidad_inef", objVO.Repeticion, command))
                If (Not objVO.equipoOriginal Is Nothing) AndAlso (objVO.equipoOriginal.Id <> gesInef.lib.util.constantes.vacio.ID) Then
                    command.Parameters.Add(_common.util.CreateParameter(DbType.Int64, "@idInefOriginal_inef", objVO.equipoOriginal.Id, command))
                Else
                    command.Parameters.Add(_common.util.CreateParameter(DbType.Int64, "@idInefOriginal_inef", Convert.DBNull, command))
                End If
                command.Parameters.Add(_common.util.CreateParameter(DbType.Single, "@costeTotal_inef", objVO.Coste, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@observaciones_inef", objVO.Observaciones, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cerrada_inef", objVO.Cerrada, command))

                command.Parameters.Add(_common.util.CreateParameter(DbType.Boolean, "@ptevalidar_inef", objVO.PteValidar, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.Boolean, "@generada_inef", objVO.Generada, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.Boolean, "@notificar_inef", objVO.Notificar, command))

                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@comentario_inef", objVO.Comentario, command))


                command.Parameters.Add(_common.util.CreateParameter(DbType.Int64, "@id", command))
                command.ExecuteNonQuery()

                Dim res As Int64
                res = Convert.ToInt64(command.Parameters("@id").Value)

                Return res

            Catch ex As Common.DbException
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function

        Public Function selectRegistro(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Object Implements _template.IDAO.selectRegistro
            Try
                Dim objVO As baseball.lib.vo.Equipo = obj

                Dim strQuery As String = _
                "select * from equipo" _
                & " where " _
                & " id_inef=@id_inef"

                command.CommandText = strQuery
                command.Parameters.Add(_common.util.CreateParameter(DbType.Int64, "@id_inef", objVO.Id, command))

                Dim reader As Common.DbDataReader = command.ExecuteReader
                Dim res As baseball.lib.vo.Equipo = Nothing
                If (reader.Read) Then
                    res = dataReaderToObject(reader)
                End If
                reader.Close()

                Return res

            Catch ex As Common.DbException
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function

        Public Function selectRegistros(ByVal command As System.Data.Common.DbCommand) As Object() Implements _template.IDAO.selectRegistros
            Try
                Dim strQuery As String = "SELECT * FROM equipo " _
                & " order by id_inef desc"
                command.CommandText = strQuery

                Dim reader As Common.DbDataReader = command.ExecuteReader
                Dim res As baseball.lib.vo.Equipo() = dataReaderToArray(reader)
                reader.Close()

                Return res
            Catch ex As Exception
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function

        Public Function updateRegistro(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Object Implements _template.IDAO.updateRegistro
            Try
                Dim objVO As baseball.lib.vo.Equipo = obj

                Dim strQuery As String = _
                " update equipo" _
                & " set " _
                & "  num_inef = @num_inef" _
                & ", cod_inef = @cod_inef" _
                & ", cod_zona = @cod_zona" _
                & ", cod_area = @cod_area" _
                & ", cod_unidad = @cod_unidad" _
                & ", cod_equipo = @cod_equipo" _
                & ", cod_tipoinef = @cod_tipoinef" _
                & ", descResumida_inef = @descResumida_inef" _
                & ", descDetallada_inef = @descDetallada_inef" _
                & ", fecIni_inef = @fecIni_inef" _
                & ", fecFin_inef = @fecFin_inef" _
                & ", causa_inef = @causa_inef" _
                & ", periodicidad_inef = @periodicidad_inef" _
                & ", idInefOriginal_inef = @idInefOriginal_inef" _
                & ", costeTotal_inef = @costeTotal_inef" _
                & ", observaciones_inef = @observaciones_inef" _
                & ", cerrada_inef = @cerrada_inef" _
                & ", ptevalidar_inef = @ptevalidar_inef" _
                & ", generada_inef = @generada_inef" _
                & ", notificar_inef = @notificar_inef" _
                & ", comentario_inef = @comentario_inef" _
                & " where " _
                & " id_inef = @id_inef"

                command.CommandText = strQuery
                command.Parameters.Add(_common.util.CreateParameter(DbType.Int64, "@id_inef", objVO.Id, command))

                command.Parameters.Add(_common.util.CreateParameter(DbType.DateTime, "@fecAlta_inef", objVO.Fecha, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cod_usr", objVO.Usuario.Codigo, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.Int32, "@num_inef", objVO.Numero, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cod_inef", objVO.Codigo, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cod_zona", objVO.Zona.Codigo, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cod_area", objVO.Area.Codigo, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cod_unidad", objVO.Unidad.Codigo, command))
                If (Not objVO.Equipo Is Nothing) Then
                    command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cod_equipo", objVO.Equipo.Codigo, command))
                Else
                    command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cod_equipo", Convert.DBNull, command))
                End If
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cod_tipoinef", objVO.Tipo.Codigo, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@descResumida_inef", objVO.Resumen, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@descDetallada_inef", objVO.Detalle, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.DateTime, "@fecIni_inef", objVO.Inicio, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.DateTime, "@fecFin_inef", objVO.Fin, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@causa_inef", objVO.Causa, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.Int16, "@periodicidad_inef", objVO.Repeticion, command))
                If (Not objVO.equipoOriginal Is Nothing) AndAlso (objVO.equipoOriginal.Id <> gesInef.lib.util.constantes.vacio.ID) Then
                    command.Parameters.Add(_common.util.CreateParameter(DbType.Int64, "@idInefOriginal_inef", objVO.equipoOriginal.Id, command))
                Else
                    command.Parameters.Add(_common.util.CreateParameter(DbType.Int64, "@idInefOriginal_inef", Convert.DBNull, command))
                End If
                command.Parameters.Add(_common.util.CreateParameter(DbType.Single, "@costeTotal_inef", objVO.Coste, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@observaciones_inef", objVO.Observaciones, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@cerrada_inef", objVO.Cerrada, command))

                command.Parameters.Add(_common.util.CreateParameter(DbType.Boolean, "@ptevalidar_inef", objVO.PteValidar, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.Boolean, "@generada_inef", objVO.Generada, command))
                command.Parameters.Add(_common.util.CreateParameter(DbType.Boolean, "@notificar_inef", objVO.Notificar, command))

                command.Parameters.Add(_common.util.CreateParameter(DbType.String, "@comentario_inef", objVO.Comentario, command))


                command.ExecuteNonQuery()

                Return objVO
            Catch ex As common.DbException
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function
    End Class
End Namespace
