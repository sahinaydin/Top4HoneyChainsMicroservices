using System;
using System.Net;
using System.Web.Http;
using System.Web.Security;
using Top4HoneyChainsMicroservices.AuthenticationApi.Models;
using static Top4HoneyChainsMicroservices.AuthenticationApi.Models.AccountModel;
using System.Linq;

namespace Top4HoneyChainsMicroservices.AuthenticationApi.Controllers
{
	public class AccountController : ApiController
	{
		[HttpGet]
		public BeekeeperViewModel Get(string username, string password)
		{
			if (ModelState.IsValid)
			{
				if (Membership.ValidateUser(username, password))
				{
					var user = Membership.GetUser(username);
					var beekeeper = new BeekeeperViewModel();
					using (var db = new TOP4HoneyChainsDbEntities())
					{
						var result = (from b in db.Beekeepers
									   join el in db.BeekeeperEducationLevels on b.EducationLevel equals el.LevelId
									   join pt in db.BeekeepingPurposeTypes on b.BeekeepingPurposeType equals pt.TypeId
									   join bt in db.BeekeepingTypes on b.BeekeepingType equals bt.TypeId
									   where b.BeekeeperId == (Guid)user.ProviderUserKey
									   select new BeekeeperViewModel
									   {
										   BeekeeperId = b.BeekeeperId,
										   ProfilePhoto = b.ProfilePhoto,
										   FirstName = b.FirstName,
										   LastName = b.LastName,
										   IdentityNumber = b.IdentityNumber,
										   BirthDate = b.BirthDate,
										   ExperienceTime = b.ExperienceTime,
										   EducationLevel = el.LevelId,
										   EducationLevelTitle = el.LevelTitle,
										   PhoneNumber = b.PhoneNumber,
										   AssociationMembership = b.AssociationMembership,
										   BusinessNumber = b.BusinessNumber,
										   BeekeepingPurposeType = pt.TypeId,
										   BeekeepingPurposeTypeTitle = pt.TypeTitle,
										   BeekeepingType = bt.TypeId,
										   BeekeepingTypeTitle = bt.TypeTitle
									   }).FirstOrDefault();
						return result;
					}
				}
				return null;
			}
			else
			{
				return null;
			}
		}

		[HttpPut]
		public HttpStatusCode Put(ChangePasswordModel model)
		{
			if (ModelState.IsValid)
			{
				bool changePasswordSucceeded;
				try
				{
					MembershipUser currenuser = Membership.GetUser(model.UserName, true);
					changePasswordSucceeded = currenuser.ChangePassword(model.OldPassword, model.NewPassword);

				}
				catch (Exception ex)
				{
					changePasswordSucceeded = false;
				}
				if (changePasswordSucceeded)
				{
					return HttpStatusCode.OK;
				}
				else
				{
					return HttpStatusCode.InternalServerError;
				}
			}
			else
			{
				return HttpStatusCode.BadRequest;
			}
		}
	}
}
