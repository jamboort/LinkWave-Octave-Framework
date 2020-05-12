using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lc_octvmarsh;

namespace LinkWave_Octave_Framework
{
    class Program
    {
        // We obtain the basic settings (This may be moved to the frameworl library)
        public static readonly Properties.Settings _Sett = new Properties.Settings();
        public static readonly string _OctaveToken = _Sett.OctaveToken;
        public static readonly string _OctaveUser = _Sett.OctaveUser;
        public static readonly string _OctaveCompany = _Sett.OctaveCompany;
        public static readonly String _DB_cnx_String = _Sett.cnxString;
        
        // This is were the APP starts (the test Console APP)
        static void Main(string[] args) {

                    
            //var dev = new lc_octvmarsh.OC_Device("1","PINK");
            //dev.DeviceId = "1";
            var Ms = new OC_Broker();
            LW_Device dv = new LW_Device();
            //dv = Ms.GetOvtaveDevices();
            var DB = new Data_Broker();
            var str = Ms.CreateNewOvtaveDevicesAsync("Test WP7702", "VU823585160910", "352653090128562");
            LW_Device[] Devices = DB.GetDevicesByStatus(4);
            var did = DB.GetActiveDevicesIds();
            var nDID = dv.NewDeviceIDList();
            var nTD = dv.TestingDeviceIDList();
            int affecteRows = dv.CreateNewDevice("1a", "1a", "1a");
            dv.IMEI = "352653090128562";
            dv.DeviceName = "Test WP7702";  //macdui_" //+   dv.IMEI.Substring(dv.IMEI.Length-10);
            dv.SerialNumber = "VU823585160910";
            var NewaffecteRows = dv.CreateNewDevice();
            if (NewaffecteRows > 0)
            {
                affecteRows = affecteRows + NewaffecteRows;
                Console.WriteLine(" NEW DEVICE " + dv.DeviceId + "INSERTED OK OK");
            }
            else
            {
                Console.WriteLine("NEW DEVICE NOT INSERTED");
            } 
            dv.LoadDeviceById(39);
            LW_Blueprint BP = dv.GetDevicesBlueprint();
            Console.WriteLine(" UNIT " + dv.SerialNumber);
            Console.WriteLine(" DBUNIT " + did.First());
            Console.WriteLine(" NEW UNIT " + nDID.First());
            Console.WriteLine(" TEST UNITS " + nTD.First());
            Console.WriteLine(" AFFECTED ROWS " + affecteRows);
            Console.WriteLine(" BLUEPRINT " + BP.BlueprintID);
            Console.WriteLine(" VISIBLE NAME " + dv.VisibleName);
            _ = Console.ReadLine();


        }
      
        }
    }
