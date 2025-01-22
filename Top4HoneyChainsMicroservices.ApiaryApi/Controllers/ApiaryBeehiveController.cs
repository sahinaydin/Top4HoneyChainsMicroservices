using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Repository.Concrete;

namespace Top4HoneyChainsMicroservices.ApiaryApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApiaryBeehiveController : ControllerBase
	{
		ApiaryConcrete ac = new ApiaryConcrete();

		[HttpGet("{beekeperid}")]
		public List<Apiary> GetBeekeeperApiary(Guid? beekeperid)
		{
			try
			{
				if (beekeperid != null)
				{
					return ac.GetApiaryByBeekeeperId((Guid)beekeperid);
				}
				else
				{
					return null;
				}
			}
			catch (Exception e)
			{
				return null;
			}
		}
	}
}
