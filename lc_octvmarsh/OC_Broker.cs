//using Newtonsoft.Json;
using lc_octvmarsh.Utils;
using System;
//using System.Text.Json;
//using RestSharp;
//using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace lc_octvmarsh
{

    /// <summary>
    /// The Octave Broker to manage actions with the octave platform, this class handles the individual calls to the Octave Cloud API's
    /// </summary>
    public class OC_Broker
    {
        /// <summary>
        /// We obtain the basic settings (Only the Octave settings)
        /// </summary>
        //public Properties.Settings _Setts = new Properties.Settings();
        //public _OctaveToken = _Setts.OctaveToken;
        //public _OctaveUser = _Setts.OctaveUser;
        //public _OctaveCompany = _Setts.OctaveCompany;

        //TODO read them from the settings
        private readonly string _OctaveToken = "tWlqsEKcdUesd8Yg83rXiRitEnd1d3mY";
        private readonly string _OctaveUser = "andrew_newton";
        private readonly string _OctaveCompany = "linkwave_technologies";

        public OC_Broker()
        {
        }

        /// <summary>
        /// Lists the devices comissioned in OCTAVE 
        /// </summary>
        /// <returns>An OC_Device instance</returns>
        public LW_Device GetOvtaveDevices()
        {
            try
            {
                //var responseContent = -1;
                var OB = new OC_Broker();
                OC_Utils OCU = new OC_Utils();
                string fullURL = "https://octave-api.sierrawireless.io/v5.0/<company_name>/device/?only=id,name,avSystemId,blueprintId,localVersions,location,hardware,creationDate,displayName";
                fullURL = fullURL.Replace("<company_name>", this._OctaveCompany);
                string baseAddress = fullURL;

                // We create an empty lw_device with unknown name and ID to trace
                var retDevice = new LW_Device("Unknown", "Unknown", "Unknown");

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("X-Auth-Token", this._OctaveToken);
                    client.DefaultRequestHeaders.Add("X-Auth-User", this._OctaveUser);

                    var response_ = client.GetAsync("").Result;
                    if (response_.IsSuccessStatusCode)
                    {
                        OC_Device resOK = response_.Content.ReadFromJsonAsync<OC_Device>().Result;
                        if (resOK.Head.Status == 200)
                        {
                            OC_Device Device = new OC_Device();
                            LW_Device gDevice = new LW_Device();
                            // We populate the data fields of our lw_device with the data obtained from OCTAVE
                            gDevice.DeviceName = resOK.Body.First().Name;
                            gDevice.DeviceId = resOK.Body.First().Id;
                            gDevice.SerialNumber = resOK.Body.First().Hardware.Fsn;
                            gDevice.VisibleName = OCU.UnixTimeStampToDateTime(resOK.Body.First().CreationDate).ToShortDateString();
                            gDevice.IsActive = true;

                            return gDevice;
                        }
                        else
                        {
                            return retDevice;
                        }
                    }
                    else
                    {
                        return retDevice;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load a device from octave, method = GetOctaveDevices", ex);
            }
        }

        /// <summary>
        /// Lists the devices comissioned in OCTAVE 
        /// </summary>
        /// <returns>An OC_Device instance</returns>
        public async System.Threading.Tasks.Task<string> CreateNewOctaveDevicesAsync(string Name, string IMEI, string SerialNumber)
        {
            try
            {
                //var responseContent = -1;
                var OB = new OC_Broker();
                OC_Utils OCU = new OC_Utils();
                string fullURL = "https://octave-api.sierrawireless.io/v5.0/<company_name>/device/provision";
                fullURL = fullURL.Replace("<company_name>", this._OctaveCompany);
                string baseAddress = fullURL;

                // We create an empty lw_device with unknown name and ID to trace
                var retDevice = new LW_Device("Unknown", "Unknown", "Unknown");
                retDevice.DeviceName = Name;
                retDevice.IMEI = IMEI;
                retDevice.SerialNumber = SerialNumber;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("X-Auth-Token", this._OctaveToken);
                    client.DefaultRequestHeaders.Add("X-Auth-User", this._OctaveUser);

                    var values = new Dictionary<string, string>
                    {
                        { "name", retDevice.DeviceName },
                        { "imei", retDevice.IMEI },
                        { "fsn",  retDevice.SerialNumber },
                    };

                    var json = JsonSerializer.Serialize(values);
                    var stringContent = new StringContent(json);
                    //    return Ok(responseString);

                    var response_ = await client.PostAsync(baseAddress, stringContent);
                    var responseString = await response_.Content.ReadAsStringAsync();
                    if (response_.IsSuccessStatusCode)
                    {
                        var resOK = response_.Content.ReadFromJsonAsync<OC_ProvisionResult>().Result;
                        if (resOK.Head.Status == 200)
                        {
                            OC_ProvisionResult Device = new OC_ProvisionResult();
                            OC_ProvisionResult gDevice = new OC_ProvisionResult();
                            // We populate the data fields of our lw_device with the data obtained from OCTAVE
                            gDevice.Head.Status = resOK.Head.Status;
                            //gDevice.Head.Errors.First() = resOK.Head.Errors.First();
                            //gDevice.SerialNumber = resOK.Body.First().Hardware.Fsn;
                            //gDevice.VisibleName = OCU.UnixTimeStampToDateTime(resOK.Body.First().CreationDate).ToShortDateString();
                            //gDevice.IsActive = true;

                            return gDevice.Head.Status.ToString();
                        }
                        else
                        {
                            OC_ProvisionResult Device = new OC_ProvisionResult();
                            OC_ProvisionResult gDevice = new OC_ProvisionResult();
                            // We populate the data fields of our lw_device with the data obtained from OCTAVE
                            gDevice.Head.Status = resOK.Head.Status;
                            //gDevice.Head.Errors.First() = resOK.Head.Errors.First();
                            //gDevice.SerialNumber = resOK.Body.First().Hardware.Fsn;
                            //gDevice.VisibleName = OCU.UnixTimeStampToDateTime(resOK.Body.First().CreationDate).ToShortDateString();
                            //gDevice.IsActive = true;

                            return responseString.ToString();
                        }
                    }
                    else
                    {

                        return response_.RequestMessage.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load a device from octave, method = GetOctaveDevices", ex);
            }
        }

    }
}
