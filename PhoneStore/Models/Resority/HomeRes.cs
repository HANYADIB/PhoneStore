using Microsoft.EntityFrameworkCore;

namespace PhoneStore.Models.Resority
{
    public class HomeRes :IHomeRes
    {
        private readonly ApplicationDb context;

        public HomeRes(ApplicationDb _context)
        {
            context = _context;
        }
        public List<Product> Search(string item = "", int genreId=0)
        {

            List<Product> std = context.Products.Include(s => s.Categorys).Where(s => s.Name.StartsWith(item)
            || string.IsNullOrWhiteSpace(item)


             ).ToList();

            if (genreId > 0)
                std = std.Where(a => a.Category_Id == genreId).ToList();
          
            return std;

        }
        public List<Category> GetAllCategory() 
        {
            return context.Categories.ToList();
        }
        public List<Product> GetAllProduct() 
        {
            return context.Products.ToList();
        }
    }
}
