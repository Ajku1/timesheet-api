using Microsoft.AspNetCore.Mvc;
using timesheet_api.Data;
using timesheet_api.Data.Entities.TimeEntry;
using timesheet_api.Models;

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

    [HttpGet("{id}")]
    public ActionResult<TimeEntryType> GetById(int id)
    {
        var timeEntryType = _repository.GetTimeEntryType(id);
        return Ok(timeEntryType);
    }

    [HttpPost]
    public ActionResult<TimeEntryType> Create([FromBody] TimeEntryTypeModel timeEntryTypeModel)
    {
        var timeEntryType = new TimeEntryType { Name = timeEntryTypeModel.Name };
        var savedTimeEntryType = _repository.Save(timeEntryType);
        return Ok(savedTimeEntryType);
    }

    [HttpPut("{id}")]
    public ActionResult<TimeEntryType> Update(int id, [FromBody] TimeEntryTypeModel timeEntryTypeModel)
    {
        var timeEntryType = _repository.UpdateTimeEntryType(id, timeEntryTypeModel);
        return Ok(timeEntryType);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _repository.DeleteTimeEntryType(id);
        return Ok();
    }
}