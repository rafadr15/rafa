using System.ComponentModel.DataAnnotations;

namespace webapp.Features.Subject.SubjectViews;

public class SubjectRequest
{
    [Required] public string  Name { get; set; }
    [Required] public string  ProfessorMail{ get; set; }
    [Required] public List<Double> Grades{ get; set; }
    
}