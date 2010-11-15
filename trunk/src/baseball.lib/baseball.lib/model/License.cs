using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.app.baseball.lib.model
{
    public partial class License
    {
        public override string ToString()
        {
            return string.Format("{0:0000}", Number);
        }
    }
}
