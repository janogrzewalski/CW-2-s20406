class Program
{
    static void Main(string[] args)
    {
        try
        {
            Ship ship1 = new Ship("Statek 1", 20, 100, 40000);
            Ship ship2 = new Ship("Statek 2", 18, 80, 30000);

            var liquidContainer = new LiquidContainer(1000, 200, 300, 5000, true);
            var gasContainer = new GasContainer(1200, 250, 400, 4000, 5);
            var fridgeContainer = new RefrigeratedContainer(900, 220, 350, 4500, "Banany", 5, 6);

            liquidContainer.LoadCargo(2000);
            gasContainer.LoadCargo(1800);
            fridgeContainer.LoadCargo(2000);

            ship1.LoadContainers(new List<Container> { liquidContainer, gasContainer });
            ship1.LoadContainer(fridgeContainer);

            ship1.PrintShipInfo();

            // Transfer między statkami
            ship1.TransferContainerTo(ship2, gasContainer.SerialNumber);
            ship2.PrintShipInfo();

            // Zastąpienie kontenera
            var newGas = new GasContainer(1100, 230, 370, 4100, 4);
            newGas.LoadCargo(1500);
            ship2.ReplaceContainer(gasContainer.SerialNumber, newGas);

            ship2.PrintShipInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }
    }
}
