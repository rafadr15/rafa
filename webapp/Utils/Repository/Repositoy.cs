using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp.Database;
using IModel = webapp.Base.IModel;

namespace webapp.Utils.Repository;

public class Repository<T> : IRepository<T> where T : class, IModel
{
    private readonly AppDbContext _dbContext;
    
    public DbSet<T> DbSet { get; set; }

    public Repository(AppDbContext dbcontext)
    {
        _dbContext = dbcontext;
        DbSet = _dbContext.Set<T>();

    }

    private async Task SaveChanges()
    {

        await _dbContext.SaveChangesAsync();
    }


    public DbSet<T> Dbset { get; set; }

    public async Task<ActionResult<T>> Add(T request)
    {
        var result = await DbSet.AddAsync(request);
        await SaveChanges();
        return result.Entity;
    }


    public async Task<ActionResult<IEnumerable<T>>> Get()
    {
        return await DbSet.ToListAsync();
        
    }

    public async Task<ActionResult<T>> Get(string id)
    {
        var entity = await DbSet.FirstOrDefaultAsync(e => e.id == id);
        if (entity is null)
        {
            return null;
        }

        return entity;
    }

    public async Task<ActionResult<T>> Delete(string id)
    {
        var entity = await DbSet.FirstOrDefaultAsync(e => e.id == id);
        if (entity is null)
        {
            return null;
        }

        var result = DbSet.Remove(entity);
        await SaveChanges();
        return result.Entity;
    }

    public async Task<ActionResult<T>> Update(string id, object request)
    {
        var entity = await DbSet.FirstOrDefaultAsync(e => e.id == id);
        if (entity is null)
        {
            return null;
        }

        foreach (var property in request.GetType().GetProperties())
        {
            var value = property.GetValue(request,null);
            var originalProp = entity.GetType().GetProperty(property.Name);
            if (value is not null && originalProp is not null)
            {
                originalProp.SetValue(entity, value);
            }
        }

        await SaveChanges();
        return entity;

    }

}