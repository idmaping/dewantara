namespace Dewantara.Firmware;

public interface IEngine
{
    public void Connect();
    public void Disconnect();
    public void SetFirmwareConfig(FirmwareDTO firmwareDto);
    public bool Execute(in int dwtCode, in List<dynamic> inputParam, in List<dynamic> outputParam, out List<dynamic>? result);
}