using System.ComponentModel;
using Sandelys.Distances;
using Container = Sandelys.Containers.Container;

namespace Sandelys;

public class ContainerLine
{
    private int _width;
    private int _length;
    private int _height;
    
    private long _freeSpace; //Laisvos vietos tūris;

    private List<Container> _containers = new List<Container>(); //Konteineriai

    public ContainerLine(int width, int length, int height)
    {
        _width = width;
        _length = length;
        _height = height;

        _freeSpace = width * length * height;
    }

    public long GetFreeSpace()
    {
        return _freeSpace;
    }

    public long GetMaxSpace()
    {
        return _width * _length * _height;
    }

    public int GetContainerCount()
    {
        return _containers.Count;
    }
    
    private bool CheckForFreeSpace(Container cont)
    {
        if (cont.GetV() > _freeSpace) return false;
        return true;
    }

    public bool TryAddToLine(Container cont)
    {
        if (!CheckForFreeSpace(cont)) return false;
        _containers.Add(cont);
        _freeSpace -= cont.GetV();
        return true;
    }
    
}