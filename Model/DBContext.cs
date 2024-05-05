using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OZON.Model
{
    internal class DBContext :DbContext
    {
        public DbSet<Seller> Seller { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<PickupPoint> PickupPoint { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderAssignment> OrderAssignment { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OZON;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
        }
    }
}
