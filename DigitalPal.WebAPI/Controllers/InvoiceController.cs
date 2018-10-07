using DigitalPal.BusinessLogic.Interface;
using DigitalPal.Entities;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalPal.WebAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/DigitalPal/v1/Invoice")]
    public class InvoiceController : ApiController
    {
        public IInvoiceRepository InvoiceRepository;

        [Route("{id}")]
        [ResponseType(typeof(Invoice))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(InvoiceRepository.GetInvoice(id));
        }

        [ResponseType(typeof(Invoice))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(InvoiceRepository.GetAll());
        }

        [ResponseType(typeof(Invoice))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(Invoice[] Invoice)
        {
            return Ok(InvoiceRepository.AddInvoices(Invoice));
        }

        [ResponseType(typeof(Invoice))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(Invoice[] Invoice)
        {
            return Ok(InvoiceRepository.UpdateInvoices(Invoice));
        }

        [ResponseType(typeof(Invoice))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(InvoiceRepository.DeleteInvoices(id));
        }
    }
}
