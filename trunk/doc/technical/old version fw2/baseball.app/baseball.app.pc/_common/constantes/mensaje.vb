Namespace _common.constantes
    Public MustInherit Class mensaje

        Public Shared ReadOnly NO_RECORD_SELECTED As String = "No hay ning�n registro seleccionado."
        'Public Shared ReadOnly NO_ACCESS_ALLOWED As String = "No tiene permisos para realizar esta acci�n."
        Public Shared ReadOnly OPERATION_CANCELED As String = "Operaci�n cancelada."
        Public Shared ReadOnly OPERATION_COMPLETED As String = "Operaci�n completada."
        Public Shared ReadOnly OPTION_DISABLED As String = "Opci�n deshabilitada."

        Public Shared ReadOnly INCORRECT_FORMAT As String = "Formato num�rico incorrecto."

        'Public Shared Function NOT_FOUND_USER() As String
        '    Return String.Format("El usuario {0} no tiene permisos en esta aplicaci�n. Contacte con su administrador.", baseball.lib.bl._common.cache.USUARIO.Codigo)
        'End Function

        'Public Shared Function NOT_FOUND_CONFIGFILE() As String
        '    Return "No se encuentra el fichero de configuraci�n en la ruta especificada [" & baseball.lib.common.variables.configpath.GetFullPath & "]. Contacte con su administrador."
        'End Function


    End Class
End Namespace


