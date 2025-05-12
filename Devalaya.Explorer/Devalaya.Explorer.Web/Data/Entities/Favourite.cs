namespace Devalaya.Explorer.Web.Data.Entities;

public class Favourite
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;

    public Temple? Temple { get; set; }
    public int TempleId { get; set; }

}
