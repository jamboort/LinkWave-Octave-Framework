using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace lc_octvmarsh.Utils
{
    class CloudAPIManager
    {
        public static HttpClient CloudAPI_Client { get; set; }

        public static void InizializeCloudAPI()
        {
            CloudAPI_Client = new HttpClient();
            CloudAPI_Client.BaseAddress = new Uri(Properties.Resources.BaseURI);
            CloudAPI_Client.DefaultRequestHeaders.Accept.Clear();
            CloudAPI_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            CloudAPI_Client.DefaultRequestHeaders.Add("X-Auth-Token", Properties.Settings.Default.OctaveToken);
            CloudAPI_Client.DefaultRequestHeaders.Add("X-Auth-User", Properties.Settings.Default.OctaveUser);
        }

    }
}
