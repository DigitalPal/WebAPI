using DigitalPal.BusinessLogic.Interface;
using DigitalPal.Entities;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalPal.WebAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/DigitalPal/v1/SupplierPayment")]
    public class SupplierPaymentController : ApiController
    {
        public ISupplierPaymentRepository SupplierPaymentRepository;

        [Route("{id}")]
        [ResponseType(typeof(SupplierPayment))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(SupplierPaymentRepository.GetSupplierPayment(id));
        }


        [Route("Search")]
        [ResponseType(typeof(SupplierPayment))]
        [HttpGet]
        public IHttpActionResult Search(SupplierPayment SupplierPayment)
        {
            return Ok(SupplierPaymentRepository.Search(SupplierPayment));
        }

        [ResponseType(typeof(SupplierPayment))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(SupplierPaymentRepository.GetAll());
        }

        [ResponseType(typeof(SupplierPayment))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(SupplierPayment[] SupplierPayment)
        {
            return Ok(SupplierPaymentRepository.AddSupplierPayments(SupplierPayment));
        }

        [ResponseType(typeof(SupplierPayment))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(SupplierPayment[] SupplierPayment)
        {
            return Ok(SupplierPaymentRepository.UpdateSupplierPayments(SupplierPayment));
        }

        [ResponseType(typeof(SupplierPayment))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(SupplierPaymentRepository.DeleteSupplierPayments(id));
        }
    }
}
