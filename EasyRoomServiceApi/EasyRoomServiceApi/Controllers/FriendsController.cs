using EasyRoomServiceApi.Request;
using EasyRoomServiceApi.Response;
using EasyRoomServiceApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyRoomServiceApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly FriendService _service;

        public FriendsController(FriendService service)
        {
            _service = service;
        }

        // GET: api/Friends
        /// <summary>
        /// Show all friends from the database where the connection status is true
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FriendResponse>>> GetFriends()
        {
            return await _service.GetAllFriends();
        }

        // GET: api/Friends/5
        /// <summary>
        /// Show firends data with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<FriendResponse>> GetFriend(int id)
        {
            return await _service.GetFriendByID(id);
        }

        [HttpPost("GetUserFriends")]
        public async Task<ActionResult<IEnumerable<FriendResponse>>> GetUserFriends(FriendRequest request)
        {
            return await _service.GetUserFriends(request);
        }

        // PUT: api/Friends/5
        [HttpPost("ChangeFriendStatus")]
        public async Task<IActionResult> ChangeStatus(FriendRequest friend)
        {
            try
            {
                var result = await _service.ChangeFriendStatus(friend);

                if (!result)
                {
                    return BadRequest("Wrong request please try again!");
                }

                return Ok("User updated successfully");
            }
            catch (Exception e)
            {
                return (IActionResult)e;
            }
        }

        // PUT: api/Friends/5
        [HttpPost("AddNewFriend")]
        public async Task<IActionResult> NewFriend(FriendRequest friend)
        {
            try
            {
                var result = await _service.Add(friend);

                if (!result)
                {
                    return BadRequest("Wrong request please try again!");
                }
            }
            catch (Exception e)
            {
                return (IActionResult)e;
            }

            return Ok("New Friend Added to the friend list");
        }


    }
}
