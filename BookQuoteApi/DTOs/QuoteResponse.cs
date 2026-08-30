namespace BookQuoteApi.DTOs;
public class QuoteResponse
{
    public Guid Id { get; set; }
    public string QuoteText { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
