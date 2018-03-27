using System.Web;
using System.Web.Mvc;

namespace Calculator_example___TDD_and_Moq
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
