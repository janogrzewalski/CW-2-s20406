public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; private set; }

    public LiquidContainer(int weight, int height, int depth, int maxLoad, bool isHazardous)
        : base("L", weight, height, depth, maxLoad)
    {
        IsHazardous = isHazardous;
    }

    public new void LoadCargo(int weight)
    {
        int capacityLimit = IsHazardous ? MaxLoad / 2 : (int)(MaxLoad * 0.9);

        if (weight + CurrentLoad > capacityLimit)
        {
            NotifyHazard("Próba przeładowania kontenera z niebezpiecznym ładunkiem.");
            throw new Exception("OverfillException: Przekroczono dopuszczalną pojemność dla tego kontenera.");
        }

        base.LoadCargo(weight);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"NOTYFIKACJA (Kontener {SerialNumber}): {message}");
    }
}
