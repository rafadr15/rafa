using Microsoft.EntityFrameworkCore;
using webapp.Features.Assignments.Models;

namespace webapp.Database;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options):base(options){}

    public DbSet<AssignmentModel> Assignments { get; set; } = null!;


}