using System.Web;
using System.Web.Mvc;

namespace Timer_LKS_Hotel_API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
