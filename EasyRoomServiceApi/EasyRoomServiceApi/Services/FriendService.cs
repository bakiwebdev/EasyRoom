using EasyRoomServiceApi.Data;
using EasyRoomServiceApi.Models;
using EasyRoomServiceApi.Request;
using EasyRoomServiceApi.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyRoomServiceApi.Services
{
    public class FriendService
    {
        private readonly EasyRoomContext _dbContext;

        public FriendService(EasyRoomContext dbContext)
        {
            _dbContext = dbContext;
        }

        //display all users that is friend with other users
        public async Task<ActionResult<IEnumerable<FriendResponse>>> GetAllFriends()
        {

            List<FriendResponse> friendResponses = new();

            var friends = await _dbContext.Friends.
                Include(user => user.User).
                Include(friend => friend.Partner).
                Where(status => status.Status == true).
                ToListAsync();

            foreach (var f in friends)
            {
                FriendResponse temp = new()
                {
                    ID = f.ID,
                    UserID = f.User.ID,
                    Firstname = f.User.FirstName,
                    Lastname = f.User.LastName,
                    Gender = f.User.Gender.ToString(),
                    Email = f.User.Email,
                    FriendID = f.Partner.ID,
                    FriendStatus = f.Status
                };

                friendResponses.Add(temp);
            }

            return friendResponses;
        }

        /// <summary>
        /// this method recive User id and friend id from friendRequest class and filter only 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<FriendResponse>>> GetUserFriends(FriendRequest request)
        {
            List<FriendResponse> friendResponses = new();

            var friends1 = await _dbContext.Friends.
                Include(user => user.User).
                Include(friend => friend.Partner).
                Where(status => status.Status == true).
                Where(filter => filter.UserID == request.UserID).
                ToListAsync();

            foreach (var f in friends1)
            {
                FriendResponse temp = new()
                {
                    ID = f.ID,
                    UserID = f.User.ID,
                    Firstname = f.Partner.FirstName,
                    Lastname = f.Partner.LastName,
                    Gender = f.Partner.Gender.ToString(),
                    Email = f.Partner.Email,
                    FriendID = f.Partner.ID,
                    FriendStatus = f.Status
                };

                friendResponses.Add(temp);
            }

            var friends2 = await _dbContext.Friends.
                Include(user => user.User).
                Include(friend => friend.Partner).
                Where(status => status.Status == true).
                Where(filter => filter.PartnerID == request.UserID).
                ToListAsync();

            foreach (var f in friends2)
            {
                FriendResponse temp = new()
                {
                    ID = f.ID,
                    UserID = f.Partner.ID,
                    Firstname = f.User.FirstName,
                    Lastname = f.User.LastName,
                    Gender = f.User.Gender.ToString(),
                    Email = f.User.Email,
                    FriendID = f.User.ID,
                    FriendStatus = f.Status
                };

                friendResponses.Add(temp);
            }

            return friendResponses;
        }


        //Get Friends list by id, this will return everything you need to know includeing the status of friendship between each friends
        public async Task<ActionResult<FriendResponse>> GetFriendByID(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            try
            {

                var result = await _dbContext.Friends.
                Include(user => user.User).
                Include(friend => friend.Partner)
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();

                if (result == null)
                {
                    return null;
                }

                FriendResponse friend = new()
                {
                    ID = result.ID,
                    UserID = result.User.ID,
                    Firstname = result.User.FirstName,
                    Lastname = result.User.LastName,
                    Gender = result.User.Gender.ToString(),
                    Email = result.User.Email,
                    FriendID = result.Partner.ID,
                    FriendStatus = result.Status
                };

                return friend;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Change status of friends with the defined reques body, for this service the controller only read the id of friend and status.
        public async Task<bool> ChangeFriendStatus(FriendRequest friend)
        {
            try
            {
                var result = await _dbContext.Friends.FindAsync(friend.ID);

                if (result != null)
                {
                    result.Status = friend.Status;

                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
        /*
         * this method has 2  senarious
         * first one, check if the user id and friend id are not friends before, if not , it will create new database and maket the connection status true
         * the second senario is, if both user are connected before, then change status
         */
        public async Task<bool> Add(FriendRequest friend)
        {
            try
            {
                var result = await _dbContext.Friends
                    .Where(result => result.UserID == friend.UserID && result.PartnerID == friend.FriendID || result.UserID == friend.FriendID && result.PartnerID == friend.UserID)
                    .SingleOrDefaultAsync();

                if (result == null)
                {
                    Friend newFriend = new()
                    {
                        UserID = friend.UserID,
                        PartnerID = friend.FriendID,
                        Status = true
                    };

                    _dbContext.Friends.Add(newFriend);

                }

                else
                {
                    if (result.ID >= 1)
                    {
                        result.Status = !result.Status;
                    }
                    else
                    {
                        return false;
                    }
                }


                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        // reutrn ture if both user are friends, if not return false.
        public async Task<bool> IsConnected(int UserID, int FriendID)
        {
            var result = await _dbContext.Friends
                    .Where(result => result.UserID == UserID && result.PartnerID == FriendID || result.UserID == FriendID && result.PartnerID == UserID)
                    .SingleOrDefaultAsync();

            if (result == null)
            {
                return false;
            }

            return result.Status;
        }
    }
}
