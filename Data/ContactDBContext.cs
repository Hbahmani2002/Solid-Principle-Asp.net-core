using Microsoft.EntityFrameworkCore;

namespace ContactHub.Data
{
    public class ContactDBContext : DbContext
    {
       
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
                options.UseSqlite("DataSource=contacts_db.db;Cache=Shared").LogTo(Console.WriteLine, LogLevel.Information);
    }
  
}
