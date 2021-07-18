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
    public class MessagesController : ControllerBase
    {
        private readonly MessageService _service;

        public MessagesController(MessageService service)
        {
            _service = service;
        }

        // GET: api/Messages
        [HttpPost("GetMessages")]
        public async Task<ActionResult<IEnumerable<MessageResponse>>> GetMessages(MessageRequest request)
        {
            return await _service.GetMessages(request);
        }

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostMessage(MessageRequest message)
        {
            bool result = await _service.CreateNewChat(message);

            if (result)
            {
                return Ok("New Chat Created sucessfully");
            }

            return BadRequest("Something goes wrong please try again!");
        }
    }
}
