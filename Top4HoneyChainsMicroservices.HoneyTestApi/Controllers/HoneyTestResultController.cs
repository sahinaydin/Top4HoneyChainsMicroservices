using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Entities.ViewModels;
using Top4HoneyChainsMicroservices.Repository.Concrete;

namespace Top4HoneyChainsMicroservices.HoneyTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoneyTestResultController : ControllerBase
    {
        HoneyTestResultConcrete htr = new HoneyTestResultConcrete();
        [HttpGet]
        public IEnumerable<HoneyTestResult> Get()
        {
            return htr.GetAll();
        }
        [HttpGet("{honeytestid}")]
        public List<HoneyTestResultViewModel> Get(int honeytestid)
        {
            try
            {
                using (var db = new Top4honeyChainsDbContext())
                {
                    var result = (
						from htr in db.HoneyTestResults
                        join htsi in db.HoneyTestStandardItems on htr.HoneyTestStandardItemId equals htsi.HoneyTestStandardItemId
						where htr.HoneyTestId == honeytestid
                        select new HoneyTestResultViewModel
                        {
                            HoneyTestId = htr.HoneyTestId,
							HoneyTestIresultd = htr.HoneyTestIresultd,
							HoneyTestStandardItemId = htr.HoneyTestStandardItemId,
							HoneyTestItemValue = htr.HoneyTestItemValue,
                            HoneyTestItemTitle = htsi.HoneyTestItemTitle,
							HoneyTestItemUnit = htsi.HoneyTestItemUnit,
							HoneyTestItemDesc = htsi.HoneyTestItemDesc,
							ReferenceRangeValue = htsi.ReferenceRangeValue

						}).ToList();

                    return result;
				}
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpPost]
        public ActionResult Post(HoneyTestResult model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    htr.Add(model);
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
        public ActionResult Put(HoneyTestResult model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    htr.Update(model);
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
                    htr.Delete((int)id);
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
