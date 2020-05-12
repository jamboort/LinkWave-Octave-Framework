using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

/// <summary>
/// Framework class
/// </summary>
namespace lc_octvmarsh
{

     public partial class OC_Device
    {
        [JsonProperty("head")]
        public Head Head { get; set; }

        [JsonProperty("body")]
        public Body[] Body { get; set; }
    }

    public class Body
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("avSystemId")]
        public string AvSystemId { get; set; }

        [JsonProperty("broadcastDate")]
        public long BroadcastDate { get; set; }

        [JsonProperty("companyId")]
        public string CompanyId { get; set; }

        [JsonProperty("creationDate")]
        public long CreationDate { get; set; }

        [JsonProperty("creatorId")]
        public string CreatorId { get; set; }

        [JsonProperty("dirty")]
        public bool Dirty { get; set; }

        [JsonProperty("hardware")]
        public Hardware Hardware { get; set; }

        [JsonProperty("lastEditDate")]
        public long? LastEditDate { get; set; }

        [JsonProperty("lastEditorId")]
        public string LastEditorId { get; set; }

        [JsonProperty("lastSeen")]
        public long LastSeen { get; set; }

        [JsonProperty("localActions")]
        public LocalActions LocalActions { get; set; }

        [JsonProperty("localVersions")]
        public LocalVersions LocalVersions { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("observations")]
        public Observations Observations { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("provisioningStatus")]
        public string ProvisioningStatus { get; set; }

        [JsonProperty("recentOperations")]
        public object[] RecentOperations { get; set; }

        [JsonProperty("report")]
        public Report Report { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        [JsonProperty("synced")]
        public bool Synced { get; set; }

        [JsonProperty("tags")]
        public LocalActions Tags { get; set; }

        [JsonProperty("timeSinceLastSeen")]
        public long TimeSinceLastSeen { get; set; }

        [JsonProperty("streamId")]
        public string StreamId { get; set; }

        [JsonProperty("metadata")]
        public object Metadata { get; set; }

        [JsonProperty("generatedDate", NullValueHandling = NullValueHandling.Ignore)]
        public long GeneratedDate { get; set; }

        [JsonProperty("location")]
        public object Location { get; set; }

        [JsonProperty("hash")]
        public object Hash { get; set; }

        [JsonProperty("elems")]
        public Elems Elems { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }
    }
    
    public class Elems
    {
        [JsonProperty("remote")]
        public Remote Remote { get; set; }

        [JsonProperty("measure")]
        public long Measure { get; set; }
    }

        public class Remote
    {
        [JsonProperty("sensors")]
        public Sensors Sensors { get; set; }
    }

    public class Sensors
    {
        [JsonProperty("set1")]
        public Set1 Set1 { get; set; }
    }

    public class Hardware
    {
        [JsonProperty("fsn")]
        public string Fsn { get; set; }

        [JsonProperty("iccid")]
        public string Iccid { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("module")]
        public string Module { get; set; }

        [JsonProperty("imei")]
        public string Imei { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }
    }

    public class LocalActions
    {
    }

    public class LocalVersions
    {
        [JsonProperty("edge")]
        public string Edge { get; set; }

        [JsonProperty("legato")]
        public string Legato { get; set; }

        [JsonProperty("changeDate")]
        public long ChangeDate { get; set; }

        [JsonProperty("firmware")]
        public string Firmware { get; set; }
    }

    public class Observations
    {
        [JsonProperty("/remote/sensors/set1/value")]
        public RemoteSensorsSet1Value RemoteSensorsSet1Value { get; set; }
    }

    public class RemoteSensorsSet1Value
    {
        [JsonProperty("set_1")]
        public Set1 Set1 { get; set; }
    }

    public class Set1
    {
        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("waterLevelLow")]
        public bool WaterLevelLow { get; set; }

        [JsonProperty("DissolvedOxygen")]
        public long DissolvedOxygen { get; set; }

        [JsonProperty("temperature2", NullValueHandling = NullValueHandling.Ignore)]
        public double? Set1Temperature2 { get; set; }

        [JsonProperty("Turbidity")]
        public long Turbidity { get; set; }

        [JsonProperty("flowIn")]
        public double FlowIn { get; set; }

        [JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
        public double? Temperature { get; set; }

        [JsonProperty("flowOut")]
        public double FlowOut { get; set; }

        [JsonProperty("Debris")]
        public bool Debris { get; set; }

        [JsonProperty("waterLevelHigh")]
        public bool WaterLevelHigh { get; set; }

        [JsonProperty("temperature 1", NullValueHandling = NullValueHandling.Ignore)]
        public double? Temperature1 { get; set; }

        [JsonProperty("temperature 2", NullValueHandling = NullValueHandling.Ignore)]
        public double? Temperature2 { get; set; }
    }

    public class Report
    {
        [JsonProperty("developerMode")]
        public DeveloperMode DeveloperMode { get; set; }

        [JsonProperty("signal")]
        public Signal Signal { get; set; }
    }

    public class DeveloperMode
    {
        [JsonProperty("enable")]
        public Enable Enable { get; set; }
    }

    public class Enable
    {
        [JsonProperty("value")]
        public bool Value { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }

    public class Signal
    {
        [JsonProperty("strength")]
        public Strength Strength { get; set; }
    }

    public class Strength
    {
        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }

    public class State
    {
        [JsonProperty("/io/config")]
        public IoConfig IoConfig { get; set; }
    }

    public class IoConfig
    {
        [JsonProperty("devs")]
        public Dev[] Devs { get; set; }
    }

    public class Dev
    {
        [JsonProperty("conf")]
        public Conf[] Conf { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Conf
    {
        [JsonProperty("baud")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Baud { get; set; }

        [JsonProperty("routing")]
        public string Routing { get; set; }

        [JsonProperty("std")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Std { get; set; }

        [JsonProperty("wire")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Wire { get; set; }

        [JsonProperty("stop")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Stop { get; set; }

        [JsonProperty("own")]
        public string Own { get; set; }

        [JsonProperty("bits")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Bits { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("flow")]
        public string Flow { get; set; }

        [JsonProperty("pair")]
        public string Pair { get; set; }
    }

    public class Summary
    {
        [JsonProperty("/diagnostic/logs/period")]
        public TartuGecko DiagnosticLogsPeriod { get; set; }

        [JsonProperty("/util/ulpm/value")]
        public TartuGecko UtilUlpmValue { get; set; }

        [JsonProperty("/cloudInterface/store_forward/persistence/trigger")]
        public TartuGecko CloudInterfaceStoreForwardPersistenceTrigger { get; set; }

        [JsonProperty("/util/cellular/statistics/trigger")]
        public TartuGecko UtilCellularStatisticsTrigger { get; set; }

        [JsonProperty("/util/sim/info/value")]
        public TartuGecko UtilSimInfoValue { get; set; }

        [JsonProperty("/util/ulpm/config")]
        public TartuGecko UtilUlpmConfig { get; set; }

        [JsonProperty("/util/sim/info/trigger")]
        public TartuGecko UtilSimInfoTrigger { get; set; }

        [JsonProperty("/modbus/config")]
        public TartuGecko ModbusConfig { get; set; }

        [JsonProperty("/cloudInterface/connected/value")]
        public TartuGecko CloudInterfaceConnectedValue { get; set; }

        [JsonProperty("/util/counter/enable")]
        public TartuGecko UtilCounterEnable { get; set; }

        [JsonProperty("/cloudInterface/store_forward/persistence/enable")]
        public TartuGecko CloudInterfaceStoreForwardPersistenceEnable { get; set; }

        [JsonProperty("/diagnostic/config")]
        public TartuGecko DiagnosticConfig { get; set; }

        [JsonProperty("/io/config/gpio")]
        public TartuGecko IoConfigGpio { get; set; }

        [JsonProperty("/remote/sensors/uplinkMeasured/period")]
        public TartuGecko RemoteSensorsUplinkMeasuredPeriod { get; set; }

        [JsonProperty("/cloudInterface/store_forward/period")]
        public CloudInterfaceDeveloperModeInactivityPeriod CloudInterfaceStoreForwardPeriod { get; set; }

        [JsonProperty("/diagnostic/logs/filter")]
        public TartuGecko DiagnosticLogsFilter { get; set; }

        [JsonProperty("/util/time/enable")]
        public TartuGecko UtilTimeEnable { get; set; }

        [JsonProperty("/location/coordinates/enable")]
        public TartuGecko LocationCoordinatesEnable { get; set; }

        [JsonProperty("/remote/sensors/uplinkMeasured/value")]
        public RemoteSensorsControlsettingsUpValueClass RemoteSensorsUplinkMeasuredValue { get; set; }

        [JsonProperty("/diagnostic/logs/value")]
        public TartuGecko DiagnosticLogsValue { get; set; }

        [JsonProperty("/remote/sensors/set1/enable")]
        public TartuGecko RemoteSensorsSet1Enable { get; set; }

        [JsonProperty("/remote/sensors/controlsettingsUp/value")]
        public RemoteSensorsControlsettingsUpValueClass RemoteSensorsControlsettingsUpValue { get; set; }

        [JsonProperty("/util/cellular/cells/enable")]
        public TartuGecko UtilCellularCellsEnable { get; set; }

        [JsonProperty("/remote/sensors/controlsettingsUp/enable")]
        public TartuGecko RemoteSensorsControlsettingsUpEnable { get; set; }

        [JsonProperty("/location/coordinates/trigger")]
        public TartuGecko LocationCoordinatesTrigger { get; set; }

        [JsonProperty("/util/delay/set")]
        public TartuGecko UtilDelaySet { get; set; }

        [JsonProperty("/diagnostic/logs/enable")]
        public TartuGecko DiagnosticLogsEnable { get; set; }

        [JsonProperty("/remote/sensors/controlsettingsUp/period")]
        public TartuGecko RemoteSensorsControlsettingsUpPeriod { get; set; }

        [JsonProperty("/cloudInterface/developer_mode/enable")]
        public TartuGecko CloudInterfaceDeveloperModeEnable { get; set; }

        [JsonProperty("/util/cellular/cells/period")]
        public TartuGecko UtilCellularCellsPeriod { get; set; }

        [JsonProperty("/remote/sensors/uplinkMeasured/enable")]
        public TartuGecko RemoteSensorsUplinkMeasuredEnable { get; set; }

        [JsonProperty("/util/reboot/trigger")]
        public TartuGecko UtilRebootTrigger { get; set; }

        [JsonProperty("/util/counter/period")]
        public TartuGecko UtilCounterPeriod { get; set; }

        [JsonProperty("/remote/sensors/set1/value")]
        public RemoteSensorsControlsettingsUpValueClass RemoteSensorsSet1Value { get; set; }

        [JsonProperty("/util/cellular/signal/trigger")]
        public TartuGecko UtilCellularSignalTrigger { get; set; }

        [JsonProperty("/cloudInterface/config_received/value")]
        public TartuGecko CloudInterfaceConfigReceivedValue { get; set; }

        [JsonProperty("/util/counter/trigger")]
        public TartuGecko UtilCounterTrigger { get; set; }

        [JsonProperty("/util/cellular/statistics/enable")]
        public TartuGecko UtilCellularStatisticsEnable { get; set; }

        [JsonProperty("/io/config")]
        public RemoteSensorsControlsettingsUpValueClass IoConfig { get; set; }

        [JsonProperty("/util/time/trigger")]
        public TartuGecko UtilTimeTrigger { get; set; }

        [JsonProperty("/util/cellular/statistics/value")]
        public TartuGecko UtilCellularStatisticsValue { get; set; }

        [JsonProperty("/virtual/config")]
        public TartuGecko VirtualConfig { get; set; }

        [JsonProperty("/cloudInterface/store_forward/heartbeat_on_empty")]
        public TartuGecko CloudInterfaceStoreForwardHeartbeatOnEmpty { get; set; }

        [JsonProperty("/util/sim/info/period")]
        public TartuGecko UtilSimInfoPeriod { get; set; }

        [JsonProperty("/util/cellular/signal/enable")]
        public TartuGecko UtilCellularSignalEnable { get; set; }

        [JsonProperty("/util/counter/value")]
        public TartuGecko UtilCounterValue { get; set; }

        [JsonProperty("/remote/sensors/set1/trigger")]
        public TartuGecko RemoteSensorsSet1Trigger { get; set; }

        [JsonProperty("/remote/sensors/set1/period")]
        public TartuGecko RemoteSensorsSet1Period { get; set; }

        [JsonProperty("/cloudInterface/store_forward/storage_empty")]
        public TartuGecko CloudInterfaceStoreForwardStorageEmpty { get; set; }

        [JsonProperty("/diagnostic/status/value")]
        public TartuGecko DiagnosticStatusValue { get; set; }

        [JsonProperty("/util/delay/value")]
        public TartuGecko UtilDelayValue { get; set; }

        [JsonProperty("/cloudInterface/status_line/enable")]
        public TartuGecko CloudInterfaceStatusLineEnable { get; set; }

        [JsonProperty("/util/cellular/signal/value")]
        public RemoteSensorsControlsettingsUpValueClass UtilCellularSignalValue { get; set; }

        [JsonProperty("/actions/console")]
        public TartuGecko ActionsConsole { get; set; }

        [JsonProperty("/util/cellular/signal/period")]
        public CloudInterfaceDeveloperModeInactivityPeriod UtilCellularSignalPeriod { get; set; }

        [JsonProperty("/util/cellular/statistics/period")]
        public TartuGecko UtilCellularStatisticsPeriod { get; set; }

        [JsonProperty("/cloudInterface/store_forward/flush")]
        public TartuGecko CloudInterfaceStoreForwardFlush { get; set; }

        [JsonProperty("/util/time/period")]
        public TartuGecko UtilTimePeriod { get; set; }

        [JsonProperty("/diagnostic/logs/trigger")]
        public TartuGecko DiagnosticLogsTrigger { get; set; }

        [JsonProperty("/location/coordinates/period")]
        public TartuGecko LocationCoordinatesPeriod { get; set; }

        [JsonProperty("/util/time/value")]
        public TartuGecko UtilTimeValue { get; set; }

        [JsonProperty("/remote/sensors/controlsettingsdownj")]
        public TartuGecko RemoteSensorsControlsettingsdownj { get; set; }

        [JsonProperty("/util/cellular/cells/trigger")]
        public TartuGecko UtilCellularCellsTrigger { get; set; }

        [JsonProperty("/cloudInterface/developer_mode/close_on_inactivity")]
        public TartuGecko CloudInterfaceDeveloperModeCloseOnInactivity { get; set; }

        [JsonProperty("/io/config/serial")]
        public TartuGecko IoConfigSerial { get; set; }

        [JsonProperty("/remote/sensors/controlsettingsUp/trigger")]
        public TartuGecko RemoteSensorsControlsettingsUpTrigger { get; set; }

        [JsonProperty("/util/time/offset")]
        public CloudInterfaceDeveloperModeInactivityPeriod UtilTimeOffset { get; set; }

        [JsonProperty("/set_1")]
        public RemoteSensorsControlsettingsUpValueClass Set1 { get; set; }

        [JsonProperty("/util/cellular/cells/value")]
        public TartuGecko UtilCellularCellsValue { get; set; }

        [JsonProperty("/cloudInterface/developer_mode/inactivity_period")]
        public CloudInterfaceDeveloperModeInactivityPeriod CloudInterfaceDeveloperModeInactivityPeriod { get; set; }

        [JsonProperty("/location/coordinates/value")]
        public TartuGecko LocationCoordinatesValue { get; set; }

        [JsonProperty("/util/ulpm/shutdown")]
        public TartuGecko UtilUlpmShutdown { get; set; }

        [JsonProperty("/util/sim/info/enable")]
        public TartuGecko UtilSimInfoEnable { get; set; }

        [JsonProperty("/cloudInterface/store_forward/persistence/period")]
        public CloudInterfaceDeveloperModeInactivityPeriod CloudInterfaceStoreForwardPersistencePeriod { get; set; }

        [JsonProperty("/remote/sensors/uplinkMeasured/trigger")]
        public TartuGecko RemoteSensorsUplinkMeasuredTrigger { get; set; }
    }

    public class TartuGecko
    {
        [JsonProperty("dt")]
        public Dt Dt { get; set; }

        [JsonProperty("t")]
        public T T { get; set; }

        [JsonProperty("m")]
        public bool M { get; set; }

        [JsonProperty("ts", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ts { get; set; }

        [JsonProperty("v", NullValueHandling = NullValueHandling.Ignore)]
        public bool? V { get; set; }

        [JsonProperty("d", NullValueHandling = NullValueHandling.Ignore)]
        public bool? D { get; set; }

        [JsonProperty("s", NullValueHandling = NullValueHandling.Ignore)]
        public string S { get; set; }
    }

    public class CloudInterfaceDeveloperModeInactivityPeriod
    {
        [JsonProperty("dt")]
        public Dt Dt { get; set; }

        [JsonProperty("t")]
        public T T { get; set; }

        [JsonProperty("d")]
        public long D { get; set; }

        [JsonProperty("v")]
        public long V { get; set; }

        [JsonProperty("m")]
        public bool M { get; set; }

        [JsonProperty("ts")]
        public long Ts { get; set; }
    }

    public class RemoteSensorsControlsettingsUpValueClass
    {
        [JsonProperty("dt")]
        public Dt Dt { get; set; }

        [JsonProperty("t")]
        public string T { get; set; }

        [JsonProperty("d", NullValueHandling = NullValueHandling.Ignore)]
        public string D { get; set; }

        [JsonProperty("v")]
        public string V { get; set; }

        [JsonProperty("m")]
        public bool M { get; set; }

        [JsonProperty("ts")]
        public long Ts { get; set; }

        [JsonProperty("s", NullValueHandling = NullValueHandling.Ignore)]
        public string S { get; set; }
    }

    public class Head
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [JsonProperty("messages")]
        public object[] Messages { get; set; }

        [JsonProperty("errors")]
        public object[] Errors { get; set; }

        //[JsonProperty("localaction")]
        //public LocalActions References { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }
    }

    public enum Dt { Boolean, Json, Numeric, String, Trigger };

    public enum T { Input, Output };

    public class OctaveObject
    {
        public static OctaveObject FromJson(string json) => JsonConvert.DeserializeObject<OctaveObject>(json, Converter.Settings);
    }

    public partial class OctaveStreamEvent
    {
        [JsonProperty("head")]
        public Head Head { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }

        public static OctaveStreamEvent FromJson(string json) => JsonConvert.DeserializeObject<OctaveStreamEvent>(json, Converter.Settings);
    }

    public class EventStream
    {
        [JsonProperty("head")]
        public Head Head { get; set; }

        [JsonProperty("body")]
        public Body[] Body { get; set; }

        public static EventStream FromJson(string json) => JsonConvert.DeserializeObject<EventStream>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this OctaveObject self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this EventStream self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this OctaveStreamEvent self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                DtConverter.Singleton,
                TConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class DtConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Dt) || t == typeof(Dt?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "boolean":
                    return Dt.Boolean;
                case "json":
                    return Dt.Json;
                case "numeric":
                    return Dt.Numeric;
                case "string":
                    return Dt.String;
                case "trigger":
                    return Dt.Trigger;
            }
            throw new Exception("Cannot unmarshal type Dt");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Dt)untypedValue;
            switch (value)
            {
                case Dt.Boolean:
                    serializer.Serialize(writer, "boolean");
                    return;
                case Dt.Json:
                    serializer.Serialize(writer, "json");
                    return;
                case Dt.Numeric:
                    serializer.Serialize(writer, "numeric");
                    return;
                case Dt.String:
                    serializer.Serialize(writer, "string");
                    return;
                case Dt.Trigger:
                    serializer.Serialize(writer, "trigger");
                    return;
            }
            throw new Exception("Cannot marshal type Dt");
        }

        public static readonly DtConverter Singleton = new DtConverter();
    }

    internal class TConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(T) || t == typeof(T?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "input":
                    return T.Input;
                case "output":
                    return T.Output;
            }
            throw new Exception("Cannot unmarshal type T");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (T)untypedValue;
            switch (value)
            {
                case T.Input:
                    serializer.Serialize(writer, "input");
                    return;
                case T.Output:
                    serializer.Serialize(writer, "output");
                    return;
            }
            throw new Exception("Cannot marshal type T");
        }

        public static readonly TConverter Singleton = new TConverter();
    }

}


public class OC_ProvisionResult
{
    public OC_ProvisionResult()
    {

    }

    [JsonProperty("head")]
    public Head Head { get; set; }

    [JsonProperty("body")]
    public Body Body { get; set; }
}

public class Body
{

    public string Id { get; set; }
    public string Action { get; set; }
    public string CompanyId { get; set; }
    public bool Complete { get; set; }
    public long CreationDate { get; set; }
    public string CreatorId { get; set; }
    public Details Details { get; set; }
    public List<string> DeviceIds { get; set; }
    public string State { get; set; }
    public Status Status { get; set; }
    public long Timeout { get; set; }

}

    public class Details
    {
        public DeviceDetails DeviceDetails { get; set; }
    }

    public class DeviceDetails
    {
        [JsonProperty ("fsn")]
        public string Fsn { get; set; }

        [JsonProperty("imei")]
        public string Imei { get; set; }
    }

    public  class Status
    {
    }

public class Head
{
    
    public Head()
    {
    }
    
    [JsonProperty("status")]
    public long Status { get; set; }

    [JsonProperty("ok")]
    public bool Ok { get; set; }

    [JsonProperty("messages")]
    public List<object> Messages { get; set; }
    
    [JsonProperty("errors")]
    public List<object> Errors { get; set; }

    [JsonProperty("references")]
    public Status References { get; set; }
    }







/// <summary>
/// Framework class
/// </summary>
//namespace lc_octvmarsh
//{
/// <summary>
/// The Octave Device class that contains methods and properties for the device
/// </summary>
//public partial class OC_Device
//{

//    /// <summary>
//    /// Device Class with parameters ID and Name in constructor
//    /// We aslo set any default properties
//    /// </summary>
//    /// <param name="Id"></param>
//    /// <param name="Name"></param>
//    public OC_Device(String Id, String Name)
//    {
//        //we set the patameters to the properties
//        DeviceId = Id;
//        DeviceName = Name;
//        //Defaults
//        VisibleName = "Empty";
//    }

//    /// <summary>
//    /// Device class with no parameters
//    /// </summary>
//    public OC_Device()
//    {
//        //Defaults
//        VisibleName = "Empty";
//    }

//    /// <summary>
//    /// Octave valid DeviceID
//    /// </summary>
//    public String DeviceId { get; set; }

//    /// <summary>
//    /// Octave Internal Name
//    /// </summary>
//    public String DeviceName { get; set; }

//    /// <summary>
//    /// Octave Visible Name that may or not be provided
//    /// </summary>
//    public String VisibleName { get; set; }  

//    /// <summary>
//    /// The device Octave Creation timestamp 
//    /// </summary>
//    public DateTime CreationDate { get; set; }
//}
//}
