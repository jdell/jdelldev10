Namespace _common.settings
    <Serializable()> _
    Public Class AppPreferences
        Inherits repsol.util.setting.userpreferences

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal userpreferences As repsol.util.setting.userpreferences)
            Me.Location = userpreferences.Location
            Me.Size = userpreferences.Size
        End Sub

    End Class
End Namespace

