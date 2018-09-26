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
    [RoutePrefix("api/DigitalPal/v1/RawMaterialConsumption")]
    public class RawMaterialConsumptionController : ApiController
    {
        public IRawMaterialConsumptionRepository RawMaterialConsumptionRepository;

        [Route("{id}")]
        [ResponseType(typeof(RawMaterialConsumption))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(RawMaterialConsumptionRepository.GetRawMaterialConsumption(id));
        }

        [ResponseType(typeof(RawMaterialConsumption))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(RawMaterialConsumptionRepository.GetAll());
        }

        [ResponseType(typeof(RawMaterialConsumption))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(RawMaterialConsumption[] RawMaterialConsumption)
        {
            return Ok(RawMaterialConsumptionRepository.AddRawMaterialConsumptions(RawMaterialConsumption));
        }

        [ResponseType(typeof(RawMaterialConsumption))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(RawMaterialConsumption[] RawMaterialConsumption)
        {
            return Ok(RawMaterialConsumptionRepository.UpdateRawMaterialConsumptions(RawMaterialConsumption));
        }

        [ResponseType(typeof(RawMaterialConsumption))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(RawMaterialConsumptionRepository.DeleteRawMaterialConsumptions(id));
        }
    }
}
