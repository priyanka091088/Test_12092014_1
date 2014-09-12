using MvcIoC.Filters;
using System.Web;
using System.Web.Mvc;

namespace MvcIoC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //Adds DateTime
            filters.Add(DependencyResolver.Current.GetService<DebugFilter>());
        }
    }
}