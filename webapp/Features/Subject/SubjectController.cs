using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp.Database;
using webapp.Features.Subject.SubjectModels;
using webapp.Features.Subject.SubjectViews;
using webapp.Features.Test.TestViews;

namespace webapp.Features.Subject;


[ApiController]
[Route("Subject")]

public class SubjectController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    public SubjectController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }



    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    //ce rezultate poate avea metoda

    public async Task<ActionResult<SubjectResponse>> Add(SubjectRequest request)
    {  
        
        
        var subject = new SubjectModel
        {
            id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Name = request.Name,
            ProfessorMail = request.ProfessorMail,
            Grades = new List<double>()

        };

        var response = await _dbContext.Subjects.AddAsync(subject);

        await _dbContext.SaveChangesAsync();
        return Created("subjects", response.Entity);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SubjectResponse>> Get()
    {
        var entities = await _dbContext.Subjects.Select(
            subject => new SubjectResponse

            {
                id = subject.id,
                Name = subject.Name,
                ProfessorMail = subject.ProfessorMail,
                Grades = subject.Grades
            }
        ).ToListAsync();
        
        return Ok(entities);
    }



    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SubjectResponse>> Get([FromRoute] string id)
    {
        var entity = await _dbContext.Subjects.FirstOrDefaultAsync(x => x.id == id);
        return entity is null ? NotFound("iaca nu-i") : Ok(entity);  //new subject response, parametrii 
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SubjectResponse>> Delete([FromRoute] string id)
    {
        var entity = await _dbContext.Subjects.FirstOrDefaultAsync(x => x.id == id);
        if (entity is null)
            return NotFound("iaca nu-i");

        //  var result = 
        _dbContext.Subjects.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return Ok(entity);
        //de verificat daca merge fara result.Entity
    }


    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SubjectResponse>> Patch([FromRoute] string id, [FromBody] SubjectRequest request)
    {
        var entity = await _dbContext.Subjects.FirstOrDefaultAsync(x => x.id == id);
        if (entity is null)
            return NotFound("e iaca uite ca nu-i");

        entity.Name = request.Name;
        entity.ProfessorMail = request.ProfessorMail;
        entity.Updated = DateTime.UtcNow;
        await _dbContext.SaveChangesAsync();
        return Ok(entity);




    }
}
