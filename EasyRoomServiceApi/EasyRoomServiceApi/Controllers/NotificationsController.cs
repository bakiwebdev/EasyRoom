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
    public class NotificationsController : ControllerBase
    {
        private readonly NotificationService _service;

        public NotificationsController(NotificationService service)
        {
            _service = service;
        }

        // GET: api/Notifications
        [HttpGet("GetAllNotification")]
        public async Task<ActionResult<IEnumerable<NotificationResponse>>> GetAllNotifications()
        {
            return await _service.GetAllNotifications();
        }

        // GET: api/Notifications/5
        [HttpPost("GetUserNotification")]
        public async Task<ActionResult<IEnumerable<NotificationResponse>>> GetUserNotification(NotificationRequest request)
        {
            return await _service.GetUserNotifications(request);
        }


    }
}
