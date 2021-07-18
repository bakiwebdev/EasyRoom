using EasyRoomServiceApi.Models;
using EasyRoomServiceApi.Request;
using EasyRoomServiceApi.Response;
using EasyRoomServiceApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EasyRoomServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserService _service;

        public AccountController(UserService service)
        {
            _service = service;
        }

        // POST: api/Users
        /// <summary>
        /// Creat new user, provide all data except id
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("AccountCreate")]
        public async Task<ActionResult<UserResponse>> CreateNewAccount(UserRequest user)
        {
            var result = await _service.CreateUser(user);

            if (result == null)
            {
                return BadRequest("Wrong request please try again!");
            }

            return result;
        }
        /// <summary>
        /// check user by username and password
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("AccountLogin")]
        public async Task<ActionResult<UserResponse>> LoginAccount(LoginRequest login)
        {
            var result = await _service.IsUserHasAnAccount(login);

            if (result == null)
            {
                return BadRequest("Wrong username or password, please try again");
            }
            return result;
        }
    
    }
}
