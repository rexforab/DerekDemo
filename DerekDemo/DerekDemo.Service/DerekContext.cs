using DerekDemo.Model;
using System.Data.Entity;

namespace DerekDemo.Service
{
    public class DerekContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
