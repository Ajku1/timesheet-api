using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using timesheet_api.Data;
using timesheet_api.Data.Entities.TimeEntry;
using timesheet_api.Models;

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

    [HttpGet("pending-review/{managerId}")]
    [Authorize]
    public ActionResult<IEnumerable<TimeEntry>> GetTimeEntriesPendingReview(int managerId)
    {
        var timeEntries = _repository.GetTimeEntriesPendingReview(managerId);
        return Ok(timeEntries);
    }

    [HttpPost("pending-review")]
    [Authorize]
    public ActionResult ActOnTimeEntry([FromBody] TimeEntryActionModel timeEntryActionModel)
    {
        TimeEntry updatedEntry =
            _repository.ActOnTimeEntry(timeEntryActionModel.TimeEntryId, timeEntryActionModel.Approved);
        return Ok(updatedEntry);
    }
}