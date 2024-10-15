using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Repository.Concrete;

namespace Top4HoneyChainsMicroservices.ApiaryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        DiseaseConcrete dc = new DiseaseConcrete();
        [HttpGet]
        public IEnumerable<Disease> Get()
        {
            return dc.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult Get(int? id)
        {
            try
            {
                if (id != null)
                {
                    return Ok(dc.GetById((int)id));
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
        public ActionResult Post(Disease model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dc.Add(model);
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
        public ActionResult Put(Disease model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dc.Update(model);
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
                    dc.Delete((int)id);
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
