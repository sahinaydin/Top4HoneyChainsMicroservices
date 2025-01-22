using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Repository.Concrete;

namespace Top4HoneyChainsMicroservices.BeekeeperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeekeepersController : ControllerBase
    {
        BeekeepersConcrete bc = new BeekeepersConcrete();

        [HttpGet]
        public IEnumerable<Beekeeper> Get()
        {
            return bc.GetAll();
        }
        [HttpGet("{identitynumber}")]
        public ActionResult Get(string identitynumber)
        {
            try
            {
                if (identitynumber != null)
                {
                    return Ok(bc.GetByIdentityNumber(identitynumber));
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
        public ActionResult Post(Beekeeper model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bc.Add(model);
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
        public ActionResult Put(Beekeeper model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bc.Update(model);
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
        public ActionResult Delete(Guid? id)
        {
            try
            {
                if (id != null)
                {
                    bc.DeleteByGuidId((Guid)id);
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
