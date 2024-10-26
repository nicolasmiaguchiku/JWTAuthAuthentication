using JWTAuthAuthentication.Context;
using JWTAuthAuthentication.Interfaces;
using JWTAuthAuthentication.Models;
using JWTAuthAuthentication.Validations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace JWTAuthAuthentication.Services
{
    public class UserServices : IUserServices
    {
        private readonly ISecurityService _securityService;
        private readonly DataContext _context;

        public UserServices(ISecurityService securityService, DataContext context)
        {
            _securityService = securityService;
            _context = context;
        }

        public async Task<Report> CreateUser(CreateUser newUser)
        {
            var isEquals = await _securityService.ComparePassword(newUser.Password, newUser.ConfirmPassword);

            if (!isEquals)
            {
                return new Report("Senhas não coicidem.");
            }

            if (await _context.Users.AnyAsync(user => user.Email == newUser.Email))
            {
                return new Report("Usuário já existe.");
            }

            var PasswordEncrypted = await _securityService.EncryptPassword(newUser.Password);

            var User = new User()
            {
                Name = newUser.Name,
                Email = newUser.Email,
                PasswordHash = PasswordEncrypted,
                Role = newUser.Role
            };

            _context.Add(User);
            await _context.SaveChangesAsync();

            return new Report("Usuario criado com sucesso");

        }

        public async Task<User> AuthenticateUser(string email, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
            if (user == null || !_securityService.VerifyPassword(password, user.PasswordHash))
            {
                return null;
            }

            return user;
        }
    }
}
