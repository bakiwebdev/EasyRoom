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
    public class RegistersController : ControllerBase
    {
        private readonly RegisterService _services;

        public RegistersController(RegisterService services)
        {
            _services = services;
        }
        /// <summary>
        /// Get all Registers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterRequest>>> GetRegisters()
        {
            return await _services.GetRegisters();
        }

        /*[HttpPost("createregister")]*/

        // GET: api/Registers
        /// <summary>
        /// Accept userid and post id Request and reutrn the id of register in db and the status of the post between the user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>  

        [HttpPost("GetRegisterStatus")]
        public async Task<RegisterResponse> GetStatus(RegisterRequest request)
        {
            var value = await _services.GetStatus(request);

            if (value != null)
            {
                return value;
            }

            return null;
        }

        /// <summary>
        /// Accept UserId , PostId and status then convert the current status in to viseversal then return the response.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("ChangePostStatus")]
        public async Task<RegisterResponse> ChangeStatus(RegisterRequest request)
        {
            var value = await _services.ChangeStatus(request);

            if (value != null)
            {
                return value;
            }

            return null;
        }

    }
}

