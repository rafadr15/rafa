using Microsoft.EntityFrameworkCore;
using webapp.Features.Assignments.Models;
using webapp.Features.Subject.SubjectModels;
using webapp.Features.Test.TestModels;

namespace webapp.Database;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options):base(options){}

    public DbSet<AssignmentModel> Assignments { get; set; } = null!;

    public DbSet<SubjectModel> Subjects { get; set; } = null!;
    
    
    public DbSet<TestModel> Tests { get; set; } = null!;
    
}