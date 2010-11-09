
Namespace hojaanotacioncatcher.action
    Friend Class update
        Implements _common.plain.TransactionalPlainAction

        Private _hojaanotacioncatcher As baseball.lib.vo.HojaAnotacionCatcher

        Public Sub New(ByVal hojaanotacioncatcher As baseball.lib.vo.HojaAnotacionCatcher)
            Me._hojaanotacioncatcher = hojaanotacioncatcher
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim hojaanotacioncatcherDAO As New DAO.hojaanotacioncatcherDAO

            hojaanotacioncatcherDAO.update(factory.Command, _hojaanotacioncatcher)

            Return _hojaanotacioncatcher
        End Function
    End Class
End Namespace
