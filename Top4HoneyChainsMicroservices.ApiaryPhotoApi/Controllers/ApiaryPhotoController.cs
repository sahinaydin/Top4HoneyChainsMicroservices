using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Top4HoneyChainsMicroservices.ApiaryPhotoApi.Helpers;
using Top4HoneyChainsMicroservices.Entities.Models;

namespace Top4HoneyChainsMicroservices.ApiaryPhotoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiaryPhotoController : ControllerBase
    {
        private ImageWriter imageWriter = new ImageWriter();

        [HttpPost]
        public Task<string> UploadSaveImage(IFormFile file, ApiaryPhoto model)
        {
            return imageWriter.WriteFile(file, model.ApiaryId);
        }
    }
}
