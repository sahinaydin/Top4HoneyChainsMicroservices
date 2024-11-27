using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top4HoneyChainsMicroservices.Entities.ViewModels
{
	public class BeekeeperViewModel
	{
		public Guid BeekeeperId { get; set; }
		public string ProfilePhoto { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string IdentityNumber { get; set; }
		public DateTime BirthDate { get; set; }
		public short ExperienceTime { get; set; }
		public int EducationLevel { get; set; }
		public string EducationLevelTitle { get; set; }
		public string PhoneNumber { get; set; }
		public string AssociationMembership { get; set; }
		public string BusinessNumber { get; set; }
		public int BeekeepingPurposeType { get; set; }
		public string BeekeepingPurposeTypeTitle { get; set; }
		public int BeekeepingType { get; set; }
		public string BeekeepingTypeTitle { get; set; }

	}
}
