Namespace partido

    Public Class doUpdate
        Inherits _template.ActionBL

        Private accionpartido As New baseball.lib.dao.partido.fachada
        Private _partido As baseball.lib.vo.Partido


        Public Sub New(ByVal partido As baseball.lib.vo.Partido)
            _partido = partido
        End Sub
        Public Shadows Function execute() As Object
            Return MyBase.execute
        End Function
        Protected Overrides Function accion() As Object
            Try
                If (_partido Is Nothing) Then
                    Throw New _exceptions._common.NullReferenceException()
                End If

                If (_partido.Categoria Is Nothing) Then
                    Throw New _exceptions.partido.MissingCategoryException()
                End If

                If (_partido.HomeClub Is Nothing) Then
                    Throw New _exceptions.partido.MissingHomeClubTeamException()
                End If

                If (_partido.Arbitro1 Is Nothing) Then
                    Throw New _exceptions.partido.MissingUmpire1Exception()
                End If

                If (_partido.Visitante Is Nothing) Then
                    Throw New _exceptions.partido.MissingVisitanteTeamException()
                End If

                If (_partido.Competicion Is Nothing) Then
                    Throw New _exceptions.partido.MissingLeagueException()
                End If

                Return accionpartido.update(_partido)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace
