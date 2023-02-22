namespace Sandelys.Containers;

public class Container
{
    public int _width { get; }
    public int _length { get; }
    public int _height { get; }

    /// <summary>
    /// Šitą konstruktoriu naudojam, kai yra custom konteineris.
    /// PVZ: 1010 X 9999 X 1202;
    /// </summary>
    /// <param name="width">Plotis</param>
    /// <param name="length">Ilgis</param>
    /// <param name="height">Aukštis</param>
    public Container(int width, int length, int height)
    {
        _width = width;
        _length = length;
        _height = height;
    }


    /// <returns>Konteinerio tūris</returns>
    public long GetV()
    {
        return _length * _width * _height;
    }
}


public class Big : Container
{
    
    public Big() : base(200, 200, 200) { }
}

public class Medium : Container
{
    public Medium() : base(200, 200, 100) { }
}

public class Small : Container
{
    public Small() : base(100, 100, 100)
    { }
}
