using System.ComponentModel.DataAnnotations;

namespace Octo.Web.Controllers.Auth
{
    public class RegisterModel
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
    }
}