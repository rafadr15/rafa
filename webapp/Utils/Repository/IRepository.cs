using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp.Base;

namespace webapp.Utils.Repository;

public interface IRepository<T> where T : class, IModel //CRUD repository
{
    public DbSet<T> Dbset { get; set; }
   //create
    public Task<ActionResult<T>> Add(T request);
   //read  
    public Task<ActionResult<IEnumerable<T>>> Get();
    
    public Task<ActionResult<T>> Get(string id);
   //update 
    public Task<ActionResult<T>> Update(string id, object request);
   //delete 
    public Task<ActionResult<T>> Delete(string id);
    
    
    
}