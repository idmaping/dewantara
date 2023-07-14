using Dewantara.Firmware;
using Newtonsoft.Json;

public class Program
{
    static void Main(string[] args)
    {
        FirmwareExecutor firmwareExecutor = new FirmwareExecutor();
        
        firmwareExecutor.Connect();
        
        var inputArgs = new List<dynamic>(){1.5,3};
        var outputArgs = new List<dynamic>(){"a","b"};
        var result = new List<dynamic>();

        firmwareExecutor.Run(1,inputArgs,outputArgs,out result);
        
        firmwareExecutor.Disconnect();
    }
}