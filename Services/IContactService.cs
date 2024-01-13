namespace ContactHub.Services
{
    public interface IContactService
    {
        Task<List<Contact>> FindAllContactsAsync();
        string GetPersonalContactFullName(Contact contact);
        Task<Guid> CreateContactAsync(Contact contact);
        Task UpdateContactAsync(string Name, Contact updatedContact);
        Task DeleteContactAsync(string Name);
        Task<Contact> FindContactByIdAsync(string Name);
    }
}
