namespace PhoneStore.Models.Resority
{
    public interface ICartRes
    {
        Task<int> AddItem(int Pro_Id, int qty);
        Task<int> RemoveItem(int Pro_Id);
        Task<ShoppingCart> GetUserCart();
        Task<int> GetCartItemCount(string userId = "");
        Task<ShoppingCart> GetCart(string userId);
        Task<bool> DoCheckout();
        List<Supplier> GetAllSupplier();
    }
}