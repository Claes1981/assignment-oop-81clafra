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
