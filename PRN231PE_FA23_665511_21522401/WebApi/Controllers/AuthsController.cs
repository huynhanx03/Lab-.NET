using DataAccess.DTOs;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthsController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ServiceBase<BranchAccount> _service;

    public AuthsController(
        IConfiguration configuration,
        ServiceBase<BranchAccount> service)
    {
        _service = service;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginRequest login)
    {
        var user = await _service
            .FindByAsync(x => x.EmailAddress == login.Username &&
                              x.AccountPassword == login.Password);
        if (user == null)
        {
            return Unauthorized();
        }

        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.AccountId.ToString()),
            new Claim(ClaimTypes.Role, user.Role.ToString()!),
        };

        var key = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:SerectKey").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var token = new JwtSecurityToken(
             claims: claims,
             expires: DateTime.UtcNow.AddYears(10),
             signingCredentials: creds);
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(new TokenRequest(jwt, user.Role));
    }
}
