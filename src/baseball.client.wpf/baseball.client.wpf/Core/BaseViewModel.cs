using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.app.baseball.client.wpf.Core
{
    internal abstract class BaseViewModel : com.mxply.net.common.Core.ViewModelBase
    {
        private ClientCache _cache;
        protected BaseViewModel(ClientCache cache)
        {
            this.Name = this.GetType().Name;
            this.Cache = cache;
        }

        public ClientCache Cache
        {
            get { return _cache; }
            private set { _cache = value; }
        }
    }

}
