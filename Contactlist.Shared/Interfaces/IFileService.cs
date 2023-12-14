namespace Contactlist.Shared.Interfaces;

internal interface IFileService
{
    string GetContentFromFile(string filepath);
    bool SaveContentToFile(string filepath, string content);
    
}
