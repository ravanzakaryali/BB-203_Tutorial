using FirstApiProject.DTOs.AuthDto;
using FirstApiProject.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using E = FirstApiProject.Entities;

namespace FirstApiProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    readonly UserManager<User> _userManager;

    readonly IConfiguration _configuration;
    public AuthController(UserManager<User> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto register)
    {
        E.User user = new User()
        {
            FullName = register.FullName,
            Email = register.Email,
            UserName = register.UserName,
        };
        IdentityResult identityResult = await _userManager.CreateAsync(user, register.Password);

        if (!identityResult.Succeeded)
        {
            return BadRequest(identityResult.Errors);
        }
        return Ok(new
        {
            user.FullName,
            user.Email
        });
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto login)
    {
        E.User user = await _userManager.FindByNameAsync(login.UserName);
        if (user is null) return BadRequest(new
        {
            Message = "Username or password incorrect!!!"
        });
        bool checkPassword = await _userManager.CheckPasswordAsync(user, login.Password);
        if (!checkPassword) return BadRequest(new
        {
            Message = "Username or password incorrect!!!"
        });
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email,user.Email)
        };

        string privateKey = _configuration["JWT:SecurityKey"];
        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey));

        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //Token generate
        JwtSecurityToken token = new JwtSecurityToken
            (
            issuer: _configuration["JWT:issuer"],
            audience: _configuration["JWT:audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddSeconds(10),
            signingCredentials: signingCredentials
            );

        return Ok(new
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
        });

    }
}
