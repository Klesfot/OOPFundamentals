using LibraryCabinet.DataContext;

namespace LibraryCabinet.Views;

public interface ILibraryUi
{
    void Initialize(IStorageManager storageManager);
}