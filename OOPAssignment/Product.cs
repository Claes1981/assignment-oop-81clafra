
// Represents a commodity in the supply
public class Product
{
    public string? Name { get; set; } = "";
    public string? Category { get; set; } = "";
    public decimal Price { get; set; } = 0;    // decimal for handling decimal prices
    public int Quantity { get; set; } = 0;

    // Use of constructor suggested by Perlexity.ai, https://www.perplexity.ai/search/do-you-have-any-suggestions-to-SCmsZrGFTCuwqRvC1EWtugc
    public Product()
    {
        Name = "";
        Category = "";
        Price = 0;
        Quantity = 0;
    }

    private bool CanFulfillOrder(int requestedQuantity)
    {
        throw new NotImplementedException(); //TODO
    }

    private void ReduceQuantity(int amount)
    {
        throw new NotImplementedException(); //TODO
    }
}
