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
    public class MessageService
    {
        private readonly EasyRoomContext _dbContext;

        public MessageService(EasyRoomContext dbContext)
        {
            _dbContext = dbContext;
        }

        //send all message conversetin between sender and reciver then order by the mose recent one
        public async Task<ActionResult<IEnumerable<MessageResponse>>> GetMessages(MessageRequest request)
        {
            List<MessageResponse> messageResponses = new();

            var messages = await _dbContext.Messages
                .Where(filter => filter.FromID == request.FromID && filter.ToID == request.ToID || filter.FromID == request.ToID && filter.ToID == request.FromID)
                /*.OrderByDescending(date => date.DateTime)*/
                .Take(12)
                .ToListAsync();

            foreach (Message m in messages)
            {
                MessageResponse temp = new()
                {
                    ID = m.ID,
                    Sender = m.FromID,
                    Reciver = m.ToID,
                    Body = m.Body
                };

                messageResponses.Add(temp);
            }
            return messageResponses;
        }
        //Create new conversation between user a and b , it accepts sender id, reciver id and body of message
        public async Task<bool> CreateNewChat(MessageRequest request)
        {
            if (request != null)
            {
                Message message = new()
                {
                    FromID = request.FromID,
                    ToID = request.ToID,
                    Body = request.Body,
                    DateTime = DateTime.Now
                };

                await _dbContext.Messages.AddAsync(message);

                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
