using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class OrderRepository : IOrderRepository
    {
        private IOrderDA _OrderDA;
        private IOrderDetailsDA _OrderDetailsDA;

        public OrderRepository(IOrderDA OrderDA, IOrderDetailsDA OrderDetailsDA)
        {
            _OrderDA = OrderDA;
            _OrderDetailsDA = OrderDetailsDA;
        }

        public async Task AddOrderAsync(Order[] Orders)
        {
            await _OrderDA.AddOrderAsync(Orders);
        }
        public Order[] AddOrders(Order[] Orders)
        {
            foreach(Order order in Orders)
            {
                 order.Id = Guid.NewGuid();
                _OrderDA.AddOrder(new [] { order });
                foreach(OrderDetails poDetails in order.Products)
                {
                    poDetails.OrderId = order.Id;
                    poDetails.TenantId = order.TenantId;
                    poDetails.PlantId = order.PlantId;
                }
                _OrderDetailsDA.AddOrderDetails(order.Products.ToArray());
            }

            return Orders;
        }

        public Order GetOrder(string id)
        {
            return _OrderDA.GetOrder(id);
        }

        public Order GetOrderInformation(string id)
        {
            return _OrderDA.GetOrderInformation(id);
            //order.OrderDate = or.OrderDate;
            //order.CustomerPONumber = or.CustomerPONumber;
            //order.CustomerName = or.CustomerName;
            //order.CustomerId = or.CustomerId;
            //order.OrderNumber = or.OrderNumber;
            //order.OrderStatus = or.OrderStatus;
            //order.Price = or.Price;
            //order.Remark = or.Remark;

            //foreach (var period in or)
            //{
            //}

               // return order;
        }

        public Dictionary<string, Order> GetOrders(string[] ids)
        {
            return _OrderDA.GetOrder(ids);
        }

        public Order[] GetOrders(IEnumerable<Guid?> ids)
        {
            return _OrderDA.GetOrder(ids);
        }

        public Order[] GetAll()
        {
            return _OrderDA.GetAll();
        }


        public Order[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _OrderDA.GetByIds(Ids);
        }

        public Order[] UpdateOrders(Order[] Orders)
        {
            return _OrderDA.UpdateOrder(Orders);
        }

        public Order[] DeleteOrders(string id)
        {
            return _OrderDA.DeleteOrder(id);
        }
    }
}
