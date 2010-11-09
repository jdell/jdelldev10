
Namespace arbitro.action
    Friend Class checkIfExists
        Implements _common.plain.NonTransactionalPlainAction

        Private _arbitro As baseball.lib.vo.Arbitro

        Public Sub New(ByVal arbitro As baseball.lib.vo.Arbitro)
            Me._arbitro = arbitro
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim arbitroDAO As New DAO.arbitroDAO

            Return arbitroDAO.checkIfExists(factory.Command, _arbitro)
        End Function
    End Class
End Namespace
