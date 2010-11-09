
Namespace SeccionPrg.action
    Friend Class DelSeccionPrgAction
        Implements Plain.TransactionalPlainAction

        Private _seccionPrg As GesInefVO.SeccionPrgVO

        Public Sub New(ByVal seccionPrg As GesInefVO.SeccionPrgVO)
            Me._seccionPrg = seccionPrg
        End Sub

        Public Function execute(ByVal factory As DAOFactory) As Object Implements Plain.PlainAction.execute
            Dim seccionPrgDAO As dao.SeccionPrgDAO

            seccionPrgDAO = factory.getSeccionPrgDAO

            Return seccionPrgDAO.delSeccionPrg(factory.Command, _seccionPrg)
        End Function
    End Class
End Namespace
