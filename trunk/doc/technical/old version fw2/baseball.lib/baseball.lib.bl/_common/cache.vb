Namespace _common
    Public MustInherit Class cache

#Region "Constantes"

        Public Shared ReadOnly APPNAME As String = "BaseBall"

#End Region

#Region "Variables Internas / Propiedades"
        ''' <summary>
        ''' Conexion activa
        ''' </summary>
        ''' <remarks></remarks>
        Friend Shared fileWatcher As System.IO.FileSystemWatcher

        Friend Shared ADMINISTRACION As _common.secciones.AdministracionSection
        Friend Shared CONFIGURACION As _common.secciones.ConfiguracionSection
        Friend Shared MANTENIMIENTO As _common.secciones.MantenimientoSection
        Friend Shared GRUPOS As _common.secciones.GruposSection
        Friend Shared ST As _common.secciones.STSection
        Friend Shared PI As _common.secciones.PISection

        Friend Shared ReadOnly Property IsSystemUser() As Boolean
            Get
                Return ADMINISTRACION.SystemUser.ToUpper = USUARIO.Codigo.ToUpper
            End Get
        End Property

        Private Shared _BLCerrada As Boolean = True
        Friend Shared ReadOnly Property BLCerrada() As Boolean
            Get
                Return _BLCerrada
            End Get
        End Property


        ' Cuando detectamos que el programa pasa a mantenimiento, esperamos un rato antes de echar
        '   automáticamente al usuario (en caso de que no salga el mismo antes). Este timer se encarga
        '   de eso. El nombre es por hacer la gracia, peor no es inapropiado. No hay que perder el humor...
        '
        Private Shared _tmrTimeBeforeItExplodes As System.Threading.Timer
#End Region

#Region "Variables Externas / Propiedades"

        ''' <summary>
        ''' Usuario actualmente conectado a la aplicación
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared USUARIO As baseball.lib.vo.Usuario = Nothing

        ''' <summary>
        ''' Indica si el usuario actualmente conectado tiene la
        ''' condición de MasterUser en la aplicación
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property IsMasterUser() As Boolean
            Get
                Return ADMINISTRACION.MasterUser.Contains(USUARIO.Codigo)
            End Get
        End Property


        Public Shared ReadOnly Property UrlInformes() As String
            Get
                Return CONFIGURACION.UrlInformes
            End Get
        End Property

#End Region

#Region "Eventos"

        ''' <summary>
        ''' Evento para avisar de todas las acciones que ejecuta la caché
        ''' </summary>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Shared Event Processing(ByVal e As _events.ProgressEventArgs)

        ''' <summary>Este evento se lanza cuando se detecta el paso a mantenimiento (cierre de la BL) en el fichero de configuración</summary>
        ''' <remarks>En este caso, se manda el tiempo que tardará en hacerse efectivo el cierre de la BL.</remarks>
        Public Shared Event BLClosing(ByVal e As _events.NotificationEventArgs)

        ''' <summary>Este evento se lanza cuando se ha hecho efectivo el cierre de la BL.</summary>
        Public Shared Event BLClosed(ByVal e As _events.NotificationEventArgs)

        ''' <summary>Este evento se lanza cuando la BL queda abierta para su uso.</summary>
        Public Shared Event BLOpen(ByVal e As _events.NotificationEventArgs)

#End Region

