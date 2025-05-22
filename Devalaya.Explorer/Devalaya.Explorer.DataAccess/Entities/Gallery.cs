namespace Devalaya.Explorer.DataAccess.Entities;

public class Gallery
{
    public int Id { get; set; }
    public string ImagePath { get; set; } = string.Empty;

    public Temple? Temple { get; set; }
    public int TempleId { get; set; }
}
