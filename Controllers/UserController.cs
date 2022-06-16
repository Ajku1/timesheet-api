using Microsoft.AspNetCore.Mvc;
using timesheet_api.Data;
using timesheet_api.Data.Entities.User;

namespace timesheet_api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly ITimesheetRepository _repository;

    public UserController(ITimesheetRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
        var users = _repository.GetUsers();
        var json = new JsonResult(users);
        return Ok(json);
    }

    [HttpPost]
    public ActionResult Create([FromBody] User user)
    {
        _repository.Save(user);
        return Ok(user);
    }
}