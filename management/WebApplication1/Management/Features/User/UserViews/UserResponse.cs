
using WebApplication1.Base;

namespace WebApplication1.Features.User.UserViews;

public class UserResponse : UModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    //roles
}