using Microsoft.AspNetCore.Mvc;
using System.Net;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Entities.ViewModels;

namespace Top4HoneyChainsMicroservices.ApiaryPhotoApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApiaryPhotoController : ControllerBase
	{
		private readonly Top4honeyChainsDbContext _context = new Top4honeyChainsDbContext();

		[HttpGet("{apiaryid}")]
		public List<ApiaryPhoto> Get(int apiaryid)
		{
			try
			{
				if (apiaryid != null)
				{
					return _context.ApiaryPhotos.Where(a => a.ApiaryId == apiaryid).ToList();
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

		[HttpPost("upload")]
		[Consumes("multipart/form-data")]
		public async Task<IActionResult> UploadPhoto([FromForm] ApiaryPhotoViewModel apiaryPhotoViewModel)
		{
			if (apiaryPhotoViewModel.File == null || apiaryPhotoViewModel.File.Length == 0)
			{
				return BadRequest("No file uploaded.");
			}

			using (var memoryStream = new MemoryStream())
			{
				await apiaryPhotoViewModel.File.CopyToAsync(memoryStream);
				var photo = new ApiaryPhoto
				{
					ApiaryId = apiaryPhotoViewModel.ApiaryId,
					PhotoDesc = apiaryPhotoViewModel.PhotoDesc,
					CreatedDate = DateTime.UtcNow,
					ProductionPeriodId = apiaryPhotoViewModel.ProductionPeriodId,
					Approved = false,
					ImageData = memoryStream.ToArray(),
					PhotoFileName = apiaryPhotoViewModel.File.FileName,
					ContentType = apiaryPhotoViewModel.File.ContentType
				};

				_context.ApiaryPhotos.Add(photo);
				await _context.SaveChangesAsync();

				return Ok();
			}
		}

		[HttpDelete]
		[Route("{id}")]
		public ActionResult Delete(int? id)
		{
			try
			{
                if (id != null)
                {
					var photo = _context.ApiaryPhotos.Find(id);
					if (photo != null)
					{
						_context.ApiaryPhotos.Remove(photo);
						_context.SaveChanges();
						return Ok();
					}
					else
					{
						return BadRequest(ModelState);
					}
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
	}
}
