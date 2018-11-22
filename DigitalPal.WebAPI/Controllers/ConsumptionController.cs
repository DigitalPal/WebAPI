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
    [RoutePrefix("api/DigitalPal/v1/Consumption")]
    public class ConsumptionController : ApiController
    {
        public IConsumptionRepository ConsumptionRepository;

        [Route("{id}")]
        [ResponseType(typeof(Consumption))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(ConsumptionRepository.GetConsumption(id));
        }

        [ResponseType(typeof(Consumption))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(ConsumptionRepository.GetAll());
        }

        [ResponseType(typeof(Consumption))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(Consumption[] Consumption)
        {
            return Ok(ConsumptionRepository.AddConsumptions(Consumption));
        }

        [ResponseType(typeof(Consumption))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(Consumption[] Consumption)
        {
            return Ok(ConsumptionRepository.UpdateConsumptions(Consumption));
        }

        [ResponseType(typeof(Consumption))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(ConsumptionRepository.DeleteConsumptions(id));
        }

        [Route("Search")]
        [ResponseType(typeof(Consumption))]
        [HttpPost]
        public IHttpActionResult Search(ConsumptionReport consumption)
        {
            return Ok(ConsumptionRepository.Search(consumption));
        }
    }
}
