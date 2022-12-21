using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using webapp.Features.Assignments.Models;
using webapp.Features.Assignments.Views;

namespace webapp.Features.Assignments;

[ApiController]
[Route("assignments")] //zona de endpoint
public class AssignmentsController : ControllerBase
{
    private static List<AssignmentModel>
        _mockDB = new List<AssignmentModel>(); //lista care functioneaza ca baza de date

    public AssignmentsController()
    {
    }


    [HttpPost] //adauga info in baza de date
    public AssignmentResponse Add(AssignmentRequest request)
    {
        var assignment = new AssignmentModel
        {
            id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Subject = request.Subject,
            Description = request.Description,
            Deadline = request.Deadline

        };
        _mockDB.Add(assignment);
        return new AssignmentResponse
        {
            Id = assignment.id,
            Subject = assignment.Subject,
            Description = assignment.Description,
            Deadline = assignment.Deadline
        };
    }

    [HttpGet]
    public IEnumerable<AssignmentResponse> Get()
    {
        return _mockDB.Select(
            assignment => new AssignmentResponse
            {
                Id = assignment.id,
                Subject = assignment.Subject,
                Description = assignment.Description,
                Deadline = assignment.Deadline

            }
        ).ToList(); //fiecare obiect din lista va fi transf intr un assignment response
    }

    [HttpGet("{id}")]
    public AssignmentResponse Get([FromRoute] string id)
    {
        var assignment = _mockDB.FirstOrDefault(x => x.id == id);
        if (assignment is null)
        {
            return null;
        }

        return new AssignmentResponse()
        {
            Id = assignment.id,
            Subject = assignment.Subject,
            Description = assignment.Description,
            Deadline = assignment.Deadline
        };
    }


    [HttpDelete("{id}")]
    public AssignmentModel Delete([FromRoute] string id)
    {
        var assignment = _mockDB.FirstOrDefault(x => x.id == id);
        if (assignment is null)
        {
            return null;
        }

        _mockDB.Remove(assignment);
        return assignment;
    }
    //
    // [HttpPatch("{id}")]
    //
    //
    // public AssignmentResponse Change([FromRoute] string id, [FromBody] string sub, [FromBody] string desc,
    //     [FromBody] DateTime dead)
    // {
    //     var assignment = _mockDB.FirstOrDefault(x => x.id == id);
    //     if (assignment is null)
    //     {
    //         return null;
    //     }
    //
    //       new AssignmentResponse
    //     {
    //       Id = assignment.id,
    //        Deadline=dead,
    //        Description=desc,
    //       Subject=sub
    //
    //     };
    //
    //
    //
    // }
}

//functie de delete si una de update [Httpdelete] [Httppatch] - request nou ca parametru 
