using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class Usuario
{
    [Key]
    public  int UserId { get; set; }
    [Required]
    public string? UserName { get; set; } = string.Empty;
    [Required]
    public string? Password { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? PhoneNumber { get; set; }
    [Required]  
    public string? PhoneNumberConfirmed { get; set;}
    public int Id { get; internal set; }
}
