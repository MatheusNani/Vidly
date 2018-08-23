using System.Web;
using System.Web.Mvc;

namespace Vidly
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());

			// add Authentication to all pages.
			//to be able to see the home page, add [AllowAnonymous] in the HomeController.
			filters.Add(new AuthorizeAttribute());
			filters.Add(new RequireHttpsAttribute());
		}
	}
}
