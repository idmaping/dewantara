using Newtonsoft.Json;

namespace Dewantara.Firmware;

public class FirmwareExecutor
{
    private readonly Dictionary<EngineName, IEngine> _engineExecutor;
    private readonly FirmwareDTO _firmwareConfig;
    private readonly EngineName _engineName;
    
    public FirmwareExecutor()
    {
        _engineExecutor = new Dictionary<EngineName, IEngine>();
        _engineExecutor[EngineName.CustomFirmware] = new CustomEngine();
        
        _firmwareConfig = JsonConvert.DeserializeObject<FirmwareDTO>(File.ReadAllText("./ConfigFiles/firmware.json"));
        if (_firmwareConfig == null)
        {
            throw new Exception("firmware.json not found");
        }
        _engineName = _firmwareConfig.EngineName;
        _engineExecutor[_engineName].SetFirmwareConfig(_firmwareConfig);
    }

    public void Connect()
    {
        _engineExecutor[_engineName].Connect();
    }
    
    public void Disconnect()
    {
        _engineExecutor[_engineName].Disconnect();
    }
    
    public void Run(in int dwtCode, in List<dynamic> inputParam, in List<dynamic> outputParam, out List<dynamic>? result)
    {
        _engineExecutor[_engineName].Execute(dwtCode,inputParam,outputParam, out result);
    }
    
    
    
    
}