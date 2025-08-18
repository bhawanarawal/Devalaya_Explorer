using Devalaya.Explorer.DataAccess.Entities;

namespace Devalaya.Explorer.Web.Models;

public class HomePageModel
{
    public List<Temple> Temples { get; set; }
    public List<Event> Events { get; set; }
}
