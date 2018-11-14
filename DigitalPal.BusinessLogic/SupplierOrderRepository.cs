using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class SupplierOrderRepository : ISupplierOrderRepository
    {
        private ISupplierOrderDA _SupplierOrderDA;
        private ISupplierOrderDetailsDA _SupplierOrderDetailsDA;

        public SupplierOrderRepository(ISupplierOrderDA SupplierOrderDA, ISupplierOrderDetailsDA SupplierOrderDetailsDA)
        {
            _SupplierOrderDA = SupplierOrderDA;
            _SupplierOrderDetailsDA = SupplierOrderDetailsDA;
        }

        public async Task AddSupplierOrderAsync(SupplierOrder[] SupplierOrders)
        {
            await _SupplierOrderDA.AddSupplierOrderAsync(SupplierOrders);
        }
        public SupplierOrderReport[] Search(SupplierOrder SupplierOrder)
        {
            return _SupplierOrderDA.Search(SupplierOrder);
        }

        public Dictionary<string, string> GetMaxNumber()
        {
            return _SupplierOrderDA.GetMaxNumber();
        }

        public SupplierOrder[] AddSupplierOrders(SupplierOrder[] SupplierOrders)
        {
            foreach(SupplierOrder SupplierOrder in SupplierOrders)
            {
                 SupplierOrder.Id = Guid.NewGuid();
                _SupplierOrderDA.AddSupplierOrder(new [] { SupplierOrder });
                foreach(SupplierOrderDetails poDetails in SupplierOrder.RawMaterial)
                {
                    poDetails.SupplierOrderId = SupplierOrder.Id;
                    poDetails.TenantId = SupplierOrder.TenantId;
                    poDetails.PlantId = SupplierOrder.PlantId;
                    poDetails.CreatedBy = SupplierOrder.CreatedBy;
                }
                _SupplierOrderDetailsDA.AddSupplierOrderDetails(SupplierOrder.RawMaterial.ToArray());
            }

            return SupplierOrders;
        }

        public SupplierOrder GetSupplierOrder(string id)
        {
            return _SupplierOrderDA.GetSupplierOrder(id);
        }

        public SupplierOrder GetSupplierOrderInformation(string id)
        {
            return _SupplierOrderDA.GetSupplierOrderInformation(id);
        }

        public Dictionary<string, SupplierOrder> GetSupplierOrders(string[] ids)
        {
            return _SupplierOrderDA.GetSupplierOrder(ids);
        }

        public SupplierOrder[] GetSupplierOrders(IEnumerable<Guid?> ids)
        {
            return _SupplierOrderDA.GetSupplierOrder(ids);
        }

        public SupplierOrder[] GetAll()
        {
            return _SupplierOrderDA.GetAll();
        }


        public SupplierOrder[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _SupplierOrderDA.GetByIds(Ids);
        }

        public SupplierOrder[] UpdateSupplierOrders(SupplierOrder[] SupplierOrders)
        {
            return _SupplierOrderDA.UpdateSupplierOrder(SupplierOrders);
        }

        public SupplierOrder DeleteSupplierOrders(string id)
        {
            _SupplierOrderDetailsDA.DeleteSupplierOrderDetailsBySupplierOrderId(id);
            _SupplierOrderDA.DeleteSupplierOrder(id);
            return null;
        }
    }
}
