using DigitalPal.BusinessLogic.Interface;
using DigitalPal.Entities;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalPal.WebAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/DigitalPal/v1/Order")]
    public class OrderController : ApiController
    {
        public IOrderRepository OrderRepository;

        [Route("{id}")]
        [ResponseType(typeof(Order))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(OrderRepository.GetOrderInformation(id));
        }

        [ResponseType(typeof(Order))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(OrderRepository.GetAll());
        }

        [ResponseType(typeof(Order))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(Order[] Order)
        {
            return Ok(OrderRepository.AddOrders(Order));
        }

        [ResponseType(typeof(Order))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(Order[] Order)
        {
            return Ok(OrderRepository.UpdateOrders(Order));
        }

        [ResponseType(typeof(Order))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(OrderRepository.DeleteOrders(id));
        }
    }
}