#Region "Funciones Públicas"

        Public Shared Function InicializaBaseBall(ByVal RP As String) As Boolean
            Try
                Dim res As Boolean = True

                If (Not System.IO.File.Exists(baseball.lib.common.variables.configpath.GetFullPath)) Then
                    Throw New _exceptions._common.ConfigFileNotFoundException
                End If

                Dim c As Integer = 0
                Dim t As Integer = 9
                Dim delay As Integer = 0
                RaiseEvent Processing(New _events.ProgressEventArgs("Iniciando caché: Administración", c, t))
                InicializaAdministracion(RP)
                System.Threading.Thread.Sleep(delay)
                c += 1

                RaiseEvent Processing(New _events.ProgressEventArgs("Iniciando caché: Mantenimiento", c, t))
                InicializaMantenimiento()
                System.Threading.Thread.Sleep(delay)
                c += 1

                RaiseEvent Processing(New _events.ProgressEventArgs("Iniciando caché: Verificando configuración", c, t))
                ChequeaConfiguracion()
                System.Threading.Thread.Sleep(delay)
                c += 1

                RaiseEvent Processing(New _events.ProgressEventArgs("Iniciando caché: Control de Ficheros", c, t))
                InicializaControlFichero()
                System.Threading.Thread.Sleep(delay)
                c += 1

                RaiseEvent Processing(New _events.ProgressEventArgs("Iniciando caché: Conectando", c, t))
                registrarConexion()
                System.Threading.Thread.Sleep(delay)
                c += 1

                RaiseEvent Processing(New _events.ProgressEventArgs("Operación completada", c, t))

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Function CerrarBaseBall() As Boolean
            Try
                Dim res As Boolean = True

                Dim c As Integer = 0
                Dim t As Integer = 2
                Dim delay As Integer = 0

                RaiseEvent Processing(New _events.ProgressEventArgs("Desconectando", c, t))
                registrarDesconexion()
                System.Threading.Thread.Sleep(delay)
                c += 1

                RaiseEvent Processing(New _events.ProgressEventArgs("Borrando caché", c, t))
                USUARIO = Nothing
                ADMINISTRACION = Nothing
                MANTENIMIENTO = Nothing
                CONFIGURACION = Nothing
                GRUPOS = Nothing
                ST = Nothing
                PI = Nothing
                System.Threading.Thread.Sleep(delay)
                c += 1

                RaiseEvent Processing(New _events.ProgressEventArgs("Operación completada", c, t))

                Return res
            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region

#Region "Funciones Privadas"

#Region "*********** Seccion ADMINISTRACION *************"
        Private Shared Sub InicializaAdministracion(ByVal codigo As String)
            Try
                USUARIO = New baseball.lib.vo.Usuario(codigo.ToUpper)
                ADMINISTRACION = New _common.secciones.AdministracionSection

                Dim cacheSetting As repsol.util.config.sections.section = repsol.util.config.sections.section.getSectionSetting(baseball.lib.common.variables.configpath.GetFullPath, ADMINISTRACION.Name)
                If (Not cacheSetting Is Nothing) Then
                    Try
                        ADMINISTRACION.SetMasterUsers(cacheSetting("MasterUser").Value, ";")
                        ADMINISTRACION.SmtpServer = cacheSetting("SMTPServer").Value
                        ADMINISTRACION.SystemMail = cacheSetting("SystemMail").Value
                        ADMINISTRACION.SystemUser = cacheSetting("SystemUser").Value
                    Catch ex As Exception
                        Throw New _exceptions._common.IncorrectFormatConfigFileException
                    End Try

                    If (IsSystemUser) OrElse (IsMasterUser) Then
                        Dim accSelectUsuario As New baseball.lib.bl.usuario.doGet(baseball.lib.bl._common.cache.USUARIO)
                        accSelectUsuario.SystemAction = True
                        Dim tmpUser As baseball.lib.vo.Usuario = accSelectUsuario.execute
                        If (Not tmpUser Is Nothing) Then
                            baseball.lib.bl._common.cache.USUARIO = tmpUser
                        Else
                            If (IsSystemUser) Then
                                USUARIO = New baseball.lib.vo.Usuario(cacheSetting("SystemUser").Value)
                                USUARIO.Nombre = "SYSTEM USER"
                            Else
                                USUARIO = New baseball.lib.vo.Usuario(codigo.ToUpper)
                                USUARIO.Nombre = "MASTER USER"
                            End If
                        End If
                    Else
                        Dim accUsuario As New baseball.lib.bl.usuario.doGet(New baseball.lib.vo.Usuario(Environment.UserName))
                        accUsuario.SystemAction = True
                        Dim tmpUSUARIO As [lib].vo.Usuario = accUsuario.execute
                        If (tmpUSUARIO Is Nothing) Then
                            Throw New _exceptions.usuario.UserNotFoundException
                        Else
                            Throw New _exceptions.usuario.UserNotEnabledException
                        End If
                    End If
                    '**********
                Else
                    Throw New _exceptions._common.InitializeCacheException
                End If
            Catch ex As _exceptions._common.InitializeCacheException
                Throw ex
            Catch ex As _exceptions.BaseballException
                Throw New _exceptions.BaseballException(ex.Message, New _exceptions._common.InitializeCacheException)
            Catch ex As Exception
                Throw New Exception(ex.Message, New _exceptions._common.InitializeCacheException)
            End Try
        End Sub

