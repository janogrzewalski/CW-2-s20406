public class GasContainer : Container, IHazardNotifier
{
    public int Pressure { get; private set; }

    public GasContainer(int weight, int height, int depth, int maxLoad, int pressure)
        : base("G", weight, height, depth, maxLoad)
    {
        Pressure = pressure;
    }

    public new void UnloadCargo()
    {
        CurrentLoad = (int)(CurrentLoad * 0.05); // Pozostawiamy 5%
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"NOTYFIKACJA (Kontener {SerialNumber}): {message}");
    }
}