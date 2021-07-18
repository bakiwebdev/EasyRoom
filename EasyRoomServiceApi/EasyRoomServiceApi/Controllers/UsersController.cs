using EasyRoomServiceApi.Models;
using EasyRoomServiceApi.Request;
using EasyRoomServiceApi.Response;
using EasyRoomServiceApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyRoomServiceApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _service;

        public UsersController(UserService service)
        {
            _service = service;
        }

        // GET: api/Users
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetUsers()
        {
            return await _service.GetAllUsers();
        }

        // GET: api/Users/5
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUser(int id)
        {

            var user = await _service.GetUserByID(id);

            if (user == null)
            {
                return BadRequest("Wrong request please try again!");
            }

            return user;
        }

        // PUT: api/Users/5
        /// <summary>
        /// update user name and email address
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user">id,firstnam,lastname,email address</param>
        /// <returns></returns>
        [HttpPost("ChangeDetail")]
        public async Task<IActionResult> PutUser(UserRequest user)
        {
            if (user.ID <= 0)
            {
                return BadRequest("Wrong request please try again!");
            }

            var result = await _service.ChangeUserDetail(user);

            if (!result)
            {
                return BadRequest("Wrong request please try again!");
            }

            return Ok("User updated successfully");
        }

        // POST: api/Users
        /// <summary>
        /// Creat new user, provide all data except id
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserRequest user)
        {
            var result = await _service.CreateUser(user);

            if (result == null)
            {
                return BadRequest("Wrong request please try again!");
            }

            return Ok("User created successfully");
        }
        /// <summary>
        /// check user by username and password
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("LoginRequest")]
        public async Task<ActionResult<UserResponse>> CheckUserExists(LoginRequest login)
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
