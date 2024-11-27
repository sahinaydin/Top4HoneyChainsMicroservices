using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Net;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Entities.ViewModels;

namespace Top4HoneyChainsMicroservices.ApiaryPhotoApi.Helpers
{
    public class ImageWriter
    {
		private readonly Top4honeyChainsDbContext _context = new Top4honeyChainsDbContext();

		public Response UploadImage(IFormFile file, ApiaryPhotoViewModel model)
		{
			if (CheckIfImageFile(file))
			{
				return WriteSaveFile(file, model);
			}
			return new Response { StatusCode = 100, ErrorMessage = "Invalid image file" };
		}


		private bool CheckIfImageFile(IFormFile file)
		{
			byte[] fileBytes;
			using (var ms = new MemoryStream())
			{
				file.CopyTo(ms);
				fileBytes = ms.ToArray();
			}
			return WriterHelper.GetImageFormat(fileBytes) != WriterHelper.ImageFormat.unknown;
		}

		public Response WriteSaveFile(IFormFile file, ApiaryPhotoViewModel model)
		{
			try
			{
				string path = string.Empty;
				string fileName;
				var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
				fileName = Guid.NewGuid().ToString() + extension;
				path = Path.Combine(Directory.GetCurrentDirectory(), "ApiaryPhotos", model.ApiaryId.ToString());
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "ApiaryPhotos", model.ApiaryId.ToString()));
					path = Path.Combine(Directory.GetCurrentDirectory(), "ApiaryPhotos", model.ApiaryId.ToString(), fileName);
				}
				else
				{
					path = Path.Combine(Directory.GetCurrentDirectory(), "ApiaryPhotos", model.ApiaryId.ToString(), fileName);

				}

				using (var bits = new FileStream(path, FileMode.Create))
				{
					file.CopyToAsync(bits);
				}

				var imageBytes = File.ReadAllBytes(path);


				_context.ApiaryPhotos.Add(new ApiaryPhoto
				{
					ApiaryId = (int)model.ApiaryId,
					Photo = fileName,
					PhotoDesc = model.PhotoDesc,
					CreatedDate = model.CreatedDate,
					ProductionPeriodId = model.ProductionPeriodId,
					Approved = model.Approved
				});
				_context.SaveChanges();

				return new Response { StatusCode = 200, ErrorMessage = "Success!" };
			}
			catch (Exception e)
			{
				return new Response { StatusCode = 100, ErrorMessage = e.Message };
			}
		}

		public Response DeleteImage(string directoryName,string fileName)
		{
			try
			{
				string path = Path.Combine(Directory.GetCurrentDirectory(), "ApiaryPhotos",directoryName, fileName);
				if (File.Exists(path))
				{
					File.Delete(path);
					return new Response { StatusCode = 200, ErrorMessage = "Success!" };
				}
				else
				{
					return new Response { StatusCode = 100, ErrorMessage = "File not found!" };
				}
			}
			catch (Exception e)
			{
				return new Response { StatusCode = 100, ErrorMessage = e.Message };
			}
		}
	}
}
