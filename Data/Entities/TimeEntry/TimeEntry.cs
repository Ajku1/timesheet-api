using System.ComponentModel.DataAnnotations.Schema;

namespace timesheet_api.Data.Entities.TimeEntry;

public class TimeEntry
{
    public int Id { get; set; }
    public User.User User { get; set; }
    [ForeignKey("User")]
    public string UserId { get; set; }
    public User.User Manager { get; set; }
    [ForeignKey("Manager")]
    public string ManagerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Hours { get; set; }
    public TimeEntryStatus Status { get; set; }
    public TimeEntryType Type { get; set; }
}