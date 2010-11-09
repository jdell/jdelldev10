
Namespace hojaanotacioncatcher.action
    Friend Class [get]
        Implements _common.plain.NonTransactionalPlainAction

        Private _hojaanotacioncatcher As baseball.lib.vo.HojaAnotacionCatcher

        Public Sub New(ByVal hojaanotacioncatcher As baseball.lib.vo.HojaAnotacionCatcher)
            Me._hojaanotacioncatcher = hojaanotacioncatcher
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim hojaanotacioncatcherDAO As New DAO.hojaanotacioncatcherDAO

            Return hojaanotacioncatcherDAO.get(factory.Command, _hojaanotacioncatcher)
        End Function
    End Class
End Namespace
