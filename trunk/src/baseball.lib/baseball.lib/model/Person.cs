using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using com.mxply.net.common.Extensions;

namespace com.mxply.app.baseball.lib.model
{
    public partial class Person
    {
        public override string ToString()
        {
            return string.Format("{0}, {1}", this.LastName.ToUpper(), this.FirstName.ToCorrectCase());
        }
    }
}
