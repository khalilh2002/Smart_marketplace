using System.ComponentModel.DataAnnotations;

namespace SmartMarketplace.Models;

public class User
{
  [Key]
  public int Id { get; set; }
  [Required]
  public String FirstName { get; set; } = string.Empty;
  [Required]
  public String LastName { get; set; } = string.Empty;

  [Required]
  [EmailAddress]
  public string Email { get; set;}

  [Required]
  [MinLength(8)]
  public string Password { get; set; }
}
