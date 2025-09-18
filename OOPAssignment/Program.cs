// See https://aka.ms/new-console-template for more information

// Huvudklassen som hanterar all logik
public class InventoryManager
{
    private List<Product> products;
    private List<Order> orders;

    // Metoder: LoadProductsFromCsv(), LoadOrdersFromCsv(),
    //          ProcessOrders(), SaveUpdatedProductsToCsv()
}

// Representerar en vara i lagret
public class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }    // decimal för pengar
    public int Quantity { get; set; }

    // Metoder: CanFulfillOrder(int requestedQuantity), ReduceQuantity(int amount)
}

// Representerar en enskild kundorder
public class Order
{
    public string CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string ProductName { get; set; }
    public int QuantityOrdered { get; set; }
}

static void Main(string[] args)
{
    InventoryManager manager = new InventoryManager();

    try
    {
        // 1. Läs in data
        manager.LoadProductsFromCsv("lager.csv");
        manager.LoadOrdersFromCsv("ordrar.csv");

        // 2. Bearbeta ordrar
        manager.ProcessOrders();

        // 3. Spara resultat
        manager.SaveUpdatedProductsToCsv("lager_uppdaterat.csv");

        Console.WriteLine("Lagerhantering slutförd!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fel uppstod: {ex.Message}");
    }
}
