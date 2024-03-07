namespace PhoneStore.Models
{
    public class CountryUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CityUser> CityUsers { get; set; }
    }
}
