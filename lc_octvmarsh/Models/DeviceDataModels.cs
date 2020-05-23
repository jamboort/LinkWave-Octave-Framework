using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lc_octvmarsh.Models
{
 
    /// <summary>
    /// Provides the dta teplate to make a device provisioning call on the Octave Platofm V5.0
    /// </summary>
    public class CreateNewDeviceDM
    {   /* OCTAVE DOCUMENTATION INTERFACE
         * {
             "name": "device name",
             "imei": "352653090106733",
             "fsn": "VU810385240210"
             }'
         */
        [Required(ErrorMessage = "The device name is required")]
        public string name { get; set; }
        [Required(ErrorMessage = "The device imei is required")]
        public string imei { get; set; }
        [Required(ErrorMessage = "The device serial is required")]
        public string fsn { get; set; }
    }

    public class CreateNewDeviceResponse
    {
        public string DeviceIds { get; set; }

        public string Complete { get; set; }


    }
}
