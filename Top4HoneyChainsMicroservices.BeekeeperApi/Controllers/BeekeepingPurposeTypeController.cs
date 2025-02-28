﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Repository.Concrete;

namespace Top4HoneyChainsMicroservices.BeekeeperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeekeepingPurposeTypeController : ControllerBase
    {
        BeekeepingPurposeTypeConcrete bptc = new BeekeepingPurposeTypeConcrete();

        [HttpGet]
        public IEnumerable<BeekeepingPurposeType> Get()
        {
            return bptc.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult Get(int? id)
        {
            try
            {
                if (id != null)
                {
                    return Ok(bptc.GetById((int)id));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public ActionResult Post(BeekeepingPurposeType model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bptc.Add(model);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public ActionResult Put(BeekeepingPurposeType model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bptc.Update(model);
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id != null)
                {
                    bptc.Delete((int)id);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
