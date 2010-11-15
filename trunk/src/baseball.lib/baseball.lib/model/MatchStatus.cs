using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.app.baseball.lib.model
{
    public partial class MatchStatus
    {
        public override string ToString()
        {
            return this.Description;
        }
        public static Byte Convert(common.enums.MatchStatus internalId)
        {
            return System.Convert.ToByte(internalId);
        }
        public static common.enums.MatchStatus Convert(Byte internalId)
        {
            //TODO: Complete it! - Enum
            return (common.enums.MatchStatus)internalId;
        }
    }
}
