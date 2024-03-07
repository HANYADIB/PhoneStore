using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Collections.Generic;

namespace PhoneStore.Models.Resority
{
    public class CityRes :ICityRes
    {
        private readonly ApplicationDb context;

        public CityRes(ApplicationDb _context)
        {
            context = _context;
        }
        public List<CityUser> GetAll()
        {
            return context.CityUsers.ToList();
        }
        public List<CityUser> GetId(int Id)
        {
            return context.CityUsers.Where(a=>a.Country_Id==Id).OrderBy(a=>a.Name).ToList();
        }
    }
}
