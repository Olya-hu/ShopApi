using System.Collections.Generic;
using System.Threading.Tasks;
using Database;
using OrderRequest = Services.Orders.Requests.OrderRequest;

namespace Services.Orders
{
    public interface IOrders
    {
        Task<List<Shipping>> GetShippings();
        Task Make(OrderRequest request);
    }
}
