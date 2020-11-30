using System.Web;
using System.Web.Mvc;

namespace Trabalho_Login_Encriptado
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
