using System.ComponentModel.DataAnnotations;

namespace User.ApplicationCore.Models;

public class SignInModel
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}