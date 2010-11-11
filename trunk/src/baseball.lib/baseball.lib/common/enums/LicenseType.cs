using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace com.mxply.app.baseball.lib.common.enums
{
    public enum LicenseType
    {
        [Description("Score Taker")]
        ScoreTaker = 0,

        [Description("Player")]
        Player = 1,

        [Description("Umpire")]
        Umpire = 2
    }
}
