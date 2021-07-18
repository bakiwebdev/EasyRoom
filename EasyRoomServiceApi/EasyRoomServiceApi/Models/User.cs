using System;
using System.Collections.Generic;

namespace EasyRoomServiceApi.Models
{
    public enum Gender
    {
        Male, Female
    }
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

        //Navigation Property
        public Interest Interest { get; set; }
        public Register Register { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Friend> Friends { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
