Namespace _reports
    Public MustInherit Class Estadistica
        Inherits informe

        Protected _filtro As baseball.lib.vo.FiltroEstadistica
        Public Sub New(ByVal filtro As baseball.lib.vo.FiltroEstadistica)
            _filtro = filtro
        End Sub

    End Class
End Namespace
