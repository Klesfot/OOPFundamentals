namespace LibraryCabinet.Models;

public class Patent
{
    public string Title { get; set; }
    public string[] Authors { get; set; }
    public DateTime DatePublished { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string UniqueId { get; set; }
}