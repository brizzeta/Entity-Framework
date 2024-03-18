namespace _1._Entity_Intro
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public long Population { get; set; }
        public float Area { get; set; }
        public virtual Continent Continent { get; set; }
    }

    public class Continent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Country> Country { get; set; }
    }
}
