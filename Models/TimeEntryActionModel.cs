﻿using System.ComponentModel.DataAnnotations;

namespace timesheet_api.Models;

public class TimeEntryActionModel
{
    [Required]
    public bool Approved { get; set; }
}