Namespace hojaanotacion.action
    Friend Class add
        Implements _common.plain.TransactionalPlainAction

        Private _hojaanotacion As baseball.lib.vo.HojaAnotacion

        Public Sub New(ByVal hojaanotacion As baseball.lib.vo.HojaAnotacion)
            Me._hojaanotacion = hojaanotacion
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim hojaanotacionDAO As New DAO.hojaanotacionDAO

            _hojaanotacion.Id = hojaanotacionDAO.add(factory.Command, _hojaanotacion)

            Return _hojaanotacion
        End Function
    End Class
End Namespace
