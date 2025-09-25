// Main class which handles all logic

using System.Globalization;

public class InventoryManager
{
    private List<Product>? products = new();
    private List<Order>? orders = new();

    const int PRODUCT_NAME_INDEX = 0;
    const int PRODUCT_CATEGORY_INDEX = 1;
    const int PRODUCT_PRICE_INDEX = 2;
    const int PRODUCT_QUANTITY_INDEX = 3;
    const int NUMBER_OF_EXPECTED_PRODUCT_DATA_ELEMENTS = 4;

    internal void LoadProductsFromCsv(string fileName)
    {
        Console.WriteLine($"Läser in produkter från {fileName}...");

        string[] productsArray = File.ReadAllLines(fileName);
        products = new List<Product>();
        foreach (string productDataElementsString in productsArray.Skip(1)) //Cred: https://stackoverflow.com/a/6429755
        {

            string[] productDataElementsArray = productDataElementsString.Split(',');

            if (productDataElementsArray.Length < NUMBER_OF_EXPECTED_PRODUCT_DATA_ELEMENTS)
            {
                Console.WriteLine($"Uppgift saknas för produkten {productDataElementsArray[PRODUCT_NAME_INDEX]}.");
                Console.WriteLine("Vänligen kontrollera lagerfilen.");
                continue;
            }

            if (decimal.TryParse(productDataElementsArray[PRODUCT_PRICE_INDEX], CultureInfo.InvariantCulture, out decimal productPrice)
                    && int.TryParse(productDataElementsArray[PRODUCT_QUANTITY_INDEX], out int productQuantity)) //Cred: https://stackoverflow.com/a/15897318
            {
                // Generated with assistance from TabbyML/DeepSeekCoder-6.7B
                Product product = new Product
                {
                    Name = productDataElementsArray[PRODUCT_NAME_INDEX],
                    Category = productDataElementsArray[PRODUCT_CATEGORY_INDEX],
                    Price = productPrice,
                    Quantity = productQuantity,
                };
                products.Add(product);
            }
            else
                Console.WriteLine($"Fel format i datafil på prisuppgift eller antal för vara: {productDataElementsArray[PRODUCT_NAME_INDEX]}");

        }
        Console.WriteLine($"Totalt {products.Count} produkter inlästa");
        Console.WriteLine();
    }

    internal void LoadOrdersFromCsv(string fileName)
    {
        Console.WriteLine($"Läser in ordrar från {fileName}...");

        const int ORDER_CUSTOMER_ID_INDEX = 0;
        const int ORDER_CUSTOMER_NAME_INDEX = 1;
        const int ORDER_PRODUCT_NAME_INDEX = 2;
        const int ORDER_QUANTITY_INDEX = 3;
        const int NUMBER_OF_EXPECTED_ORDER_DATA_ELEMENTS = 4;

        string[] ordersArray = File.ReadAllLines(fileName);
        orders = new List<Order>();
        foreach (string orderDataElementsString in ordersArray.Skip(1)) //Cred: https://stackoverflow.com/a/6429755
        {
            string[] orderDataElementsArray = orderDataElementsString.Split(',');

            if (orderDataElementsArray.Length < NUMBER_OF_EXPECTED_ORDER_DATA_ELEMENTS)
            {
                Console.WriteLine($"Uppgift saknas för kunden {orderDataElementsArray[ORDER_CUSTOMER_NAME_INDEX]}.");
                Console.WriteLine("Vänligen kontrollera orderfilen.");
                continue;
            }

            if (int.TryParse(orderDataElementsArray[ORDER_QUANTITY_INDEX], out int orderQuantity)) //Cred: https://stackoverflow.com/a/15897318
            {

                // Generated with assistance from TabbyML/DeepSeekCoder-6.7B
                Order order = new Order
                {
                    CustomerId = orderDataElementsArray[ORDER_CUSTOMER_ID_INDEX],
                    CustomerName = orderDataElementsArray[ORDER_CUSTOMER_NAME_INDEX],
                    ProductName = orderDataElementsArray[ORDER_PRODUCT_NAME_INDEX],
                    QuantityOrdered = orderQuantity,
                };
                orders.Add(order);
            }
            else
                Console.WriteLine($"Fel format i datafil på antal för order från {orderDataElementsArray[1]}, {orderDataElementsArray[2]}.");

        }
        Console.WriteLine();
    }

    internal void ProcessOrders()
    {
        int successfulOrders = 0;
        int unsuccessfulOrders = 0;

        Console.WriteLine("Bearbetar ordrar...");

        // Generated with assistance from Github Copilot, TabbyML/DeepSeekCoder-6.7B,
        // and https://www.perplexity.ai/search/i-have-these-nested-c-loops-fo-cz0L.YKdS2m2Wc62qhpYEg
        if (orders != null && products != null)
        {
            foreach (Order order in orders)
            {
                Product? foundProduct = products.Find(product => product.Name == order.ProductName);

                if (foundProduct != null)
                {
                    if (foundProduct.Quantity >= order.QuantityOrdered)
                    {
                        foundProduct.Quantity -= order.QuantityOrdered;
                        Console.WriteLine($"Order för {order.QuantityOrdered} st av {order.ProductName} till {order.CustomerName} (ID: {order.CustomerId}) har behandlats och skickas.");
                        successfulOrders++;
                    }
                    else
                    {
                        Console.WriteLine($"Otillräckligt lager för {order.ProductName} för kund {order.CustomerName} (ID: {order.CustomerId}).");
                        unsuccessfulOrders++;
                    }
                }
                else
                {
                    Console.WriteLine($"Produkten {order.ProductName} finns inte i lagret för kund {order.CustomerName} (ID: {order.CustomerId}).");
                    unsuccessfulOrders++;
                }
            }
        }
        else
        {
            Console.WriteLine("Inga ordrar att behandla."); // Generated by TabbyML/Qwen2.5-Coder-7B
            return;
        }

        Console.WriteLine("Orderbearbetning slutförd");
        Console.WriteLine($"- {successfulOrders} ordrar skickade");
        Console.WriteLine($"- {unsuccessfulOrders} ordrar kunde inte skickas.");
        Console.WriteLine();
    }

    internal void SaveUpdatedProductsToCsv(string fileName)
    {
        if (products != null)
        {

            Console.WriteLine($"Sparar uppdaterat lager till {fileName}...");

            string[] productsArray = new string[products.Count + 1]; //Add 1 extra element for headings

            productsArray[0] = "Name,Category,Price,Quantity";

            for (int productIndex = 0; productIndex < products.Count; productIndex++)
            {
                string[] productDataElementsArray = new string[4];
                productDataElementsArray[PRODUCT_NAME_INDEX] = products[productIndex].Name ?? "";
                productDataElementsArray[PRODUCT_CATEGORY_INDEX] = products[productIndex].Category ?? "";
                productDataElementsArray[PRODUCT_PRICE_INDEX] = products[productIndex].Price.ToString("0.00", CultureInfo.InvariantCulture);
                productDataElementsArray[PRODUCT_QUANTITY_INDEX] = products[productIndex].Quantity.ToString();

                productsArray[productIndex + 1] = String.Join(",", productDataElementsArray); // Add 1 to index since first element is headings
            }
            File.WriteAllLines(fileName, productsArray);

            Console.WriteLine("Klart!");
            Console.WriteLine();
        }
    }
}



