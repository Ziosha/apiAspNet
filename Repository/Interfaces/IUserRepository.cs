using System.Collections.Generic;
using System.Threading.Tasks;
using apiprueba.Dtos;
using apiprueba.Models;

namespace apiprueba.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);
        Task<List<User>> GetAllUSer();
        Task<User> RegisterUser(UserCreate user);
    }
}