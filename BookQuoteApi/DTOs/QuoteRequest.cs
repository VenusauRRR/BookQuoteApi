namespace BookQuoteApi.DTOs;
public class QuoteRequest
{
    public string QuoteText { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}
