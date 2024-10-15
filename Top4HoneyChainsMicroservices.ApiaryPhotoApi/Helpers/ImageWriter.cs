using System.Net;
using Top4HoneyChainsMicroservices.Entities.Models;
using Top4HoneyChainsMicroservices.Entities.ViewModels;

namespace Top4HoneyChainsMicroservices.ApiaryPhotoApi.Helpers
{
    public class ImageWriter
    {
        public async Task<string> UploadImage(IFormFile file, ApiaryPhoto model)
        {
            try
            {
                if (CheckIfImageFile(file))
                {
                    return await WriteFile(file, model.ApiaryId);
                }
                else
                {
                    return "Invalid image file";
                }
            }
            catch
            {
                return "Invalid image file";
            }
        }

        /// <summary>
        /// Method to check if file is image file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method to write file onto the disk
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<string> WriteFile(IFormFile file, int apiaryId)
        {
            try
            {
                string fileName;
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = Guid.NewGuid().ToString() + extension; //Create a new Name for the file due to security reasons.
                var path = Path.Combine(Directory.GetCurrentDirectory(), "HazelnutImages", apiaryId.ToString(), fileName);
                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }
                // Create single instance of sample data from first line of dataset for model input
                var imageBytes = File.ReadAllBytes(path);
                return "Success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
