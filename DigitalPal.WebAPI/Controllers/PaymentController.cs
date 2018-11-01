using DigitalPal.BusinessLogic.Interface;
using DigitalPal.Entities;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalPal.WebAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/DigitalPal/v1/Payment")]
    public class PaymentController : ApiController
    {
        public IPaymentRepository PaymentRepository;

        [Route("{id}")]
        [ResponseType(typeof(Payment))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(PaymentRepository.GetPayment(id));
        }


        [Route("Search")]
        [ResponseType(typeof(Payment))]
        [HttpGet]
        public IHttpActionResult Search(Payment Payment)
        {
            return Ok(PaymentRepository.Search(Payment));
        }

        [ResponseType(typeof(Payment))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(PaymentRepository.GetAll());
        }

        [ResponseType(typeof(Payment))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(Payment[] Payment)
        {
            return Ok(PaymentRepository.AddPayments(Payment));
        }

        [ResponseType(typeof(Payment))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(Payment[] Payment)
        {
            return Ok(PaymentRepository.UpdatePayments(Payment));
        }

        [ResponseType(typeof(Payment))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(PaymentRepository.DeletePayments(id));
        }
    }
}
