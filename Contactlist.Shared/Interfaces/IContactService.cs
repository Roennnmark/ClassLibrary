namespace Contactlist.Shared.Interfaces;

public interface IContactService
{
    bool AddContactToList(IContact contact);
    IEnumerable<IContact> GetAllContactsFromList();
    IContact GetContactFromList(string email);
    IContact DeleteContactFromList(string email);
}

