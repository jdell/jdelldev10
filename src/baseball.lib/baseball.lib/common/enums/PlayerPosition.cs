using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace com.mxply.app.baseball.lib.common.enums
{
    public enum PlayerPosition
    {
        [Description("No Position")]
        NoPosition = 0,

        [Description("Pitcher")]
        Pitcher = 1,

        [Description("Catcher")]
        Catcher = 2,

        [Description("First Base")]
        FirstBase = 3,

        [Description("Second Base")]
        SecondBase = 4,

        [Description("Third Base")]
        ThirdBase = 5,

        [Description("Short Stop")]
        ShortStop = 6,

        [Description("Left Field")]
        LeftField = 7,

        [Description("Center Field")]
        CenterField = 8,

        [Description("Right Field")]
        RightField = 9,

        [Description("Designed Batter")]
        DesignedBatter = 10,

        [Description("Designed Runner")]
        DesignedRunner = 11
    }
}
