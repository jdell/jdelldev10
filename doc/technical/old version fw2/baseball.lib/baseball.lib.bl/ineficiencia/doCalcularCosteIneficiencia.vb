Namespace Ineficiencia
    ''' <summary>
    ''' El objetivo de esta acción es proporcionar los datos necesarios a la ineficiencia para que por ella misma
    ''' pueda calcular el importe total de sus costes.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class doCalcularCosteIneficiencia
        Inherits _template.ActionBL

        Private accionIneficiencia As New baseball.lib.dao.Ineficiencia.fachada
        Private _ineficiencia As baseball.lib.vo.ineficiencia.IneficienciaVO

        Public Sub New(ByVal ineficiencia As baseball.lib.vo.ineficiencia.IneficienciaVO)
            _ineficiencia = ineficiencia
        End Sub
        Public Shadows Function execute() As Single
            Return MyBase.execute
        End Function

        Protected Overrides Function accion() As Object
            Try
                Dim res As Double = 0

                'TODO:Revisar - Calculo de Costes -la repera-
                If (Not Me._ineficiencia.Costes Is Nothing) Then
                    Dim doSelCosteReal As Coste.doSeleccionarCosteReal
                    For Each coste As baseball.lib.vo.coste.CosteVO In Me._ineficiencia.Costes
                        coste.Ineficiencia = _ineficiencia
                        doSelCosteReal = New Coste.doSeleccionarCosteReal(coste)
                        coste = doSelCosteReal.execute
                    Next
                End If

                res = _ineficiencia.CalculaTotal()

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace
