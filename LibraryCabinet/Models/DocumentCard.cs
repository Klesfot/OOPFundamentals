namespace LibraryCabinet.Models;

public class DocumentCard<T> : IDocumentCard<T>
{
    public int DocumentNumber { get; set; }
    public T Document { get; set; }
}