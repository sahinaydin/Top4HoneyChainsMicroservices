using System.Net;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Entities.ViewModels;

namespace Top4HoneyChainsMicroservices.ApiaryPhotoApi.Helpers
{
    public class ImageWriter
    {
		public Response UploadImage(IFormFile file, string apiaryid)
		{
			if (CheckIfImageFile(file))
			{
				return WriteFile(file, apiaryid);
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

		public Response WriteFile(IFormFile file, string apiaryid)
		{
			try
			{
				string path = string.Empty;
				string fileName;
				var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
				fileName = Guid.NewGuid().ToString() + extension;
				path = Path.Combine(Directory.GetCurrentDirectory(), "ApiaryPhotos", apiaryid);
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "ApiaryPhotos", apiaryid.ToString()));
					path = Path.Combine(Directory.GetCurrentDirectory(), "ApiaryPhotos", apiaryid, fileName);
				}
				else
				{
					path = Path.Combine(Directory.GetCurrentDirectory(), "ApiaryPhotos", apiaryid, fileName);

				}

				using (var bits = new FileStream(path, FileMode.Create))
				{
					file.CopyToAsync(bits);
				}

				var imageBytes = File.ReadAllBytes(path);
				return new Response { StatusCode = 200, ErrorMessage = "Success!" };
			}
			catch (Exception e)
			{
				return new Response { StatusCode = 100, ErrorMessage = e.Message };
			}
		}
	}
}
