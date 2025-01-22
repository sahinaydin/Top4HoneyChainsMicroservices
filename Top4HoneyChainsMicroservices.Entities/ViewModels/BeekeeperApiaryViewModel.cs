using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top4HoneyChainsMicroservices.Entities.ViewModels
{
	public class BeekeeperApiaryViewModel
	{
		public int ApiaryId { get; set; }

		public Guid? BeekeeperId { get; set; }

		public Guid? ApiaryQrcode { get; set; }

		public string ApiaryTitle { get; set; } = null!;

		public short NumberOfBeehives { get; set; }

		public decimal? LocationLatitude { get; set; }

		public decimal? LocationLongitude { get; set; }

		public int? LocationType { get; set; }

		public int? ProductionPeriodId { get; set; }
		public string FirstName { get; set; } = null!;

		public string LastName { get; set; } = null!;
	}
}
