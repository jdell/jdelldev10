using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using com.mxply.net.common.Commands;
using com.mxply.net.common.EventAggregator;
using com.mxply.app.baseball.client.wpf.Core;
using com.mxply.net.common.Extensions;
using System.Deployment.Application;

namespace com.mxply.app.baseball.client.wpf.ViewModels
{
    internal class MainWindowViewModel:Core.BaseViewModel
    {
        private List<Core.BaseViewModel> _pages;
        private Core.BaseViewModel _currentPage;

        private DelegateCommand<String> _goToPageCommand;
        private DelegateCommand _closeCommand;


        public MainWindowViewModel(ClientCache cache)
            : base(cache)
        {
            ServicesFactory.EventService.GetEvent<GenericEvent<string>>().Subscribe(
                s =>
                {
                    if (s.Topic == "NavigateToPageEvent")
                        if (GoToPageCommand.CanExecute(s.Value))
                            GoToPageCommand.Execute(s.Value);
                }
                );

        }
        public DelegateCommand<String> GoToPageCommand
        {
            get
            {
                if (_goToPageCommand == null)
                    _goToPageCommand = new DelegateCommand<string>(OnGoToPage, CanGoToPage);
                return _goToPageCommand;
            }
        }

        private void OnGoToPage(string pageName)
        {
            this.CurrentPage = Pages.Where(o => o.Name == pageName).First();
        }
        private bool CanGoToPage(string pageName)
        {
            return Pages != null && Pages.Count(o => o.Name == pageName) > 0;
        }
        public DelegateCommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new DelegateCommand(OnClose);
                return _closeCommand;
            }
        }

        private void OnClose()
        {
            this.Name.PublishEvent("CloseWindow");
        }
        public string Title
        {
            get
            {
                Version v = null;
                string productName = string.Empty;
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

                System.Reflection.AssemblyName assemblyName = assembly.GetName();
                productName = assemblyName.Name;
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    v = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                }
                else
                {
                    v = assemblyName.Version;
                }
#if DEBUG
                return String.Format("BaseBall - {0} v{1} -TESTMODE-", productName, v.ToString());
#else
                return String.Format("BaseBall - {0} v{1}", productName,v.ToString());
#endif
            }
        }
        public Core.BaseViewModel CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    _currentPage.Initialize();
                    OnPropertyChanged("CurrentPage");
                }
            }
        }
        public List<Core.BaseViewModel> Pages
        {
            get
            {
                if (_pages == null) _pages = new List<Core.BaseViewModel>();
                return _pages;
            }
            private set { _pages = value; OnPropertyChanged("Pages"); }
        }
        public override bool Initialize()
        {
            try
            {
                if (Pages.Count > 0) CurrentPage = Pages[0];
                return true;
            }
            catch (Exception ex)
            {
                Common.HandleError(this.Name, ex); //throw ex;
                return false;
            }
        }
    }
}
