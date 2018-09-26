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
    [RoutePrefix("api/DigitalPal/v1/Tenant")]
    public class TenantController : ApiController
    {
        public ITenantRepository tenantRepository;

        [Route("{id}")]
        [ResponseType(typeof(Tenant))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(tenantRepository.Get(id));
        }

        [ResponseType(typeof(Tenant))]
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(tenantRepository.GetAll());
        }

        [ResponseType(typeof(Tenant))]
        [Route("")]
        [HttpPost]
        public IHttpActionResult Save(Tenant[] tenant)
        {
            return Ok(tenantRepository.Add(tenant));
        }

        [ResponseType(typeof(Tenant))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(Tenant[] tenant)
        {
            return Ok(tenantRepository.Update(tenant));
        }

        [ResponseType(typeof(Tenant))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(tenantRepository.Delete(id));
        }
    }
}
