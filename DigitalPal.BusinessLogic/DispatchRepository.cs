using DigitalPal.BusinessLogic.Interface;
using DigitalPal.DataAccess.Interface;
using DigitalPal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalPal.BusinessLogic
{
    public class DispatchRepository : IDispatchRepository
    {
        private IDispatchDA _DispatchDA;
        private IOrderDA _OrderDA;
        private IDispatchDetailsDA _DispatchDetailsDA;

        public DispatchRepository(IDispatchDA DispatchDA, IDispatchDetailsDA DispatchDetailsDA, IOrderDA OrderDA)
        {
            _DispatchDA = DispatchDA;
            _DispatchDetailsDA = DispatchDetailsDA;
            _OrderDA = OrderDA;
        }

        public async Task AddDispatchAsync(Dispatch[] Dispatchs)
        {
            await _DispatchDA.AddDispatchAsync(Dispatchs);
        }

        public DispatchReport[] Search(DispatchReport Dispatch)
        {
            return _DispatchDA.Search(Dispatch);
        }

        public Dispatch[] AddDispatch(Dispatch[] Dispatchs)
        {
            List<Order> lstOrd = new List<Order>();
            foreach (Dispatch dispatch in Dispatchs)
            {
                dispatch.Id = Guid.NewGuid();
                _DispatchDA.AddDispatch(new[] { dispatch });
                foreach (DispatchDetails dispatchDetails in dispatch.DispatchDetails)
                {
                    dispatchDetails.DispatchId = dispatch.Id;
                    dispatchDetails.TenantId = dispatch.TenantId;
                    dispatchDetails.PlantId = dispatch.PlantId;
                }
                _DispatchDetailsDA.AddDispatchDetails(dispatch.DispatchDetails.ToArray());

                Order ord = _OrderDA.GetOrder(dispatch.OrderId.ToString());
                if (ord != null)
                {
                    ord.Id = dispatch.OrderId;
                    ord.CanDelete = false;
                    ord.CanEdit = false;
                    lstOrd.Add(ord);
                }
            }
            //Update order, if entry in dispatch then set can edit can delete to false
            _OrderDA.UpdateOrder(lstOrd.GroupBy(p => p.Id).Select(grp => grp.FirstOrDefault()).ToArray());

            return Dispatchs;
        }

        public Dispatch GetDispatch(string id)
        {
            return _DispatchDA.GetDispatch(id);
        }

        public Dictionary<string, Dispatch> GetDispatch(string[] ids)
        {
            return _DispatchDA.GetDispatch(ids);
        }

        public Dispatch[] GetDispatch(IEnumerable<Guid?> ids)
        {
            return _DispatchDA.GetDispatch(ids);
        }

        public Dispatch[] GetAll()
        {
            return _DispatchDA.GetAll();
        }


        public Dispatch[] GetByIds(IEnumerable<Guid> Ids)
        {
            return _DispatchDA.GetByIds(Ids);
        }

        public Dispatch[] UpdateDispatch(Dispatch[] Dispatchs)
        {
            return _DispatchDA.UpdateDispatch(Dispatchs);
        }

        public Dispatch DeleteDispatch(string id)
        {
            _DispatchDetailsDA.DeleteOrderDetailsByDispatchId(id);
            _DispatchDA.DeleteDispatch(id);
            return null;
        }
    }
}
