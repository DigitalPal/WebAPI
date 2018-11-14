using DigitalPal.BusinessLogic.Interface;
using DigitalPal.Entities;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalPal.WebAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/DigitalPal/v1/SupplierOrder")]
    public class SupplierOrderController : ApiController
    {
        public ISupplierOrderRepository SupplierOrderRepository;

        [Route("{id}")]
        [ResponseType(typeof(SupplierOrder))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(SupplierOrderRepository.GetSupplierOrderInformation(id));
        }

        [Route("Search")]
        [ResponseType(typeof(SupplierOrder))]
        [HttpPost]
        public IHttpActionResult Search(SupplierOrder SupplierOrder)
        {
            return Ok(SupplierOrderRepository.Search(SupplierOrder));
        }

        [ResponseType(typeof(SupplierOrder))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(SupplierOrderRepository.GetAll());
        }

        [ResponseType(typeof(Dictionary<string, string>))]
        [HttpGet]
        [Route("maxNumbers")]
        public IHttpActionResult GetMaxNumber()
        {
            return Ok(SupplierOrderRepository.GetMaxNumber());
        }

        [ResponseType(typeof(SupplierOrder))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(SupplierOrder[] SupplierOrder)
        {
            return Ok(SupplierOrderRepository.AddSupplierOrders(SupplierOrder));
        }

        [ResponseType(typeof(SupplierOrder))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(SupplierOrder[] SupplierOrder)
        {
            return Ok(SupplierOrderRepository.UpdateSupplierOrders(SupplierOrder));
        }

        [ResponseType(typeof(SupplierOrder))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(SupplierOrderRepository.DeleteSupplierOrders(id));
        }
    }
}
