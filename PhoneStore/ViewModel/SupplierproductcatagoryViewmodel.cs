using PhoneStore.Models;

namespace PhoneStore.ViewModel
{
    public class SupplierproductcatagoryViewmodel
    {
        public List<Product> Products { get; set; }
        public List<Category> categories { get; set; }
        public List<Supplier>suppliers { get; set; }
        public string item { get; set; } = "";
        public int catagorgsId { get; set; } = 0;
        public int suppliersId { get; set; } = 0;
        public string Nameproduct { get; set; } = "";

        public Double priceproduct { get; set; } = 0;
        public string descripsion { get; set; } = "";
        public int Category_Id { get; set; } = 0;
        public int Supplier_Id { get; set; } = 0;
        public string? Image { get; set; } 
        public IFormFile? File { get; set; } 

    }
}
