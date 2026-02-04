using SecureWebAPI.Models;

namespace SecureWebAPI.Services
{
    public interface IAuthServices
    {
         Task<AuthModel> RegisterAsync(RegisterModel model);
    }
}
