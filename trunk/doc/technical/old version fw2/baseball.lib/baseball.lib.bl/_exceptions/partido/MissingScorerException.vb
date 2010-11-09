Namespace _exceptions.partido
    Public Class MissingUmpire2Exception
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("Falta indicar el arbitro de 1ra base.")
        End Sub

    End Class
End Namespace

