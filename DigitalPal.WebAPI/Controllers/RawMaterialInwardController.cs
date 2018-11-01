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


        [Route("Search")]
        [ResponseType(typeof(RawMaterialInward))]
        [HttpGet]
        public IHttpActionResult Search(RawMaterialInward RawMaterialInward)
        {
            return Ok(RawMaterialInwardRepository.Search(RawMaterialInward));
        }

        [ResponseType(typeof(RawMaterialInward))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(RawMaterialInwardRepository.GetAll());
        }

        [ResponseType(typeof(RawMaterialInward))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(RawMaterialInward[] RawMaterialInward)
        {
            return Ok(RawMaterialInwardRepository.AddRawMaterialInwards(RawMaterialInward));
        }

        [ResponseType(typeof(RawMaterialInward))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(RawMaterialInward[] RawMaterialInward)
        {
            return Ok(RawMaterialInwardRepository.UpdateRawMaterialInwards(RawMaterialInward));
        }

        [ResponseType(typeof(RawMaterialInward))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(RawMaterialInwardRepository.DeleteRawMaterialInwards(id));
        }
    }
}
