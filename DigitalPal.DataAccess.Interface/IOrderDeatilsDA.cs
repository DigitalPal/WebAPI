using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Interface
{
    public interface IOrderDetailsDA
    {
        Task AddOrderDetailsAsync(OrderDetails[] OrderDetails);
        OrderDetails[] AddOrderDetails(OrderDetails[] OrderDetails);

        OrderDetails GetOrderDetails(string id);

        Dictionary<string, OrderDetails> GetOrderDetails(string[] ids);

        OrderDetails[] GetOrderDetails(IEnumerable<Guid?> ids);

        OrderDetails[] GetAll();

        OrderDetails[] GetByIds(IEnumerable<Guid> Ids);

        OrderDetails[] UpdateOrderDetails(OrderDetails[] OrderDetails);

        OrderDetails[] DeleteOrderDetails(string id);
    }
}
