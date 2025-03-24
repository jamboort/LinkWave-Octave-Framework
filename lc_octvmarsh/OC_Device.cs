using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Converters;

/// <summary>
/// Framework class
/// </summary>
namespace lc_octvmarsh
{

    public partial class OC_Device
    {
        [JsonPropertyName("head")]
        public Head Head { get; set; }

        [JsonPropertyName("body")]
        public Body[] Body { get; set; }
    }

    public class Body
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("avSystemId")]
        public string AvSystemId { get; set; }

        [JsonPropertyName("broadcastDate")]
        public long BroadcastDate { get; set; }

        [JsonPropertyName("companyId")]
        public string CompanyId { get; set; }

        [JsonPropertyName("creationDate")]
        public long CreationDate { get; set; }

        [JsonPropertyName("creatorId")]
        public string CreatorId { get; set; }

        [JsonPropertyName("dirty")]
        public bool Dirty { get; set; }

        [JsonPropertyName("hardware")]
        public Hardware Hardware { get; set; }

        [JsonPropertyName("lastEditDate")]
        public long? LastEditDate { get; set; }

        [JsonPropertyName("lastEditorId")]
        public string LastEditorId { get; set; }

        [JsonPropertyName("lastSeen")]
        public long LastSeen { get; set; }

        [JsonPropertyName("localActions")]
        public LocalActions LocalActions { get; set; }

        [JsonPropertyName("localVersions")]
        public LocalVersions LocalVersions { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("observations")]
        public Observations Observations { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("provisioningStatus")]
        public string ProvisioningStatus { get; set; }

        [JsonPropertyName("recentOperations")]
        public object[] RecentOperations { get; set; }

        [JsonPropertyName("report")]
        public Report Report { get; set; }

        [JsonPropertyName("state")]
        public State State { get; set; }

        [JsonPropertyName("summary")]
        public Summary Summary { get; set; }

        [JsonPropertyName("synced")]
        public bool Synced { get; set; }

        [JsonPropertyName("tags")]
        public LocalActions Tags { get; set; }

        [JsonPropertyName("timeSinceLastSeen")]
        public long TimeSinceLastSeen { get; set; }

        [JsonPropertyName("streamId")]
        public string StreamId { get; set; }

        [JsonPropertyName("metadata")]
        public object Metadata { get; set; }

        [JsonPropertyName("generatedDate")]
        public long GeneratedDate { get; set; }

        [JsonPropertyName("location")]
        public object Location { get; set; }

        [JsonPropertyName("hash")]
        public object Hash { get; set; }

        [JsonPropertyName("elems")]
        public Elems Elems { get; set; }

        [JsonPropertyName("version")]
        public long Version { get; set; }
    }

    public class Elems
    {
        [JsonPropertyName("remote")]
        public Remote Remote { get; set; }

        [JsonPropertyName("measure")]
        public long Measure { get; set; }
    }

    public class Remote
    {
        [JsonPropertyName("sensors")]
        public Sensors Sensors { get; set; }
    }

    public class Sensors
    {
        [JsonPropertyName("set1")]
        public Set1 Set1 { get; set; }
    }

    public class Hardware
    {
        [JsonPropertyName("fsn")]
        public string Fsn { get; set; }

        [JsonPropertyName("iccid")]
        public string Iccid { get; set; }

        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }

        [JsonPropertyName("module")]
        public string Module { get; set; }

        [JsonPropertyName("imei")]
        public string Imei { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }
    }

    public class LocalActions
    {
    }

    public class LocalVersions
    {
        [JsonPropertyName("edge")]
        public string Edge { get; set; }

        [JsonPropertyName("legato")]
        public string Legato { get; set; }

        [JsonPropertyName("changeDate")]
        public long ChangeDate { get; set; }

        [JsonPropertyName("firmware")]
        public string Firmware { get; set; }
    }

    public class Observations
    {
        [JsonPropertyName("/remote/sensors/set1/value")]
        public RemoteSensorsSet1Value RemoteSensorsSet1Value { get; set; }
    }

    public class RemoteSensorsSet1Value
    {
        [JsonPropertyName("set_1")]
        public Set1 Set1 { get; set; }
    }

    public class Set1
    {
        [JsonPropertyName("destination")]
        public string Destination { get; set; }

        [JsonPropertyName("waterLevelLow")]
        public bool WaterLevelLow { get; set; }

        [JsonPropertyName("DissolvedOxygen")]
        public long DissolvedOxygen { get; set; }

        [JsonPropertyName("temperature2")]
        public double? Set1Temperature2 { get; set; }

        [JsonPropertyName("Turbidity")]
        public long Turbidity { get; set; }

        [JsonPropertyName("flowIn")]
        public double FlowIn { get; set; }

        [JsonPropertyName("temperature")]
        public double? Temperature { get; set; }

        [JsonPropertyName("flowOut")]
        public double FlowOut { get; set; }

        [JsonPropertyName("Debris")]
        public bool Debris { get; set; }

        [JsonPropertyName("waterLevelHigh")]
        public bool WaterLevelHigh { get; set; }

        [JsonPropertyName("temperature 1")]
        public double? Temperature1 { get; set; }

        [JsonPropertyName("temperature 2")]
        public double? Temperature2 { get; set; }
    }

    public class Report
    {
        [JsonPropertyName("developerMode")]
        public DeveloperMode DeveloperMode { get; set; }

        [JsonPropertyName("signal")]
        public Signal Signal { get; set; }
    }

    public class DeveloperMode
    {
        [JsonPropertyName("enable")]
        public Enable Enable { get; set; }
    }

    public class Enable
    {
        [JsonPropertyName("value")]
        public bool Value { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }
    }

    public class Signal
    {
        [JsonPropertyName("strength")]
        public Strength Strength { get; set; }
    }

    public class Strength
    {
        [JsonPropertyName("value")]
        public long Value { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }
    }

    public class State
    {
        [JsonPropertyName("/io/config")]
        public IoConfig IoConfig { get; set; }
    }

    public class IoConfig
    {
        [JsonPropertyName("devs")]
        public Dev[] Devs { get; set; }
    }

    public class Dev
    {
        [JsonPropertyName("conf")]
        public Conf[] Conf { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class Conf
    {
        [JsonPropertyName("baud")]
        public long Baud { get; set; }

        [JsonPropertyName("routing")]
        public string Routing { get; set; }

        [JsonPropertyName("std")]
        public long Std { get; set; }

        [JsonPropertyName("wire")]
        public long Wire { get; set; }

        [JsonPropertyName("stop")]
        public long Stop { get; set; }

        [JsonPropertyName("own")]
        public string Own { get; set; }

        [JsonPropertyName("bits")]
        public long Bits { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("flow")]
        public string Flow { get; set; }

        [JsonPropertyName("pair")]
        public string Pair { get; set; }
    }

    public class Summary
    {
        [JsonPropertyName("/diagnostic/logs/period")]
        public TartuGecko DiagnosticLogsPeriod { get; set; }

        [JsonPropertyName("/util/ulpm/value")]
        public TartuGecko UtilUlpmValue { get; set; }

        [JsonPropertyName("/cloudInterface/store_forward/persistence/trigger")]
        public TartuGecko CloudInterfaceStoreForwardPersistenceTrigger { get; set; }

        [JsonPropertyName("/util/cellular/statistics/trigger")]
        public TartuGecko UtilCellularStatisticsTrigger { get; set; }

        [JsonPropertyName("/util/sim/info/value")]
        public TartuGecko UtilSimInfoValue { get; set; }

        [JsonPropertyName("/util/ulpm/config")]
        public TartuGecko UtilUlpmConfig { get; set; }

        [JsonPropertyName("/util/sim/info/trigger")]
        public TartuGecko UtilSimInfoTrigger { get; set; }

        [JsonPropertyName("/modbus/config")]
        public TartuGecko ModbusConfig { get; set; }

        [JsonPropertyName("/cloudInterface/connected/value")]
        public TartuGecko CloudInterfaceConnectedValue { get; set; }

        [JsonPropertyName("/util/counter/enable")]
        public TartuGecko UtilCounterEnable { get; set; }

        [JsonPropertyName("/cloudInterface/store_forward/persistence/enable")]
        public TartuGecko CloudInterfaceStoreForwardPersistenceEnable { get; set; }

        [JsonPropertyName("/diagnostic/config")]
        public TartuGecko DiagnosticConfig { get; set; }

        [JsonPropertyName("/io/config/gpio")]
        public TartuGecko IoConfigGpio { get; set; }

        [JsonPropertyName("/remote/sensors/uplinkMeasured/period")]
        public TartuGecko RemoteSensorsUplinkMeasuredPeriod { get; set; }

        [JsonPropertyName("/cloudInterface/store_forward/period")]
        public CloudInterfaceDeveloperModeInactivityPeriod CloudInterfaceStoreForwardPeriod { get; set; }

        [JsonPropertyName("/diagnostic/logs/filter")]
        public TartuGecko DiagnosticLogsFilter { get; set; }

        [JsonPropertyName("/util/time/enable")]
        public TartuGecko UtilTimeEnable { get; set; }

        [JsonPropertyName("/location/coordinates/enable")]
        public TartuGecko LocationCoordinatesEnable { get; set; }

        [JsonPropertyName("/remote/sensors/uplinkMeasured/value")]
        public RemoteSensorsControlsettingsUpValueClass RemoteSensorsUplinkMeasuredValue { get; set; }

        [JsonPropertyName("/diagnostic/logs/value")]
        public TartuGecko DiagnosticLogsValue { get; set; }

        [JsonPropertyName("/remote/sensors/set1/enable")]
        public TartuGecko RemoteSensorsSet1Enable { get; set; }

        [JsonPropertyName("/remote/sensors/controlsettingsUp/value")]
        public RemoteSensorsControlsettingsUpValueClass RemoteSensorsControlsettingsUpValue { get; set; }

        [JsonPropertyName("/util/cellular/cells/enable")]
        public TartuGecko UtilCellularCellsEnable { get; set; }

        [JsonPropertyName("/remote/sensors/controlsettingsUp/enable")]
        public TartuGecko RemoteSensorsControlsettingsUpEnable { get; set; }

        [JsonPropertyName("/location/coordinates/trigger")]
        public TartuGecko LocationCoordinatesTrigger { get; set; }

        [JsonPropertyName("/util/delay/set")]
        public TartuGecko UtilDelaySet { get; set; }

        [JsonPropertyName("/diagnostic/logs/enable")]
        public TartuGecko DiagnosticLogsEnable { get; set; }

        [JsonPropertyName("/remote/sensors/controlsettingsUp/period")]
        public TartuGecko RemoteSensorsControlsettingsUpPeriod { get; set; }

        [JsonPropertyName("/cloudInterface/developer_mode/enable")]
        public TartuGecko CloudInterfaceDeveloperModeEnable { get; set; }

        [JsonPropertyName("/util/cellular/cells/period")]
        public TartuGecko UtilCellularCellsPeriod { get; set; }

        [JsonPropertyName("/remote/sensors/uplinkMeasured/enable")]
        public TartuGecko RemoteSensorsUplinkMeasuredEnable { get; set; }

        [JsonPropertyName("/util/reboot/trigger")]
        public TartuGecko UtilRebootTrigger { get; set; }

        [JsonPropertyName("/util/counter/period")]
        public TartuGecko UtilCounterPeriod { get; set; }

        [JsonPropertyName("/remote/sensors/set1/value")]
        public RemoteSensorsControlsettingsUpValueClass RemoteSensorsSet1Value { get; set; }

        [JsonPropertyName("/util/cellular/signal/trigger")]
        public TartuGecko UtilCellularSignalTrigger { get; set; }

        [JsonPropertyName("/cloudInterface/config_received/value")]
        public TartuGecko CloudInterfaceConfigReceivedValue { get; set; }

        [JsonPropertyName("/util/counter/trigger")]
        public TartuGecko UtilCounterTrigger { get; set; }

        [JsonPropertyName("/util/cellular/statistics/enable")]
        public TartuGecko UtilCellularStatisticsEnable { get; set; }

        [JsonPropertyName("/io/config")]
        public RemoteSensorsControlsettingsUpValueClass IoConfig { get; set; }

        [JsonPropertyName("/util/time/trigger")]
        public TartuGecko UtilTimeTrigger { get; set; }

        [JsonPropertyName("/util/cellular/statistics/value")]
        public TartuGecko UtilCellularStatisticsValue { get; set; }

        [JsonPropertyName("/virtual/config")]
        public TartuGecko VirtualConfig { get; set; }

        [JsonPropertyName("/cloudInterface/store_forward/heartbeat_on_empty")]
        public TartuGecko CloudInterfaceStoreForwardHeartbeatOnEmpty { get; set; }

        [JsonPropertyName("/util/sim/info/period")]
        public TartuGecko UtilSimInfoPeriod { get; set; }

        [JsonPropertyName("/util/cellular/signal/enable")]
        public TartuGecko UtilCellularSignalEnable { get; set; }

        [JsonPropertyName("/util/counter/value")]
        public TartuGecko UtilCounterValue { get; set; }

        [JsonPropertyName("/remote/sensors/set1/trigger")]
        public TartuGecko RemoteSensorsSet1Trigger { get; set; }

        [JsonPropertyName("/remote/sensors/set1/period")]
        public TartuGecko RemoteSensorsSet1Period { get; set; }

        [JsonPropertyName("/cloudInterface/store_forward/storage_empty")]
        public TartuGecko CloudInterfaceStoreForwardStorageEmpty { get; set; }

        [JsonPropertyName("/diagnostic/status/value")]
        public TartuGecko DiagnosticStatusValue { get; set; }

        [JsonPropertyName("/util/delay/value")]
        public TartuGecko UtilDelayValue { get; set; }

        [JsonPropertyName("/cloudInterface/status_line/enable")]
        public TartuGecko CloudInterfaceStatusLineEnable { get; set; }

        [JsonPropertyName("/util/cellular/signal/value")]
        public RemoteSensorsControlsettingsUpValueClass UtilCellularSignalValue { get; set; }

        [JsonPropertyName("/actions/console")]
        public TartuGecko ActionsConsole { get; set; }

        [JsonPropertyName("/util/cellular/signal/period")]
        public CloudInterfaceDeveloperModeInactivityPeriod UtilCellularSignalPeriod { get; set; }

        [JsonPropertyName("/util/cellular/statistics/period")]
        public TartuGecko UtilCellularStatisticsPeriod { get; set; }

        [JsonPropertyName("/cloudInterface/store_forward/flush")]
        public TartuGecko CloudInterfaceStoreForwardFlush { get; set; }

        [JsonPropertyName("/util/time/period")]
        public TartuGecko UtilTimePeriod { get; set; }

        [JsonPropertyName("/diagnostic/logs/trigger")]
        public TartuGecko DiagnosticLogsTrigger { get; set; }

        [JsonPropertyName("/location/coordinates/period")]
        public TartuGecko LocationCoordinatesPeriod { get; set; }

        [JsonPropertyName("/util/time/value")]
        public TartuGecko UtilTimeValue { get; set; }

        [JsonPropertyName("/remote/sensors/controlsettingsdownj")]
        public TartuGecko RemoteSensorsControlsettingsdownj { get; set; }

        [JsonPropertyName("/util/cellular/cells/trigger")]
        public TartuGecko UtilCellularCellsTrigger { get; set; }

        [JsonPropertyName("/cloudInterface/developer_mode/close_on_inactivity")]
        public TartuGecko CloudInterfaceDeveloperModeCloseOnInactivity { get; set; }

        [JsonPropertyName("/io/config/serial")]
        public TartuGecko IoConfigSerial { get; set; }

        [JsonPropertyName("/remote/sensors/controlsettingsUp/trigger")]
        public TartuGecko RemoteSensorsControlsettingsUpTrigger { get; set; }

        [JsonPropertyName("/util/time/offset")]
        public CloudInterfaceDeveloperModeInactivityPeriod UtilTimeOffset { get; set; }

        [JsonPropertyName("/set_1")]
        public RemoteSensorsControlsettingsUpValueClass Set1 { get; set; }

        [JsonPropertyName("/util/cellular/cells/value")]
        public TartuGecko UtilCellularCellsValue { get; set; }

        [JsonPropertyName("/cloudInterface/developer_mode/inactivity_period")]
        public CloudInterfaceDeveloperModeInactivityPeriod CloudInterfaceDeveloperModeInactivityPeriod { get; set; }

        [JsonPropertyName("/location/coordinates/value")]
        public TartuGecko LocationCoordinatesValue { get; set; }

        [JsonPropertyName("/util/ulpm/shutdown")]
        public TartuGecko UtilUlpmShutdown { get; set; }

        [JsonPropertyName("/util/sim/info/enable")]
        public TartuGecko UtilSimInfoEnable { get; set; }

        [JsonPropertyName("/cloudInterface/store_forward/persistence/period")]
        public CloudInterfaceDeveloperModeInactivityPeriod CloudInterfaceStoreForwardPersistencePeriod { get; set; }

        [JsonPropertyName("/remote/sensors/uplinkMeasured/trigger")]
        public TartuGecko RemoteSensorsUplinkMeasuredTrigger { get; set; }
    }

    public class TartuGecko
    {
        [JsonPropertyName("dt")]
        public Dt Dt { get; set; }

        [JsonPropertyName("t")]
        public T T { get; set; }

        [JsonPropertyName("m")]
        public bool M { get; set; }

        [JsonPropertyName("ts")]
        public long? Ts { get; set; }

        [JsonPropertyName("v")]
        public bool? V { get; set; }

        [JsonPropertyName("d")]
        public bool? D { get; set; }

        [JsonPropertyName("s")]
        public string S { get; set; }
    }

    public class CloudInterfaceDeveloperModeInactivityPeriod
    {
        [JsonPropertyName("dt")]
        public Dt Dt { get; set; }

        [JsonPropertyName("t")]
        public T T { get; set; }

        [JsonPropertyName("d")]
        public long D { get; set; }

        [JsonPropertyName("v")]
        public long V { get; set; }

        [JsonPropertyName("m")]
        public bool M { get; set; }

        [JsonPropertyName("ts")]
        public long Ts { get; set; }
    }

    public class RemoteSensorsControlsettingsUpValueClass
    {
        [JsonPropertyName("dt")]
        public Dt Dt { get; set; }

        [JsonPropertyName("t")]
        public string T { get; set; }

        [JsonPropertyName("d")]
        public string D { get; set; }

        [JsonPropertyName("v")]
        public string V { get; set; }

        [JsonPropertyName("m")]
        public bool M { get; set; }

        [JsonPropertyName("ts")]
        public long Ts { get; set; }

        [JsonPropertyName("s")]
        public string S { get; set; }
    }

    public class Head
    {
        [JsonPropertyName("status")]
        public long Status { get; set; }

        [JsonPropertyName("ok")]
        public bool Ok { get; set; }

        [JsonPropertyName("messages")]
        public object[] Messages { get; set; }

        [JsonPropertyName("errors")]
        public object[] Errors { get; set; }

        //[JsonPropertyName("localaction")]
        //public LocalActions References { get; set; }

        [JsonPropertyName("version")]
        public long Version { get; set; }
    }

    public enum Dt { Boolean, Json, Numeric, String, Trigger };

    public enum T { Input, Output };

    public class OctaveObject
    {
        public static OctaveObject FromJson(string json) => JsonSerializer.Deserialize<OctaveObject>(json);
    }

    public partial class OctaveStreamEvent
    {
        [JsonPropertyName("head")]
        public Head Head { get; set; }

        [JsonPropertyName("body")]
        public Body Body { get; set; }

        public static OctaveStreamEvent FromJson(string json) => JsonSerializer.Deserialize<OctaveStreamEvent>(json);
    }

    public class EventStream
    {
        [JsonPropertyName("head")]
        public Head Head { get; set; }

        [JsonPropertyName("body")]
        public Body[] Body { get; set; }

        public static EventStream FromJson(string json) => JsonSerializer.Deserialize<EventStream>(json);
    }

    public static class Serialize
    {
        public static string ToJson(this OctaveObject self) => JsonSerializer.Serialize(self);
        public static string ToJson(this EventStream self) => JsonSerializer.Serialize(self);
        public static string ToJson(this OctaveStreamEvent self) => JsonSerializer.Serialize(self);
    }


    //TODO refactor not sure what it is used for
    //internal static class Converter
    //{
    //    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    //    {
    //        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
    //        DateParseHandling = DateParseHandling.None,
    //        Converters =
    //        {
    //            DtConverter.Singleton,
    //            TConverter.Singleton,
    //            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal}
    //        },
    //    };
    //}

    //TODO: REFACTOR

    //    internal class ParseStringConverter : JsonConverter
    //    {
    //    public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

    //    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    //    {
    //        if (reader.TokenType == JsonToken.Null) return null;
    //        var value = serializer.Deserialize<string>(reader);
    //        long l;
    //        if (Int64.TryParse(value, out l))
    //        {
    //            return l;
    //        }
    //        throw new Exception("Cannot unmarshal type long");
    //    }

    //    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    //    {
    //        if (untypedValue == null)
    //        {
    //            serializer.Serialize(writer, null);
    //            return;
    //        }
    //        var value = (long)untypedValue;
    //        serializer.Serialize(writer, value.ToString());
    //        return;
    //    }

    //    public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    //}

    //TODO: REFACTOR
    //internal class DtConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type t) => t == typeof(Dt) || t == typeof(Dt?);

    //    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    //    {
    //        if (reader.TokenType == JsonToken.Null) return null;
    //        var value = serializer.Deserialize<string>(reader);
    //        switch (value)
    //        {
    //            case "boolean":
    //                return Dt.Boolean;
    //            case "json":
    //                return Dt.Json;
    //            case "numeric":
    //                return Dt.Numeric;
    //            case "string":
    //                return Dt.String;
    //            case "trigger":
    //                return Dt.Trigger;
    //        }
    //        throw new Exception("Cannot unmarshall type Dt");
    //    }

    //    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    //    {
    //        if (untypedValue == null)
    //        {
    //            serializer.Serialize(writer, null);
    //            return;
    //        }
    //        var value = (Dt)untypedValue;
    //        switch (value)
    //        {
    //            case Dt.Boolean:
    //                serializer.Serialize(writer, "boolean");
    //                return;
    //            case Dt.Json:
    //                serializer.Serialize(writer, "json");
    //                return;
    //            case Dt.Numeric:
    //                serializer.Serialize(writer, "numeric");
    //                return;
    //            case Dt.String:
    //                serializer.Serialize(writer, "string");
    //                return;
    //            case Dt.Trigger:
    //                serializer.Serialize(writer, "trigger");
    //                return;
    //        }
    //        throw new Exception("Cannot marshal type Dt");
    //    }

    //    public static readonly DtConverter Singleton = new DtConverter();
    //}

    //TODO: REFACTOR
    //internal class TConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type t) => t == typeof(T) || t == typeof(T?);

    //    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    //    {
    //        if (reader.TokenType == JsonToken.Null) return null;
    //        var value = serializer.Deserialize<string>(reader);
    //        switch (value)
    //        {
    //            case "input":
    //                return T.Input;
    //            case "output":
    //                return T.Output;
    //        }
    //        throw new Exception("Cannot unmarshal type T");
    //    }

    //    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    //    {
    //        if (untypedValue == null)
    //        {
    //            serializer.Serialize(writer, null);
    //            return;
    //        }
    //        var value = (T)untypedValue;
    //        switch (value)
    //        {
    //            case T.Input:
    //                serializer.Serialize(writer, "input");
    //                return;
    //            case T.Output:
    //                serializer.Serialize(writer, "output");
    //                return;
    //        }
    //        throw new Exception("Cannot marshal type T");
    //    }

    //    public static readonly TConverter Singleton = new TConverter();
    //}

}


public class OC_ProvisionResult
{
    public OC_ProvisionResult()
    {

    }

    [JsonPropertyName("head")]
    public Head Head { get; set; }

    [JsonPropertyName("body")]
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
    [JsonPropertyName("fsn")]
    public string Fsn { get; set; }

    [JsonPropertyName("imei")]
    public string Imei { get; set; }
}

public class Status
{
}

public class Head
{

    public Head()
    {
    }

    [JsonPropertyName("status")]
    public long Status { get; set; }

    [JsonPropertyName("ok")]
    public bool Ok { get; set; }

    [JsonPropertyName("messages")]
    public List<object> Messages { get; set; }

    [JsonPropertyName("errors")]
    public List<object> Errors { get; set; }

    [JsonPropertyName("references")]
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
