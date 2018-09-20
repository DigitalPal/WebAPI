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
    [RoutePrefix("api/DigitalPal/v1/ProductionDetails")]
    public class ProductionDetailsController : ApiController
    {
        public IProductionDetailsRepository ProductionDetailsRepository;

        [Route("{id}")]
        [ResponseType(typeof(ProductionDetails))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(ProductionDetailsRepository.GetProductionDetails(id));
        }

        [ResponseType(typeof(ProductionDetails))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(ProductionDetailsRepository.GetAll());
        }

        [ResponseType(typeof(ProductionDetails))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(ProductionDetails[] ProductionDetails)
        {
            return Ok(ProductionDetailsRepository.AddProductionDetails(ProductionDetails));
        }


        [ResponseType(typeof(ProductionDetails))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(ProductionDetails[] ProductionDetails)
        {
            return Ok(ProductionDetailsRepository.UpdateProductionDetails(ProductionDetails));
        }

        [ResponseType(typeof(ProductionDetails))]
        [HttpDelete]
        [Route("")]
        public IHttpActionResult Delete(ProductionDetails[] ProductionDetails)
        {
            return Ok(ProductionDetailsRepository.DeleteProductionDetails(ProductionDetails));
        }
    }
}
