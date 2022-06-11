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
        // return _userService.GetAll();
        return Ok(new List<User>());
    }

    [HttpPost]
    public ActionResult Create([FromBody]User user)
    {
        _repository.Save(user);
        return Ok(user);
    }
}