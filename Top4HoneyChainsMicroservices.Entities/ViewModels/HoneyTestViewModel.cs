using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top4HoneyChainsMicroservices.Entities.ViewModels
{
	public class HoneyTestViewModel
	{
		public int HoneyTestId { get; set; }

		public int? HoneyTestStandardId { get; set; }

		public string? StandardTitle { get; set; }

		public string? StandardDescription { get; set; }

		public int? ApiaryId { get; set; }

		public string ApiaryTitle { get; set; } = null!;

		public string? HoneyTestTitle { get; set; }

		public DateTime? HoneyTestDatetime { get; set; }
	}
}
