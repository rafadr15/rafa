using webapp.Base;

namespace webapp.Features.Assignments.Models;

public class AssignmentModel : Model
{
    public string SubjectId { get; set; }
    public string Description { get;set; }
    public  DateTime Deadline { get; set; }

    public float Grade { get; set; }
    


}