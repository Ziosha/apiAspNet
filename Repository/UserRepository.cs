using System.Threading.Tasks;
using apiprueba.Data;
using apiprueba.Models;
using apiprueba.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using apiprueba.Dtos;

namespace apiprueba.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users
            .Include(u => u.Nacimientos)
            .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<List<User>> GetAllUSer()
        {
            var users = await _context.Users
            .Include(u => u.Nacimientos)
            .Include(u => u.Telofonos)
            .ToListAsync();

            return users;
        }

        public async Task<User> RegisterUser(UserCreate user)
        {
            var user1 = new User()
            {
                Name = user.Name,
                Edad1 = user.Edad
            };
            await _context.Users.AddAsync(user1);
            await _context.SaveChangesAsync();

            var nacimiento = new Nacimiento()
            {
                Ciudad = user.Ciudad,
                Pais = user.Pais,
                UserId = user1.Id
            };
            await _context.Nacimientos.AddAsync(nacimiento);
            await _context.SaveChangesAsync();

            var telefono = new Telefono()
            {
                Numero = user.Telefono,
                CodigoDePais = user.CodigoTelefono,
                UserId = user1.Id
            };
            await _context.Telefonos.AddAsync(telefono);
            await _context.SaveChangesAsync();

            return user1 ;
        }
    }
}