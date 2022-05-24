using System.Threading.Tasks;
using apiprueba.Dtos;
using apiprueba.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace apiprueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
      
        [HttpGet]
        public async Task<ActionResult> GetUsers(int userId)
        {
            var user = await _userRepository.GetAllUSer();
             return Ok(user);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUserForId(int userId)
        {
            var user = await _userRepository.GetUser(userId);
             return Ok(user);    
        }

        [HttpPost]
        public async Task<ActionResult> UserCreate(UserCreate user)
        {
            var userCreate = await _userRepository.RegisterUser(user);
            return Ok("User created");
        }



    
    }
}