using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Repository.Concrete;

namespace Top4HoneyChainsMicroservices.ApiaryHoneyProductionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentMethodController : ControllerBase
    {
        TreatmentMethodConcrete tmc = new TreatmentMethodConcrete();
        [HttpGet]
        public IEnumerable<TreatmentMethod> Get()
        {
            return tmc.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            try
            {
                if (id != null)
                {
                    return Ok(tmc.GetById((int)id));
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
        public IActionResult Post(TreatmentMethod model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tmc.Add(model);
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
        public IActionResult Put(TreatmentMethod model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tmc.Update(model);
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
                    tmc.Delete((int)id);
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
