using System.Collections.Generic;
using System.Threading.Tasks;
using apiprueba.Models;
using System;

namespace apiprueba.Repository.Interfaces
{
    public interface IRolsRepository
    {
        Task<Rol> GetRol(int id);
        Task<List<Telefono>> GetPhonesForRolId(int rolId);
        // Task<List<Rol>> GetAllRol();
        // Task<Rol> RegisterRol(RolCreate rol);
    }
}
