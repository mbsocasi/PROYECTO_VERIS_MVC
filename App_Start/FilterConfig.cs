using System.Web;
using System.Web.Mvc;

namespace PROYECTO_VERIS_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new Filtros.Filtro());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
