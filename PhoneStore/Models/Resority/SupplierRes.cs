namespace PhoneStore.Models.Resority
{
    public class SupplierRes: ISupplierRes
    {
        private readonly ApplicationDb context;

        public SupplierRes(ApplicationDb _context)
        {
            context = _context;
        }
        public List<Supplier> Getall()
        {
            return context.Suppliers.ToList();
        }
    }
}
