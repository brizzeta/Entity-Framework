using Classes;
using Microsoft.EntityFrameworkCore;

namespace Country_DbContext
{
    public class CountryDBContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Continent> Continent { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=DESKTOP-UL85ESV\SQLEXPRESS;Database=Countries;Integrated Security=SSPI;TrustServerCertificate=true");
        }
    }
}
