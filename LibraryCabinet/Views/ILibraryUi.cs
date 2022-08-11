using LibraryCabinet.DataContext;
using LibraryCabinet.Models;

namespace LibraryCabinet.Views;

public interface ILibraryUi
{
    void Initialize(IStorageManager storageManager);
}