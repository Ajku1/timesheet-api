using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using timesheet_api.Data;
using timesheet_api.Data.Entities.User;
using timesheet_api.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace timesheet_api.Controllers;

[ApiController]
[Route("api")]
public class AccountController : ControllerBase
{
    private readonly SignInManager<User> _signInManager;
    private readonly ITimesheetRepository _timesheetRepository;

    public AccountController(SignInManager<User> signInManager, ITimesheetRepository timesheetRepository)
    {
        _signInManager = signInManager;
        _timesheetRepository = timesheetRepository;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        SignInResult signInResult = await _signInManager.PasswordSignInAsync(
            loginModel.Username,
            loginModel.Password,
            false,
            false
        );
        return signInResult.Succeeded ? Ok() : Unauthorized();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        if (_timesheetRepository.isEmailInUse(registerModel.Email))
        {
            return Conflict();
        }

        User user = new User()
        {
            Name = registerModel.Name,
            UserName = registerModel.Username,
            Email = registerModel.Email,
            ManagerId = registerModel.ManagerId
        };
        var result = await _signInManager.UserManager.CreateAsync(user, registerModel.Password);
        if (result != IdentityResult.Success)
        {
            throw new InvalidOperationException("Failed to register user.");
        }

        return Ok();
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }
}