Imports baseball.lib.vo
Imports System.Data.Common

Namespace estadistica.DAO
    Friend Class estadisticaDAO
        Inherits _template.objectDAO

        '*********************************

#Region "************* BASE RUNNING**************"

        Friend Function getAllForBaseRunning(ByVal command As System.Data.Common.DbCommand, ByVal filtro As vo.FiltroEstadistica) As List(Of baseball.lib.vo.EstadisticaBaseRunning)
            Try
                Dim strQuery As String = _
                 " select j.id_jugador, j.nombre_jugador, j.apellido1_jugador, j.apellido2_jugador " _
                & ",sum(h.R_hojaanotacionplayer) as R, sum(h.CR_hojaanotacionplayer) as CR, sum(h.C_hojaanotacionplayer) as C " _
                & " from hojaanotacionplayer h " _
                & " left join jugador j on j.id_jugador = h.id_jugador" _
                & " left join hojaanotacion ha on ha.id_hojaanotacion = h.id_hojaanotacion" _
                & " left join partido p on p.id_partido = ha.id_partido"
                If (Not filtro Is Nothing) Then
                    Dim strB As New System.Text.StringBuilder
                    strB.Append(" where (1=1) ")
                    If (Not filtro.Competicion Is Nothing) Then
                        strB.Append(" AND (id_competicion=@id_competicion) ")
                        command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_competicion", filtro.Competicion.Id, command))
                    End If
                    If (Not filtro.Partido Is Nothing) Then
                        strB.Append(" AND (p.id_partido=@id_partido) ")
                        command.Parameters.Add(Me.CreateParameter(DbType.Int16, "@id_partido", filtro.Partido.Id, command))
                    End If
                    If (filtro.Fecha.Desde.HasValue) Then
                        strB.Append(" AND (fecha_partido>=@fechaDesde_partido) ")
                        command.Parameters.Add(Me.CreateParameter(DbType.Date, "@fechaDesde_partido", filtro.Fecha.Desde.Value, command))
                    End If
                    If (filtro.Fecha.Hasta.HasValue) Then
                        strB.Append(" AND (fecha_partido <=@fechaHasta_partido) ")
                        command.Parameters.Add(Me.CreateParameter(DbType.Date, "@fechaHasta_partido", filtro.Fecha.Hasta.Value, command))
                    End If
                    strQuery &= strB.ToString
                End If
                strQuery &= " group by " _
                & " j.id_jugador, j.nombre_jugador, j.apellido1_jugador, j.apellido2_jugador"
                command.CommandText = strQuery
                Dim reader As Data.Common.DbDataReader = command.ExecuteReader
                Dim res As List(Of baseball.lib.vo.EstadisticaBaseRunning) = dataReaderToListBaseRunning(reader)
                reader.Close()

                Return res
            Catch ex As Exception
                Throw ex
            Finally
                command.Parameters.Clear()
            End Try
        End Function

        Private Function dataReaderToListBaseRunning(ByVal reader As System.Data.Common.DbDataReader) As List(Of EstadisticaBaseRunning)
            Try
                Dim res As New List(Of baseball.lib.vo.EstadisticaBaseRunning)

                If (Not reader Is Nothing) Then
                    While (reader.Read)
                        res.Add(dataReaderToVOBaseRunning(reader))
                    End While
                    reader.Close()
                End If

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Function dataReaderToVOBaseRunning(ByVal reader As System.Data.Common.DbDataReader) As EstadisticaBaseRunning
            Try
                Dim res As baseball.lib.vo.EstadisticaBaseRunning = Nothing
                If (Not reader Is Nothing) Then
                    Dim ccollections As New List(Of String)
                    For i As Integer = 0 To reader.FieldCount - 1
                        ccollections.Add(reader.GetName(i))
                    Next
                    Dim col As String = String.Empty

                    res = New baseball.lib.vo.EstadisticaBaseRunning
                    res.C = Convert.ToInt16(reader("C"))
                    res.R = Convert.ToInt16(reader("R"))
                    res.CR = Convert.ToInt16(reader("CR"))

                    res.Jugador = New baseball.lib.vo.Jugador
                    res.Jugador.Id = Convert.ToInt16(reader("id_jugador"))
                    res.Jugador.Apellido1 = Convert.ToString(reader("apellido1_jugador"))
                    res.Jugador.Apellido2 = Convert.ToString(reader("apellido2_jugador"))
                    res.Jugador.Nombre = Convert.ToString(reader("nombre_jugador"))

                End If
                Return res

            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region

#Region "..."

        Friend Overrides Function add(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Object

        End Function

        Friend Overrides Function checkIfExists(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Boolean

        End Function

        Protected Overrides Function dataReaderToList(ByVal reader As System.Data.Common.DbDataReader) As Object

        End Function

        Protected Overrides Function dataReaderToVO(ByVal reader As System.Data.Common.DbDataReader) As Object

        End Function

        Friend Overrides Function [get](ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Object

        End Function

        Friend Overrides Function getAll(ByVal command As System.Data.Common.DbCommand) As Object

        End Function

        Friend Overrides Function remove(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Object

        End Function

        Friend Overrides Function update(ByVal command As System.Data.Common.DbCommand, ByVal obj As Object) As Object

        End Function
#End Region

    End Class
End Namespace
