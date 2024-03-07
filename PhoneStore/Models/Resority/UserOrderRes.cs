using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PhoneStore.Models.Resority
{
    public class UserOrderRes: IUserOrderRes
    {
        private readonly UserManager<ApplacationUser> _userManager;
        private readonly ApplicationDb _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserOrderRes(UserManager<ApplacationUser> userManager, ApplicationDb db,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _db = db;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<IEnumerable<Order>> UserOrders()
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
                throw new Exception("User is not logged-in");
            var orders = await _db.Orders
                            .Include(x => x.OrderStatuses)
                            .Include(x => x.OrderDetails)
                            .ThenInclude(x => x.Products)
                            .ThenInclude(x => x.Categorys)
                            .Where(a => a.UserId == userId)
                            .ToListAsync();
            return orders;
        }

        private string GetUserId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            string userId = _userManager.GetUserId(principal);
            return userId;
        }
        public List<Order> GetAllOrder(string Id) 
        {
            List<Order> order = _db.Orders.Include(c=>c.OrderStatuses).Where(a => a.UserId == Id).ToList();
            return order;
        }
        public int GetNumdersOrder(string Id) 
        {
            var order = _db.Orders.Where(a => a.UserId == Id).Count();
            return order;
        }
    }
}
