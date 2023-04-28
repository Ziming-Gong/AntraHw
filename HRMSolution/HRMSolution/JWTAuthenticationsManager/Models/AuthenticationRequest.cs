using System.Drawing;

namespace JWTAuthenticationsManager.Models;

public class AuthenticationRequest
{
    
    public string Username { get; set; }
    public string Password { get; set; }
    
    public AuthenticationRequest()
    {
        
    }
}