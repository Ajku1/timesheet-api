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
    public ActionResult Create([FromBody] TimeEntryCreateModel timeEntryCreateModel)
    {
        TimeEntry timeEntryToCreate = new TimeEntry
        {
            StartDate = timeEntryCreateModel.StartDate,
            EndDate = timeEntryCreateModel.EndDate,
            Hours = timeEntryCreateModel.Hours,
            UserId = timeEntryCreateModel.UserId,
            ManagerId = timeEntryCreateModel.ManagerId,
            TypeId = timeEntryCreateModel.Type.Id,
            Status = TimeEntryStatus.Pending
        };
        var timeEntry = _repository.Save(timeEntryToCreate);
        return Ok(timeEntry);
    }

    [HttpPost("pending-review")]
    public ActionResult<IEnumerable<TimeEntry>> GetTimeEntries([FromBody] TimeEntriesGetModel timeEntriesGetModel)
    {
        var userTimeEntries = _repository.GetUserTimeEntries(timeEntriesGetModel.UserId);
        var timeEntriesPendingReview = _repository.GetTimeEntriesPendingReview(timeEntriesGetModel.UserId);
        return Ok(userTimeEntries.Concat(timeEntriesPendingReview));
    }

    [HttpPut("{id}/pending-review")]
    public ActionResult ActOnTimeEntry(int id, [FromBody] TimeEntryActionModel timeEntryActionModel)
    {
        TimeEntry updatedEntry = _repository.ActOnTimeEntry(id, timeEntryActionModel.Approved);
        return Ok(updatedEntry);
    }
}