#End Region

#Region "************ Seccion MANTENIMIENTO *************"
        Private Shared Sub InicializaMantenimiento()
            Try
                MANTENIMIENTO = New _common.secciones.MantenimientoSection
                Dim mantenimientoSetting As repsol.util.config.sections.section = repsol.util.config.sections.section.getSectionSetting(baseball.lib.common.variables.configpath.GetFullPath, MANTENIMIENTO.Name)
                If (Not mantenimientoSetting Is Nothing) Then
                    Try
                        MANTENIMIENTO.DebugMode = Convert.ToBoolean(mantenimientoSetting("Debug").Value)
                        MANTENIMIENTO.EnMantenimiento = Convert.ToBoolean(mantenimientoSetting("enMantenimiento").Value)
                        MANTENIMIENTO.Mensaje = Convert.ToString(mantenimientoSetting("mensaje").Value)
                        MANTENIMIENTO.Detalle = Convert.ToString(mantenimientoSetting("detalle").Value)
                        MANTENIMIENTO.TiempoEspera = Convert.ToInt32(mantenimientoSetting("tiempoEspera").Value)
                    Catch ex As Exception
                        Throw New _exceptions._common.IncorrectFormatConfigFileException
                    End Try

                Else
                    Throw New _exceptions._common.InitializeCacheException
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

#End Region

