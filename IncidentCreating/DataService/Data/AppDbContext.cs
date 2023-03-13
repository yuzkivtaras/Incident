using Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace DataService.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Incident> Incidents { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}