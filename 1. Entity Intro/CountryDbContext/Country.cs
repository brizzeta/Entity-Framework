using Microsoft.EntityFrameworkCore;
using Classes;

namespace CountryDbContext
{
    public class CountryDBContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Continent> Continent { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=DESKTOP-UL85ESV\SQLEXPRESS;Database=Countries;Integrated Security=SSPI;TrustServerCertificate=true");
        }
        public CountryDBContext()
        {
            if (Database.EnsureCreated())
            {
                var continent = new List<Continent>
                {
                    new Continent { Name = "Europe" },
                    new Continent { Name = "Asia" },
                    new Continent { Name = "Africa" },
                    new Continent { Name = "North America" },
                    new Continent { Name = "South America" },
                };
                var countries = new List<Country>
                    {
                        new Country(){ Name = "Ukraine", Capital = "Kyiv", Population = 37584321, Area = 603628, Continent = continent[0] },
                        new Country(){ Name = "Italy", Capital = "Rome", Population = 58746861, Area = 301340, Continent = continent[0] },
                        new Country(){ Name = "France", Capital = "Paris", Population = 67750000, Area = 643801, Continent = continent[0] },
                        new Country(){ Name = "Germany", Capital = "Berlin", Population = 83200000, Area = 357592, Continent = continent[0] },
                        new Country(){ Name = "Poland", Capital = "Warsaw", Population = 37750000, Area = 312696, Continent = continent[0] },
                        new Country(){ Name = "Japan", Capital = "Tokyo", Population = 125416877, Area = 377975, Continent = continent[1] },
                        new Country(){ Name = "China", Capital = "Beijing", Population = 1409670000, Area = 9596961, Continent = continent[1] },
                        new Country(){ Name = "USA", Capital = "Washington", Population = 334914895, Area = 9833520, Continent = continent[3] },
                        new Country(){ Name = "Canada", Capital = "Ottawa", Population = 40528396, Area = 3855100, Continent = continent[3] },
                        new Country(){ Name = "Brazil", Capital = "Brasilia", Population = 203062512, Area = 8515767, Continent = continent[4] }
                    };
                Continent?.AddRange(continent);
                Countries?.AddRange(countries);
                SaveChanges();
            }
        }
    }
}
