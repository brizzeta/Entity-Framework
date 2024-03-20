using Classes;
using CountryDbContext;
using Microsoft.EntityFrameworkCore;

namespace _1._Entity_Intro
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                                  "10. Add country\n" +
                                  "11. Change information\n" +
                                  "12. Delete country\n" +
                                  "0. Exit\n");
                Console.Write("Enter: ");
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
                        Console.ReadKey();
                        Console.Clear();
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
                    case 10:
                        Console.Clear();
                        Console.Write("Enter a name of country: ");
                        string country = Console.ReadLine();
                        Console.Clear();
                        Console.Write("Enter a capital: ");
                        string capital = Console.ReadLine();
                        Console.Clear();
                        Console.Write("Enter area: ");
                        float area2 = float.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.Write("Enter a population: ");
                        long population2 = long.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Choose the continent:\n1. Europe\n2. Asia\n3. Africa\n4. North America\n5. South America");
                        Console.Write(": ");
                        input = short.Parse(Console.ReadLine());
                        string continent = string.Empty;
                        switch (input)
                        {
                            case 1:
                                continent = "Europe";
                                break;
                            case 2:
                                continent = "Asia";
                                break;
                            case 3:
                                continent = "Africa";
                                break;
                            case 4:
                                continent = "North America";
                                break;
                            case 5:
                                continent = "South America";
                                break;
                            default:
                                Console.WriteLine("Not correct.");
                                continue;
                        }
                        Console.Clear();
                        AddCountry(continent, country, capital, area2, population2);
                        continue;
                    case 11:
                        Console.Clear();
                        Console.Write("Enter a name of country: ");
                        string country3 = Console.ReadLine();
                        Console.Clear();
                        Console.Write("Enter a capital: ");
                        string capital3 = Console.ReadLine();
                        Console.Clear();
                        Console.Write("Enter area: ");
                        float area3 = float.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.Write("Enter a population: ");
                        long population3 = long.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Choose the continent:\n1. Europe\n2. Asia\n3. Africa\n4. North America\n5. South America");
                        Console.Write(": ");
                        input = short.Parse(Console.ReadLine());
                        string continent3 = string.Empty;
                        switch (input)
                        {
                            case 1:
                                continent3 = "Europe";
                                break;
                            case 2:
                                continent3 = "Asia";
                                break;
                            case 3:
                                continent3 = "Africa";
                                break;
                            case 4:
                                continent3 = "North America";
                                break;
                            case 5:
                                continent3 = "South America";
                                break;
                            default:
                                Console.WriteLine("Not correct.");
                                continue;
                        }
                        Console.Clear();
                        UpdateCountry(input, continent3, country3, capital3, area3, population3);
                        continue;
                    case 12:
                        Console.Clear();
                        AllCountries();
                        Console.Write("Enter: ");
                        input = short.Parse(Console.ReadLine());
                        Console.Clear();
                        DeleteCountry(input);
                        continue;
                    case 0:
                        Console.Clear();
                        break;
                }
                break;
            }
        }

        /*         -------------------------------------------------------------------      */
        /*         ---------------------         1  TASK      ------------------------      */
        /*         -------------------------------------------------------------------      */

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
                int j = 1;
                Console.WriteLine("COUNTRIES\n");
                foreach (var i in country)
                {
                    Console.WriteLine($"{j}. {i}");
                    j++;
                }
            }
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

        /*         -------------------------------------------------------------------      */
        /*         ---------------------         2  TASK      ------------------------      */
        /*         -------------------------------------------------------------------      */

        public static void AddCountry(string cont, string name, string nameCapital, float area, long population)
        {
            using (var context = new CountryDBContext())
            {
                try
                {
                    var continent = context.Continent.FirstOrDefault(i => i.Name == cont);
                    if (continent == null)
                    {
                        throw new Exception("Continent not found.");
                    }
                    var country = new Country { Name = name, Capital = nameCapital, Area = area, Population = population, Continent = continent };
                    context.Countries.Add(country);
                    context.SaveChanges();
                    Console.WriteLine("Country added.");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    return;
                }
            }
        }

        public static void UpdateCountry(int ID, string cont, string name, string capital, float area, long population)
        {
            using (var context = new CountryDBContext())
            {
                try
                {
                    var country = context.Countries.Include(i => i.Continent).FirstOrDefault(i => i.ID == ID);
                    if (country == null)
                    {
                        throw new Exception("Country not found.");
                    }
                    var continent = context.Continent.FirstOrDefault(i => i.Name == cont);
                    if (continent == null)
                    {
                        throw new Exception("Continent not found.");
                    }
                    country.Name = name;
                    country.Capital = capital;
                    country.Population = population;
                    country.Area = area;
                    country.Continent = continent;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
            }
            Console.WriteLine("Information updated.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void DeleteCountry(int ID)
        {
            using (var context = new CountryDBContext())
            {
                try
                {
                    var country = context.Countries.FirstOrDefault(c => c.ID == ID);
                    if (country == null)
                    {
                        throw new InvalidOperationException("Country not found.");
                    }

                    context.Countries.Remove(country);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
            }
            Console.WriteLine("Country deleted.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
