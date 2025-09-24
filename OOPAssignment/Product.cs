// See https://aka.ms/new-console-template for more information


// Represents a commodity in the supply
public class Product
{
    public string? Name { get; set; }
    public string? Category { get; set; }
    public decimal Price { get; set; }    // decimal for handling decimal prices
    public int Quantity { get; set; }

    private bool CanFulfillOrder(int requestedQuantity)
    {
        throw new NotImplementedException(); //TODO
    }

    private void ReduceQuantity(int amount)
    {
        throw new NotImplementedException(); //TODO
    }
}
