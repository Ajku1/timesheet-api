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

    [HttpPost]
    [Authorize]
    public ActionResult Create([FromBody] TimeEntryCreateModel timeEntryCreateModel)
    {
        TimeEntry timeEntryToCreate = new TimeEntry()
        {
            StartDate = timeEntryCreateModel.StartDate,
            EndDate = timeEntryCreateModel.EndDate,
            Hours = timeEntryCreateModel.Hours,
            UserId = 1,
            ManagerId = 2,
            Type = timeEntryCreateModel.Type,
            Status = TimeEntryStatus.Pending
        };
        var timeEntry = _repository.Save(timeEntryToCreate);
        return Ok(timeEntry);
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