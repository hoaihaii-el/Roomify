using RoomifyAR.Entities;
using RoomifyAR.Requests;

namespace RoomifyAR.Repositories
{
    public interface IAccountRepo
    {
        Task<User> Register(Register request);
        Task<string> Login(string userName, string pwd);
    }
}
