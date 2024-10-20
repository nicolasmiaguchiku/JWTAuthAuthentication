
namespace JWTAuthAuthentication.Interfaces
{
    public interface ISecurityService
    {
        public Task<bool> ComparePassword(string password, string confirmPassword);
        public Task<string> EncryptPassword(string password);
        public bool VerifyPassword(string password, string passwordHash);
    }
}
