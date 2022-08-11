using LibraryCabinet.Models;

namespace LibraryCabinet.DataContext;

public interface IStorageManager
{
    List<IDocumentCard<Patent>> FindPatentDocumentCardsByNumber(int cardId);
    List<IDocumentCard<Book>> FindBookDocumentCardsByNumber(int cardId);
    List<IDocumentCard<LocalizedBook>> FindLocalizedBookDocumentCardsByNumber(int cardId);
}