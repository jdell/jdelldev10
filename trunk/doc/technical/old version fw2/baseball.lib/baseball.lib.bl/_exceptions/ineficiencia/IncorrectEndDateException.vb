Namespace _exceptions.ineficiencia
    Public Class IncorrectEndDateException
        Inherits ValidatingException

        Public Sub New(ByVal fechaFin As DateTime)
            MyBase.new(String.Format("La fecha de fin de la ineficiencia es incorrecta. Esto se debe a que ha especificado como fecha de fin [{0}] un valor superior a la fecha actual [{1}].", fechaFin.ToString(baseball.lib.common.constantes.formato.FECHAHORA), DateTime.Now.ToString(baseball.lib.common.constantes.formato.FECHAHORA)))
        End Sub

    End Class
End Namespace

