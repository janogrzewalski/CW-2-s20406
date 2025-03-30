public abstract class Container
{
    public string SerialNumber { get; private set; }
    public int Weight { get; private set; }
    public int Height { get; private set; }
    public int Depth { get; private set; }
    public int MaxLoad { get; private set; }
    public int CurrentLoad { get; set; }

    private static int serialCounter = 1;

    protected Container(string type, int weight, int height, int depth, int maxLoad)
    {
        SerialNumber = $"KON-{type}-{serialCounter++}";
        Weight = weight;
        Height = height;
        Depth = depth;
        MaxLoad = maxLoad;
        CurrentLoad = 0;
    }

    public virtual void LoadCargo(int weight)
    {
        if (weight + CurrentLoad > MaxLoad)
            throw new Exception("OverfillException: Przekroczono maksymalną ładowność kontenera.");
        CurrentLoad += weight;
    }

    public virtual void UnloadCargo()
    {
        CurrentLoad = 0;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"{SerialNumber}: Waga: {Weight}, Obciążenie: {CurrentLoad}/{MaxLoad}");
    }
}