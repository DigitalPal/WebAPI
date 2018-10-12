using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic.Interface
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order[] Orders);
        Order[] AddOrders(Order[] Orders);

        Order GetOrder(string id);

        Order GetOrderInformation(string id);
        Dictionary<string, string> GetMaxNumber();

        Dictionary<string, Order> GetOrders(string[] ids);

        Order[] GetOrders(IEnumerable<Guid?> ids);

        Order[] GetAll();

        Order[] GetByIds(IEnumerable<Guid> Ids);

        Order[] UpdateOrders(Order[] Orders);

        Order[] DeleteOrders(string id);
    }
}
