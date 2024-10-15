using Microsoft.AspNetCore.Mvc;
using System.Net;
using Top4HoneyChainsMicroservices.ApiaryPhotoApi.Helpers;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Entities.ViewModels;

namespace Top4HoneyChainsMicroservices.ApiaryPhotoApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApiaryPhotoController : ControllerBase
	{
		private readonly Top4honeyChainsDbContext _context = new Top4honeyChainsDbContext();
		private ImageWriter imageWriter = new ImageWriter();

		[HttpPost]
		[Route("UploadPhoto")]
		public Response PostApiaryPhoto([FromForm] ApiaryPhotoViewModel model)
		{

			Response response = new Response();
			try
			{
				var imagecount = _context.ApiaryPhotos.Where(a => a.ApiaryId == model.ApiaryId).Count();
				if (imagecount < 10)
				{
					_context.ApiaryPhotos.Add(new ApiaryPhoto
					{
						ApiaryId = model.ApiaryId,
						Photo = model.Photo,
						PhotoDesc = model.PhotoDesc,
						CreatedDate = model.CreatedDate,
						ProductionPeriodId = model.ProductionPeriodId,
						Approved = model.Approved
					});
					_context.SaveChanges();
					response = imageWriter.UploadImage(model.File, model.ApiaryId.ToString());
				}
				else
				{
					response.StatusCode = (int)HttpStatusCode.NotImplemented;
					response.ErrorMessage = "Upload image limit 10!";
				}
			}
			catch (Exception ex)
			{
				response.StatusCode = 100;
				response.ErrorMessage = ex.Message;
			}
			return response;
		}
	}
}
