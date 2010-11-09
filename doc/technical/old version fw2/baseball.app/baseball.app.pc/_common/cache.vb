Namespace _common.variables

    Public MustInherit Class cache
        '
        'El SSafe ha vuelto a hacer de las suyas!
        Public Shared MdiForm As frm._principal.frmPrincipal
        '

        Public Shared equipo As baseball.lib.vo.Equipo = Nothing

        Public Shared Function InicializaAPP(ByVal commandLine As ObjectModel.ReadOnlyCollection(Of String)) As Boolean
            Try
                Dim res As Boolean = True

                InicializaEntornoApp()

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Shared Function CerrarAPP() As Boolean
            Try

            Catch ex As Exception
                Throw ex
            End Try
        End Function

#Region "*********** Seccion ENTORNO *************"
        Public Shared ENTORNO As _common.secciones.EntornoSection = Nothing
        Private Shared Sub InicializaEntornoApp()
            Try
                ENTORNO = New _common.secciones.EntornoSection
                Dim entornoSetting As repsol.util.config.sections.section = repsol.util.config.sections.section.getSectionSetting(baseball.lib.common.variables.configpath.GetFullPath, ENTORNO.Name)
                If (Not entornoSetting Is Nothing) Then

                    Try
                        ENTORNO.PathImprovementFile = IO.Path.GetFullPath(entornoSetting("pathImprovementFile").Value)
                        ENTORNO.PathOnlineHelpFile = IO.Path.GetFullPath(entornoSetting("pathOnlineHelpFile").Value)
                        ENTORNO.ShowImprovementMsg = entornoSetting("showImprovementMsg").Value
                    Catch ex As Exception
                        Throw New baseball.lib.bl._exceptions._common.IncorrectFormatConfigFileException
                    End Try
                Else
                    Throw New baseball.lib.bl._exceptions._common.InitializeCacheException
                End If

            Catch ex As baseball.lib.bl._exceptions._common.InitializeCacheException
                Throw ex
            Catch ex As baseball.lib.bl._exceptions.BaseballException
                Throw New baseball.lib.bl._exceptions.BaseballException(ex.Message, New baseball.lib.bl._exceptions._common.InitializeCacheException)
            Catch ex As Exception
                Throw New Exception(ex.Message, New baseball.lib.bl._exceptions._common.InitializeCacheException)
            End Try
        End Sub

#End Region

    End Class

End Namespace

