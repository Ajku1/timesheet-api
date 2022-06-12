using System.ComponentModel.DataAnnotations.Schema;

namespace timesheet_api.Data.Entities.TimeEntry;

public class TimeEntry
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ManagerId { get; set; }
    [Column(TypeName = "date")]
    public DateTime Date { get; set; }
    public int Hours { get; set; }
    public TimeEntryStatus Status { get; set; }
    public TimeEntryType Type { get; set; }
}