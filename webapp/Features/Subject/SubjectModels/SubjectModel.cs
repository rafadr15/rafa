using webapp.Base;
using webapp.Features.Assignments.Models;
using webapp.Features.Test.TestModels;

namespace webapp.Features.Subject.SubjectModels;

public class SubjectModel : Model
{
    public string Name { get; set; }
    public string ProfessorMail { get; set; }
    public List<Double> Grades { get; set; }
    
    public AssignmentModel Assignment { get; set; }
    public List<TestModel> Tests { get; set; }
}


