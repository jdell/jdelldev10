
Namespace jugador.action
    Friend Class remove
        Implements _common.plain.TransactionalPlainAction

        Private _jugador As baseball.lib.vo.Jugador

        Public Sub New(ByVal jugador As baseball.lib.vo.Jugador)
            Me._jugador = jugador
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim jugadorDAO As New DAO.jugadorDAO

            Return jugadorDAO.remove(factory.Command, _jugador)
        End Function
    End Class
End Namespace
