using System.ComponentModel.DataAnnotations;

namespace dotnet_3.Models;
public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public DateTime CreateDateTime {get; set; } = DateTime.Now;
}