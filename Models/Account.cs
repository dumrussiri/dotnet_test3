namespace dotnet_3.Models;

public class Account
{
    public string? UAccID { get; set; }
    public string? UAccUsername { get; set; }
    public DateTime CreateDateTime { get; set; } = DateTime.Now;
}