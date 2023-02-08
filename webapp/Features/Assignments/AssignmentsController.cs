using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;
using webapp.Database;
using webapp.Features.Assignments.Models;
using webapp.Features.Assignments.Views;
namespace webapp.Features.Assignments;

[ApiController]
[Route("assignments")] //zona de endpoint
public class AssignmentsController : ControllerBase
{ 
    private  readonly AppDbContext _dbContext;

//DEPENDENCY INJECTIONS (DI)face rost de serviicile de care avem nevoie 

    public AssignmentsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]//adauga info in baza de date
    public async Task<ActionResult<AssignmentResponse>> Add(AssignmentRequest request)
    {
        var subject = await _dbContext.Subjects.FirstOrDefaultAsync(x =>x.id==request.Subject);
        if (subject is null)
        {
            return NotFound("nu e");
        }
        
        
        var assignment = new AssignmentModel
        {
            id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            SubjectId = request.Subject,
            Description = request.Description,
            Deadline = request.Deadline,
            Grade= request.Grade

        };
        subject.Grades.Add(assignment.Grade);
        //folosim metodetele async in cazul in care fac requesturi catre un server(gen. baze de date)
        //ptc nu stim cand o sa primim un raspuns(milisecunde, secunde)
        //si vrem sa asteptam acel raspuns oricat e nevoie 


        var response = await _dbContext.Assignments.AddAsync(assignment);

        await _dbContext.SaveChangesAsync();
        return Ok(new AssignmentResponse
        {
            Id = response.Entity.id,
            Subject = response.Entity.SubjectId,
            Description = response.Entity.Description,
            Deadline = response.Entity.Deadline,
            Grade=response.Entity.Grade
        });
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AssignmentResponse>>> Get()
    {
        return Ok(await _dbContext.Assignments.Include(x => x.SubjectId).Select(x => new AssignmentResponse
        {
            Id = x.id,
            Subject = x.SubjectId,
            Description = x.Description,
            Deadline = x.Deadline,
            Grade=x.Grade
        }).ToListAsync());

    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    //async=task
    public async Task<ActionResult<AssignmentResponse>> Get([FromRoute] string id)
    {
        var entity = await _dbContext.Assignments.Include(x => x.SubjectId)
            .FirstOrDefaultAsync(x => x.id == x.SubjectId);
        //tabela de assignment va cauta intr-o tabela dupa subjectid
        if (entity is null)
        {
            return NotFound();
        }

        return Ok(new AssignmentResponse
            {
                Id = entity.id,
                Subject = entity.SubjectId,
                Description = entity.Description,
                Deadline = entity.Deadline,
                Grade = entity.Grade
                
            });
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<AssignmentResponse>> Delete([FromRoute] string id)
    {
        var entity = await _dbContext.Assignments.FirstOrDefaultAsync(x => x.id == id);

        if (entity is null)
        {
            return NotFound();
        }

      var response=  _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return new AssignmentResponse()
        {
           Id=response.Entity.id,
           Deadline = response.Entity.Deadline,
           Description = response.Entity.Description,
           Subject = response.Entity.SubjectId,
           Grade= response.Entity.Grade

        };

    }


[HttpPatch("{id}")]
     public async Task<ActionResult<AssignmentResponse>>  Patch([FromRoute] string id, [FromBody] AssignmentRequest request)
     {    var entity = await _dbContext.Assignments.FirstOrDefaultAsync(x => x.id == id);
        // var assignment = _mockDB.FirstOrDefault(x => x.id == id);
    
         if (entity is null)
             return NotFound("e iaca uite ca nu-i");
    
         entity.Deadline = request.Deadline;
         entity.Description = request.Description;
         entity.Grade = request.Grade;
         entity.SubjectId = request.Subject;
         entity.Updated = DateTime.UtcNow;
         await _dbContext.SaveChangesAsync();
    
         return new AssignmentResponse
         {
             Id =entity.id,
             Deadline = entity.Deadline, 
             Description = entity.Description,
             Subject = entity.SubjectId,
             Grade=entity.Grade
         }; 
     }
}

//functie de delete si una de update [Httpdelete] [Httppatch] - request nou ca parametru 
