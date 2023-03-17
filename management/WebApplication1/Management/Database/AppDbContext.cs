using Microsoft.EntityFrameworkCore;
using WebApplication1.Features.User;


namespace WebApplication1.Database;

public class AppDbContext : DbContext

{
    public AppDbContext(DbContextOptions options):base(options){}

    public DbSet<UserModel> User { get; set; } = null!;

}