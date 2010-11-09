Namespace _exceptions.partido
    Public Class MissingLeagueException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("Falta indicar la competicion.")
        End Sub

    End Class
End Namespace

