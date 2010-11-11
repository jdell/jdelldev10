using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using com.mxply.app.baseball.lib.model;

namespace com.mxply.app.baseball.client.wpf.ViewModels
{
    internal class FederationViewModel : com.mxply.app.baseball.client.wpf.common.ViewModels.ViewModelBase
    {
        ObservableCollection<Federation> _federations = null;
        Federation _selectedFederation = null;



        public Federation SelectedFederation
        {
            get
            {
                return _selectedFederation;
            }
            set
            {
                if (_selectedFederation != value)
                {
                    _selectedFederation = value;
                    OnPropertyChanged("SelectedFederation");
                }
            }
        }
        public ObservableCollection<Federation> Federations
        {
            get
            {
                return _federations;
            }
            set
            {
                if (_federations != value)
                {
                    _federations = value;
                    OnPropertyChanged("Federations");
                }
            }
        }

    }
}
