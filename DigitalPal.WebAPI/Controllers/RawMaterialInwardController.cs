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
    [RoutePrefix("api/DigitalPal/v1/RawMaterialInward")]
    public class RawMaterialInwardController : ApiController
    {
        public IRawMaterialInwardRepository RawMaterialInwardRepository;

        [Route("{id}")]
        [ResponseType(typeof(RawMaterialInward))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(RawMaterialInwardRepository.GetRawMaterialInward(id));
        }

        [ResponseType(typeof(RawMaterialInward))]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(RawMaterialInwardRepository.GetAll());
        }

        [ResponseType(typeof(RawMaterialInward))]
        [HttpPost]
        public IHttpActionResult Save(RawMaterialInward[] RawMaterialInward)
        {
            return Ok(RawMaterialInwardRepository.AddRawMaterialInwards(RawMaterialInward));
        }

        [ResponseType(typeof(RawMaterialInward))]
        [HttpDelete]
        public IHttpActionResult Delete(RawMaterialInward[] RawMaterialInward)
        {
            return Ok(RawMaterialInwardRepository.DeleteRawMaterialInwards(RawMaterialInward));
        }
    }
}
