using Microsoft.AspNetCore.Mvc;
using timesheet_api.Data;
using timesheet_api.Data.Entities.TimeEntry;

namespace timesheet_api.Controllers;

[ApiController]
[Route("api/time-entries")]
public class TimeEntryController : ControllerBase
{
    private readonly ITimesheetRepository _repository;

    public TimeEntryController(ITimesheetRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TimeEntry>> GetTimeEntriesPendingReview(int managerId)
    {
        var timeEntries = _repository.GetTimeEntriesPendingReview(managerId);
        return Ok(timeEntries);
    }
}