using Devalaya.Explorer.DataAccess.Repositories;
using Devalaya.Explorer.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Devalaya.Explorer.Web.Controllers;

public class HomeController(ITemplesRepository templesRepo,IEventsRepository eventsRepo) : Controller
{
    private readonly ITemplesRepository _templesRepository = templesRepo;
    private readonly IEventsRepository _eventsRepository = eventsRepo;
    public async Task<IActionResult> Index()
    {
        var temples = await _templesRepository.GetTemplesAsync(4);
        var events = await _eventsRepository.GetAllEventsAsync();
        var homeModel= new HomePageModel
        {
            Temples = temples.ToList(),
            Events = events.ToList()
        };
        return View(homeModel);
    }
    public IActionResult About()
    {
        return View();
    }
    public IActionResult ChatBot()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }
}
