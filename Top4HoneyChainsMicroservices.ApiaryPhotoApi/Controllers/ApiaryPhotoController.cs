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
					response = imageWriter.UploadImage(model.File, model);
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

		[HttpDelete]
		[Route("RemovePhoto/{id}")]
		public Response DeleteApiaryPhoto(int? id)
		{
			Response response = new Response();
			try
			{
				if (id != null)
				{
					var photo = _context.ApiaryPhotos.Find(id);
					if (photo != null)
					{
						_context.ApiaryPhotos.Remove(photo);
						_context.SaveChanges();
						response = imageWriter.DeleteImage(photo.ApiaryId.ToString(), photo.Photo);
					}
					else
					{
						response.StatusCode = (int)HttpStatusCode.NotImplemented;
						response.ErrorMessage = "The photo is not found!";
					}
				}
				else
				{
					response.StatusCode = (int)HttpStatusCode.NotImplemented;
					response.ErrorMessage = "The photo is not valid!";
				}
			}
			catch (Exception ex)
			{
				response.StatusCode = 200;
				response.ErrorMessage = ex.Message;
			}
			return response;
		}
	}
}
