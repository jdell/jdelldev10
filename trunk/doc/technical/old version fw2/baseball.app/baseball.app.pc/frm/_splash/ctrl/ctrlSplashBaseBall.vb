Namespace frm._splash.ctrl
    Public Class ctrlSplashBaseBall

        Private _vista As frmSplashBaseBall

        Public Sub inicializarForm(ByRef frm As Form)
            Try
                _vista = frm

                _vista.Status = "Iniciando aplicación..."
                _vista.appName = String.Format("{0} v{1}", My.Application.Info.ProductName, Application.ProductVersion) 'My.Application.Info.Version.ToString())
                _vista.OperatingSystem = Environment.OSVersion.VersionString
                _vista.StatusDetails = "cargando componentes..."
                _vista.IndustrialComplex = My.Application.Info.CompanyName
#If DEBUG Then
                _vista.Release = "Desarrollo"
#Else
                _vista.Release = "Producción"
#End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub


    End Class
End Namespace

