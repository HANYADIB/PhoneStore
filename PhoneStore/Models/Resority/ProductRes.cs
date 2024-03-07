using Microsoft.EntityFrameworkCore;

namespace PhoneStore.Models.Resority
{
    public class ProductRes :IProductRes 
    {
        private readonly ApplicationDb context;

        public ProductRes(ApplicationDb _context)
        {
            context = _context;
        }
        public List<Product> Getall()
        {
            return context.Products.Include(x => x.Categorys).Include(c => c.Suppliers).ToList();
        }
        public Product Getbyid(int Id)
        {
            return context.Products.FirstOrDefault(d => d.Product_Id == Id);
        }
        public Product GetbyNamebyId(string Name, int Product_Id)
        {
            return context.Products.FirstOrDefault(s => s.Name == Name && s.Product_Id != Product_Id);

        }
        public void Adding(Product Item)
        {
            context.Products.Add(Item);
            context.SaveChanges();
        }
        public void Delete(int Id)
        {
            Product Item = Getbyid(Id);
            context.Products.Remove(Item);
            context.SaveChanges();

        }
        public void Edite(Product item, int Id)
        {
            Product olditem = Getbyid(Id);
            olditem.Name = item.Name;
            olditem.Price = item.Price;
            olditem.Description = item.Description;
            olditem.Category_Id = item.Category_Id;
           // olditem.Image = item.Image;
            context.SaveChanges();
        }
        public Product GetDetails(int Id)
        {
            return context.Products.Include(s => s.Categorys).Include(c => c.Suppliers).FirstOrDefault(c => c.Product_Id == Id);
        }
        public List<Product> GetAllStudentsindepart(int Id)
        {
            return context.Products.Where(c => c.Category_Id == Id).ToList();
        }
        public List<Product> Search(string item = "", int catagorgsId = 0, int suppliersId = 0)
        {
            List<Product> std = context.Products.Include(s => s.Categorys).Where(s => s.Name.StartsWith(item)
            || string.IsNullOrWhiteSpace(item)




             ).ToList();
            
            if (catagorgsId > 0)
                std = std.Where(a => a.Category_Id == catagorgsId).ToList();
            if (suppliersId > 0)
                std = std.Where(a => a.Supplier_Id == suppliersId).ToList();
            return std;
          

        }
    }
}
