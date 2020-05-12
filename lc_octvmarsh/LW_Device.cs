using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Framework class that holds the LW or DB device structure different from the OC_Device
/// </summary>
namespace lc_octvmarsh
{

    public class LW_Device
    {
        private LW_Device device;

        #region Constructors

        /// <summary>
        /// This enum is to manage the different status of the devices in the LW DB needs to be mantained when DB 
        /// </summary>
        enum Status {
            New = 3,
            Unused = 0,
            Operational = 4,
            Depreciated = 5,
            In_Field = 6,
            Maintenace = 7,
            Testing = 8,
        }

        /// <summary>
        /// Device Class with parameters ID and Name in constructor
        /// We aslo set any default properties
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        public LW_Device(string Name, string SerialNumber, string IMEI )
        {
            //we set the patameters to the properties
            this.SerialNumber = SerialNumber;
            this.IMEI = IMEI;
            this.DeviceName = Name;
            //Defaults
            VisibleName = "Empty";
            Blueprint = 1;
            IsNew = true;
            //HasUpdates = false;
        }


        /// <summary>
        /// Default class constructor for the LW_Device class with no parameters
        /// </summary>
        public LW_Device()
        {
            //Defaults
            VisibleName = "Empty";
            Blueprint = 1;
            HasUpdates = false;
            IsNew = true;
        }

        public LW_Device(LW_Device device)
        {
            this.device = device;
        }

        #endregion

        #region Properties
        /// <summary>
        /// The internal primary key in the database
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Octave valid DeviceID
        /// </summary>
        public String DeviceId { get; set; }
        //  {
        //    get { return DeviceId; }
        //    set
        //    {
        //        //HasUpdates = true;
        //        DeviceId = value; 
        //    }
        //}

        /// <summary>
        /// Octave Internal Name
        /// </summary>
        public String DeviceName { get; set; }

        /// <summary>
        /// Octave Visible Name that may or not be provided
        /// </summary>
        public String VisibleName { get; set; }

        /// <summary>
        /// The device Octave Creation timestamp 
        /// </summary>
        public DateTime CreationDate { get; set; } 

        /// <summary>
        /// The devices Serial Number
        /// </summary>
        public String SerialNumber { get; set; }

        /// <summary>
        /// Is the unit active ? True or False
        /// </summary>
        public Boolean IsActive { get; set; }

        /// <summary>
        /// The current status of the device this status is bases on the enum status
        /// </summary>
        public int CurrentStatus { get; set; }

        /// <summary>
        /// The IMEI number for the device
        /// </summary>
        public string IMEI { get; set; }

        /// <summary>
        /// The Blueprint database ID number for the device
        /// </summary>
        public int Blueprint { get; set; }
        
        /// <summary>
        /// Has Updates flag to allow or not updating
        /// </summary>
        private bool HasUpdates { get; set; }

        /// <summary>
        /// Indicates if this is a new or a known device. Set by default to true on the empty constructor. 
        /// This prevents the createNewDevice from attempting to insert a new device into the DataBase
        /// </summary>
        private bool IsNew { get; set; }

        #endregion

        #region Public Methods

