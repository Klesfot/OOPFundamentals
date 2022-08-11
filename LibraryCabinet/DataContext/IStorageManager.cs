using LibraryCabinet.Models;

namespace LibraryCabinet.DataContext;

public interface IStorageManager
{
    List<IDocumentCard<Patent>> PatentDocuments { get; set; }
    List<IDocumentCard<Book>> BookDocuments { get; set; }
    List<IDocumentCard<LocalizedBook>> LocalizedBookDocuments { get; set; }

    // normally I would ask PO to clarify if search by document type is required or not, due to ambiguous task description
    // but doing it like this would make it easier to change storage manager to a DB in the future
    List<IDocumentCard<Patent>> FindPatentDocumentCardsByNumber(int cardId);
    List<IDocumentCard<Book>> FindBookDocumentCardsByNumber(int cardId);
    List<IDocumentCard<LocalizedBook>> FindLocalizedBookDocumentCardsByNumber(int cardId);
}