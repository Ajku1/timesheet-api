using Microsoft.AspNetCore.Mvc;
using timesheet_api.Data;
using timesheet_api.Data.Entities.User;
using timesheet_api.Models;

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
        var userModels = users.Select(user => new UserModel()
            { Id = user.Id, Name = user.Name, ManagerId = user.ManagerId });
        return Ok(userModels);
    }
}