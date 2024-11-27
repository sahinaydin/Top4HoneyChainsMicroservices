using System.Web;
using System.Web.Mvc;

namespace Top4HoneyChainsMicroservices.AuthenticationApi
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
