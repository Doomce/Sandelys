using Sandelys.Containers;
using Sandelys.Distances;

namespace Sandelys;

public class Area
{
    private List<WareHouse> _warehouses = new List<WareHouse>();
    private List<Container> atvezta = new List<Container>(); //Laikinas Variable
    public Area()
    {
        _warehouses.Add(new WareHouse(Distance.ConvertMetersToCm(50), Distance.ConvertMetersToCm(25)));
        _warehouses.Add(new WareHouse(Distance.ConvertMetersToCm(75), Distance.ConvertMetersToCm(20)));
        AtvaziavoSiuntos();
    }
    
    
    public void AtvaziavoSiuntos() //Toks TEST metodas....
    {
        
        for (int i = 0; i < 200; i++)
        {
            atvezta.Add(new L());
            atvezta.Add(new Big());
            
        }
        
        for (int i = 0; i < 1000; i++)
        {
            atvezta.Add(new Medium());
            atvezta.Add(new Small());
        }
        
        int ikrauta = 0;
        AllocateContainer(ref ikrauta);

        if (atvezta.Count > 0)
        {
            Console.WriteLine("Sandeliuose nebeuztenka vietos.");
        }
        Console.WriteLine("Liko: "+atvezta.Count+"; Ikrauta: "+ikrauta);
        
        foreach (var house in _warehouses)
        {
            house.PrintLinesInfo();
        }
    }

    /// <summary>
    /// Priskiria siuntų vietas sandėlyje
    /// </summary>
    /// <param name="contCountInWh">Įdėtų į sandėlį siuntų kiekis (Reference)</param>
    private void AllocateContainer(ref int contCountInWh)
    {
        atvezta.Sort((cont1, cont2) => cont2.GetV().CompareTo(cont1.GetV())); //Rušiavims pagal tūrį;
        foreach (var container in atvezta)
        {
            if (_warehouses.Any(warehouse => warehouse.AddIfFreeSpaceExists(container)))
            {
                contCountInWh++;
            }
        }
        atvezta.RemoveRange(0, contCountInWh);
    }
    
}