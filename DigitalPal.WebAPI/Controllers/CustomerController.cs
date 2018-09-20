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
    [RoutePrefix("api/DigitalPal/v1/Customer")]
    public class CustomerController : ApiController
    {
        public ICustomerRepository CustomerRepository;

        [Route("{id}")]
        [ResponseType(typeof(Customer))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(CustomerRepository.Get(id));
        }

        [ResponseType(typeof(Customer))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(CustomerRepository.GetAll());
        }

        [ResponseType(typeof(Customer))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(Customer[] Customer)
        {
            return Ok(CustomerRepository.Add(Customer));
        }

        [ResponseType(typeof(Customer))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(Customer[] Customer)
        {
            return Ok(CustomerRepository.Update(Customer));
        }

        [ResponseType(typeof(Customer))]
        [HttpDelete]
        [Route("")]
        public IHttpActionResult Delete(Customer[] Customer)
        {
            return Ok(CustomerRepository.Delete(Customer));
        }
    }
}
