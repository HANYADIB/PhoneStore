using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore.Models
{
    public class City
    {
        public int Id  { get; set; }
        public string Name { get; set; }
        [ForeignKey("Countries")]
        public int Country_Id { get; set; }
        public Country Countries { get; set; }
    }
}