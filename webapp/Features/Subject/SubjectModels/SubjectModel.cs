using webapp.Base;
using webapp.Features.Assignments.Models;
using webapp.Features.Test.TestModels;

namespace webapp.Features.Subject.SubjectModels;

public class SubjectModel : Model
{
    public string Name { get; set; }
    public string ProfessorMail { get; set; }
    public List<Double> Grades { get; set; }
}


