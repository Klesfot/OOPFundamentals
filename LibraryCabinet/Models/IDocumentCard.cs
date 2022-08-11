namespace LibraryCabinet.Models;

public interface IDocumentCard<T>
{
    // stored in the file system
    // contains document id
    // contains document info (depends on document type)
    // needs to be queryable 
    int DocumentNumber { get; set; }
    T Document { get; set; }
}

public interface IOutputDocumentCard
{
    // same as IDocumentCard, but loosely typed for output only
    int DocumentNumber { get; set; }
    string DocumentInfo { get; set; }
}