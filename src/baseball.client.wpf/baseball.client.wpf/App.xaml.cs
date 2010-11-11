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
    }
}
