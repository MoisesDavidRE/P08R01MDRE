using System.Web;
using System.Web.Mvc;

namespace P08R01MVC_Plagas_MDRE
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
