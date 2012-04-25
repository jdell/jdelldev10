using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.app.baseball.lib.model
{
    public partial class WarningType
    {
        public override string ToString()
        {
            return this.Description;
        }
        public static Byte Convert(common.enums.WarningType internalId)
        {
            return System.Convert.ToByte(internalId);
        }
        public static common.enums.WarningType Convert(Byte internalId)
        {
            //TODO: Complete it! - Enum
            return (common.enums.WarningType)internalId;
        }
    }
}
