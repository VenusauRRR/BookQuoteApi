namespace BookQuoteApi.Models;

public class Quote
{
    public Guid Id { get; set; }

    public string QuoteText { get; set; } = string.Empty;
    public string userId { get; set; } = string.Empty;
}
