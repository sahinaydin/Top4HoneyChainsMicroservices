using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Entities.ViewModels;
using Top4HoneyChainsMicroservices.Repository.Concrete;

namespace Top4HoneyChainsMicroservices.HoneyTestApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApiaryHoneyTestController : ControllerBase
	{
		[HttpGet("{apiaryid}")]
		public List<HoneyTestViewModel> Get(int apiaryid)
		{
			try
			{
				using (var db = new Top4honeyChainsDbContext())
				{
					var result = (from ht in db.HoneyTests
								  join hts in db.HoneyTestStandards on ht.HoneyTestStandardId equals hts.StandardId
								  join a in db.Apiaries on ht.ApiaryId equals a.ApiaryId
								  where ht.ApiaryId == apiaryid
								  select new HoneyTestViewModel
								  {
									  HoneyTestId = ht.HoneyTestId,
									  HoneyTestTitle = ht.HoneyTestTitle,
									  HoneyTestDatetime = ht.HoneyTestDatetime,
									  ApiaryId = ht.ApiaryId,
									  ApiaryTitle = a.ApiaryTitle,
									  HoneyTestStandardId = ht.HoneyTestStandardId,
									  StandardTitle = hts.StandardTitle,
									  StandardDescription = hts.StandardDescription
								  }).ToList();
					return result;
				}
			}
			catch (Exception ex)
			{
				return null;
			}

		}
	}
}
