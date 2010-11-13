using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mxply = com.mxply.net.common;

namespace com.mxply.app.baseball.lib.bl.core
{
    public abstract class ActionBL:Mxply.Core.ActionBL
    {
        protected override string GetConnectionName()
        {
            return "com.mxply.app.baseball.lib.Properties.Settings.dbBaseballConnectionString";
        }
    }
}
