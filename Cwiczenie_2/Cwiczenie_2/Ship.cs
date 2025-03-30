public class Ship
{
    public string Name { get; private set; }
    public int MaxSpeed { get; private set; }
    public int MaxContainerCount { get; private set; }
    public int MaxWeight { get; private set; }
    private List<Container> Containers = new List<Container>();

    public Ship(string name, int maxSpeed, int maxContainerCount, int maxWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxWeight = maxWeight;
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainerCount)
            throw new Exception("Statek osiągnął maksymalną liczbę kontenerów.");

        int totalWeight = Containers.Sum(c => c.Weight + c.CurrentLoad) + container.Weight + container.CurrentLoad;
        if (totalWeight > MaxWeight)
            throw new Exception("Statek przekroczył maksymalną ładowność.");

        Containers.Add(container);
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }

    public void UnloadContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Containers.Remove(container);
        }
    }

    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        var existing = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (existing != null)
        {
            Containers.Remove(existing);
            LoadContainer(newContainer);
        }
    }

    public void TransferContainerTo(Ship targetShip, string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            targetShip.LoadContainer(container);
            Containers.Remove(container);
        }
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"\nStatek: {Name} | Maks. kontenerów: {MaxContainerCount}, Maks. waga: {MaxWeight}, Prędkość: {MaxSpeed} węzłów");
        Console.WriteLine("Lista kontenerów:");
        foreach (var c in Containers)
        {
            c.PrintInfo();
        }
    }
}