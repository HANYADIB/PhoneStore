namespace PhoneStore.Models.Resority
{
    public interface IUserOrderRes
    {
        Task<IEnumerable<Order>> UserOrders();
        List<Order> GetAllOrder(string Id);
        int GetNumdersOrder(string Id);
    }
}