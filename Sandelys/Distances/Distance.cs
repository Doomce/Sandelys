using Microsoft.VisualBasic.CompilerServices;

namespace Sandelys.Distances;

public  class Distance
{
    
    public static int ConvertMetersToCm(int value)
    {
        return value*100;
    }
    
    public static int ConvertCmToMeters(int value)
    {
        return value/100;
    }
}