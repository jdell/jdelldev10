using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mxply.app.baseball.lib.bl.exceptions
{
    public class BaseballException : com.mxply.net.common.Exceptions.BaseException
    {
        public BaseballException(Exception ex)
            : base(ex, "BaseballException")
        {
        }
        public BaseballException(string message)
            : base(message)
        {
        }
        public BaseballException(string message, string detail)
            : base(message, detail)
        {
        }

    }

}
