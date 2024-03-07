namespace PhoneStore.Models.Resority
{
    public interface IProductRes
    {
        List<Product> Getall();
        public Product Getbyid(int Id);
        public Product GetbyNamebyId(string Name, int Product_Id);
        public void Adding(Product Item);
        public void Delete(int Id);
        public void Edite(Product item, int Id);
        public Product GetDetails(int Id);
        List<Product> Search(string item = "", int catagorgsId = 0, int suppliersId = 0);
    }
}