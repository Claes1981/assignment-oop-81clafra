// See https://aka.ms/new-console-template for more information

// Huvudklassen som hanterar all logik

using System.Globalization;

public class InventoryManager
{
    private List<Product> products;
    private List<Order> orders;

    internal void LoadProductsFromCsv(string fileName)
    {
        string[] productsArray = File.ReadAllLines(fileName);
        products = new List<Product>();
        foreach (string productDataElementsString in productsArray.Skip(1)) //Cred: https://stackoverflow.com/a/6429755
        {
            string[] productDataElementsArray = productDataElementsString.Split(',');

            // Generated with assistance from TabbyML/DeepSeekCoder-6.7B
            Product product = new Product
            {
                Name = productDataElementsArray[0],
                Category = productDataElementsArray[1],
                Price = decimal.Parse(productDataElementsArray[2], CultureInfo.InvariantCulture), //Cred: https://stackoverflow.com/a/15897318
                Quantity = int.Parse(productDataElementsArray[3])
            };
            products.Add(product);
        }
    }

    internal void LoadOrdersFromCsv(string fileName)
    {
        string[] ordersArray = File.ReadAllLines(fileName);
        orders = new List<Order>();
        foreach (string orderDataElementsString in ordersArray.Skip(1)) //Cred: https://stackoverflow.com/a/6429755
        {
            string[] orderDataElementsArray = orderDataElementsString.Split(',');

            // Generated with assistance from TabbyML/DeepSeekCoder-6.7B
            Order order = new Order
            {
                CustomerId = orderDataElementsArray[0],
                CustomerName = orderDataElementsArray[1],
                ProductName = orderDataElementsArray[2],
                QuantityOrdered = int.Parse(orderDataElementsArray[3])
            };
            orders.Add(order);
        }
    }

    internal void ProcessOrders()
    {
        // Generated with assistance from Github Copilot, TabbyML/DeepSeekCoder-6.7B,
        // and https://www.perplexity.ai/search/i-have-these-nested-c-loops-fo-cz0L.YKdS2m2Wc62qhpYEg
        foreach (Order order in orders)
        {
            Product? foundProduct = products.Find(product => product.Name == order.ProductName);

            if (foundProduct != null)
            {
                if (foundProduct.Quantity >= order.QuantityOrdered)
                {
                    foundProduct.Quantity -= order.QuantityOrdered;
                    Console.WriteLine($"Order för {order.QuantityOrdered} av {order.ProductName} till {order.CustomerName} (ID: {order.CustomerId}) har behandlats.");
                }
                else
                {
                    Console.WriteLine($"Otillräckligt lager för {order.ProductName} för kund {order.CustomerName} (ID: {order.CustomerId}).");
                }
            }
            else
                Console.WriteLine($"Produkten {order.ProductName} finns inte i lagret för kund {order.CustomerName} (ID: {order.CustomerId}).");
        }
    }

    internal void SaveUpdatedProductsToCsv(string fileName)
    {
        foreach (Product product in products)
        {
            productsArray.
        }
        File.WriteAllLines(fileName,productsArray);
    }



}
