using Contactlist.Shared.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Contactlist.Shared.Services;

public class ContactService : IContactService
{
    private readonly IFileService _fileService = new FileService();
    private List<IContact> _contacts = [];
    private readonly string _filePath = @"c:\ClassLibrary\contacts.json";

    public bool AddContactToList(IContact contact)
    {
        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);

                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

                var result = _fileService.SaveContentToFile(_filePath, json);
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ContactService - AddContactToList:: " + ex.Message); }
        return false;
    }

    public IEnumerable<IContact> GetAllContactsFromList()
    {
        try
        {
            var content = _fileService.GetContentFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _contacts;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ContactService - GetContactsFromList:: " + ex.Message); }
        return null!;
    }


    public IContact GetContactFromList(string email)
    {
        try
        {
            GetAllContactsFromList();

            var contact = _contacts.FirstOrDefault(x => x.Email == email);
            return contact ??= null!;
        }
        catch (Exception ex) { Debug.WriteLine("ContactService - GetContactFromList:: " + ex.Message); }
        return null!;
    }

    public IContact DeleteContactFromList(string email)
    {
        try
        {
            GetAllContactsFromList();
            var contact = _contacts.FirstOrDefault(x => x.Email == email);

            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }
        catch (Exception ex) { Debug.WriteLine("ContactService - DeleteContactFromList:: " + ex.Message); }
        return null!;
    }

}
