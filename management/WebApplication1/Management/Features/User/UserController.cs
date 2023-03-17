using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Features.User;



[ApiController]
[Route("User")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _dbContext;
}