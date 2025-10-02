
// Documentation added with help by TabbyML/Mistral-7B
// 1. Read data
// This section reads data from two separate CSV files, lager.csv and ordrar.csv.
// The data from these files is used to populate the InventoryManager instance's
// Product and Order objects.

// 2. Process the orders
// This section processes the orders by updating the Product objects with the
// corresponding quantity changes.

// 3. Save resulting supply
// This section saves the updated Product objects to a new CSV file,
// lager_uppdaterat.csv.
namespace OOPAssignment;

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        InventoryManager manager = new InventoryManager();

        try
        {
            Console.WriteLine("=== LAGERHANTERINGSSYSTEM ===");
            Console.WriteLine();

            // 1. Read data
            manager.LoadProductsFromCsv("lager.csv");
           
            manager.LoadOrdersFromCsv("ordrar.csv");

            // 2. Process the orders   
            manager.ProcessOrders();

            // 3. Save resulting supply
            manager.SaveUpdatedProductsToCsv("lager_uppdaterat.csv");

            Console.WriteLine("Lagerhantering slutförd!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fel uppstod: {ex.Message}");
        }
    }
}
