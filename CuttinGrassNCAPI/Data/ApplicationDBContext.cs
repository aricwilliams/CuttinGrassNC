using Microsoft.EntityFrameworkCore;
using CuttinGrassNCAPI.Model.DBCustomers;

namespace CuttinGrassNCAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Customers> Customers { get; set; }
    }
}
