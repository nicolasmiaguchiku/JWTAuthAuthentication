using JWTAuthAuthentication.Context;
using JWTAuthAuthentication.Interfaces;
using JWTAuthAuthentication.Models;

namespace JWTAuthAuthentication.Services
{
    public class SecurityServices : ISecurityService
    {

        public Task<bool> ComparePassword(string password, string confirmPassWord)
        {
            var isEqual = password.Trim().Equals(confirmPassWord.Trim());

            return Task.FromResult(isEqual);
        }

        public Task<string> EncryptPassword(string password)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            return Task.FromResult(passwordHash);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }

}
}
