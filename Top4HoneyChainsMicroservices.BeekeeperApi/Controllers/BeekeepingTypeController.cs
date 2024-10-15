using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Repository.Concrete;

namespace Top4HoneyChainsMicroservices.BeekeeperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeekeepingTypeController : ControllerBase
    {
        BeekeepingTypeConcrete btc = new BeekeepingTypeConcrete();

        [HttpGet]
        public IEnumerable<BeekeepingType> Get()
        {
            return btc.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult Get(int? id)
        {
            try
            {
                if (id != null)
                {
                    return Ok(btc.GetById((int)id));
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
        public ActionResult Post(BeekeepingType model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    btc.Add(model);
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
        public ActionResult Put(BeekeepingType model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    btc.Update(model);
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
                    btc.Delete((int)id);
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
