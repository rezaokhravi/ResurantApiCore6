using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core6.Models.Entites;
using Core6.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ResurantApiCore6.Models.Auth;
using ResurantApiCore6.Models.Dtos;

namespace Core6.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthenticateController : Controller
{
    private readonly ILogger<ResturantController> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly ResponseResult _result;
    public AuthenticateController(
        ILogger<ResturantController> logger,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration,
        ResponseResult result
        )
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _result = result;
    }

    /// <summary>
    /// سرویس ورود جهت اعمال اعتبار سنجی به کاربر
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromQuery] LoginModel model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = GetToken(authClaims);

            _result.IsSucess = true;
            _result.StatusCode = StatusCodes.Status200OK;
            _result.Message = "لایگن با موفقیت انجام شد";
            _result.Error = null;
            _result.Data = new
            {
                token = $"bearer {new JwtSecurityTokenHandler().WriteToken(token)}" ,
                expiration = token.ValidTo
            };

            return Ok(_result);
        }
        _result.IsSucess = false;
        _result.StatusCode = StatusCodes.Status401Unauthorized;
        _result.Message = "عدم امکان تایید ورود شما";
        _result.Error = "User Unauthorized!";
        _result.Data = null;
        return Ok(_result);
    }

    /// <summary>
    /// سرویس ثبت نام جهت استفاده از سایر سرویس ها
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromQuery] RegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);
        if (userExists != null)
        {
            _result.IsSucess = false;
            _result.StatusCode = StatusCodes.Status500InternalServerError;
            _result.Message = "نام کاربر تکراری می باشد";
            _result.Error = "User already exists!";
            _result.Data = null;
            return Ok(_result);
        }

        IdentityUser user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            _result.IsSucess = false;
            _result.StatusCode = StatusCodes.Status500InternalServerError;
            _result.Message = "خطا در ثبت نام، لطفا مجدد تلاش نمائید";
            _result.Error = result.Errors.Select(s=>s.Description).ToList();
            _result.Data = null;
            return Ok(_result);
        }

         if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));


        if (await _roleManager.RoleExistsAsync(UserRoles.User))
        {
            await _userManager.AddToRoleAsync(user, UserRoles.User);
        }

        _result.IsSucess = true;
        _result.StatusCode = 200;
        _result.Message = "ثبت نام با موفقیت انجام شد";
        _result.Error = "Error";
        _result.Data = result.Errors;
        return Ok(_result);
    }

    /// <summary>
    /// سرویس ایجاد راهبر
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("register-admin")]
    public async Task<IActionResult> RegisterAdmin([FromQuery] RegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);
        if (userExists != null)
        {
            _result.IsSucess = false;
            _result.StatusCode = StatusCodes.Status500InternalServerError;
            _result.Message = "نام کاربر تکراری می باشد";
            _result.Error = "User already exists!";
            _result.Data = null;
            return Ok(_result);
        }

        IdentityUser user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            _result.IsSucess = false;
            _result.StatusCode = StatusCodes.Status500InternalServerError;
            _result.Message = "خطا در ثبت نام، لطفا مجدد تلاش نمائید";
            _result.Error = "User creation failed! Please check user details and try again";
            _result.Data = null;
            return Ok(_result);
        }

        if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

        if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
        {
            await _userManager.AddToRoleAsync(user, UserRoles.Admin);
        }
        
        _result.IsSucess = true;
        _result.StatusCode = 200;
        _result.Message = "ثبت نام با موفقیت انجام شد";
        _result.Error = null;
        _result.Data = null;
        return Ok(_result);
    }

    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

        return token;
    }


}