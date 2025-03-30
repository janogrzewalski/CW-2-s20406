public class RefrigeratedContainer : Container
{
    public string ProductType { get; private set; }
    public int RequiredTemperature { get; private set; }
    public int ContainerTemperature { get; private set; }

    public RefrigeratedContainer(int weight, int height, int depth, int maxLoad, string productType, int requiredTemperature, int containerTemperature)
        : base("C", weight, height, depth, maxLoad)
    {
        ProductType = productType;
        RequiredTemperature = requiredTemperature;
        ContainerTemperature = containerTemperature;

        if (ContainerTemperature < RequiredTemperature)
        {
            throw new Exception($"Zbyt niska temperatura w kontenerze dla produktu: {ProductType}");
        }
    }
}