using Microsoft.AspNetCore.Mvc;
using PhoneStore.Models.Resority;

namespace PhoneStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRes _cartRepo;

        public CartController(ICartRes cartRepo)
        {
            _cartRepo = cartRepo;
        }
        public async Task<IActionResult> AddItem(int Product_Id, int qty = 1, int redirect = 0)
        {
            var cartCount = await _cartRepo.AddItem(Product_Id, qty);
            if (redirect == 0)
                return Ok(cartCount);
            return RedirectToAction("GetUserCart");
        }

        public async Task<IActionResult> RemoveItem(int Product_Id)
        {
            var cartCount = await _cartRepo.RemoveItem(Product_Id);
            return RedirectToAction("GetUserCart");
        }
        public async Task<IActionResult> GetUserCart()
        {
            var cart = await _cartRepo.GetUserCart();
            ViewBag.sup = _cartRepo.GetAllSupplier();
            return View(cart);
        }

        public async Task<IActionResult> GetTotalItemInCart()
        {
            var cartItem = await _cartRepo.GetCartItemCount();
            return Ok(cartItem);
        }

        public async Task<IActionResult> Checkout()
        {
            bool isCheckedOut = await _cartRepo.DoCheckout();
            if (!isCheckedOut)
                throw new Exception("Something happen in server side");
            return RedirectToAction("UserOrders", "UserOrder");
        }
    }
}
