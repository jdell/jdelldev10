Namespace _exceptions.usuario
    Public Class MissingTeamException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("Falta indicar el equipo.")
        End Sub

    End Class
End Namespace

