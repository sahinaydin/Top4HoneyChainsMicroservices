using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Repository.Concrete;

namespace Top4HoneyChainsMicroservices.HoneyTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoneyTestStandardItemController : ControllerBase
    {
        HoneyTestStandardItemConcrete htsi = new HoneyTestStandardItemConcrete();
        [HttpGet]
        public IEnumerable<HoneyTestStandardItem> Get()
        {
            return htsi.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult Get(int? id)
        {
            try
            {
                if (id != null)
                {
                    return Ok(htsi.GetById((int)id));
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
        public ActionResult Post(HoneyTestStandardItem model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    htsi.Add(model);
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
        public ActionResult Put(HoneyTestStandardItem model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    htsi.Update(model);
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
                    htsi.Delete((int)id);
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
