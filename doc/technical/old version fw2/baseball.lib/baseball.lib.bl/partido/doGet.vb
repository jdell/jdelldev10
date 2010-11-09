Namespace partido

    Public Class doGet
        Inherits _template.ActionBL

        Private accionpartido As New baseball.lib.dao.partido.fachada
        Private _partido As baseball.lib.vo.Partido
        Private _full As Boolean = False
        Public Sub New(ByVal partido As baseball.lib.vo.Partido, Optional ByVal full As Boolean = False)
            _partido = partido
            _full = full
        End Sub

        Public Shadows Function execute() As baseball.lib.vo.Partido
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Try
                If (_partido Is Nothing) Then
                    Throw New _exceptions._common.NullReferenceException()
                End If

                Return accionpartido.get(_partido, _full)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace

