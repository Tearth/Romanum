using System.Web.Mvc;
using App.MVC.Filters;

namespace App.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ValidateModelStateAttribute());
        }
    }
}