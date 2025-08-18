using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devalaya.Explorer.DataAccess.Entities;
public class Temple: BaseModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Deity { get; set; } = string.Empty;
    [NotMapped]
    public IFormFile? Image { get; set; }
    public string? ImagePath { get; set; }

    public string? Slug { get; set; }
    public DateTime? MadeYear { get; set; } 
    public List<Event>? Events { get; set; }
    public List<Favourite>? Favourites { get; set; }
    public List<Gallery>? Galleries { get; set; }
    public List<Review>? Reviews { get; set; }

}
