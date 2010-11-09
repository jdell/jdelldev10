Namespace _template.edicion.ctrl
    Public MustInherit Class editctrl
        Inherits repsol.forms.template.edicion.ctrl.EditFormCtrl

        Public MustOverride Function getObject(ByVal frm As repsol.forms.template.edicion.EditForm) As Object
        Public MustOverride Function getNewObject() As Object

        <Obsolete("Obsoleto.", True)> _
        Public Overrides Function canAccept(ByRef frm As repsol.forms.template.edicion.EditForm) As Boolean

        End Function

        <Obsolete("Obsoleto.", True)> _
        Public Overrides Function EsCodigoValido(ByRef frm As repsol.forms.template.edicion.EditForm) As Boolean

        End Function

    End Class
End Namespace

