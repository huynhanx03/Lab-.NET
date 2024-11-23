namespace DataAccess.DTOs;
public class TokenRequest
{
    public TokenRequest(string token, int? role)
    {
        Token = token;
        Role = role;
    }
    public string Token { get; set; } = default!;
    public int? Role { get; set; }
}
