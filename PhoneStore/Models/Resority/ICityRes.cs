namespace PhoneStore.Models.Resority
{
    public interface ICityRes
    {
        public List<CityUser> GetAll();
        public List<CityUser> GetId(int Id);
    }
}