// See https://aka.ms/new-console-template for more information

// Huvudklassen som hanterar all logik

public class InventoryManager
{
    private List<Product> products;
    private List<Order> orders;

    internal void LoadProductsFromCsv(string filePath)
    {
        string[] productsArray = File.ReadAllLines(filePath);
    }

    internal void LoadOrdersFromCsv(string filePath)
    {
        throw new NotImplementedException();
    }

    internal void ProcessOrders()
    {
        throw new NotImplementedException();
    }

    internal void SaveUpdatedProductsToCsv(string filePath)
    {
        throw new NotImplementedException();
    }



}
