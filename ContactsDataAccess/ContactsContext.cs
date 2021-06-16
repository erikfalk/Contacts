using ContactsDataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactsDataAccess
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        
    }
}
