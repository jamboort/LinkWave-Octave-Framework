using System;

namespace lc_octvmarsh
{

    public class Data_Broker
    {
        /// <summary>
        /// We obtain the basic settings (Only the DB settings)
        /// </summary>
        public static readonly String _DB_cnx_String = _Sett.cnxString;
        public Data_Broker()
        {

        }

        public lw_device GetDeviceById(string ID)
        {

        }

        public static string[] GetActiveDevicesIds()
        {
            string sql = "SELECT * FROM Devices WHERE IsActive = 1";
            var connection = new SqlConnection(_DB_cnx_String);

            {
                var Devices = connection.Query(sql);
                var IDs = new List<string>();
                foreach (var i in Devices)
                {
                    IDs.Add(i.DeviceId);
                }

                String[] ArrIds = IDs.ToArray();

                return ArrIds;
            }
        }

    }
}

