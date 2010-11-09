
Namespace SeccionPrg.action
    Friend Class AddSeccionPrgAction
        Implements Plain.NonTransactionalPlainAction

        Private _seccionPrg As GesInefVO.SeccionPrgVO

        Public Sub New(ByVal seccionPrg As GesInefVO.SeccionPrgVO)
            Me._seccionPrg = seccionPrg
        End Sub

        Public Function execute(ByVal factory As DAOFactory) As Object Implements Plain.PlainAction.execute
            Dim seccionPrgDAO As dao.SeccionPrgDAO

            seccionPrgDAO = factory.getSeccionPrgDAO

            Return seccionPrgDAO.addSeccionPrg(factory.Command, _seccionPrg)
        End Function
    End Class
End Namespace
