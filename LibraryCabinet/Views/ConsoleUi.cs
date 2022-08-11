using LibraryCabinet.DataContext;
using LibraryCabinet.Models;

namespace LibraryCabinet.Views;

public class ConsoleUi : ILibraryUi
{
    private IStorageManager _storageManager;

    public void Initialize(IStorageManager storageManager)
    {
        _storageManager = storageManager;
        var commandLine = string.Empty;

        Console.WriteLine("Initialized console UI for LibraryCabinet");
        Console.WriteLine("\nCommands: " +
                          "\n/search [document number] - displays all documents with a specified document number" +
                          "\n/quit - quits the application");

        while (commandLine != "/quit")
        {
            commandLine = Console.ReadLine();

            if (commandLine != null)
            {
                var command = commandLine.Split(' ');
                switch (command.FirstOrDefault())
                {
                    case "/search":
                    {
                        if (command.Length != 2)
                        {
                            Console.WriteLine("Invalid number of arguments for /search");
                        }
                        else
                        {
                            var documentId = Convert.ToInt32(command[1]);
                            var patents = _storageManager.FindPatentDocumentCardsByNumber(documentId);
                            var books = _storageManager.FindBookDocumentCardsByNumber(documentId);
                            var localizedBooks = _storageManager.FindLocalizedBookDocumentCardsByNumber(documentId);

                            DisplaySearchResults(patents, books, localizedBooks);
                        }
                    } break;
                    case "/quit":
                    {
                        break;
                    }
                }
            }
        }
    }

    private void DisplaySearchResults(List<IDocumentCard<Patent>> patents, List<IDocumentCard<Book>> books,
        List<IDocumentCard<LocalizedBook>> localizedBooks)
    {
        Console.WriteLine($"Found {patents.Count} patents:\n");
        foreach (var patent in patents)
        {
            Console.WriteLine($"Document number {patent.DocumentNumber} " +
                              $"\nTitle: {patent.Document.Title}" +
                              $"\nAuthors: ");

            foreach (var author in patent.Document.Authors)
            {
                Console.WriteLine($"[{author}] ");
            }

            Console.Write($"Date published: {patent.Document.DatePublished}" +
                                 $"\nExpiration date: {patent.Document.ExpirationDate}" +
                                 $"\nUnique id: {patent.Document.UniqueId}");
        }

        Console.WriteLine($"\n\n{books.Count} books:\n");
        foreach (var book in books)
        {
            Console.WriteLine($"Document number {book.DocumentNumber} " +
                              $"\nISBN: {book.Document.Isbn}" +
                              $"\nTitle: {book.Document.Title}" +
                              $"\nAuthors: ");


            foreach (var author in book.Document.Authors)
            {
                Console.Write($"[{author}] ");
            }

            Console.WriteLine($"\nNumber of pages: {book.Document.PagesCount}" +
                              $"\nPublisher: {book.Document.Publisher}" +
                              $"\nDate published: {book.Document.DatePublished}");
        }

        Console.WriteLine($"\n\n{books.Count} localized books:\n");
        foreach (var localizedBook in localizedBooks)
        {
            Console.WriteLine($"Document number {localizedBook.DocumentNumber} " +
                              $"\nISBN: {localizedBook.Document.OriginalBook.Isbn}" +
                              $"\nTitle: {localizedBook.Document.OriginalBook.Title}" +
                              $"\nAuthors: ");


            foreach (var author in localizedBook.Document.OriginalBook.Authors)
            {
                Console.Write($"[{author}] ");
            }

            Console.WriteLine($"\nNumber of pages: {localizedBook.Document.OriginalBook.PagesCount}" +
                              $"\nOriginal publisher: {localizedBook.Document.OriginalBook.Publisher}" +
                              $"\nCountry of localization: {localizedBook.Document.CountryOfLocalization}" +
                              $"\nLocal publisher: {localizedBook.Document.LocalPublisher}" +
                              $"\nDate published: {localizedBook.Document.OriginalBook.DatePublished}");
        }
    }
}