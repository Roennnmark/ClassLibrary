using Contactlist.Shared.Interfaces;
using System.Diagnostics;

namespace Contactlist.Shared.Services;

internal class FileService : IFileService
{
    public string GetContentFromFile(string filepath)
    {
        try
        {
            if (File.Exists(filepath))
            {
                return File.ReadAllText(filepath);
            }
        }
        catch (Exception ex){ Debug.WriteLine("FileService - ReadContentFromFile:: " + ex.Message); }
        return null!;
    }

    public bool SaveContentToFile(string filepath, string content)
    {
        try
        {
            using var sw = new StreamWriter(filepath);
            sw.WriteLine(content);
        }
        catch (Exception ex) { Debug.WriteLine("FileService - SaveContentToFile:: " + ex.Message); }
        return false;
    }
}
