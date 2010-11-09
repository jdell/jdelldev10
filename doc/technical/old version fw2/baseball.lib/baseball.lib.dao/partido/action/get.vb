
Namespace partido.action
    Friend Class [get]
        Implements _common.plain.NonTransactionalPlainAction

        Private _partido As baseball.lib.vo.Partido
        Private _full As Boolean
        Public Sub New(ByVal partido As baseball.lib.vo.Partido, ByVal full As Boolean)
            Me._partido = partido
            _full = full
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim partidoDAO As New DAO.partidoDAO
            Dim res As vo.Partido = partidoDAO.get(factory.Command, _partido)

            If (_full) Then
                Dim jugadorDAO As New jugador.DAO.jugadorDAO
                Dim hojaDAO As New hojaanotacion.DAO.hojaanotacionDAO
                Dim hojapitcherDAO As New hojaanotacionpitcher.DAO.hojaanotacionpitcherDAO
                Dim hojacatcherDAO As New hojaanotacioncatcher.DAO.hojaanotacioncatcherDAO
                Dim hojaplayerDAO As New hojaanotacionplayer.DAO.hojaanotacionplayerDAO

                res.HomeClub.Jugadores.AddRange(jugadorDAO.getAll(factory.Command, res.HomeClub))
                res.Visitante.Jugadores.AddRange(jugadorDAO.getAll(factory.Command, res.Visitante))

                res.AnotacionHomeClub = hojaDAO.get(factory.Command, res, res.HomeClub)
                If (Not res.AnotacionHomeClub Is Nothing) Then
                    'Existe
                    'res.AnotacionHomeClub = New vo.HojaAnotacion()
                    'res.AnotacionHomeClub.Partido = res
                    'res.AnotacionHomeClub.Equipo = res.HomeClub
                    res.AnotacionHomeClub.ListaPlayer.AddRange(hojaplayerDAO.getAll(factory.Command, res.AnotacionHomeClub))
                    res.AnotacionHomeClub.ListaPitcher.AddRange(hojapitcherDAO.getAll(factory.Command, res.AnotacionHomeClub))
                    res.AnotacionHomeClub.ListaCatcher.AddRange(hojacatcherDAO.getAll(factory.Command, res.AnotacionHomeClub))
                    'Falta eliminar los repetidos
                Else
                    'No existe, lo genero
                    res.AnotacionHomeClub = New vo.HojaAnotacion(res, res.HomeClub)
                End If

                res.AnotacionVisitante = hojaDAO.get(factory.Command, res, res.Visitante)
                If (Not res.AnotacionVisitante Is Nothing) Then
                    'Existe       
                    'res.AnotacionVisitante = New vo.HojaAnotacion()
                    'res.AnotacionVisitante.Partido = res
                    'res.AnotacionVisitante.Equipo = res.Visitante
                    res.AnotacionVisitante.ListaPlayer.AddRange(hojaplayerDAO.getAll(factory.Command, res.AnotacionVisitante))
                    res.AnotacionVisitante.ListaPitcher.AddRange(hojapitcherDAO.getAll(factory.Command, res.AnotacionVisitante))
                    res.AnotacionVisitante.ListaCatcher.AddRange(hojacatcherDAO.getAll(factory.Command, res.AnotacionVisitante))
                    'Falta eliminar los repetidos
                Else
                    'No existe, lo genero
                    res.AnotacionVisitante = New vo.HojaAnotacion(res, res.Visitante)
                End If

            End If

            Return res
        End Function
    End Class
End Namespace
