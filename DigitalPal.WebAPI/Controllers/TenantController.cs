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
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(tenantRepository.GetAll());
        }

        [ResponseType(typeof(Tenant))]
        [HttpPost]
        public IHttpActionResult Save(Tenant[] tenant)
        {
            return Ok(tenantRepository.Add(tenant));
        }

        [ResponseType(typeof(Tenant))]
        [HttpDelete]
        public IHttpActionResult Delete(Tenant[] tenant)
        {
            return Ok(tenantRepository.Delete(tenant));
        }
    }
}
