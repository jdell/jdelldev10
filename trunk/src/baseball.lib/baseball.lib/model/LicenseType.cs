using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.app.baseball.lib.model
{
    public partial class LicenseType
    {
        public override string ToString()
        {
            return this.Description;
        }
        public static Byte Convert(common.enums.LicenseType internalId)
        {
            return System.Convert.ToByte(internalId);
        }
        public static common.enums.LicenseType Convert(Byte internalId)
        {
            //TODO: Complete it! - Enum
            return (common.enums.LicenseType)internalId;
        }
    }
}
