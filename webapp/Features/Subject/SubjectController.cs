using Microsoft.AspNetCore.Mvc;
using webapp.Features.Subject.SubjectModels;
using webapp.Features.Subject.SubjectViews;
using webapp.Features.Test.TestViews;

namespace webapp.Features.Subject;


[ApiController]
[Route("Subject")]

public class SubjectController : ControllerBase
{
    private static List<SubjectModel> _mockDBSubject = new List<SubjectModel>();

    public SubjectController()
    {
    }



    [HttpPost]
    public SubjectResponse Add(SubjectRequest request)
    {

        var subject = new SubjectModel
        {
            id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Name = request.Name,
            ProfessorMail = request.ProfessorMail,
            Grades = request.Grades.ToList()

        };
        _mockDBSubject.Add(subject);
        return new SubjectResponse
        {
            Id = subject.id,
            Name = subject.Name,
            ProfessorMail = subject.ProfessorMail,
            Grades = subject.Grades.ToList()
        };

    }

    [HttpGet]
    public IEnumerable<SubjectResponse> Get()
    {
        return _mockDBSubject.Select(
            subject => new SubjectResponse
            {
                Id = subject.id,
                Name = subject.Name,
                ProfessorMail = subject.ProfessorMail,
                Grades = subject.Grades.ToList()
            }).ToList();
    }



    [HttpGet("{id}")]
    public SubjectResponse Get([FromRoute] string id)
    {
        var subject = _mockDBSubject.FirstOrDefault(x => x.id == id);
        if (subject is null)
        {
            return null;
        }

        return new SubjectResponse
        {
            Id = subject.id,
            Name = subject.Name,
            ProfessorMail = subject.ProfessorMail,
            Grades = subject.Grades.ToList()
        };
    }

    [HttpDelete("{id}")]
    public SubjectModel Delete([FromRoute] string id)
    {
        var subject = _mockDBSubject.FirstOrDefault(x => x.id == id);
        if (subject is null)
        {
            return null;
        }

        _mockDBSubject.Remove(subject);
        return subject;

    }


    [HttpPatch("{id}")]

    public SubjectResponse Patch([FromRoute] string id, [FromBody] SubjectRequest request)
    {
        var subject = _mockDBSubject.FirstOrDefault(x => x.id == id);
        if (subject is null)
        {
            return null;
        }

        subject.Name = request.Name;
        subject.ProfessorMail = request.ProfessorMail;
        subject.Grades = request.Grades;
        subject.Updated = DateTime.UtcNow;

        return new SubjectResponse
        {
            Id = subject.id,
            Name = subject.Name,
            ProfessorMail = subject.ProfessorMail,
            Grades = subject.Grades.ToList()
        };
    }
    
}
