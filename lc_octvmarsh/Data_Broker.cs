using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lc_octvmarsh
{
    /// <summary>
    /// Manages all the data functionalities for the Linkwave database
    /// </summary>
    public class Data_Broker
    {

        #region Properties

        /// <summary>
        /// We obtain the basic settings (Only the DB settings)
        /// </summary>
        private lc_octvmarsh.Properties.Settings _Sett = new Properties.Settings();

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Data_Broker()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves the list of active devices ID's from the database
        /// </summary>
        /// <returns>an array of strings containing the ID's or a List Empty if there are no devices active</returns>
        public string[] GetActiveDevicesIds()
        {
            var _DB_cnx_String = _Sett.cnxString;
            string sql = "SELECT * FROM Devices WHERE IsActive = 1";
            var connection = new SqlConnection(connectionString: _DB_cnx_String);

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



        /// <summary>
        /// Retreives the list of devices ID's from the database based on the status of the devices
        /// </summary>
        /// <param name="State">The type of devices requested by StatusID</param>
        /// <returns></returns>
        public string[] ListDeviceByState(Int32 State)
        {
            var _DB_cnx_String = _Sett.cnxString;
            string sql = "SELECT * FROM Devices WHERE Status = " + State;
            var connection = new SqlConnection(_DB_cnx_String);

            {
                var Devices = connection.Query(sql);
                var IDs = new List<string>();
                if (Devices.Count() > 0)
                {
                    foreach (var i in Devices)
                    {
                        IDs.Add(i.DeviceId);
                    }
                }
                else
                {
                    IDs.Add("List Empty");
                }
                String[] ArrIds = IDs.ToArray();

                return ArrIds;
            }
        }

        ///// <summary>
        ///// Insert a new device into the database, new devices are only added when provisioning and there is an overload with no DeviceID
        ///// IMPORTANT NOTE use InsertAsDevice in place of this one
        ///// </summary>
        ///// <param name="DeviceID">Octave Device ID  is only used in special cases</param>
        ///// <param name="Imei">The IMEI number of the device</param>
        ///// <param name="SerialNumber">The Sierrawireless Serial number</param>
        ///// <returns>The number of fields created in the Data Base</returns>
        //public int InsertNewDevice(string DeviceID, string Imei, string SerialNumber)
        //{
        //    int affectedrows = 0;
        //    string _DB_cnx_String = _Sett.cnxString;
        //    string sql = "INSERT INTO Devices (DeviceId, DeviceName, CreationDate, SerialNumber, Status, IMEI) VALUES ('" + DeviceID
        //        + "', 'New Unit', GETDATE(), '" + SerialNumber
        //        + "', 3, '" + Imei + "')";
        //    var connection = new SqlConnection(_DB_cnx_String);

        //    {
        //        affectedrows = connection.Execute(sql);
        //        return affectedrows;
        //    }
        //}

        /// <summary>
        /// Insert a new device into the database, new devices are only added when provisioning
        /// </summary>
        /// <param name="DeviceName">Name for the device to display, NOTE when added to Octave this can not be modified </param>
        /// <param name="Imei">The IMEI number of the device</param>
        /// <param name="SerialNumber">The Sierrawireless Serial number</param>
        /// <returns>Number of Rows Affected = 1 if insert worked well, -1 if insert failed </returns>
        public int InsertNewDevice(string DeviceName, string Imei, string SerialNumber)
        {
            int affectedrows = 0;
            string _DB_cnx_String = _Sett.cnxString;
            string sql = "INSERT INTO Devices (DeviceId, DeviceName, CreationDate, SerialNumber, Status, IMEI) VALUES ('', "
                + "' " + DeviceName + "', GETDATE(), '" + SerialNumber
                + "', 3, '" + Imei + "')";
            var connection = new SqlConnection(_DB_cnx_String);
            {
                try
                {
                    affectedrows = connection.Execute(sql);
                    return affectedrows;
                }
                catch
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IEnumerable<dynamic> GetBlueprintByID(int ID)
        {
            var _DB_cnx_String = _Sett.cnxString;
            string sql = "SELECT * FROM Blueprints WHERE ID = " + ID;
            var connection = new SqlConnection(_DB_cnx_String);

            {
                var DS_Blueprint = connection.Query(sql);
                if (DS_Blueprint.Count() > 0)
                {
                    return DS_Blueprint;
                }
                else
                {
                    return DS_Blueprint;
                }
            }
        }

        /// <summary>
        /// Fetches the dataset from the DB with the device table info based in the DB ID
        /// </summary>
        /// <param name="ID">Table Primary Key ID</param>
        /// <returns></returns>
        public IEnumerable<dynamic> GetDeviceByID(int ID)
        {
            var _DB_cnx_String = _Sett.cnxString;
            string sql = "SELECT * FROM Devices WHERE ID = " + ID;
            var connection = new SqlConnection(_DB_cnx_String);

            {
                var DS_Device = connection.Query(sql);
                if (DS_Device.Count() > 0)
                {
                    return DS_Device;
                }
                else
                {
                    return DS_Device;
                }
            }
        }

        /// <summary>
        /// Fetches the dataset from the DB with the device table info for a device based on the octave ID
        /// </summary>
        /// <param name="ID">Octave Devie ID</param>
        /// <returns></returns>
        public IEnumerable<dynamic> GetDeviceByOctaveID(string ID)
        {
            var _DB_cnx_String = _Sett.cnxString;
            string sql = "SELECT * FROM Devices WHERE DeviceId = '" + ID + "'";
            var connection = new SqlConnection(_DB_cnx_String);

            {
                var DS_Device = connection.Query(sql);
                if (DS_Device.Count() > 0)
                {
                    return DS_Device;
                }
                else
                {
                    return DS_Device;
                }
            }
        }
        /// <summary>
        /// Fetches the dataset from the DB with the device table info for a device based on the octave ID
        /// </summary>
        /// <param name="Status">Octave Devie ID</param>
        /// <returns></returns>
        public LW_Device[] GetDevicesByStatus(int Status)
        {
            var _DB_cnx_String = _Sett.cnxString;
            string sql = "SELECT * FROM Devices WHERE Status = " + Status;
            var connection = new SqlConnection(_DB_cnx_String);
            {
                var DS_Device = connection.Query(sql);
                if (DS_Device.Count() > 0)
                {
                    LW_Device[] DVS = new LW_Device[DS_Device.Count()];
                    {

                        int Pos = 0;
                        foreach (var Dev in DS_Device)
                        {
                            LW_Device Device = new LW_Device();
                            Device.ID = Dev.Id;
                            Device.Blueprint = Dev.Blueprint;
                            Device.CreationDate = Dev.CreationDate;
                            Device.CurrentStatus = Status;
                            Device.DeviceId = Dev.DeviceId;
                            Device.DeviceName = Dev.DeviceName;
                            Device.IMEI = Dev.IMEI;
                            Device.IsActive = Dev.IsActive;
                            Device.SerialNumber = Dev.SerialNumber;
                            DVS.SetValue(Device, Pos);

                            Pos++;
                        }
                    }
                    ;
                    LW_Devices DeviceList = new LW_Devices(DVS);

                    return DVS;
                }
                else
                {
                    throw new Exception("Devices not loaded");
                    //return DVS;
                }
            }
        }
    }
    #endregion

}