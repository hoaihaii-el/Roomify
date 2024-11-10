using Microsoft.EntityFrameworkCore;
using RoomifyAR.Entities;
using RoomifyAR.Errors;
using RoomifyAR.Repositories;
using RoomifyAR.Requests;
using RoomifyAR.StaticServices;

namespace RoomifyAR.Services
{
    public class AccountService(DataContext _context, JWTManager _jwtManager) : IAccountRepo
    {
        public async Task<string> Login(string userName, string pwd)
        {
            var user = await _context.Users
                .Where(u => u.Username == userName)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new CustomException("User not found!");
            }

            if (!PasswordHasher.VerifyPassword(pwd, user.PasswordHash))
            {
                throw new CustomException("Wrong password!");
            }

            return _jwtManager.GenerateJWTToken(user.Email, user.Role);
        }

        public async Task<User> Register(Register request)
        {
            var user = await _context.Users
                .Where(u => u.Username == request.UserName || u.Email == request.Email)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                throw new CustomException("Username exist!");
            }

            var newUser = new User
            {
                Username = request.UserName,
                Email = request.Email,
                PasswordHash = PasswordHasher.Hash(request.Password),
                Role = "User",
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }
    }
}
