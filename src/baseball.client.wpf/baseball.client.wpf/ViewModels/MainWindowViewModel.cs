using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace com.mxply.app.baseball.client.wpf.ViewModels
{
    internal class MainWindowViewModel:common.ViewModels.ViewModelBase
    {
        ICommand _goToPageCommand = null;



        public ICommand GoToPageCommand
        {
            get
            {
                if (_goToPageCommand == null)
                    _goToPageCommand = null;

                return _goToPageCommand;
            }
            set
            {
                if (_goToPageCommand != value)
                {
                    _goToPageCommand = value;
                    OnPropertyChanged("GoToPageCommand");
                }
            }
        }
    }
}
