using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Repository.Concrete;

namespace Top4HoneyChainsMicroservices.ApiaryHoneyProductionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiaryHoneyProductionsController : ControllerBase
    {
        ApiaryHoneyProductionConcrete ahpc = new ApiaryHoneyProductionConcrete();
        [HttpGet]
        public IEnumerable<ApiaryHoneyProduction> Get()
        {
            return ahpc.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            try
            {
                if (id != null)
                {
                    return Ok(ahpc.GetById((int)id));
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
        public IActionResult Post(ApiaryHoneyProduction model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ahpc.Add(model);
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
        public IActionResult Put(ApiaryHoneyProduction model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ahpc.Update(model);
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
        public IActionResult Delete(int? id)
        {
            try
            {
                if (id != null)
                {
                    ahpc.Delete((int)id);
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
