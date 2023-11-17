using System.ComponentModel.DataAnnotations;
namespace WebService.Requests
{
    public class AuthRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
