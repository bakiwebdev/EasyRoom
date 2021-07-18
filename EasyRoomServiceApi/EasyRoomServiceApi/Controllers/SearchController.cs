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
    public class SearchController : ControllerBase
    {
        private readonly SearchService _service;

        public SearchController(SearchService service)
        {
            _service = service;
        }

        // POST: api/Search
        /// <summary>
        /// search users based on the data provided
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<SearchResponse>>> Search(SearchRequest request)
        {
            try
            {
                if (request.UserID <= 0)
                {
                    return BadRequest("Wrong request please try again!");
                }

                var result = await _service.SearchFriends(request);

                if (result == null)
                {
                    return BadRequest("Wrong request please try again!");
                }

                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }


        }
    }
}
