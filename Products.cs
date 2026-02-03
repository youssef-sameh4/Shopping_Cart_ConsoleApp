
public class Products
{
    public static Dictionary<string, double> AllItems = new Dictionary<string, double>()
{
    { "TV", 1220 },
    { "Laptop", 18500 },
    { "Mobile", 9500 },
    { "Headphones", 650 },
    { "Keyboard", 450 },
    { "Mouse", 300 },
    { "Monitor", 4200 },
    { "Printer", 3800 },
    { "Scanner", 2900 },
    { "Speaker", 1200 },
    { "Camera", 7600 },
    { "SmartWatch", 2100 },
    { "Tablet", 6800 },
    { "PowerBank", 550 },
    { "Router", 900 },
    { "FlashDrive", 180 },
    { "ExternalHDD", 3200 },
    { "SSD", 2600 },
    { "RAM", 1500 },
    { "CPU", 7200 },
    { "Motherboard", 5400 },
    { "GPU", 14500 },
    { "Case", 1300 },
    { "CoolingFan", 400 },
    { "UPS", 2700 },
    { "Projector", 8900 },
    { "Microphone", 1600 },
    { "Webcam", 1100 },
    { "GameController", 1400 },
    { "VRHeadset", 9800 }
};

    public static IEnumerable<Tuple<string, double>> GetPriceItem()
    {
        var CartPrice = new List<Tuple<string, double>>();
        var CarItems = Operation.GetCartItems();
        foreach (var item in CarItems)
        {
            double price = 0;
            bool founditem = AllItems.TryGetValue(item, out price);
            if (founditem)
            {
                Tuple<string, double> itemAndPrice = new Tuple<string, double>(item, price);
                CartPrice.Add(itemAndPrice);
            }

        }
        return CartPrice;
    }
}
