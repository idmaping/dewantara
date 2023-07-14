using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dewantara.Firmware;

public enum EngineName
{
    [EnumMember(Value = "CustomFirmware")] 
    CustomFirmware,
    [EnumMember(Value = "WebotsFirmware")] 
    Webots
}

public class FirmwareDTO
{
    [JsonProperty( Required = Required.Always )]
    [JsonConverter(typeof(StringEnumConverter))]
    public EngineName EngineName { get; set; }

    [JsonProperty(Required = Required.Always)]
    public string DwtCodeFileLocation { get; set; }
}