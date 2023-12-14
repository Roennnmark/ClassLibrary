using Contactlist.Shared.Interfaces;
using Contactlist.Shared.Models;
using Contactlist.Shared.Services;

namespace Contactlist.ConsoleApp.Tests;

public class ContactService_Tests
{
    [Fact]
    public void GetAllContactsFromList_ThenReturnListOfContacts()
    {
        // Arrange
        IContactService contactService = new ContactService();
        IContact contact = new Contact();
        // Act
        IEnumerable<IContact> result = contactService.GetAllContactsFromList();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Any());
    }
}
