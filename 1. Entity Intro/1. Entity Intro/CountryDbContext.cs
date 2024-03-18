using Microsoft.EntityFrameworkCore;


namespace _1._Entity_Intro
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
