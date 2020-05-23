using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_octvmarsh.Utils
{
    public class LW_CloudRequestException : Exception
    {
        public LW_CloudRequestException()
        {
        }

        public LW_CloudRequestException(string message)
            : base(message)
        {
            message = $"The HTTP Request falied or timed out" + message;
        }

        public LW_CloudRequestException(string message, Exception inner)
            : base(message, inner)
        {
            message = $"The HTTP Request falied or timed out" + message;
        }
    }


}
