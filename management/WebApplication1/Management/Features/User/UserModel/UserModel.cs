using WebApplication1.Base;

namespace WebApplication1.Features.User;

public class UserModel : UModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; } 
    public List<string> Roles { get; set; } //de completat
}