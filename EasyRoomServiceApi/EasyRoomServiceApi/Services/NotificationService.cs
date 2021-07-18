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
    public class NotificationService
    {
        private readonly EasyRoomContext _dbContext;

        public NotificationService(EasyRoomContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActionResult<IEnumerable<NotificationResponse>>> GetAllNotifications()
        {
            List<NotificationResponse> value = new();

            var notifications = await _dbContext.Notifications
                .Include(user => user.User)
                .OrderByDescending(order => order.Date)
                .ToListAsync();

            foreach (Notification n in notifications)
            {
                NotificationResponse temp = new()
                {
                    ID = n.ID,
                    Firstname = n.User.FirstName,
                    PostID = n.PostID
                };

                value.Add(temp);
            }

            return value;
        }

        /// <summary>
        /// Recive user id and filter all notification of 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<NotificationResponse>>> GetUserNotifications(NotificationRequest request)
        {
            var notifications = await _dbContext.Notifications
                .Include(user => user.User)
                .OrderByDescending(order => order.Date)
                .ToListAsync();

            List<NotificationResponse> value = new();

            FriendService friendService = new FriendService(_dbContext);

            foreach (Notification n in notifications)
            {
                //if both are friends
                if (await friendService.IsConnected(n.UserID, request.UserID))
                {
                    NotificationResponse temp = new()
                    {
                        ID = n.ID,
                        Firstname = n.User.FirstName,
                        PostID = n.PostID
                    };

                    value.Add(temp);
                }

            }

            return value;
        }

        public async Task CreateNotification(int userID, int postID)
        {
            Notification notification = new()
            {
                Status = true,
                UserID = userID,
                PostID = postID,
                Date = DateTime.Now
            };

            await _dbContext.Notifications.AddAsync(notification);
            await _dbContext.SaveChangesAsync();
        }
    }
}
