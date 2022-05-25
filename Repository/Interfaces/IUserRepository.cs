using System.Collections.Generic;
using System.Threading.Tasks;
using apiprueba.Dtos;
using apiprueba.Dtos.User;
using apiprueba.Models;

namespace apiprueba.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);
        Task<User> GetAllUSer();
        Task<User> RegisterUser(UserCreate user);
        Task<List<User>> GetUserForAge();
        Task<List<UserPhoneDto>> GetUSerForDto(int userId);
    }
}