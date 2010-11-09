
Namespace partido.action
    Friend Class update
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

            partidoDAO.update(factory.Command, _partido)

            If (Not _partido.AnotacionHomeClub Is Nothing) Then
                _partido.AnotacionHomeClub.Partido = _partido
                If (Not hojaDAO.checkIfExists(factory.Command, _partido.AnotacionHomeClub)) Then
                    _partido.AnotacionHomeClub.Id = hojaDAO.add(factory.Command, _partido.AnotacionHomeClub)
                Else
                    hojaDAO.update(factory.Command, _partido.AnotacionHomeClub)
                End If

                For Each player As vo.HojaAnotacionPlayer In _partido.AnotacionHomeClub.ListaPlayer
                    player.HojaAnotacion = _partido.AnotacionHomeClub
                    If (Not hojaplayerDAO.checkIfExists(factory.Command, player)) Then
                        hojaplayerDAO.add(factory.Command, player)
                    Else
                        hojaplayerDAO.update(factory.Command, player)
                    End If
                Next
                For Each catcher As vo.HojaAnotacionCatcher In _partido.AnotacionHomeClub.ListaCatcher
                    catcher.HojaAnotacion = _partido.AnotacionHomeClub
                    If (Not hojacatcherDAO.checkIfExists(factory.Command, catcher)) Then
                        hojacatcherDAO.add(factory.Command, catcher)
                    Else
                        hojacatcherDAO.update(factory.Command, catcher)
                    End If
                Next
                For Each pitcher As vo.HojaAnotacionPitcher In _partido.AnotacionHomeClub.ListaPitcher
                    pitcher.HojaAnotacion = _partido.AnotacionHomeClub
                    If (Not hojapitcherDAO.checkIfExists(factory.Command, pitcher)) Then
                        hojapitcherDAO.add(factory.Command, pitcher)
                    Else
                        hojapitcherDAO.update(factory.Command, pitcher)
                    End If
                Next
            End If

            If (Not _partido.AnotacionVisitante Is Nothing) Then
                _partido.AnotacionVisitante.Partido = _partido
                If (Not hojaDAO.checkIfExists(factory.Command, _partido.AnotacionVisitante)) Then
                    _partido.AnotacionVisitante.Id = hojaDAO.add(factory.Command, _partido.AnotacionVisitante)
                Else
                    hojaDAO.update(factory.Command, _partido.AnotacionVisitante)
                End If

                For Each player As vo.HojaAnotacionPlayer In _partido.AnotacionVisitante.ListaPlayer
                    player.HojaAnotacion = _partido.AnotacionVisitante
                    If (Not hojaplayerDAO.checkIfExists(factory.Command, player)) Then
                        hojaplayerDAO.add(factory.Command, player)
                    Else
                        hojaplayerDAO.update(factory.Command, player)
                    End If
                Next
                For Each catcher As vo.HojaAnotacionCatcher In _partido.AnotacionVisitante.ListaCatcher
                    catcher.HojaAnotacion = _partido.AnotacionVisitante
                    If (Not hojacatcherDAO.checkIfExists(factory.Command, catcher)) Then
                        hojacatcherDAO.add(factory.Command, catcher)
                    Else
                        hojacatcherDAO.update(factory.Command, catcher)
                    End If
                Next
                For Each pitcher As vo.HojaAnotacionPitcher In _partido.AnotacionVisitante.ListaPitcher
                    pitcher.HojaAnotacion = _partido.AnotacionVisitante
                    If (Not hojapitcherDAO.checkIfExists(factory.Command, pitcher)) Then
                        hojapitcherDAO.add(factory.Command, pitcher)
                    Else
                        hojapitcherDAO.update(factory.Command, pitcher)
                    End If
                Next
            End If

            Return _partido
        End Function
    End Class
End Namespace
