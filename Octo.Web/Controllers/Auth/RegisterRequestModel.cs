using System.ComponentModel.DataAnnotations;

namespace Octo.Web.Controllers.Auth
{
    public class RegisterRequestModel
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
    }
}