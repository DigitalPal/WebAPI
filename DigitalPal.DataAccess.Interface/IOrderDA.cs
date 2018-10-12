using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.DataAccess.Interface
{
    public interface IOrderDA
    {
        Task AddOrderAsync(Order[] Order);
        Order[] AddOrder(Order[] Order);

        Order GetOrder(string id);

        Order GetOrderInformation(string id);
        Dictionary<string, string> GetMaxNumber();
        Dictionary<string, Order> GetOrder(string[] ids);

        Order[] GetOrder(IEnumerable<Guid?> ids);

        Order[] GetAll();

        Order[] GetByIds(IEnumerable<Guid> Ids);

        Order[] UpdateOrder(Order[] Order);

        Order[] DeleteOrder(string id);
    }
}
