namespace Contactlist.Shared.Interfaces;

internal interface IFileService
{
    /// <summary>
    /// Get content as a string from filepath
    /// </summary>
    /// <param name="filepath">enter the filepath (c:\ClassLibrary\contacts.json)</param>
    /// <returns>returns file content as string if file exists, else returns null</returns>
    string GetContentFromFile(string filepath);

    /// <summary>
    /// Saves content to filepath
    /// </summary>
    /// <param name="filepath">enter the filepath (c:\ClassLibrary\contacts.json)</param>
    /// <param name="content">enter your content as a string</param>
    /// <returns>returns true if saved, false if failed</returns>
    bool SaveContentToFile(string filepath, string content);
    
}
