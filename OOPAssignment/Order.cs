
// Represents a single customer order.
public class Order
{
    public string? CustomerId { get; set; } = "";
    public string? CustomerName { get; set; } = "";
    public string? ProductName { get; set; } = "";
    public int QuantityOrdered { get; set; } = 0;

    // Use of constructor suggested by Perlexity.ai, https://www.perplexity.ai/search/do-you-have-any-suggestions-to-SCmsZrGFTCuwqRvC1EWtugc
    public Order()
    {
        CustomerId = "";
        CustomerName = "";
        ProductName = "";
        QuantityOrdered = 0;
    }
}
