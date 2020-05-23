using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using lc_octvmarsh.Models;
using lc_octvmarsh.Utils;
using Newtonsoft.Json;

namespace lc_octvmarsh.Managers.Public
{
    public class DeviceManager
    {
        private bool KEEP = Properties.Settings.Default.LW_KEEP;
        public async Task<string> ProvisionDevice(CreateNewDeviceDM device)
        {
            string json = JsonConvert.SerializeObject(device);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            string url = Properties.Resources.PartialProvisionDevice;
            url = url.Replace("<company_name>", Properties.Settings.Default.OctaveCompany);
            try
            {
                using (HttpResponseMessage response = await CloudAPIManager.CloudAPI_Client.PutAsync(url, data))
                {
                    if(response.IsSuccessStatusCode)
                    {
                        CreateNewDeviceResponse oc_Device = await response.Content.ReadAsAsync<CreateNewDeviceResponse>();
                        if (KEEP)
                        {
                            //TODO: Implement a KEEP
                        }
                        return (oc_Device.DeviceIds);
                    }
                    else
                    {
                        throw new LW_CloudRequestException($"Provision Device returned an invalid response with the following reason : { response.ReasonPhrase }. ");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new LW_CloudRequestException($"Provision Device returned no response, there was an exception registered. ", ex);
            }
        }
    }
}