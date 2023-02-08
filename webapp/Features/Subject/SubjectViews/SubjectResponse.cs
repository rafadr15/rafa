using webapp.Base;

namespace webapp.Features.Subject.SubjectViews;

public class SubjectResponse : Model
{
    
    public string Name { get; set; }
    public string ProfessorMail { get; set; }
    public List<Double> Grades { get; set; }
}
