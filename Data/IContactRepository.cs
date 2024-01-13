namespace ContactHub.Data
{
    public interface IContactRepository
    {
        Task<List<Contact>> FindAllContactsAsync();
        Task<Contact> FindContactByIdAsync(string Name);
        Task<Guid> InsertAsync(Contact contact);
        Task UpdateAsync(Contact contact, Contact existingContact);
        Task DeleteAsync(Contact contact);
        
    }
}
