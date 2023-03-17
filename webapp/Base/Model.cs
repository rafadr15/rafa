

using Microsoft.EntityFrameworkCore;

namespace webapp.Base
{
    public class Model : IModel
    {
        public string id { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public Model()
        {
            id = Guid.NewGuid().ToString();
            Created = Updated = DateTime.UtcNow;
            
        }
}
}