
Namespace arbitro.action
    Friend Class update
        Implements _common.plain.TransactionalPlainAction

        Private _arbitro As baseball.lib.vo.Arbitro

        Public Sub New(ByVal arbitro As baseball.lib.vo.Arbitro)
            Me._arbitro = arbitro
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim arbitroDAO As New DAO.arbitroDAO

            arbitroDAO.update(factory.Command, _arbitro)

            Return _arbitro
        End Function
    End Class
End Namespace
