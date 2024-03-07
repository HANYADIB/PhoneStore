using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Models
{
    public class Category
    {
        [Key]
        public int Cat_Id { get; set; }
        public string Name { get; set; }
        public virtual List<Product>? Products { get; set; }
    }
}
