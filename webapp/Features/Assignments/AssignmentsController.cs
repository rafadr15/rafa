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


    [HttpPost] //adauga info in baza de date
    public async Task<AssignmentResponse> Add(AssignmentRequest request)
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
        //folosim metodetele async in cazul in care fac requesturi catre un server(gen. baze de date)
        //ptc nu stim cand o sa primim un raspuns(milisecunde, secunde)
        //si vrem sa asteptam acel raspuns oricat e nevoie 


        var response = await _dbContext.AddAsync(assignment);
        await _dbContext.SaveChangesAsync();
        //_mockDB.Add(assignment);
        return new AssignmentResponse
        {
            Id = response.Entity.id,
            Subject = response.Entity.Subject,
            Description = response.Entity.Description,
            Deadline = response.Entity.Deadline
        };
    }

    [HttpGet]
    public async Task<IEnumerable<AssignmentResponse>> Get()
    {
        var entities = await _dbContext.Assignments.ToListAsync();
        return entities.Select(
            assignment => new AssignmentResponse
            {
                Id = assignment.id,
                Subject = assignment.Subject,
                Description = assignment.Description,
                Deadline = assignment.Deadline

            }
        ); //fiecare obiect din lista va fi transf intr un assignment response
    }

    [HttpGet("{id}")]
    
    //async=task
    public async Task<ActionResult<AssignmentResponse>> Get([FromRoute] string id)
    {
        var entity = await _dbContext.Assignments.FirstOrDefaultAsync(x => x.id == id);
        //var assignment = _mockDB.FirstOrDefault(x => x.id == id);
        if (entity is null)
        {
            return NotFound("Assignment not found");
        }

        return new AssignmentResponse
        {
            Id = entity.id,
            Subject = entity.Subject,
            Description = entity.Description,
            Deadline = entity.Deadline
        };
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<AssignmentResponse>> Delete([FromRoute] string id)
    {
        var entity = await _dbContext.Assignments.FirstOrDefaultAsync(x => x.id == id);

        if (entity is null)
        {
            return NotFound();
        }

        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return new AssignmentResponse()
        {
           Id=entity.id,
           Deadline = entity.Deadline,
           Description = entity.Description,
           Subject = entity.Subject

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
         entity.Subject = request.Subject;
         entity.Updated = DateTime.UtcNow;
         await _dbContext.SaveChangesAsync();
    
         return new AssignmentResponse
         {
             Id =entity.id,
             Deadline = entity.Deadline, 
             Description = entity.Description,
             Subject = entity.Subject
         }; 
     }
}

//functie de delete si una de update [Httpdelete] [Httppatch] - request nou ca parametru 
