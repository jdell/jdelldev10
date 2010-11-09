Namespace _exceptions.partido
    Public Class MissingHomeClubTeamException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("Falta indicar el equipo homeclub.")
        End Sub

    End Class
End Namespace

