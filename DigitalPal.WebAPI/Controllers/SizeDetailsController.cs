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
    [RoutePrefix("api/DigitalPal/v1/SizeDetails")]
    public class SizeDetailsController : ApiController
    {
        public ISizeDetailsRepository SizeDetailsRepository;

        [Route("{id}")]
        [ResponseType(typeof(SizeDetails))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(SizeDetailsRepository.GetSizeDetails(id));
        }

        [ResponseType(typeof(SizeDetails))]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(SizeDetailsRepository.GetAll());
        }

        [ResponseType(typeof(SizeDetails))]
        [HttpPost]
        public IHttpActionResult Save(SizeDetails[] SizeDetails)
        {
            return Ok(SizeDetailsRepository.AddSizeDetails(SizeDetails));
        }

        [ResponseType(typeof(SizeDetails))]
        [HttpDelete]
        public IHttpActionResult Delete(SizeDetails[] SizeDetails)
        {
            return Ok(SizeDetailsRepository.DeleteSizeDetails(SizeDetails));
        }
    }
}
