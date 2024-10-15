using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Repository.Concrete;

namespace Top4HoneyChainsMicroservices.HoneyTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoneyTestsController : ControllerBase
    {
        HoneyTestConcrete htc = new HoneyTestConcrete();
        [HttpGet]
        public IEnumerable<HoneyTest> Get()
        {
            return htc.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult Get(int? id)
        {
            try
            {
                if (id != null)
                {
                    return Ok(htc.GetById((int)id));
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
        public ActionResult Post(HoneyTest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    htc.Add(model);
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
        public ActionResult Put(HoneyTest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    htc.Update(model);
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
                    htc.Delete((int)id);
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
