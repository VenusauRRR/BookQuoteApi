namespace BookQuoteApi.DTOs;

public class BookRequest
{

    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public DateTime PublicationDate { get; set; }
}