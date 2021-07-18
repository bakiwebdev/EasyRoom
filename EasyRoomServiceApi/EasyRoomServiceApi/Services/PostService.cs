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
    public class PostService
    {
        private readonly EasyRoomContext _dbContext;

        public PostService(EasyRoomContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Display all postes including user data
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<PostResponse>>> GetAllPost()
        {

            List<PostResponse> postResponses = new();

            var post = await _dbContext.Posts
                .Include(user => user.User)
                .Where(filter => filter.ExpireDate > DateTime.Today)
                .OrderByDescending(date => date.CreatedDate)
                .Take(20)
                .ToListAsync();

            foreach (var p in post)
            {
                PostResponse temp = new()
                {
                    PostID = p.ID,
                    Date = p.CreatedDate.Date.ToString("dd-MM-yyyy"),
                    Title = p.Title,
                    Body = p.Body,
                    UserID = p.User.ID,
                    Firstname = p.User.FirstName,
                    Lastname = p.User.LastName,
                    Gender = p.User.Gender.ToString()
                };

                postResponses.Add(temp);
            }

            return postResponses;

        }

        /// <summary>
        /// Filter post by id
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns></returns>
        public async Task<ActionResult<PostResponse>> GetPostByID(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            try
            {
                var result = await _dbContext.Posts
                .Include(user => user.User).Where(i => i.ID == id).FirstOrDefaultAsync();

                if (result == null)
                {
                    return null;
                }


                PostResponse post = new()
                {
                    PostID = result.ID,
                    Date = result.CreatedDate.Date.ToString("dd-MM-yyyy"),
                    Title = result.Title,
                    Body = result.Body,
                    UserID = result.User.ID,
                    Firstname = result.User.FirstName,
                    Lastname = result.User.LastName,
                    Gender = result.User.Gender.ToString()
                };

                return post;


            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Create new post form user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<bool> CreatePost(PostRequest request)
        {
            if (request.UserID <= 0)
            {
                return false;
            }

            var user = _dbContext.Users.FindAsync(request.UserID);

            if (user.Result == null)
            {
                return false;
            }

            Post post = new()
            {
                CreatedDate = DateTime.Today,
                ExpireDate = DateTime.Today.AddDays(10),
                Title = request.Title,
                Body = request.Body,
                UserID = request.UserID,
                Game = Game.Pubg
            };
            _dbContext.Posts.Add(post);

            await _dbContext.SaveChangesAsync();

            //create new notification after each post save
            NotificationService notification = new NotificationService(_dbContext);
            await notification.CreateNotification(post.UserID, post.ID);
            return true;
        }
        /// <summary>
        /// Delete existing post based on the provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeletePostByID(int id)
        {
            var post = await _dbContext.Posts.FindAsync(id);

            if (post == null)
            {
                return false;
            }

            _dbContext.Posts.Remove(post);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
