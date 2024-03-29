﻿using System.ComponentModel.DataAnnotations;

namespace webapp.Features.Assignments.Views;

public class AssignmentRequest
{
    [Required] public string Subject { get; set; }
    [Required] public string Description { get; set; }
    [Required]  public DateTime Deadline { get; set; }
    [Required] public float Grade { get; set; }
}