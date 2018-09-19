﻿using Autofac.Extras.DynamicProxy;
using DigitalPal.BusinessLogic.Interface;
using DigitalPal.Common.LogUtils;
using DigitalPal.Entities;
using System.Web.Http;
using System.Web.Http.Description;

namespace DigitalPal.WebAPI.Controllers
{
    //[Authorize]
    //[Intercept(typeof(CallLogger))]
    [RoutePrefix("api/DigitalPal/v1/DispatchDetails")]
    public class DispatchDetailsController : ApiController
    {
        public IDispatchDetailsRepository DispatchDetailsRepository;

        [Route("{id}")]
        [ResponseType(typeof(DispatchDetails))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(DispatchDetailsRepository.GetDispatchDetails(id));
        }

        [ResponseType(typeof(DispatchDetails))]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(DispatchDetailsRepository.GetAll());
        }

        [ResponseType(typeof(DispatchDetails))]
        [HttpPost]
        public IHttpActionResult Save(DispatchDetails[] DispatchDetails)
        {
            return Ok(DispatchDetailsRepository.AddDispatchDetails(DispatchDetails));
        }

        [ResponseType(typeof(DispatchDetails))]
        [HttpDelete]
        public IHttpActionResult Delete(DispatchDetails[] DispatchDetails)
        {
            return Ok(DispatchDetailsRepository.DeleteDispatchDetails(DispatchDetails));
        }
    }
}
