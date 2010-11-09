
Namespace hojaanotacion.action
    Friend Class [get]
        Implements _common.plain.NonTransactionalPlainAction

        Private _hojaanotacion As baseball.lib.vo.HojaAnotacion

        Public Sub New(ByVal hojaanotacion As baseball.lib.vo.HojaAnotacion)
            Me._hojaanotacion = hojaanotacion
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim hojaanotacionDAO As New DAO.hojaanotacionDAO

            Return hojaanotacionDAO.get(factory.Command, _hojaanotacion)
        End Function
    End Class
End Namespace
