using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace com.mxply.app.baseball.lib.common.enums
{
    public enum MatchStatus
    {
        [Description("Pending")]
        Pending = 0,

        [Description("Completed")]
        Completed = 1,

        [Description("Deferred")]
        Deferred = 2,

        [Description("Forfeit")]
        Forfeit = 3
    }
}
