using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace baseball.client.wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Views.MainWindow main = new Views.MainWindow() { DataContext = new com.mxply.app.baseball.client.wpf.ViewModels.MainWindowViewModel() };

            main.Show();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                //base.OnStartup(e);
                string ietfLanguageTag = "es-ES";
                com.mxply.net.logging.Application.SApplication.Initialize("BASEBALL.Client");
                com.mxply.net.logging.LogUtil.Manager.Info("Baseball startup");

                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(ietfLanguageTag);
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;

                FrameworkElement.LanguageProperty.OverrideMetadata(
                    typeof(FrameworkElement),
                    new FrameworkPropertyMetadata(
                        System.Windows.Markup.XmlLanguage.GetLanguage(ietfLanguageTag)));

                com.mxply.app.baseball.client.wpf.Core.Cache applicationCache = new com.mxply.app.baseball.client.wpf.Core.Cache();

                //using (ConcelloCambreServiceClient service = applicationCache.CreateService())
                //{
                //    service.CheckDBIntegrity();
                //    ResultAppSetting resultService = service.ObtenerAppSettingCustom();
                //    if (!resultService.Success)
                //        throw new Exception(resultService.Error.Message);
                //    applicationCache.AppSetting = resultService.Value;
                //}

                com.mxply.app.baseball.client.wpf.ViewModels.MainWindowViewModel mainvm = new com.mxply.app.baseball.client.wpf.ViewModels.MainWindowViewModel(applicationCache);
                //mainvm.Pages.Add(new ViewModels.DashboardViewModel(applicationCache));
                //mainvm.Pages.Add(new ViewModels.AddParticipanteViewModel(applicationCache));
                //mainvm.Pages.Add(new ViewModels.PrintViewModel(applicationCache));
                //mainvm.Pages.Add(new ViewModels.ActividadesViewModel(applicationCache));
                //mainvm.Pages.Add(new ViewModels.ParticipanteDetailViewModel(applicationCache));
                //mainvm.Pages.Add(new ViewModels.InstanciaActividadDetailViewModel(applicationCache));
                //mainvm.Pages.Add(new ViewModels.SolicitudViewModel(applicationCache));
                //mainvm.Pages.Add(new ViewModels.BusquedaViewModel(applicationCache));
                //mainvm.Pages.Add(new ViewModels.NotificacionesViewModel(applicationCache));
                //mainvm.Pages.Add(new ViewModels.NotificacionDetailViewModel(applicationCache));

                Views.MainWindow mainview = new Views.MainWindow();
                mainview.DataContext = mainvm;

                System.Windows.Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

                mainvm.Initialize();
                mainview.Show();
            }
            catch (Exception ex)
            {
                com.mxply.app.baseball.client.wpf.Core.Common.HandleError("App", ex);
            }
        }
        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
                base.OnExit(e);

            }
            catch (Exception ex)
            {
                com.mxply.app.baseball.client.wpf.Core.Common.HandleError("App", ex);
            }
        }
    }
}
