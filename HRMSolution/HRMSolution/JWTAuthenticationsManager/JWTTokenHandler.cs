using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTAuthenticationsManager.Models;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace JWTAuthenticationsManager;

public class JWTTokenHandler
{
    public const string JWT_Secret_key = "UjXn2r5u8x/A?D(G-KaPdSgVkYp3s6v9y$B&E)H@MbQeThWmZq4t7w!z%C*F-JaN";
    private const int JWT_Token_Validity_Min = 20000;

    private readonly List<UserAccount> _userAccounts;
    public JWTTokenHandler()
    {
        _userAccounts = new List<UserAccount>()
        {
            new UserAccount(){Username = "admin", Password = "admin@1234",Role = "Admin"}
        };
    }
    
    
    // 
    public AuthenticationResponse GenerateToken(AuthenticationRequest authenticationRequest)
    {
        if (string.IsNullOrEmpty(authenticationRequest.Username) ||
            string.IsNullOrEmpty(authenticationRequest.Password))
        {
            return null;
        }

        var result = _userAccounts
            .Where(x => x.Username == authenticationRequest.Username && x.Password == authenticationRequest.Password)
            .FirstOrDefault();
        if (result == null)
        {
            return null;
        }
        // generate Token
        var tokenExpiryTime = DateTime.Now.AddMinutes(JWT_Token_Validity_Min); // from now to 20 mins
        var tokenKey = Encoding.ASCII.GetBytes(JWT_Secret_key);
        var claimsIdentity = new ClaimsIdentity(new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Name, authenticationRequest.Username),
            new Claim(ClaimTypes.Role, result.Role)
        });

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature
        );
        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = tokenExpiryTime,
            SigningCredentials = signingCredentials
        };
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
        var token = jwtSecurityTokenHandler.WriteToken(securityToken);
        return new AuthenticationResponse
        {
            Token = token,
            ExpiresIn = (int)tokenExpiryTime.Subtract(DateTime.Now).TotalMilliseconds,
            Username = authenticationRequest.Username
        };
    }
    
}