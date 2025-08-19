using System.Diagnostics;
using Devalaya.Explorer.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Devalaya.Explorer.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
