using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.app.baseball.lib.model
{
    public partial class Address
    {
        public override string ToString()
        {
            return string.Format("{0}, {1} {2}, {3} - {4}", Street, City, ZipCode, State, Country);
        }
    }
}
