using Autofac.Extras.DynamicProxy;
using DigitalPal.BusinessLogic.Interface;
using DigitalPal.Common.LogUtils;
using DigitalPal.Entities;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalPal.WebAPI.Controllers
{
    //[Authorize]
    //[Intercept(typeof(CallLogger))]
    [RoutePrefix("api/DigitalPal/v1/Supplier")]
    public class SupplierController : ApiController
    {
        public ISupplierRepository SupplierRepository;

        [Route("{id}")]
        [ResponseType(typeof(Supplier))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(SupplierRepository.GetSupplier(id));
        }

        [ResponseType(typeof(Supplier))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(SupplierRepository.GetAll());
        }

        [ResponseType(typeof(Supplier))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(Supplier[] Supplier)
        {
            return Ok(SupplierRepository.AddSuppliers(Supplier));
        }

        [ResponseType(typeof(Supplier))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(Supplier[] Supplier)
        {
            return Ok(SupplierRepository.UpdateSuppliers(Supplier));
        }

        [ResponseType(typeof(Supplier))]
        [HttpDelete]
        [Route("")]
        public IHttpActionResult Delete(Supplier[] Supplier)
        {
            return Ok(SupplierRepository.DeleteSuppliers(Supplier));
        }
    }
}
