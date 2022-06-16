﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using timesheet_api.Data.Entities.User;
using timesheet_api.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace timesheet_api.Controllers;

[ApiController]
[Route("api")]
public class AccountController : ControllerBase
{
    private readonly SignInManager<User> _signInManager;

    public AccountController(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {
        if (loginModel == null || !ModelState.IsValid)
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

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }
}