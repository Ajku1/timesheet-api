using System.ComponentModel.DataAnnotations;

namespace timesheet_api.Models;

public class TimeEntryActionModel
{
    [Required]
    public int TimeEntryId { get; set; }
    [Required]
    public bool Approved { get; set; }
}