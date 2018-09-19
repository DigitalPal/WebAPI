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
    [RoutePrefix("api/DigitalPal/v1/PriceDetails")]
    public class PriceDetailsController : ApiController
    {
        public IPriceDetailsRepository PriceDetailsRepository;

        [Route("{id}")]
        [ResponseType(typeof(PriceDetails))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(PriceDetailsRepository.GetPriceDetails(id));
        }

        [ResponseType(typeof(PriceDetails))]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(PriceDetailsRepository.GetAll());
        }

        [ResponseType(typeof(PriceDetails))]
        [HttpPost]
        public IHttpActionResult Save(PriceDetails[] PriceDetails)
        {
            return Ok(PriceDetailsRepository.AddPriceDetails(PriceDetails));
        }

        [ResponseType(typeof(PriceDetails))]
        [HttpDelete]
        public IHttpActionResult Delete(PriceDetails[] PriceDetails)
        {
            return Ok(PriceDetailsRepository.DeletePriceDetails(PriceDetails));
        }
    }
}
