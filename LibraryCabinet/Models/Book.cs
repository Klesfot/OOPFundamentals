namespace LibraryCabinet.Models;

public class Book
{
    public string Isbn { get; set; }
    public string Title { get; set; }
    public string[] Authors { get; set; }
    public int PagesCount { get; set; }
    public string Publisher { get; set; }
    public DateTime DatePublished { get; set; }
}