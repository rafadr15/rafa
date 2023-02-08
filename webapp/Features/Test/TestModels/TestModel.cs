using webapp.Base;
using webapp.Features.Assignments.Models;
using webapp.Features.Subject.SubjectModels;

namespace webapp.Features.Test.TestModels;

public class TestModel : Model 
{
    public string SubjectId { get; set; }

    public float Grade { get; set; }
    public DateTime TestDate { get; set; }
   
    
}


