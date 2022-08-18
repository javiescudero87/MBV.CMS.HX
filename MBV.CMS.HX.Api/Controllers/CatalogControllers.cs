using MBV.CMS.HX.Domain.Catalog;
using Microsoft.AspNetCore.Mvc;

namespace MBV.CMS.HX.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class CatalogControllers : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Actions()
        {
            return View(Catalog.Instance.RegisteredActions);
        }
    }
}
