using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top4HoneyChainsMicroservices.Entities.ViewModels
{
	public class HoneyTestResultViewModel
	{
		public int HoneyTestIresultd { get; set; }

		public int HoneyTestId { get; set; }

		public int? HoneyTestStandardItemId { get; set; }

		public string? HoneyTestItemValue { get; set; }

		public string? HoneyTestItemTitle { get; set; }

		public string? HoneyTestItemDesc { get; set; }

		public string? ReferenceRangeValue { get; set; }

		public string? HoneyTestItemUnit { get; set; }
	}
}
