using webapp.Base;
using webapp.Features.Assignments.Models;
using webapp.Features.Subject.SubjectModels;

namespace webapp.Features.Test.TestModels;

public class TestModel : Model 
{
    public string Subject { get; set; }
    public DateTime TestDate { get; set; }
    public AssignmentModel Assignment { get; set; }
    public List<TestModel> Tests { get; set; }
}


