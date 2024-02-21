using OmniLine.Models;
using Microsoft.EntityFrameworkCore;

namespace OmniLine.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CounterAgent> CounterAgents { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contact>().HasIndex(e =>e.Email).IsUnique();
            modelBuilder.Entity<CounterAgent>().HasIndex(c=>c.Name).IsUnique();
        }


    }
}
