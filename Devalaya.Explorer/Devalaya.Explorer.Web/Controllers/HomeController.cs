﻿using Microsoft.AspNetCore.Mvc;

namespace Devalaya.Explorer.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult About()
    {
        return View();
    }
    public IActionResult ChatBot()
    {
        return View();
    }
}
