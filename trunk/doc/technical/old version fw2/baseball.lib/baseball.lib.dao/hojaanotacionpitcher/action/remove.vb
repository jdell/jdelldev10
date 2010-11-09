
Namespace hojaanotacionpitcher.action
    Friend Class remove
        Implements _common.plain.TransactionalPlainAction

        Private _hojaanotacionpitcher As baseball.lib.vo.HojaAnotacionPitcher

        Public Sub New(ByVal hojaanotacionpitcher As baseball.lib.vo.HojaAnotacionPitcher)
            Me._hojaanotacionpitcher = hojaanotacionpitcher
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim hojaanotacionpitcherDAO As New DAO.hojaanotacionpitcherDAO

            Return hojaanotacionpitcherDAO.remove(factory.Command, _hojaanotacionpitcher)
        End Function
    End Class
End Namespace
