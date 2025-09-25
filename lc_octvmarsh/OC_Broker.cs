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
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
        public async Task<string> CreateNewOctaveDevicesAsync(string Name, string IMEI, string SerialNumber)
        {
            return await CreateNewAV_System(Name, IMEI, SerialNumber);
            //try
            //{
            //    //var responseContent = -1;
            //    var OB = new OC_Broker();
            //    OC_Utils OCU = new OC_Utils();
            //    string fullURL = "https://octave-api.sierrawireless.io/v5.0/<company_name>/device/provision";
            //    fullURL = fullURL.Replace("<company_name>", this._OctaveCompany);
            //    string baseAddress = fullURL;

            //    // We create an empty lw_device with unknown name and ID to trace
            //    var retDevice = new LW_Device("Unknown", "Unknown", "Unknown");
            //    retDevice.DeviceName = Name;
            //    retDevice.IMEI = IMEI;
            //    retDevice.SerialNumber = SerialNumber;

            //    using (var client = new HttpClient())
            //    {
            //        client.BaseAddress = new Uri(baseAddress);
            //        client.DefaultRequestHeaders.Accept.Clear();
            //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //        client.DefaultRequestHeaders.Add("X-Auth-Token", this._OctaveToken);
            //        client.DefaultRequestHeaders.Add("X-Auth-User", this._OctaveUser);

            //        var values = new Dictionary<string, string>
            //        {
            //            { "name", retDevice.DeviceName },
            //            { "imei", retDevice.IMEI },
            //            { "fsn",  retDevice.SerialNumber },
            //        };

            //        var json = JsonSerializer.Serialize(values);
            //        StringContent stringContent = new StringContent(json);
            //        //    return Ok(responseString);

            //        var response_ = await client.PostAsync(baseAddress, stringContent);
            //        var responseString = await response_.Content.ReadAsStringAsync();
            //        if (response_.IsSuccessStatusCode)
            //        {
            //            var resOK = response_.Content.ReadFromJsonAsync<OC_ProvisionResult>().Result;
            //            if (resOK.Head.Status == 200)
            //            {
            //                OC_ProvisionResult Device = new OC_ProvisionResult();
            //                OC_ProvisionResult gDevice = new OC_ProvisionResult();
            //                // We populate the data fields of our lw_device with the data obtained from OCTAVE
            //                gDevice.Head.Status = resOK.Head.Status;
            //                //gDevice.Head.Errors.First() = resOK.Head.Errors.First();
            //                //gDevice.SerialNumber = resOK.Body.First().Hardware.Fsn;
            //                //gDevice.VisibleName = OCU.UnixTimeStampToDateTime(resOK.Body.First().CreationDate).ToShortDateString();
            //                //gDevice.IsActive = true;

            //                return gDevice.Head.Status.ToString();
            //            }
            //            else
            //            {
            //                OC_ProvisionResult Device = new OC_ProvisionResult();
            //                OC_ProvisionResult gDevice = new OC_ProvisionResult();
            //                // We populate the data fields of our lw_device with the data obtained from OCTAVE
            //                gDevice.Head.Status = resOK.Head.Status;
            //                //gDevice.Head.Errors.First() = resOK.Head.Errors.First();
            //                //gDevice.SerialNumber = resOK.Body.First().Hardware.Fsn;
            //                //gDevice.VisibleName = OCU.UnixTimeStampToDateTime(resOK.Body.First().CreationDate).ToShortDateString();
            //                //gDevice.IsActive = true;

            //                return responseString.ToString();
            //            }
            //        }
            //        else
            //        {

            //            return response_.RequestMessage.ToString();
            //        }
            //    }
        
            //catch (Exception ex)
            //{
            //    throw new Exception(message: "Unable to load a device from octave, method = GetOctaveDevices", innerException: ex);
            //}
        }

        private async Task<string> CreateNewAV_System(string Name, string IMEI, string SerialNumber)
        {
            await AVC_Logon();
            // Build CSV content (NAME,LABELS,IMEI,FSN,MQTT-Password)
            string timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            string[] labels = { "DM_BackOffice", timestamp, "" };
            string MQTT_Password = Environment.GetEnvironmentVariable(variable: "MQTT_Password");
            AV_RegistrationAdditionalInfo additionalInfo = new AV_RegistrationAdditionalInfo();
            string csvHeader = "NAME,LABELS,IMEI,SERIAL NUMBER,MQTT";
            string csvBody = $"{Name},{string.Join(separator: "|", labels)},{IMEI},{SerialNumber},{MQTT_Password}";
            string CSVfile = csvHeader + Environment.NewLine + csvBody + Environment.NewLine;

            // Choose storage parameters:
            // Prefer passing these from configuration or environment variables in production.
            string connectionString = Environment.GetEnvironmentVariable(variable: "AZURE_FILE_CONNECTION_STRING");
            string shareName = Environment.GetEnvironmentVariable(variable: "AZURE_FILE_SHARE_NAME") ?? "AV_RegistrationUploads";
            string directoryPath = DateTime.UtcNow.ToString(format: "yyyy/MM/dd"); // optional date-based directory
            string fileName = $"{Name}_{DateTime.UtcNow:yyyyMMddHHmmss}.csv";

            // Upload the CSV to Azure File Share
            await AzureFileShareUploader.UploadTextAsync(connectionString, shareName, directoryPath, fileName, CSVfile);

            // Return the path for caller convenience
            return $"/{shareName}/{directoryPath}/{fileName}";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uriString: "https://eu.airvantage.net");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(item: new MediaTypeWithQualityHeaderValue(mediaType: "application/json"));
                client.DefaultRequestHeaders.Accept.Add(item: new MediaTypeWithQualityHeaderValue(mediaType: "text/csv"));
                client.DefaultRequestHeaders.Accept.Add(item: new MediaTypeWithQualityHeaderValue(mediaType: "multipart/mixed"));
                client.DefaultRequestHeaders.Add(name: "X-Auth-Token", value: this._OctaveToken);
                client.DefaultRequestHeaders.Add(name: "X-Auth-User", value: this._OctaveUser);


                //We have a stored file now we need to call the API to register the system
                string registreURL = "/api/v1/operations/systems/register";
                string json = JsonSerializer.Serialize(value: additionalInfo);
                StringContent data = new StringContent(content: json, encoding: Encoding.UTF8, mediaType: "application/json");
                HttpResponseMessage response_ = await client.PostAsync(requestUri: registreURL, content: data);

            }

        }

        private async Task<string> AVC_Logon()
        {
            if (!string.IsNullOrEmpty(value: AVC_Registration.Token))
            {
                return AVC_Registration.Token;
            }

            // Create the form data
            Dictionary<string, string> formData = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "username", "ian.a.burt@gmail.com" },
                { "password", "5i3rr@01." },
                { "client_id", "4debfad112be4d5dba070763c8136939" },
                { "client_secret", "ruByjZc_xWUeJCBoETc5A9sbnXYK7GdBC9JJdYXLiJA" }
            };

            FormUrlEncodedContent content = new FormUrlEncodedContent(nameValueCollection: formData);

            // Send the request
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(requestUri: "https://eu.airvantage.net/api/oauth/token", content);

            // Read the response
            string result = await response.Content.ReadAsStringAsync();
            AVC_Registration.Token = "";
            return AVC_Registration.Token;
            // Console.WriteLine($"Response: {response.StatusCode}\n{result}");

        }

        private async Task UpdateAV_System()
        {
            // Prepare CSV content
            string csvData = "SerialNumber,IMEI\n1234567890,9876543210";
            StringContent csvContent = new StringContent(csvData, Encoding.UTF8, "text/csv");
            csvContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"file\"",
                FileName = "\"file.csv\""
            };

            // Prepare JSON content
            string jsonData = @"{
                              ""defaultApplications"": [""45aa62ac003841fb8fb5b3b21cdf7f86"", ""45aa62ac003841fb8fb5b3b21cdf7f87""],
                              ""offerId"":StringContent25aa92ac003841fb8fb5b3b21cdf7f17""
                    }";
            StringContent jsonContent = new StringContent(content: jsonData, encoding: Encoding.UTF8, mediaType: "application/json");
            jsonContent.Headers.ContentDisposition = new ContentDispositionHeaderValue(dispositionType: "form-data")
            {
                Name = "\"defaultValues\"",
                FileName = "\"defaultValues.json\""
            };

            // Create multipart/mixed content
            var multipartContent = new MultipartContent(subtype: "mixed");
            multipartContent.Add(content: csvContent);
            multipartContent.Add(content: jsonContent);

            // Send request
            using HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(method: HttpMethod.Post, requestUri: "https://na.airvantage.net/api/v1/operations/systems/register")
            {
                Content = multipartContent
            };

            HttpResponseMessage response = await client.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(value: $"Response: {response.StatusCode}\n{result}");

        }
    }


   public static class AVC_Registration
    {
        public static string Token { get; set; } = string.Empty;
        public static string RefreshToken { get; set; } = string.Empty;
    }

    public class AV_RegistrationAdditionalInfo
    {
        public string[] defaultApplications { get; set; } = { "4f19aef9c1b24203bb5c298a921da04e"};
        public string offerId { get; set; } = "offerId";
    }
}
