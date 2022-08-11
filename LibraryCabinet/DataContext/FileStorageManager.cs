using LibraryCabinet.Models;

namespace LibraryCabinet.DataContext;

public class FileStorageManager : IStorageManager
{
    public List<IDocumentCard<Patent>> PatentDocuments { get; set; }
    public List<IDocumentCard<Book>> BookDocuments { get; set; }
    public List<IDocumentCard<LocalizedBook>> LocalizedBookDocuments { get; set; }

    public FileStorageManager()
    {
        // GetDocumentCards() -- searches FS for all files and fills up ^ collections
    }

    public List<IDocumentCard<Patent>> FindPatentDocumentCardsByNumber(int cardId)
    {
        // var foundPatents = Patents.Where(d => d.DocumentNumber == cardId);
        // return foundDocumentCards

        throw new NotImplementedException();
    }

    public List<IDocumentCard<Book>> FindBookDocumentCardsByNumber(int cardId)
    {
        // var foundPatents = Patents.Where(d => d.DocumentNumber == cardId);
        // return foundDocumentCards

        throw new NotImplementedException();
    }

    public List<IDocumentCard<LocalizedBook>> FindLocalizedBookDocumentCardsByNumber(int cardId)
    {
        // var foundPatents = Patents.Where(d => d.DocumentNumber == cardId);
        // return foundDocumentCards

        throw new NotImplementedException();
    }

    private string GetDocumentCards()
    {
        // List<IDocument> patents;
        // foreach(var file in files)
        // {
        //      if (file.Name.Is("Patent")) { patents.Add(new DocumentCard<Patent>(file.FileNumber, new Patent(parse json for Patent values here))) }
        //      if (file.Name.Is("Book")) { ... }
        //      ...
        // }

        throw new NotImplementedException();
    }
}