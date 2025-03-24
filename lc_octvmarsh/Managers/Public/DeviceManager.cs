using lc_octvmarsh.Models;
using lc_octvmarsh.Utils;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lc_octvmarsh.Managers.Public
{
    public class DeviceManager
    {
        private bool KEEP = Properties.Settings.Default.LW_KEEP;
        public async Task<string> ProvisionDevice(CreateNewDeviceDM device)
        {
            string json = JsonSerializer.Serialize(value: device);
            var data = new StringContent(content: json, encoding: Encoding.UTF8, mediaType: "application/json");

            string url = Properties.Resources.PartialProvisionDevice;
            url = url.Replace(oldValue: "<company_name>", newValue: Properties.Settings.Default.OctaveCompany);
            try
            {
                using (HttpResponseMessage response = await CloudAPIManager.CloudAPI_Client.PutAsync(requestUri: url, content: data))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        CreateNewDeviceResponse oc_Device = await response.Content.ReadFromJsonAsync<CreateNewDeviceResponse>();
                        if (KEEP)
                        {
                            //TODO: Implement a KEEP
                        }
                        return (oc_Device.DeviceIds);
                    }
                    else
                    {
                        throw new LW_CloudRequestException(message: $"Provision Device returned an invalid response with the following reason : {response.ReasonPhrase}. ");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new LW_CloudRequestException(message: $"Provision Device returned no response, there was an exception registered. ", ex);
            }
        }
    }
}