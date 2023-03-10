using System.ComponentModel.DataAnnotations;

namespace webapp.Features.Test.TestViews;

public class TestRequest
{
    [Required] public string Subject { get; set; }
    [Required] public DateTime TestDate { get; set; } 
    [Required] public float Grade { get; set; }
} 