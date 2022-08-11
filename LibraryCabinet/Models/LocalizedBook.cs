namespace LibraryCabinet.Models;

public class LocalizedBook
{
    public Book OriginalBook { get; set; }
    public string CountryOfLocalization { get; set; }
    public string LocalPublisher { get; set; }
}