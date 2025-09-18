// See https://aka.ms/new-console-template for more information


// Representerar en vara i lagret
public class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }    // decimal för pengar
    public int Quantity { get; set; }

    // Metoder: CanFulfillOrder(int requestedQuantity), ReduceQuantity(int amount)
}
