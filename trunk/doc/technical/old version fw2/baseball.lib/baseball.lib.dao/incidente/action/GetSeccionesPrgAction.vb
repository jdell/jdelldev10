
Namespace SeccionPrg.action
    Friend Class GetSeccionPrgsAction
        Implements Plain.NonTransactionalPlainAction


        Public Sub New()
        End Sub

        Public Function execute(ByVal factory As DAOFactory) As Object Implements Plain.PlainAction.execute
            Dim seccionPrgDAO As dao.SeccionPrgDAO

            seccionPrgDAO = factory.getSeccionPrgDAO

            Return seccionPrgDAO.getSeccionPrgs(factory.Command)
        End Function
    End Class
End Namespace
