using System.Diagnostics;
using Devalaya.Explorer.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Devalaya.Explorer.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
