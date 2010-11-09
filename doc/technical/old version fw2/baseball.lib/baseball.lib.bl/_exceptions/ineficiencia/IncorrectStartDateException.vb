Namespace _exceptions.ineficiencia
    Public Class IncorrectStartDateException
        Inherits ValidatingException

        Public Sub New(ByVal fechaInicio As DateTime, ByVal fechaFin As DateTime)
            MyBase.new(String.Format("La fecha de inicio de la ineficiencia es incorrecta. Esto se debe a que ha especificado como fecha de inicio [{0}] un valor superior a la fecha de fin [{1}] o a la fecha actual [{2}].", fechaInicio.ToString(baseball.lib.common.constantes.formato.FECHAHORA), baseball.lib.common.funciones.getinfo.FECHA(fechaFin, True), DateTime.Now.ToString(baseball.lib.common.constantes.formato.FECHAHORA)))
        End Sub

    End Class
End Namespace

