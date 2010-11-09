Namespace variables
    Public MustInherit Class configpath

        Public Shared DIRECTORY As String = Environment.CurrentDirectory

        Public Shared FILE As String = "baseballconfig.xml"

        Public Shared Function GetFullPath() As String
            Return System.IO.Path.GetFullPath(String.Format("{0}\{1}", baseball.lib.common.variables.configpath.DIRECTORY, baseball.lib.common.variables.configpath.FILE))
        End Function

    End Class
End Namespace