        public void LoadDevices(string DeviceId)
        {

        }
        /// <summary>
        /// Creates a new device on the Device table in the DB 
        /// If the Device ID is null or an empty string the device is new and we can attempt to create a new device, otherwise it is not new and we should pass
        /// </summary>
        /// <param name="D_Name"></param>
        /// <param name="Imei"></param>
        /// <param name="SerialNumber"></param>
        /// <returns>The number of items added to the tatabase or if return value -1 indicates that the devices can not be created 
        /// or that an error in the insert happend</returns>
        public int CreateNewDevice(string D_Name, string Imei, string SerialNumber)
        {
            if (IsNew)
            {
                if (string.IsNullOrEmpty(D_Name))
                {
                    return -1;
                }
                else
                {
                    IsNew = false;
                    Data_Broker DB = new Data_Broker();
                    return DB.InsertNewDevice(D_Name, Imei, SerialNumber);
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Creates a new device on the Device table in the DB 
        /// If the Device ID is null or an empty string the device is new and we can attempt to create a new device, otherwise it is not new and we should pass
        /// </summary>
        /// <returns>The number of items added to the tatabase or if return value -1 indicates that the devices can not be created 
        /// or that an error in the insert happend</returns>
        public int CreateNewDevice()
        {
            if (IsNew)
            {
                return -1;
            }
            else
            {
                Data_Broker DB = new Data_Broker();
                return DB.InsertNewDevice(DeviceName, IMEI, SerialNumber);
            }
        }

        /// <summary>
        /// Gets a given Device by the DB ID the data is only for the device 
        /// if other data is necesary it mus be loaded seperatlly 
        /// </summary>
        /// <param name="ID">The Data Base ID</param>
        public void LoadDeviceById(int ID)
        {
            Data_Broker DB = new Data_Broker();
            var Device = DB.GetDeviceByID(ID);
            if (Device.Count() > 0)
            {
                this.DeviceName = Device.First().DeviceName;
                this.Blueprint = Device.First().Blueprint;
                this.CreationDate = Device.First().CreationDate;
                this.CurrentStatus = Device.First().Status;
                this.DeviceId = Device.First().DeviceId;
                this.IMEI = Device.First().IMEI;
                this.IsActive = Device.First().IsActive;
                this.IsNew = false;
                this.SerialNumber = Device.First().SerialNumber;
                this.VisibleName = Device.First().VisibleName;
                this.HasUpdates = false;
            }

        }

        /// <summary>
        /// Gets a given Device by the Octave ID the data is only for the device 
        /// if other data is necesary it mus be loaded seperatlly 
        /// </summary>
        /// <param name="OctaveDeviceID"></param>
        public void LoadDeviceByOctaveId(string OctaveDeviceID)
        {
            Data_Broker DB = new Data_Broker();
            var Device = DB.GetDeviceByOctaveID(OctaveDeviceID);
            if (Device.Count() > 0)
            {
                this.DeviceName = Device.First().DeviceName;
                this.Blueprint = Device.First().Blueprint;
                this.CreationDate = Device.First().CreationDate;
                this.CurrentStatus = Device.First().Status;
                this.DeviceId = Device.First().DeviceId;
                this.IMEI = Device.First().IMEI;
                this.IsActive = Device.First().IsActive;
                this.IsNew = false;
                this.SerialNumber = Device.First().SerialNumber;
                this.VisibleName = Device.First().VisibleName;
                this.HasUpdates = false;
            }
        }

        /// <summary>
        /// Adds a new device to the database (this is a striped down device that can not be used until added to Octave)
        /// New devices are only added when provisioning
        /// </summary>
        /// <param name="DeviceName">The name of the device on the Octave platform. NOTE this name can not be changed in OCTAVE once it has been set</param>
        /// <param name="Imei">The IMEI number of the device</param>
        /// <param name="SerialNumber">The Sierrawireless Serial number</param>
        /// <returns></returns>
        public int AddNewOctaveDevice(string DeviceName, string Imei, string SerialNumber)
        {
            Data_Broker DB = new Data_Broker();
            return DB.InsertNewDevice(DeviceName, Imei, SerialNumber);
        }

        /// <summary>
        /// We list the ID's of all the devices in the DataBase that are signaled as Status NEW
        /// </summary>
        /// <returns>An Array of ID's in String</returns>
        public string[] NewDeviceIDList()
        {
            var DB = new Data_Broker();
            return DB.ListDeviceByState(3);
        }

        /// <summary>
        /// We list the ID's of all the devices in the DataBase that are signaled as Status DEPRECIATED
        /// </summary>
        /// <returns>An Array of ID's in String</returns>
        public string[] DepreciatedIDDeviceList()
        {
            var DB = new Data_Broker();
            return DB.ListDeviceByState(5);
        }

        /// <summary>
        /// We list the ID's of all the devices in the DataBase that are signaled as Status OPERATIONAL
        /// </summary>
        /// <returns>An Array of ID's in String</returns>
        public string[] OperationalDeviceIDList()
        {
            var DB = new Data_Broker();
            return DB.ListDeviceByState(4);
        }

        /// <summary>
        /// We list the ID's of all the devices in the DataBase that are signaled as Status IN THE FIELD
        /// </summary>
        /// <returns>An Array of ID's in String</returns>
        public string[] InFieldDeviceIDList()
        {
            var DB = new Data_Broker();
            return DB.ListDeviceByState(6);
        }

        /// <summary>
        /// We list the ID's of all the devices in the DataBase that are signaled as Status IN MAINTENANCE
        /// </summary>
        /// <returns>An Array of ID's in String</returns>
        public string[] MaintenanceDeviceIDList()
        {
            var DB = new Data_Broker();
            return DB.ListDeviceByState(7);
        }

        /// <summary>
        /// We list the ID's of all the devices in the DataBase that are signaled as Status TESTING
        /// </summary>
        /// <returns>An Array of ID's in String</returns>
        public string[] TestingDeviceIDList()
        {
            var DB = new Data_Broker();
            return DB.ListDeviceByState(8);
        }

        /// <summary>
        /// Retreives a loaded instance of a blueprint from the Data Base for the current instance of the device or a default to 1
        /// </summary>
        /// <returns>LW_Blueprint instance</returns>
        public LW_Blueprint GetDevicesBlueprint()
        {
            LW_Blueprint blueprint = new LW_Blueprint();
            return blueprint.GetBlueprintById(Blueprint);
        }

        #endregion
    }

    /// <summary>
    /// Public class tha contains an instance of the database representation of a devices blue print.. 
    /// configuration for this blueprint is in the octave platform
    /// Properties can not be set by external code, only via the GetBlueprintById()
    /// </summary>
    public class LW_Blueprint
    {

        #region Constructors

        /// <summary>
        /// Default constructor for the LW_Blueprint class
        /// </summary>
        public LW_Blueprint()
        {

        }

        #endregion

        /// <summary>
        /// Database ID that relates to the devices blueprint field
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The string ID that represents the blueprint's ID in the Octabe platform
        /// </summary>
        public string BlueprintID
        {
            get;
            private set;
        }

        /// <summary>
        /// The name of the blueprint on both the DB and the Octave platform
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Version of the blueprint
        /// </summary>
        public int Version
        {
            get;
            private set;
        }

        /// <summary>
        /// The date created in the DB (Not in Octave)
        /// </summary>
        public DateTime CreationDate
        {
            get;
            private set;
        }

        public LW_Blueprint GetBlueprintById(int ID)
        {
            Data_Broker DB = new Data_Broker();
            var Blueprint = DB.GetBlueprintByID(ID);
            if (Blueprint.Count() > 0)
            {
                this.Name = Blueprint.First().Name;
                this.Version = Blueprint.First().Version;
                this.BlueprintID = Blueprint.First().BlueprintID;
                this.CreationDate = Blueprint.First().CreationDate;
                return this;
            }
            else
            {
                return this;
            }

        }
    }
}