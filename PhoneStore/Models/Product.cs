using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PhoneStore.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }
        [Required]
        [Remote(action: "NameCheck", controller: "product", AdditionalFields = "Product_Id")]
        public string Name { get; set; }

        public double Price { get; set; }

        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
        public string? Description { get; set; }
        [ForeignKey("Categorys")]
        public int Category_Id { get; set; }
        public virtual Category? Categorys { get; set; }
        [ForeignKey("Suppliers")]
        public int Supplier_Id { get; set; }
        public virtual Supplier? Suppliers { get; set; }
    }
}
