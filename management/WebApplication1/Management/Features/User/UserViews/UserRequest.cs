
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Features.User.UserViews;

public class UserRequest
{
   [Required] public string FirstName { get; set; }
   [Required] public string LastName { get; set; }
   [EmailAddress]
   [Required] public string Email { get; set; }
}