using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;
using webapp.Database;
using webapp.Features.Assignments.Models;
using webapp.Features.Assignments.Views;
using webapp.Migrations;
using webapp.Utils.Repository;

namespace webapp.Features.Assignments;

[ApiController]
[Route("api/assignments")] //zona de endpoint
public class AssignmentsController : ControllerBase
{
    private readonly IRepository<AssignmentModel> _repository;
    private readonly IMapper _mapper;

    public AssignmentsController(IRepository<AssignmentModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<ActionResult<AssignmentResponse>> Add([FromBody] AssignmentRequest request)
    {

         var assignment = _mapper.Map<AssignmentModel>(request);
         var result=await _repository.Add(assignment);
         return Created("api/assignments", _mapper.Map<AssignmentResponse>(result.Value));

    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<AssignmentResponse>>> Get()
    {
        var result = await _repository.Get();
        return Ok(result.Value.Select(
            assignment => _mapper.Map<AssignmentResponse>(assignment)).ToList());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<AssignmentResponse>> Get([FromRoute] string id)
    {



        var result = await _repository.Get(id);
        if (result.Value is null)
        {
            return NotFound("nu e");

        }

        return Ok(_mapper.Map<AssignmentResponse>(result.Value));
    }
    
    



}
