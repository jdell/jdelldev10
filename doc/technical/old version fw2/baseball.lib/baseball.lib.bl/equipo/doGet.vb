Namespace equipo

    Public Class doGet
        Inherits _template.ActionBL

        Private accionequipo As New baseball.lib.dao.equipo.fachada
        Private _equipo As baseball.lib.vo.Equipo

        Public Sub New(ByVal equipo As baseball.lib.vo.Equipo)
            _equipo = equipo
        End Sub

        Public Shadows Function execute() As baseball.lib.vo.Equipo
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Try
                If (_equipo Is Nothing) Then
                    Throw New _exceptions._common.NullReferenceException()
                End If

                Return accionequipo.get(_equipo)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace

