Imports Microsoft.Office.Interop
Namespace Ineficiencia

    Friend Class doCanSaveIneficiencia
        Inherits _template.ActionBL

        Private accionIneficiencia As New baseball.lib.dao.Ineficiencia.fachada
        Private _ineficiencia As baseball.lib.vo.ineficiencia.IneficienciaVO

        Public Sub New(ByVal ineficiencia As baseball.lib.vo.ineficiencia.IneficienciaVO)
            _ineficiencia = ineficiencia
        End Sub
        Public Shadows Function execute() As Object
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Try
                If (_ineficiencia Is Nothing) Then
                    Throw New _exceptions._common.NullReferenceException()
                End If

                If (Me._ineficiencia.Zona Is Nothing) Then
                    Throw New _exceptions.ineficiencia.MissingZoneException
                End If
                If (Me._ineficiencia.Area Is Nothing) Then
                    Throw New _exceptions.ineficiencia.MissingAreaException
                End If
                If (Me._ineficiencia.Unidad Is Nothing) Then
                    Throw New _exceptions.ineficiencia.MissingUnitException
                End If
                If (Me._ineficiencia.Tipo Is Nothing) Then
                    Throw New _exceptions.ineficiencia.MissingTypeOfInefficiencyException
                End If

                If ((_ineficiencia.Inicio > DateTime.Now) OrElse ((Not baseball.lib.common.funciones.getinfo.IsEmpty(_ineficiencia.Fin)) AndAlso (_ineficiencia.Inicio > _ineficiencia.Fin))) Then
                    Throw New _exceptions.ineficiencia.IncorrectStartDateException(_ineficiencia.Inicio, _ineficiencia.Fin)
                End If

                If (Not baseball.lib.common.funciones.getinfo.IsEmpty(_ineficiencia.Fin)) AndAlso (_ineficiencia.Fin > DateTime.Now) Then
                    Throw New _exceptions.ineficiencia.IncorrectEndDateException(_ineficiencia.Fin)
                End If

                If (String.IsNullOrEmpty(Me._ineficiencia.Resumen)) Then
                    Throw New _exceptions.ineficiencia.MissingSummaryException
                End If
                If (String.IsNullOrEmpty(Me._ineficiencia.Causa)) Then
                    Throw New _exceptions.ineficiencia.MissingCauseException
                End If

                'If (Me._ineficiencia.Comision Is Nothing) OrElse (Not Me._ineficiencia.Comision.HaveLeader()) Then
                '    Throw New _exceptions.ineficiencia.MissingLeaderException
                'End If
                If (String.IsNullOrEmpty(Me._ineficiencia.Detalle)) Then
                    Throw New _exceptions.ineficiencia.MissingDetailException
                End If

                If (_ineficiencia.Repeticion = vo.ineficiencia.IneficienciaVO.tPeriodicidadInef.Ocasional) AndAlso ((_ineficiencia.IneficienciaOriginal Is Nothing) OrElse (baseball.lib.common.funciones.getinfo.IsEmpty(_ineficiencia.IneficienciaOriginal.Id))) Then
                    Throw New _exceptions.ineficiencia.MissingParentException
                End If

                Return True

            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace
