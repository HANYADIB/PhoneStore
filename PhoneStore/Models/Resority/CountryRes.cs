namespace PhoneStore.Models.Resority
{
    public class CountryRes:ICountryRes
    {
        private readonly ApplicationDb context;

        public CountryRes(ApplicationDb _context)
        {
            context = _context;
        }
        public List<CountryUser> GetAll() 
        {
            return context.CountryUsers.ToList();
        }
    }
}
