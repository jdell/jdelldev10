using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.app.baseball.lib.model
{
    public partial class ChampionshipType
    {
        public override string ToString()
        {
            return this.Description;
        }
        public static Byte Convert(common.enums.ChampionshipType internalId)
        {
            return System.Convert.ToByte(internalId);
        }
        public static common.enums.ChampionshipType Convert(Byte internalId)
        {
            //TODO: Complete it! - Enum
            return (common.enums.ChampionshipType)internalId;
        }
    }
}
