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
}
