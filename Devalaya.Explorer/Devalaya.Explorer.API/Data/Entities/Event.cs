namespace Devalaya.Explorer.Web.Data.Entities;

public class Event
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public DateTime EventDate { get; set; }
    public string Contact { get; set; } = string.Empty;

    public Temple? Temple { get; set; }
    public int? TempleId { get; set; }
}
