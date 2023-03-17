namespace WebApplication1.Base;

public class UModel
{
    public string Id { get; set; }

    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    
    public UModel()
    {
        Id = Guid.NewGuid().ToString();
        Created = Updated = DateTime.UtcNow;
            
    }

}