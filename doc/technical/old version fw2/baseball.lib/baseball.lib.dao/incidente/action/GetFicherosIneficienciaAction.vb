
Namespace equipo.action
    Friend Class GetFicherosequipoAction
        Implements _common.plain.NonTransactionalPlainAction

        Private _equipo As baseball.lib.vo.Equipo

        Public Sub New(ByVal equipo As baseball.lib.vo.Equipo)
            Me._equipo = equipo
        End Sub

        Public Function execute(ByVal factory As _common.DAOFactory) As Object Implements _common.plain.PlainAction.execute
            Dim res As String() = Nothing

            Dim pathFicheros As String = gesInef.lib.dao.Configuration.DAO.ConfigurationDAO.CONFIG_PATH_ATTACHEDFILE & _equipo.Codigo
            If (IO.Directory.Exists(pathFicheros)) Then
                res = IO.Directory.GetFiles(pathFicheros)
            End If

            Return res
        End Function
    End Class
End Namespace
