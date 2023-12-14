namespace Contactlist.Shared.Interfaces;

public interface IContactService
{
    /// <summary>
    /// Add contact to list
    /// </summary>
    /// <param name="contact"></param>
    /// <returns>Adds contact to list if not matching with another contact</returns>
    bool AddContactToList(IContact contact);

    /// <summary>
    /// Gets all contacts from list
    /// </summary>
    /// <returns>returns list if not empty</returns>
    IEnumerable<IContact> GetAllContactsFromList();

    /// <summary>
    /// Get specified contact
    /// </summary>
    /// <param name="email">matching input email with contact email</param>
    /// <returns>returns specified contact if user input matches email from a contact</returns>
    IContact GetContactFromList(string email);

    /// <summary>
    /// Deletes a contact
    /// </summary>
    /// <param name="email">matching input email with contact email</param>
    /// <returns>Deletes contact if user input matches email from a contact</returns>
    IContact DeleteContactFromList(string email);
}

