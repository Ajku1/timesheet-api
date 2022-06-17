using System.ComponentModel.DataAnnotations;
using timesheet_api.Data.Entities.TimeEntry;

namespace timesheet_api.Models;

public class TimeEntryCreateModel
{
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public int Hours { get; set; }
    [Required]
    public TimeEntryType Type { get; set; }
}