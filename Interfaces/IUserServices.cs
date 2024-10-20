using JWTAuthAuthentication.Models;
using JWTAuthAuthentication.Validations;

namespace JWTAuthAuthentication.Interfaces
{
    public interface IUserServices
    {
        Task<Report> CreateUser(CreateUser newUSer);

        Task<User> AuthenticateUser(string email, string password);
    }
}
