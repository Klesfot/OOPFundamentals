namespace LibraryCabinet.Models;

public interface IDocumentCard<T>
{
    int DocumentNumber { get; set; }
    T Document { get; set; }
}