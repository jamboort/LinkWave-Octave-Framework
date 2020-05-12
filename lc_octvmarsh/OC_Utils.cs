using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_octvmarsh
{
    /// <summary>
    /// The utility functions that are used in divers areas of the Octave framework
    /// </summary>
    class OC_Utils
    {
        /// <summary>
        /// Converst the Octave timestamp in unix format into a DateTime object. The octave timestamp comes in ms precision
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            unixTimeStamp /= 1000;
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
