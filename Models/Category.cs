using System.ComponentModel.DataAnnotations;

namespace dotnet_3.Models;
public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? UAccID { get; set; }
    public string? UAccUsername { get; set; }
    public DateTime CreateDateTime {get; set; } = DateTime.Now;
}