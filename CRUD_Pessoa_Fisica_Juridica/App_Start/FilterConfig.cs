using System.Web;
using System.Web.Mvc;

namespace CRUD_Pessoa_Fisica_Juridica
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
