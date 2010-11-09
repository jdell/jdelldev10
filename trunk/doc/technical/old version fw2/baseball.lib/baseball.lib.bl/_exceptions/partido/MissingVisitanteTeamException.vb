Namespace _exceptions.partido
    Public Class MissingVisitanteTeamException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("Falta indicar el equipo visitante.")
        End Sub

    End Class
End Namespace

