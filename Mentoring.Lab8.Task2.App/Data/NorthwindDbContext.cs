using System.Data.Entity;
using Mentoring.Lab8.Task2.App.Entities;

namespace Mentoring.Lab8.Task2.App.Data
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext()
            : base("NorthwindDB")
        {
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}