#Region "************ Seccion CONTROL FICHERO *************"

        Private Shared Sub InicializaControlFichero()
            Try
                ' Creamos un FileSystemWatcher para estar atentos a cualquier cambio que se pueda producir
                '   en el fichero de configuración. Si se produce un cambio, iremos a mirar si hay que
                '   entrar en "modo mantenimiento" o lo que corresponda.
                fileWatcher = New System.IO.FileSystemWatcher(baseball.lib.common.variables.configpath.DIRECTORY)

                ' asociamos un manejador al evento "Changed", que es el que nos interesa...
                AddHandler fileWatcher.Changed, AddressOf configuracionHaCambiado

                ' configuramos el filesystem watcher...
                With fileWatcher
                    .EnableRaisingEvents = True
                    .Filter = "*.xml"
                    .NotifyFilter = System.IO.NotifyFilters.LastWrite
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '
        Private Shared Sub configuracionHaCambiado(ByVal source As Object, ByVal e As System.IO.FileSystemEventArgs)
            Try
                ' Desactivamos temporalmente el fileSystemWatcher para no atender esos eventos mientras atendemos
                '   uno de esos eventos.
                CType(source, System.IO.FileSystemWatcher).EnableRaisingEvents = False

                ' recargamos la configuración y vulvemos a chequearla para poder detectar los cambios...
                InicializaBaseBall(USUARIO.Codigo)

                ' Volvemos a activar los eventos del FileSystemWatcher.
                CType(source, System.IO.FileSystemWatcher).EnableRaisingEvents = True
            Catch ex As Exception
                Throw ex
            End Try
        End Sub



        ''' <summary>Lee la configuración y comprueba si hay cambios que deban ser notificados.</summary>
        Private Shared Sub ChequeaConfiguracion()
            Try
                If MANTENIMIENTO.EnMantenimiento And Not IsMasterUser Then
                    If Not BLCerrada Then
                        ' Acabamos de detectar un paso a mantenimiento y como no es masterUser entonces hay que
                        '   avisar a la vista para comunicar este hecho.
                        RaiseEvent BLClosing(New _events.NotificationEventArgs(MANTENIMIENTO.Mensaje, MANTENIMIENTO.Detalle, MANTENIMIENTO.getSeguntosEspera))

                        ' Lanzamos el temporizador que cerrará "automágicamente" la BL cuando el tiempo de
                        '   espera indicado haya transcurrido.
                        Dim timerDelegate As System.Threading.TimerCallback = AddressOf doFinalizar
                        _tmrTimeBeforeItExplodes = New System.Threading.Timer(timerDelegate, Nothing, MANTENIMIENTO.getMiliseguntosEspera, System.Threading.Timeout.Infinite)
                    Else
                        ' Ya estaba cerrada entonces sigue cerrada.
                        RaiseEvent BLClosed(New _events.NotificationEventArgs(MANTENIMIENTO.Mensaje, MANTENIMIENTO.Detalle, MANTENIMIENTO.getSeguntosEspera))
                    End If

                    Exit Sub
                End If

                If Not MANTENIMIENTO.EnMantenimiento And BLCerrada Then
                    ' 1) Acabamos de iniciar la aplicación y no hay nada que impida abrir la BL, así que
                    '   la abrimos.
                    ' 2) Acaban de abrir la BL así que la marcamos como abierta.
                    setBLCerrada(False)
                End If
                RaiseEvent BLOpen(New _events.NotificationEventArgs("BL Abierta", "Los usuarios pueden llamar a la BL", 0))
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        ' Esto es lo que hacemos cuando finalice el temporizador de espera...
        '
        Private Shared Sub doFinalizar(ByVal stateinfo As Object)
            setBLCerrada(True)
            RaiseEvent BLClosed(New _events.NotificationEventArgs(MANTENIMIENTO.Mensaje, MANTENIMIENTO.Detalle, MANTENIMIENTO.getMiliseguntosEspera))
        End Sub

#End Region

#Region "Registro de la Conexion - Desconexion a la aplicación"

        Private Shared Sub registrarConexion()
            Try
                If (IsMasterUser) OrElse (IsSystemUser) Then Return

                'CONEXION = New baseball.lib.vo.conexion.ConexionVO
                'CONEXION.Usuario = USUARIO
                'CONEXION.Conexion = DateTime.Now

                'Dim doConectar As New baseball.lib.bl.Conexion.doInsertarConexion(CONEXION)
                'doConectar.SystemAction = True
                'CONEXION = doConectar.execute
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Private Shared Sub registrarDesconexion()
            Try
                If (IsMasterUser) OrElse (IsSystemUser) Then Return
                'If (CONEXION Is Nothing) Then Return

                'CONEXION.Desconexion = DateTime.Now
                'Dim doConectar As New baseball.lib.bl.Conexion.doActualizarConexion(CONEXION)
                'doConectar.SystemAction = True
                'doConectar.execute()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
#End Region

#Region "Utiles"
        ''' <summary>Determina si el proyecto está en mantenimiento (BL Cerrada)</summary>
        ''' <remarks>El uso habitual de esta propiedad consiste en ponerla a TRUE cuando ha
        ''' pasado el tiempo indicado en "tiempoEspera" después de recibir el evento de que
        ''' el fichero de configuración ha cambiado y que ya tiene un "enMantenimiento = SI"</remarks>
        Private Shared Sub setBLCerrada(ByVal value As Boolean)
            ' El proyecto no puede pasarse a mantenimiento si el fichero de configuración dice que
            '   no está en mantenimiento.
            _BLCerrada = value AndAlso MANTENIMIENTO.EnMantenimiento
        End Sub
#End Region

#End Region

    End Class
End Namespace

