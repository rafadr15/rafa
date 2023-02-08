using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp.Database;
using webapp.Features.Test.TestModels;
using webapp.Features.Test.TestViews;

namespace webapp.Features.Test;

[ApiController]
[Route("test")]

public class TestController : ControllerBase
{
    private readonly AppDbContext _dbContext;
       // _mockDbTestModels = new List<TestModel>();


    public TestController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }



    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TestResponse>>Add(TestRequest request)
    {   
        var test = new TestModel
        {
            id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            SubjectId = request.Subject,
            TestDate = request.TestDate,
            Grade=request.Grade

        };
        var subject = await _dbContext.Subjects.FirstOrDefaultAsync(x =>x.id==request.Subject);
        if (subject is null)
        {
            return NotFound("nu e");
        }
        subject.Grades.Add(test.Grade);

        var response = await _dbContext.Tests.AddAsync(test);
        await _dbContext.SaveChangesAsync();
        return Ok(new TestResponse
        {
            Id = response.Entity.id,
            Subject = response.Entity.SubjectId,
            TestDate = response.Entity.TestDate,
            Grade = response.Entity.Grade
        });
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public  async Task<ActionResult<IEnumerable<TestResponse>>> Get()

    {   
         
        return Ok(await _dbContext.Tests.Include(x => x.SubjectId).Select(x => new TestResponse
        {
            Id = x.id,
            Subject = x.SubjectId,
            TestDate = x.TestDate,
            Grade = x.Grade
           
        }).ToListAsync());

    }
    


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public  async  Task<ActionResult<TestResponse>> Get([FromRoute] string id)
    {

        var entity = await _dbContext.Tests.Include(x => x.SubjectId)
            .FirstOrDefaultAsync(x => x.id == x.SubjectId);
        //tabela de assignment va cauta intr-o tabela dupa subjectid
        if (entity is null)
        {
            return NotFound();
        }

        return Ok(new TestResponse
        {
            Id = entity.id,
            Subject = entity.SubjectId,
            TestDate = entity.TestDate,
            Grade = entity.Grade
        });
    }

    [HttpDelete("{id}")]

    public async Task<ActionResult<TestModel>> Delete([FromRoute] string id)

    {
        var entity = await _dbContext.Tests.FirstOrDefaultAsync(x => x.id == id);
        if (entity is null)
            return NotFound("iaca nu-i");
        _dbContext.Tests.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return Ok(entity);
    }


    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<TestResponse>> Patch([FromRoute] string id, [FromBody] TestRequest request)
    {
        var entity = await _dbContext.Tests.FirstOrDefaultAsync(x => x.id == id);
        if (entity is null)
            return NotFound("iaca nu-i");
        
        entity.SubjectId = request.Subject;
        entity.TestDate = request.TestDate;
        entity.Grade = request.Grade;
        entity.Updated = DateTime.UtcNow;
        await _dbContext.SaveChangesAsync();
        return Ok(entity);
    }
}

