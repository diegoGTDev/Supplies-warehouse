using WebService.Models.Response;
using WebService.Requests;

namespace WebService.Services
{
    public interface iUserService
    {
        UserResponse Auth(AuthRequest authRequest);
    }
}
