using Microsoft.AspNetCore.Mvc;

namespace Devalaya.Explorer.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
