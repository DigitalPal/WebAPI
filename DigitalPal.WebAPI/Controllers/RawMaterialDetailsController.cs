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
    [RoutePrefix("api/DigitalPal/v1/RawMaterialDetails")]
    public class RawMaterialDetailsController : ApiController
    {
        public IRawMaterialDetailsRepository RawMaterialDetailsRepository;

        [Route("{id}")]
        [ResponseType(typeof(RawMaterialDetails))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(RawMaterialDetailsRepository.GetRawMaterialDetails(id));
        }

        [ResponseType(typeof(RawMaterialDetails))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(RawMaterialDetailsRepository.GetAll());
        }

        [ResponseType(typeof(RawMaterialDetails))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(RawMaterialDetails[] RawMaterialDetails)
        {
            return Ok(RawMaterialDetailsRepository.AddRawMaterialDetails(RawMaterialDetails));
        }

        [ResponseType(typeof(RawMaterialDetails))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(RawMaterialDetails[] RawMaterialDetails)
        {
            return Ok(RawMaterialDetailsRepository.UpdateRawMaterialDetails(RawMaterialDetails));
        }

        [ResponseType(typeof(RawMaterialDetails))]
        [HttpDelete]
        [Route("")]
        public IHttpActionResult Delete(RawMaterialDetails[] RawMaterialDetails)
        {
            return Ok(RawMaterialDetailsRepository.DeleteRawMaterialDetails(RawMaterialDetails));
        }
    }
}
