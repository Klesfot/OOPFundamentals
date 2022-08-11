using LibraryCabinet.DataContext;
using LibraryCabinet.Views;

var console = new ConsoleUi();
var fileStorageManager = new FileStorageManager();
console.Initialize(fileStorageManager);