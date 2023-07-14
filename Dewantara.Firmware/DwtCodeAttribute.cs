namespace Dewantara.Firmware;

[AttributeUsage( AttributeTargets.Method, AllowMultiple = false )]
public class DwtCodeAttribute : Attribute
{
    public DwtCodeAttribute( UInt16 dwtcode )
    {
        DwtCode = dwtcode;
    }

    public UInt16 DwtCode { get; }
}
