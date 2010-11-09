Namespace _template
    ''' <summary>
    ''' Define la forma en que se ejecutan las acciones. Todas las acciones de la BL tienen un método "ejecutar"
    ''' que ejecuta una determinada acción. Esta clase obliga a las acciones de la BL a comportarse del mismo modo.
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class ActionBL

        Private _systemAction As Boolean = False
        Friend Property SystemAction() As Boolean
            Get
                Return _systemAction
            End Get
            Set(ByVal value As Boolean)
                _systemAction = False
            End Set
        End Property

        ''' <summary>
        ''' Ejecuta la acción.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function execute() As Object
            Try
                If (Not SystemAction) AndAlso (Not _common.cache.MANTENIMIENTO Is Nothing AndAlso _common.cache.MANTENIMIENTO.EnMantenimiento AndAlso _common.cache.BLCerrada AndAlso Not _common.cache.IsMasterUser) Then
                    Throw New _exceptions._common.OutOfServiceException("Aplicación fuera de servicio en estos momentos. Inténtelo más tarde.")
                End If

                Return accion()
            Catch ex As repsol.exceptions.ForeignKeyInstanceException
                Throw New _exceptions.BaseballException("Acción restringida debida al estado de este registro. Contacte con su administrador.", ex.Message)
            Catch ex As repsol.exceptions.DuplicateKeyInstanceException
                Throw New _exceptions.BaseballException("Acción restringida debida a la duplicación de clave. Contacte con su administrador.", ex.Message)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>
        ''' Acción a implementar en las clases derivadas.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected MustOverride Function accion() As Object

    End Class

End Namespace
