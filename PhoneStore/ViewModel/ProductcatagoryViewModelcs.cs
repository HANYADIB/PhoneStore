using PhoneStore.Models;

namespace PhoneStore.ViewModel
{
    public class ProductcatagoryViewModelcs
    {
        public List<Product> Products { get; set; }
        public List<Category> categories { get; set; }
        public string item { get; set; } = "";
        public int GenreId { get; set; } 
    }
}
