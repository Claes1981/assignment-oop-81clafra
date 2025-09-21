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

            if (decimal.TryParse(productDataElementsArray[2], CultureInfo.InvariantCulture, out decimal price)
                && int.TryParse(productDataElementsArray[3], out int quantity)) //Cred: https://stackoverflow.com/a/15897318
            {
                // Generated with assistance from TabbyML/DeepSeekCoder-6.7B
                Product product = new Product
                {
                    Name = productDataElementsArray[0],
                    Category = productDataElementsArray[1],
                    Price = price,
                    Quantity = quantity,
                };
            }
            else
            {}
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
        int successfulOrders = 0;
        int unsuccessfulOrders = 0;

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
                    successfulOrders++;
                }
                else
                {
                    Console.WriteLine($"Otillräckligt lager för {order.ProductName} för kund {order.CustomerName} (ID: {order.CustomerId}).");
                    unsuccessfulOrders++;
                }
            }
            else
                Console.WriteLine($"Produkten {order.ProductName} finns inte i lagret för kund {order.CustomerName} (ID: {order.CustomerId}).");
        }
        Console.WriteLine("Orderbearbetning slutförd");
        Console.WriteLine($"- {successfulOrders} ordrar skickade");
        Console.WriteLine($"- {unsuccessfulOrders} ordrar kunde inte skickas.");
    }

    internal void SaveUpdatedProductsToCsv(string fileName)
    {
        string[] productsArray = new string[products.Count + 1]; //Add 1 extra element for headings

        productsArray[0] = "Name,Category,Price,Quantity";

        for (int productIndex = 0; productIndex < products.Count; productIndex++)
        {
            string[] productDataElementsArray = new string[4];
            productDataElementsArray[0] = products[productIndex].Category;
            productDataElementsArray[1] = products[productIndex].Name;
            productDataElementsArray[2] = products[productIndex].Price.ToString("0.00", CultureInfo.InvariantCulture);
            productDataElementsArray[3] = products[productIndex].Quantity.ToString();

            productsArray[productIndex + 1] = String.Join(",", productDataElementsArray); // Add 1 to index since first element is headings
        }
        File.WriteAllLines(fileName, productsArray);
    }



}
