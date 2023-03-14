using DataService.Data;
using DataService.IRepository;
using Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace DataService.Repository
{
    public class ContactsRepository : GenericContactRepository<Contact>, IContactsRepository
    {
        public ContactsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> UpdateContact(Contact contact)
        {
            var existingContact = await dbSet.Where(x => x.Email == contact.Email).FirstOrDefaultAsync();
            
            if (existingContact != null)
            {
                contact.Email = existingContact.Email;
                contact.FirstName = existingContact.FirstName;
                contact.LastName = existingContact.LastName;
            }

            return true;
        }
    }
}
