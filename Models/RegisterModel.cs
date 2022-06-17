using System.ComponentModel.DataAnnotations;

namespace timesheet_api.Models;

public class RegisterModel
{
    [Required] public string Name { get; set; }
    [Required] public string ManagerId { get; set; }
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
    [Required] public string Email { get; set; }
}