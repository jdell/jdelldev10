Namespace funciones
    Public MustInherit Class getinfo

        Public Shared Function FECHA(ByVal fec As DateTime, Optional ByVal includehour As Boolean = False) As String
            Dim res As String = baseball.lib.common.constantes.formato.FECHAVACIA
            If Not (fec = baseball.lib.common.constantes.vacio.FECHA) Then
                If (includehour) Then
                    res = fec.ToString(constantes.formato.FECHAHORA)
                Else
                    res = fec.ToString(constantes.formato.FECHA)
                End If
            End If
            Return res
        End Function
        Public Shared Function FECHA(ByVal fec As Nullable(Of DateTime), Optional ByVal includehour As Boolean = False) As String
            Dim res As String = baseball.lib.common.constantes.formato.FECHAVACIA
            If (fec.HasValue) Then
                If (includehour) Then
                    res = fec.Value.ToString(constantes.formato.FECHAHORA)
                Else
                    res = fec.Value.ToString(constantes.formato.FECHA)
                End If
            End If
            Return res
        End Function

        Public Shared Function FECHA(ByVal fec As DateTime, ByVal filler As String) As Object
            Dim res As Object = Convert.DBNull
            If Not (fec = baseball.lib.common.constantes.vacio.FECHA) Then
                res = fec
            End If
            Return res
        End Function

        Public Enum tLOGICO
            SINO
            VERDADEROFALSO
            APLICANOAPLICA
            PERSONALIZADO
        End Enum

        Public Shared Function LOGICO(ByVal bool As Boolean, Optional ByVal tipo As tLOGICO = tLOGICO.SINO, Optional ByVal valorTrue As String = "", Optional ByVal valorFalse As String = "") As String
            Dim res As String = "SI"
            Dim _tmpTrue As String = String.Empty
            Dim _tmpFalse As String = String.Empty

            Select Case tipo
                Case tLOGICO.APLICANOAPLICA
                    _tmpTrue = "Aplica"
                    _tmpFalse = "No Aplica"

                Case tLOGICO.SINO
                    _tmpTrue = "SI"
                    _tmpFalse = "NO"

                Case tLOGICO.VERDADEROFALSO
                    _tmpTrue = "Verdadero"
                    _tmpFalse = "Falso"

                Case tLOGICO.PERSONALIZADO
                    _tmpTrue = valorTrue
                    _tmpFalse = valorFalse
            End Select

            res = IIf(bool, _tmpTrue, _tmpFalse)
            Return res
        End Function

        Public Shared Function IsEmpty(ByVal id As Long) As Boolean
            Return constantes.vacio.ID.CompareTo(id) = 0
        End Function

    End Class
End Namespace

