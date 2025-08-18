namespace Devalaya.Explorer.DataAccess.Entities;

public class BaseModel
{
    public DateTime? CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModiefiedDate { get; set; }
    public string? LastModiefiedBy{ get; set; }
}
