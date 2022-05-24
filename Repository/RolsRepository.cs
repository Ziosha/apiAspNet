using System.Threading.Tasks;
using apiprueba.Data;
using apiprueba.Models;
using apiprueba.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;

namespace apiprueba.Repository
{
    public class RolsRepository : IRolsRepository
    {
        private readonly DataContext _context;
        public RolsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Rol> GetRol(int id)
        {
            var rol = await _context.Rols
            .Include(r => r.UserRols)
            .ThenInclude( r => r.User)
            .ThenInclude( r => r.Telofonos)
            .FirstOrDefaultAsync(r => r.Id == id);

            return rol;
        }

        public async Task<List<Telefono>> GetPhonesForRolId(int rolId)
        {
            var telefonos = await _context.Telefonos
            .Where(t => t.User.UserRols.Any(ur => ur.RolId == rolId))
            // .Select( t => t.User)
            .OrderBy(t => t.Numero)
            .ToListAsync();
            

            return telefonos ;
        }
        


    }
}