Namespace _exceptions.ineficiencia
    Public Class MissingDetailException
        Inherits ValidatingException

        Public Sub New()
            MyBase.new("No se ha establecido la descripción detallada.")
        End Sub

    End Class
End Namespace

