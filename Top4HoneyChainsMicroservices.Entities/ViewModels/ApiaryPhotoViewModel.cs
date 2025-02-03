using Microsoft.AspNetCore.Http;

namespace Top4HoneyChainsMicroservices.Entities.ViewModels
{
	public class ApiaryPhotoViewModel
	{
		public int PhotoId { get; set; }

		public int? ApiaryId { get; set; }

		public string? PhotoDesc { get; set; }

		public DateTime? CreatedDate { get; set; }

		public int? ProductionPeriodId { get; set; }

		public bool? Approved { get; set; }

		public string? PhotoFileName { get; set; }

		public string? ContentType { get; set; }
		public required IFormFile File { get; set; }
	}
}
