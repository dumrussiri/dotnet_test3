using System.ComponentModel.DataAnnotations;

namespace dotnet_3.Models;
public class Category
{
    [Key]
    public string? UAccID { get; set; }
    [Required]
    public string? UAccUsername { get; set; }
    public DateTime CreateDateTime {get; set; } = DateTime.Now;
}