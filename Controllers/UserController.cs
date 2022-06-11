using Microsoft.AspNetCore.Mvc;
using timesheet_api.Data.Entities.User;
using timesheet_api.Services;

namespace timesheet_api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService; 
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
        // return _userService.GetAll();
        return Ok(new List<User>());
    }
}