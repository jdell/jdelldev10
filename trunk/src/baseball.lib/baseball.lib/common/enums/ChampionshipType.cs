using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace com.mxply.app.baseball.lib.common.enums
{
    public enum ChampionshipType
    {
        [Description("League")]
        League = 0,

        [Description("Tournament")]
        Tournament = 1
    }
}
