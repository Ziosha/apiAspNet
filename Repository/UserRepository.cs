using System.Threading.Tasks;
using apiprueba.Data;
using apiprueba.Models;
using apiprueba.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using apiprueba.Dtos;
using apiprueba.Dtos.User;
using apiprueba.Dtos.Telefono;

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

        public async Task<User> GetAllUSer()
        {
            var users = await _context.Users
            .Include(u => u.Nacimientos)
            .Include(u => u.Telofonos)
            .FirstOrDefaultAsync();

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

        public async Task<List<User>> GetUserForAge()
        {
            var users = await _context.UserRols
            .Include(u => u.User)
            .ThenInclude(u => u.Telofonos)
            .Where(u => u.RolId == 6 || u.RolId == 8)
            .ToListAsync();

            users = users.Where(u => u.User.Edad1 > 19 && u.User.Edad1 < 41).ToList();
            users = users.Where(u => u.User.Telofonos.Any(t => t.CodigoDePais > 300 && t.CodigoDePais < 500)).ToList();

            return users.Select(u => u.User).ToList();
        }

        public async Task<List<UserPhoneDto>> GetUSerForDto(int userId)
        {
            var usersReturn = new List<UserPhoneDto>();

            var users = await _context.Users.Include(u => u.Telofonos).ToListAsync();
            foreach(var i in users)
            {
                var telefonosuer = new List<PhoneDto>();
                foreach (var n in i.Telofonos)
                {
                    var tel = new PhoneDto()
                    {
                        Numero = n.Numero,
                        Codigo = n.CodigoDePais
                    };
                    telefonosuer.Add(tel);
                }
                var user = new UserPhoneDto()
                {
                    UserId = i.Id,
                    Nombre = i.Name,
                    phones = telefonosuer
                };
                usersReturn.Add(user);
            }

            return usersReturn;
        }


    }
}