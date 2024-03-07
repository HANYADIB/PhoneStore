namespace PhoneStore.Models.Resority
{
    public class CatagoryRes: ICatagoryRes
    {
        private readonly ApplicationDb context;

        public CatagoryRes(ApplicationDb _context)
        {
            context = _context;
        }
        public List<Category> Getall()
        {
            return context.Categories.ToList();
        }
    }
}
