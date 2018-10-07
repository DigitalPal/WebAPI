using DigitalPal.BusinessLogic.Interface;
using DigitalPal.Entities;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalPal.WebAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/DigitalPal/v1/Product")]
    public class ProductController : ApiController
    {
        public IProductRepository ProductRepository;

        [Route("{id}")]
        [ResponseType(typeof(Product))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(ProductRepository.GetProduct(id));
        }

        [ResponseType(typeof(Product))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(ProductRepository.GetAll());
        }

        [ResponseType(typeof(Product))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(Product[] Product)
        {
            return Ok(ProductRepository.AddProducts(Product));
        }

        [ResponseType(typeof(Product))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(Product[] Product)
        {
            return Ok(ProductRepository.UpdateProducts(Product));
        }

        [ResponseType(typeof(Product))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(ProductRepository.DeleteProducts(id));
        }
    }
}
