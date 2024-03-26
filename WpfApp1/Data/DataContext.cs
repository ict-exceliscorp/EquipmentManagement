using System.Data.Entity;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<Site> Sites { get; set; }

        public DbSet<Equipment> Equipments { get; set;}

        public DbSet<Condition> Conditions { get; set; }

        public DbSet<RegisteredEquipment> RegisteredEquipments { get; set; }
    }
}
