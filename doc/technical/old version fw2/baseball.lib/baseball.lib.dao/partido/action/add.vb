Namespace partido.action
    Friend Class add
        Implements _common.plain.TransactionalPlainAction

        Private _partido As baseball.lib.vo.Partido

        Public Sub New(ByVal partido As baseball.lib.vo.Partido)
            Me._partido = partido
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim partidoDAO As New DAO.partidoDAO
            Dim hojaDAO As New hojaanotacion.DAO.hojaanotacionDAO
            Dim hojapitcherDAO As New hojaanotacionpitcher.DAO.hojaanotacionpitcherDAO
            Dim hojacatcherDAO As New hojaanotacioncatcher.DAO.hojaanotacioncatcherDAO
            Dim hojaplayerDAO As New hojaanotacionplayer.DAO.hojaanotacionplayerDAO

            _partido.Id = partidoDAO.add(factory.Command, _partido)

            If (Not _partido.AnotacionHomeClub Is Nothing) Then
                _partido.AnotacionHomeClub.Partido = _partido
                _partido.AnotacionHomeClub.Id = hojaDAO.add(factory.Command, _partido.AnotacionHomeClub)

                For Each player As vo.HojaAnotacionPlayer In _partido.AnotacionHomeClub.ListaPlayer
                    player.HojaAnotacion = _partido.AnotacionHomeClub
                    hojaplayerDAO.add(factory.Command, player)
                Next
                For Each catcher As vo.HojaAnotacionCatcher In _partido.AnotacionHomeClub.ListaCatcher
                    catcher.HojaAnotacion = _partido.AnotacionHomeClub
                    hojacatcherDAO.add(factory.Command, catcher)
                Next
                For Each pitcher As vo.HojaAnotacionPitcher In _partido.AnotacionHomeClub.ListaPitcher
                    pitcher.HojaAnotacion = _partido.AnotacionHomeClub
                    hojapitcherDAO.add(factory.Command, pitcher)
                Next
            End If

            If (Not _partido.AnotacionVisitante Is Nothing) Then
                _partido.AnotacionVisitante.Partido = _partido
                _partido.AnotacionVisitante.Id = hojaDAO.add(factory.Command, _partido.AnotacionVisitante)

                For Each player As vo.HojaAnotacionPlayer In _partido.AnotacionVisitante.ListaPlayer
                    player.HojaAnotacion = _partido.AnotacionVisitante
                    hojaplayerDAO.add(factory.Command, player)
                Next
                For Each catcher As vo.HojaAnotacionCatcher In _partido.AnotacionVisitante.ListaCatcher
                    catcher.HojaAnotacion = _partido.AnotacionVisitante
                    hojacatcherDAO.add(factory.Command, catcher)
                Next
                For Each pitcher As vo.HojaAnotacionPitcher In _partido.AnotacionVisitante.ListaPitcher
                    pitcher.HojaAnotacion = _partido.AnotacionVisitante
                    hojapitcherDAO.add(factory.Command, pitcher)
                Next
            End If

            Return _partido
        End Function
    End Class
End Namespace
