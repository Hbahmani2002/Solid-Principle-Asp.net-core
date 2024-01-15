using Microsoft.EntityFrameworkCore;

namespace ContactHub.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDBContext _db;

        public ContactRepository(ContactDBContext db)
        {
            _db = db;
        }

        public async Task<List<Contact>> FindAllContactsAsync()
        {
            try { return await _db.Contacts.ToListAsync(); }
            catch (Exception ex)
            {
                string xx = ex.Message;
                return null;
            }
            
        }

        public async Task<Contact> FindContactByIdAsync(string Name)
        {
            var contact = await _db.Contacts.SingleOrDefaultAsync(c => c.Name == Name);
            return contact;
        }

        public async Task<Guid> InsertAsync(Contact contact)
        {
            contact.Id = Guid.NewGuid();
            contact.CreatedOn = DateTime.Now;

            await _db.Contacts.AddAsync(contact);
            await _db.SaveChangesAsync();
            return contact.Id;
        }

        public async Task UpdateAsync(Contact contact, Contact existingContact)
        {
            existingContact.FullName = contact.FullName;
            existingContact.PhoneNumber = contact.PhoneNumber;
            existingContact.EmailAddress = contact.EmailAddress;
            existingContact.Address = contact.Address;
            existingContact.IsDeleted = contact.IsDeleted;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Contact contact)
        {
            _db.Contacts.Remove(contact);
            await _db.SaveChangesAsync();
        }
    }
}
