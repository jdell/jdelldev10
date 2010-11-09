
Namespace _common
    Public MustInherit Class facade

        Friend factory As DAOFactory

        Public Sub New()
            factory = New DAOFactory()
        End Sub

    End Class
End Namespace


