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
    [RoutePrefix("api/DigitalPal/v1/Dispatch")]
    public class DispatchController : ApiController
    {
        public IDispatchRepository DispatchRepository;

        [Route("{id}")]
        [ResponseType(typeof(Dispatch))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(DispatchRepository.GetDispatch(id));
        }

        [Route("Search")]
        [ResponseType(typeof(Dispatch))]
        [HttpPost]
        public IHttpActionResult Search(DispatchReport Dispatch)
        {
            return Ok(DispatchRepository.Search(Dispatch));
        }

        [ResponseType(typeof(Dispatch))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(DispatchRepository.GetAll());
        }

        [ResponseType(typeof(Dispatch))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(Dispatch[] Dispatch)
        {
            return Ok(DispatchRepository.AddDispatch(Dispatch));
        }

        [ResponseType(typeof(Dispatch))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(Dispatch[] Dispatch)
        {
            return Ok(DispatchRepository.UpdateDispatch(Dispatch));
        }

        [ResponseType(typeof(Dispatch))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(DispatchRepository.DeleteDispatch(id));
        }
    }
}
