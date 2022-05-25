using System;
using System.Threading.Tasks;
using apiprueba.Dtos;
using apiprueba.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace apiprueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
      
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                var user = await _userRepository.GetAllUSer();
                return Ok(user);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error");
            }
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUserForId(int userId)
        {
            try
            {
                var user = await _userRepository.GetUser(userId);
                if(user == null){
                    return NoContent();
                }
                return Ok(user); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error");
            }
               
        }

        [HttpPost]
        public async Task<ActionResult> UserCreate(UserCreate user)
        {
            try
            {
                var userCreate = await _userRepository.RegisterUser(user);
                return Accepted(userCreate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error al registrar");
            }
            
        }

        [HttpGet("forAge")]
        public async Task<IActionResult> UserForAge()
        {
            try
            {
                var user = await _userRepository.GetUserForAge();
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error");
            }
        }

        [HttpGet("Phone")]
        public async Task<IActionResult> UserPhone()
        {
            try
            {
                var user = await _userRepository.GetUSerForDto(1);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error");
            }
        }



    
    }
}