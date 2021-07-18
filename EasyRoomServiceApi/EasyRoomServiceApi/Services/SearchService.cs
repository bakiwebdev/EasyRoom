using EasyRoomServiceApi.Data;
using EasyRoomServiceApi.Request;
using EasyRoomServiceApi.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRoomServiceApi.Services
{
    public class SearchService
    {
        private readonly EasyRoomContext _dbContext;

        public SearchService(EasyRoomContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// this filter all users based on the data privided.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<SearchResponse>>> SearchFriends(SearchRequest request)
        {

            List<SearchResponse> searchResponses = new();

            var serach_result = await _dbContext.Users
                .Where(filter => filter.FirstName.Contains(request.Data) || filter.LastName.Contains(request.Data) || filter.Email.Contains(request.Data))
                .ToListAsync();

            FriendService friendService = new FriendService(_dbContext);

            foreach (var result in serach_result)
            {


                SearchResponse temp = new()
                {
                    ID = request.UserID,
                    UserID = result.ID,
                    Firstname = result.FirstName,
                    Lastname = result.LastName,
                    Email = result.Email,
                    Gender = result.Gender.ToString(),
                    Status = await friendService.IsConnected(request.UserID, result.ID)
                };

                searchResponses.Add(temp);

            }

            return searchResponses;
        }
    }
}
