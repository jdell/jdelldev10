Namespace _exceptions.partido
    Public Class MissingUmpire1Exception
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("Falta indicar el arbitro principal.")
        End Sub

    End Class
End Namespace

