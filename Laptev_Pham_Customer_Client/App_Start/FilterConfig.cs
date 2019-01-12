using System.Web;
using System.Web.Mvc;

namespace Laptev_Pham_Customer_Client
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
