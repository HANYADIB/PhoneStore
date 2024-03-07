using Microsoft.AspNetCore.Mvc;
using PhoneStore.Models;
using PhoneStore.Models.Resority;

namespace PhoneStore.Controllers
{
    public class UserOrderController : Controller
    {
        private readonly IUserOrderRes _userOrderRepo;

        public UserOrderController(IUserOrderRes userOrderRepo)
        {
            _userOrderRepo = userOrderRepo;
        }
        public async Task<IActionResult> UserOrders()
        {
            var orders = await _userOrderRepo.UserOrders();
            return View(orders);
        }

    }
}
