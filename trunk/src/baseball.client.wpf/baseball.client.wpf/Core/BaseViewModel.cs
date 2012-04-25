using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.app.baseball.client.wpf.Core
{
    internal class BaseViewModel
    {
        private Cache _cache;
        protected BaseViewModel(Cache cache)
        {
            this.Name = this.GetType().Name;
            this.Cache = cache;
        }

        public Cache Cache
        {
            get { return _cache; }
            private set { _cache = value; }
        }
    }

}
