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
    [RoutePrefix("api/DigitalPal/v1/Production")]
    public class ProductionController : ApiController
    {
        public IProductionRepository ProductionRepository;

        [Route("{id}")]
        [ResponseType(typeof(Production))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(ProductionRepository.GetProduction(id));
        }

        [ResponseType(typeof(Production))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(ProductionRepository.GetAll());
        }

        [ResponseType(typeof(Production))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(Production[] Production)
        {
            return Ok(ProductionRepository.AddProduction(Production));
        }


        [ResponseType(typeof(Production))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(Production[] Production)
        {
            return Ok(ProductionRepository.UpdateProduction(Production));
        }

        [ResponseType(typeof(Production))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(ProductionRepository.DeleteProduction(id));
        }

        [Route("Search")]
        [ResponseType(typeof(Production))]
        [HttpPost]
        public IHttpActionResult Search(ProductionReport productionReport)
        {
            return Ok(ProductionRepository.Search(productionReport));
        }
    }
}
