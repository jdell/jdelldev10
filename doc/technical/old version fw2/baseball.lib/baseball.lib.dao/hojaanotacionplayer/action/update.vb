
Namespace hojaanotacionplayer.action
    Friend Class update
        Implements _common.plain.TransactionalPlainAction

        Private _hojaanotacionplayer As baseball.lib.vo.HojaAnotacionPlayer

        Public Sub New(ByVal hojaanotacionplayer As baseball.lib.vo.HojaAnotacionPlayer)
            Me._hojaanotacionplayer = hojaanotacionplayer
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim hojaanotacionplayerDAO As New DAO.hojaanotacionplayerDAO

            hojaanotacionplayerDAO.update(factory.Command, _hojaanotacionplayer)

            Return _hojaanotacionplayer
        End Function
    End Class
End Namespace
