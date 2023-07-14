using System.Text;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace Dewantara.Firmware;

public class CustomEngine : IEngine
{
    private ScriptEngine _engine;
    private readonly MemoryStream _error = new MemoryStream();
    private readonly MemoryStream _result = new MemoryStream();
    private FirmwareDTO _firmware;
    
    public void Connect()
    {
        _engine = Python.CreateEngine();
        _engine.Runtime.IO.SetErrorOutput(_error, Encoding.Default);
        _engine.Runtime.IO.SetOutput(_result, Encoding.Default);
    }

    public void Disconnect()
    {
        //do nothing
    }

    public void SetFirmwareConfig(FirmwareDTO firmware)
    {
        _firmware = firmware;
    }

    public bool Execute(in int dwtCode, in List<dynamic> inputParam, in List<dynamic> outputParam, out List<dynamic>? result)
    {
        var returnValue = new List<dynamic>();
        var filename = _firmware.DwtCodeFileLocation+dwtCode+".py";
        
        var argv = new List<string>(){""};
        if (inputParam.Count > 1) argv.AddRange(inputParam.Select(input => input.ToString()).Cast<string>());
        try
        {
            _engine.GetSysModule().SetVariable("argv", argv);
            var scope = _engine.CreateScope();
            _engine.CreateScriptSourceFromFile(filename).Execute(scope);
            if (outputParam.Count > 0)
                returnValue.AddRange(outputParam.Select(value => scope.GetVariable(value.ToString())));
            result = returnValue;
            return true;
        }
        catch( Exception ex )
        {
            result = null;
            return false;
        }
    }
}
