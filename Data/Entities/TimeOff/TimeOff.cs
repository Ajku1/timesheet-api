namespace timesheet_api.Data.Entities.TimeOff;

public class TimeOff
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ManagerId { get; set; }
    public TimeOffStatus Status { get; set; }
    public TimeOffType Type { get; set; }
}