using System;

namespace lc_octvmarsh.Utils
{
    /// <summary>
    /// The utility functions that are used in divers areas of the Octave framework
    /// </summary>
    class OC_Utils
    {
        /// <summary>
        /// Converts the Octave timestamp in Unix format into a DateTime object. The octave timestamp comes in ms precision
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            unixTimeStamp /= 1000;
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, millisecond: 0, kind: DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(value: unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
