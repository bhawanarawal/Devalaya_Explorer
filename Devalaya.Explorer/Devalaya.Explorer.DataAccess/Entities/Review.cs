namespace Devalaya.Explorer.DataAccess.Entities;


public class Review
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string CommentedBy { get; set; } = string.Empty;

    public Temple? Temple { get; set; }
    public int TempleId { get; set; }
}
