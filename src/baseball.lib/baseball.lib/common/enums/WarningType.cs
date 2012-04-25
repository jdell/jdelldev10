using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace com.mxply.app.baseball.lib.common.enums
{
    public enum WarningType
    {
        [Description("Yellow Card")]
        YellowCard = 1,

        [Description("Red Card")]
        RedCard = 2
    }
}
