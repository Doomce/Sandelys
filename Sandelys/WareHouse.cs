using Sandelys.Containers;
using Sandelys.Distances;

namespace Sandelys;

public class WareHouse
{
    /// <summary>
    /// SANDELIO PLOTIS
    /// </summary>
    private int _width;
    /// <summary>
    /// SANDELIO ILGIS
    /// </summary>
    private int _length;

    private List<ContainerLine> _lines = new List<ContainerLine>();

    public WareHouse(int width, int length)
    {
        _width = width;
        _length = length;
        LinesSetUp();
    }

    void LinesSetUp()
    {
        int lines = LinesCount(_width, Distance.ConvertMetersToCm(2));
        _lines.Capacity = lines;
        
        for (var i = 0; i < _lines.Capacity; i++)
        {
            _lines.Add(new ContainerLine(Distance.ConvertMetersToCm(2), _length, Distance.ConvertMetersToCm(6)));
        }
    }

    public bool AddIfFreeSpaceExists(Container cont)
    {
        return _lines.Any(line => line.TryAddToLine(cont));
    }


    public void PrintLinesInfo()
    {
        int lineIndex = 0;
        foreach (var line in _lines)
        {
            lineIndex++;
            Console.WriteLine(lineIndex+" Eileje laisvos vietos: "+line.GetFreeSpace()+"; Siuntu kiekis - "+line.GetContainerCount());
        }
        Console.WriteLine("-------------");
    }
    
    /// <summary>
    /// MATMENYS TURI BŪTI PATEIKTI CENTRIMETRAIISSS
    /// </summary>
    /// <param name="wWidth">Sandelio plotis CM</param>
    /// <param name="lWidth">Eilės plotis CM</param>
    /// <param name="offset">Eilės saugus atstumas CM</param>
    /// <returns>Linijų kiekis</returns>
    private int LinesCount(int wWidth, int lWidth, int offset = 200)
    {
        int count = 0;
        while (wWidth > 0)
        {
            if (wWidth <= lWidth + offset)
            {
                if (wWidth >= lWidth) count++;
                break;
            }
            count++;
            wWidth -= lWidth + offset;
        }
        return count;
    }
    
    
}