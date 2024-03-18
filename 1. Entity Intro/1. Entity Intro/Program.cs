using System.Diagnostics.Metrics;

namespace _1._Entity_Intro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CountryDBContext())
            {
                if (context.Database.EnsureCreated())
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
                    context.Continent?.AddRange(continent);
                    context.Countries?.AddRange(countries);
                    context.SaveChanges();
                }
            }
            Console.Clear();
            short input = 0;
            while (true)
            {
                Console.WriteLine("1. All information\n" +
                                  "2. All countries\n" +
                                  "3. Capitals\n" +
                                  "4. European countries\n" +
                                  "5. Countries with an area greater than a specific number\n" +
                                  "6. All countries that have the letters 'A' and 'E' in their names\n" +
                                  "7. All countries whose names begin with the letter 'A'\n" +
                                  "8. All countries with an area in the specified range\n" +
                                  "9. All countries that have more than the specified number of inhabitants\n" +
                                  "0. Exit");
                Console.Write("Enter:  ");
                input = short.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        AllInfo();
                        continue;
                    case 2:
                        Console.Clear();
                        AllCountries();
                        continue;
                    case 3:
                        Console.Clear();
                        Capitals();
                        continue;
                    case 4:
                        Console.Clear();
                        CountryOfEurope();
                        continue;
                    case 5:
                        Console.Clear();
                        Console.Write("Enter a num: ");
                        int area = int.Parse(Console.ReadLine());
                        Console.Clear();
                        ShowArea(area);
                        continue;
                    case 6:
                        Console.Clear();
                        CountryWith_A_or_E();
                        continue;
                    case 7:
                        Console.Clear();
                        CountryStartWith_A();
                        continue;
                    case 8:
                        Console.Clear();
                        Console.Write("Enter a start: ");
                        int areaStart = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.Write("Enter a finish: ");
                        int areaEnd = int.Parse(Console.ReadLine());
                        Console.Clear();
                        CountryWithAreaRange(areaStart, areaEnd);
                        continue;
                    case 9:
                        Console.Clear();
                        Console.Write("Enter a count of inhabitants: ");
                        int population = int.Parse(Console.ReadLine());
                        Console.Clear();
                        CountryWithBiggerPopulation(population);
                        continue;
                    case 0:
                        Console.Clear();
                        break;
                }
                break;
            }
        }

        static public void AllInfo()
        {
            using (var context = new CountryDBContext())
            {
                var countries = context.Countries.ToList();
                foreach (var i in countries)
                {
                    Console.WriteLine($"Country: {i.Name}\n Capital: {i.Capital}\n Population: {i.Population}\n Area: {i.Area}\n Continent: {i.Continent.Name}\n\n");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        static public void AllCountries()
        {
            using (var context = new CountryDBContext())
            {
                var country = context.Countries.Select(i => i.Name);
                foreach (var i in country)
                    Console.WriteLine($"Country: {i}");
            }
            Console.ReadKey();
            Console.Clear();
        }

        static public void Capitals()
        {
            using (var context = new CountryDBContext())
            {
                var capital = context.Countries.Select(i => i.Capital);
                foreach (var i in capital)
                {
                    Console.WriteLine($"Capital: {i}");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        static public void CountryOfEurope()
        {
            using (var context = new CountryDBContext())
            {
                var countryEuropa = context.Countries.Where(i => i.Continent.Name == "Europe").Select(i => i.Name);
                foreach (var i in countryEuropa)
                {
                    Console.WriteLine($"Country: {i}");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        static public void ShowArea(float area)
        {
            using (var context = new CountryDBContext())
            {
                var areaCountry = context.Countries.Where(i => i.Area > area).Select(i => i.Name);
                foreach (var i in areaCountry)
                {
                    Console.WriteLine($"Country: {i}");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        static public void CountryWith_A_or_E()
        {
            using (var context = new CountryDBContext())
            {
                var country = context.Countries.Where(i => i.Name.Contains("a") || i.Name.Contains("e")).Select(i => i.Name);
                foreach (var i in country)
                {
                    Console.WriteLine($"Country: {i}");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        static public void CountryStartWith_A()
        {
            using (var context = new CountryDBContext())
            {
                var country = context.Countries.Where(i => i.Name.StartsWith("A")).Select(i => i.Name);
                foreach (var i in country)
                {
                    Console.WriteLine($"Country: {i}");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        static public void CountryWithAreaRange(float start, float end)
        {
            using (var context = new CountryDBContext())
            {
                var countryArea = context.Countries.Where(i => i.Area > start && i.Area < end).Select(i => i.Name);
                foreach (var i in countryArea)
                {
                    Console.WriteLine($"Country: {i}");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        static public void CountryWithBiggerPopulation(long population)
        {
            using (var context = new CountryDBContext())
            {
                var countryBiggerPopulation = context.Countries.Where(i => i.Population > population).Select(i => i.Name);
                foreach (var i in countryBiggerPopulation)
                {
                    Console.WriteLine($"Country: {i}");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
