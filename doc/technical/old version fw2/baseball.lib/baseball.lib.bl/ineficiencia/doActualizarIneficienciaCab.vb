Namespace Ineficiencia

    Public Class doActualizarIneficienciaCab
        Inherits _template.ActionBL

        Private accionIneficiencia As New baseball.lib.dao.Ineficiencia.fachada
        Private _ineficiencia As baseball.lib.vo.ineficiencia.IneficienciaVO

        Public Sub New(ByVal ineficiencia As baseball.lib.vo.ineficiencia.IneficienciaVO)
            _ineficiencia = ineficiencia
        End Sub
        Public Shadows Function execute() As Object
            Return MyBase.execute
        End Function

#Region "<20070808>"
        '<20070808> Incidencia! el coste devuelve cero porque
        'la lista de costes (_ineficiencia.Costes) es nothing
        Private Function ChunkToVO(ByVal aObj As baseball.lib.vo.coste.CosteChunkVO()) As baseball.lib.vo.coste.CosteVO()
            Try
                Dim res As baseball.lib.vo.coste.CosteVO() = Nothing
                If Not (aObj Is Nothing) Then
                    For i As Integer = 0 To aObj.Length - 1
                        ReDim Preserve res(i)
                        res(i) = aObj(i).Coste
                    Next
                End If
                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '</20070808> **********************
#End Region


        Protected Overrides Function accion() As Object
            Try
                Dim doCanSave As New doCanSaveIneficiencia(_ineficiencia)
                If (doCanSave.execute) Then
                    '<20070808> Incidencia! el coste devuelve cero porque
                    'la lista de costes (_ineficiencia.Costes) es nothing
                    Dim accSelCoste As New Coste.doSeleccionarCostesPorIneficiencia(_ineficiencia)
                    Dim aCosteChunk As baseball.lib.vo.coste.CosteChunkVO() = accSelCoste.execute
                    Me._ineficiencia.Costes = baseball.lib.vo.coste.CosteChunkVO.getVOFromChunk(aCosteChunk)
                    '</20070808> ************************************

                    '<20070704> Calculamos el coste de la ineficiencia
                    Dim accCoste As New doCalcularCosteIneficiencia(Me._ineficiencia)
                    Me._ineficiencia.Coste = accCoste.execute()
                    '</20070704> ************************************

                    ''20070507: Cambio! ahora solo se avisa por email cuando la
                    ''ineficiencia está validada. Como tal, debemos poner que envíe
                    ''mails en cada modificación.
                    Dim ineficienciaCambio As baseball.lib.vo.ineficiencia.IneficienciaVO = accionIneficiencia.ActualizarIneficienciaCab(_ineficiencia)

                    If (Not Me._ineficiencia.PteValidar) Then
                        '20070507: Debido al cambio, ahora necesito recuperar todos 
                        'los datos de la ineficiencia
                        Dim acciones As New baseball.lib.dao.Accion.fachada
                        Dim comision As New baseball.lib.dao.Comision.fachada
                        Dim integrantes As New baseball.lib.dao.Integrante.fachada

                        If (_ineficiencia.Repeticion <> baseball.lib.vo.ineficiencia.IneficienciaVO.tPeriodicidadInef.Ocasional) Then
                            ineficienciaCambio.Acciones = baseball.lib.vo.accion.AccionChunkVO.getVOFromChunk(acciones.SeleccionarAccionesPorIneficiencia(Me._ineficiencia))
                            ineficienciaCambio.Comision = comision.SeleccionarComisionPorIneficiencia(Me._ineficiencia)
                            ineficienciaCambio.Comision.Integrantes = baseball.lib.vo.integrante.IntegranteChunkVO.getVOFromChunk(integrantes.SeleccionarIntegrantesPorComision(ineficienciaCambio.Comision))
                        Else
                            If (Not _ineficiencia.IneficienciaOriginal Is Nothing) Then
                                ineficienciaCambio.Acciones = baseball.lib.vo.accion.AccionChunkVO.getVOFromChunk(acciones.SeleccionarAccionesPorIneficiencia(Me._ineficiencia.IneficienciaOriginal))
                                ineficienciaCambio.Comision = comision.SeleccionarComisionPorIneficiencia(Me._ineficiencia.IneficienciaOriginal)
                                ineficienciaCambio.Comision.Integrantes = baseball.lib.vo.integrante.IntegranteChunkVO.getVOFromChunk(integrantes.SeleccionarIntegrantesPorComision(ineficienciaCambio.Comision))
                            End If
                        End If

                        If (Not ineficienciaCambio.Acciones Is Nothing) Then
                            Dim tareas As New baseball.lib.dao.Tarea.fachada
                            For Each accionObj As baseball.lib.vo.accion.AccionVO In ineficienciaCambio.Acciones
                                accionObj.Tareas = tareas.SeleccionarTareasPorAccion(accionObj)
                            Next
                        End If

                        Dim costes As New baseball.lib.dao.Coste.fachada
                        ineficienciaCambio.Costes = baseball.lib.vo.coste.CosteChunkVO.getVOFromChunk(costes.SeleccionarCostesPorIneficiencia(Me._ineficiencia))

                        Dim doNotificar As New doNotificarIneficiencia(ineficienciaCambio, True)
                        doNotificar.execute()
                    End If
                End If

                Return _ineficiencia
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class

End Namespace
