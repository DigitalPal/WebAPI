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
    [RoutePrefix("api/DigitalPal/v1/Plant")]
    public class PlantController : ApiController
    {
        public IPlantRepository PlantRepository;

        [Route("{id}")]
        [ResponseType(typeof(Plant))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(PlantRepository.GetPlant(id));
        }

        [ResponseType(typeof(Plant))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(PlantRepository.GetAll());
        }

        [ResponseType(typeof(Plant))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(Plant[] Plant)
        {
            return Ok(PlantRepository.AddPlants(Plant));
        }

        [ResponseType(typeof(Plant))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(Plant[] Plant)
        {
            return Ok(PlantRepository.UpdatePlants(Plant));
        }

        [ResponseType(typeof(Plant))]
        [HttpDelete]
        [Route("")]
        public IHttpActionResult Delete(Plant[] Plant)
        {
            return Ok(PlantRepository.DeletePlants(Plant));
        }
    }
}
