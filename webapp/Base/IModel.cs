namespace webapp.Base;

public interface IModel
{
    string id { get; set; }
    DateTime Created { get; set; }
    DateTime Updated { get; set; }
}