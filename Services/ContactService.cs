using ContactHub.Data;

namespace ContactHub.Services
{
    public class ContactService: IContactService
    {
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Contact>> FindAllContactsAsync()
        {
            return await _repository.FindAllContactsAsync();
        }

        public async Task<Contact> FindContactByIdAsync(string Name)
        {
            var contact = await _repository.FindContactByIdAsync(Name);
            return contact;
        }

        public async Task<Guid> CreateContactAsync(Contact contact)
        {
            return await _repository.InsertAsync(contact);
        }

        public async Task UpdateContactAsync(string Name, Contact updatedContact)
        {
            var existingContact = await _repository.FindContactByIdAsync(Name);

            if (existingContact != null)
            {
                await _repository.UpdateAsync(updatedContact, existingContact);
            }
        }

        public async Task DeleteContactAsync(string Name)
        {
            var existingContact = await _repository.FindContactByIdAsync(Name);
            if (existingContact != null)
            {
                await _repository.DeleteAsync(existingContact);
            }
        }

        public string GetPersonalContactFullName(Contact contact)
        {
            if (contact is PersonalContact personalContact)
            {
                string fullName = $"{contact.FullName} {personalContact.Nickname}";
                return fullName;
            }
            return contact.FullName;
        }
    }
}
