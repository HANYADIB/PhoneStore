using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore.Models
{
    public class CityUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("CountryUsers")]
        public int Country_Id { get; set; }
        public CountryUser CountryUsers { get; set; }
    }
}
