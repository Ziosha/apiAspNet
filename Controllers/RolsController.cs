using System.Threading.Tasks;
using apiprueba.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace apiprueba.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RolsController : ControllerBase
    {

        private readonly IRolsRepository _rolsRepository;
        public RolsController(IRolsRepository rolsRepository)
        {
            _rolsRepository = rolsRepository;
        }

        [HttpGet("{rolId}")]
        public async Task<ActionResult> GetRols(int rolId)
        {
            var rol = await _rolsRepository.GetRol(rolId);
            return Ok(rol);
        }

        [HttpGet]
        public async Task<IActionResult> PhoneForRolId(int rolId)
        {
            var phone = await _rolsRepository.GetPhonesForRolId(rolId);
            return Ok(phone);
        }
    }
}



// todos los roles que tiene un usario
// los usuario que tengan años de 30 al 50
// listar los nombres de los usuarios y sus telefono y sus roles
