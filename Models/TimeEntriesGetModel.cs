using System.ComponentModel.DataAnnotations;

namespace timesheet_api.Models;

public class TimeEntriesGetModel
{
    [Required]
    public string UserId { get; set; }
}