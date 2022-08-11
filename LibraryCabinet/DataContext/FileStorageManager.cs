using LibraryCabinet.Models;
using Newtonsoft.Json;

namespace LibraryCabinet.DataContext;

public class FileStorageManager : IStorageManager
{
    private List<IDocumentCard<Patent>> PatentDocuments { get; set; }
    private List<IDocumentCard<Book>> BookDocuments { get; set; }
    private List<IDocumentCard<LocalizedBook>> LocalizedBookDocuments { get; set; }
    private List<IDocumentCard<Magazine>> MagazineDocuments { get; set; }

    public FileStorageManager()
    {
        GetDocumentCards();
    }

    public List<IDocumentCard<Patent>> FindPatentDocumentCardsByNumber(int cardId)
    {
        var foundPatents = PatentDocuments.Where(d => d.DocumentNumber == cardId);
        return foundPatents.ToList();
    }

    public List<IDocumentCard<Book>> FindBookDocumentCardsByNumber(int cardId)
    {
        var foundBooks = BookDocuments.Where(d => d.DocumentNumber == cardId);
        return foundBooks.ToList();
    }

    public List<IDocumentCard<LocalizedBook>> FindLocalizedBookDocumentCardsByNumber(int cardId)
    {
        var foundLocalizedBooks = LocalizedBookDocuments.Where(d => d.DocumentNumber == cardId);
        return foundLocalizedBooks.ToList();
    }
    public List<IDocumentCard<Magazine>> FindMagazineDocumentCardsByNumber(int cardId)
    {
        var foundMagazines = MagazineDocuments.Where(d => d.DocumentNumber == cardId);
        return foundMagazines.ToList();
    }

    private void GetDocumentCards()
    {
        PatentDocuments = new List<IDocumentCard<Patent>>();
        BookDocuments = new List<IDocumentCard<Book>>();
        LocalizedBookDocuments = new List<IDocumentCard<LocalizedBook>>();
        MagazineDocuments = new List<IDocumentCard<Magazine>>();
        var libraryDirectory = new DirectoryInfo(@"C:\DocumentLibrary");
        var files = libraryDirectory.GetFiles("*.json");

        foreach (var file in files)
        {
            var valuesToReplace = new [] { "#", ".json" };
            var formattedFileName = file.Name;
            foreach (var value in valuesToReplace)
            {
                formattedFileName = formattedFileName.Replace(value, string.Empty);
            }
            
            var documentId = Convert.ToInt32(formattedFileName.Split('_')[1]);

            if (file.Name.StartsWith("Patent"))
            {
                var deserializedPatent = JsonConvert.DeserializeObject<Patent>(File.ReadAllText(file.FullName));
                var newPatentDocCard = new DocumentCard<Patent>
                {
                    DocumentNumber = documentId,
                    Document = deserializedPatent ?? throw new InvalidOperationException()
                };
                PatentDocuments.Add(newPatentDocCard);
            }

            if (file.Name.StartsWith("Book"))
            {
                var deserializedBook = JsonConvert.DeserializeObject<Book>(File.ReadAllText(file.FullName));
                var newBookDocCard = new DocumentCard<Book>
                {
                    DocumentNumber = documentId,
                    Document = deserializedBook ?? throw new InvalidOperationException()
                };
                BookDocuments.Add(newBookDocCard);
            }

            if (file.Name.StartsWith("LocalizedBook"))
            {
                var deserializedLocalizedBook = JsonConvert.DeserializeObject<LocalizedBook>(File.ReadAllText(file.FullName));
                var newLocalizedBookDocCard = new DocumentCard<LocalizedBook>
                {
                    DocumentNumber = documentId,
                    Document = deserializedLocalizedBook ?? throw new InvalidOperationException()
                };
                LocalizedBookDocuments.Add(newLocalizedBookDocCard);
            }

            if (file.Name.StartsWith("Magazine"))
            {
                var deserializedMagazine= JsonConvert.DeserializeObject<Magazine>(File.ReadAllText(file.FullName));
                var newMagazineDocCard = new DocumentCard<Magazine>
                {
                    DocumentNumber = documentId,
                    Document = deserializedMagazine ?? throw new InvalidOperationException()
                };
                MagazineDocuments.Add(newMagazineDocCard);
            }
        }
    }
}