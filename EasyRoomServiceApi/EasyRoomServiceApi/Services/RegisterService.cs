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
    public class RegisterService
    {
        private readonly EasyRoomContext _dbContext;

        public RegisterService(EasyRoomContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Get all Registration stored in the database
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<RegisterRequest>>> GetRegisters()
        {
            var registers = await _dbContext.Registers.ToListAsync();

            List<RegisterRequest> value = new();

            foreach (Register r in registers)
            {
                RegisterRequest temp = new()
                {
                    UserID = r.UserID,
                    PostID = r.PostID,
                    Status = r.Status
                };

                value.Add(temp);
            }

            return value;
        }
        //Add new Registeration and make the status false
        public bool AddNewRegister(int userID, int postID)
        {
            try
            {
                Register newRegister = new()
                {
                    UserID = userID,
                    PostID = postID,
                    Status = false
                };

                //save new registers
                _dbContext.Registers.Add(newRegister);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
        }
        //Get the status and if the user and post has no status it will create automatically
        public async Task<RegisterResponse> GetStatus(RegisterRequest request)
        {
            var user = await _dbContext.Users.FindAsync(request.UserID);
            var post = await _dbContext.Posts.FindAsync(request.PostID);

            if (user == null || post == null)
            {
                return null;
            }

            var register = await _dbContext.Registers
                .Where(filter => filter.UserID == request.UserID && filter.PostID == request.PostID)
                .FirstOrDefaultAsync();

            if (register == null)
            {
                AddNewRegister(user.ID, post.ID);

                //get the id of the new register
                var getNewRegister = await _dbContext.Registers
                .Where(filter => filter.UserID == request.UserID && filter.PostID == request.PostID)
                .FirstOrDefaultAsync();

                RegisterResponse value = new()
                {
                    ID = getNewRegister.ID,
                    Status = getNewRegister.Status
                };

                return value;
            }

            RegisterResponse temp = new()
            {
                ID = register.ID,
                Status = register.Status
            };

            return temp;
        }
        //Change the staus based on defined object
        public async Task<RegisterResponse> ChangeStatus(RegisterRequest request)
        {
            var user = await _dbContext.Users.FindAsync(request.UserID);
            var post = await _dbContext.Posts.FindAsync(request.PostID);

            if (user == null || post == null)
            {
                return null;
            }

            Register register = await _dbContext.Registers
                .Where(filter => filter.UserID == request.UserID && filter.PostID == request.PostID)
                .FirstOrDefaultAsync();

            if (register != null)
            {
                register.Status = request.Status;

                await _dbContext.SaveChangesAsync();

                RegisterResponse value = new()
                {
                    ID = register.ID,
                    Status = register.Status
                };

                return value;
            }

            return null;
        }
    }
}
