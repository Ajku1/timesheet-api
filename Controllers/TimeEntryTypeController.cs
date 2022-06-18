using Microsoft.AspNetCore.Mvc;
using timesheet_api.Data;
using timesheet_api.Data.Entities.TimeEntry;

namespace timesheet_api.Controllers;

[ApiController]
[Route("api/time-entry-types")]
public class TimeEntryTypeController : ControllerBase
{
    private readonly ITimesheetRepository _repository;

    public TimeEntryTypeController(ITimesheetRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TimeEntryType>> Get()
    {
        var timeEntryTypes = _repository.GetTimeEntryTypes();
        return Ok(timeEntryTypes);
    }
}