// See https://aka.ms/new-console-template for more information

// Huvudklassen som hanterar all logik

public class InventoryManager
{
    private List<Product> products;
    private List<Order> orders;

    internal void LoadProductsFromCsv(string filePath)
    {
        // Generated with assistance from TabbyML/DeepSeekCoder-6.7B
        string fullPath = Path.Combine(Path.GetFullPath(@"../OOPAssignment"), filePath);

        string[] productsArray = File.ReadAllLines(fullPath);
        products = new List<Product>();
        foreach (string productDataElementsString in productsArray)
        {
            string[] productDataElementsArray = productDataElementsString.Split(',');

            // Generated with assistance from TabbyML/DeepSeekCoder-6.7B
            Product product = new Product
            {
                Name = productDataElementsArray[0],
                Category = productDataElementsArray[1],
                Price = decimal.Parse(productDataElementsArray[2]),
                Quantity = int.Parse(productDataElementsArray[3])
            };
            products.Add(product);
        } 
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
