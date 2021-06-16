using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ContactsDataAccess
{
    public class ContactsContextFactory : IDesignTimeDbContextFactory<ContactsContext>
    {
        public ContactsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContactsContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=contacts_db;User ID=admin;Password=test");

            return new ContactsContext(optionsBuilder.Options);
        }
    }
}
