using System;
using System.Collections.Generic;

namespace EasyRoomServiceApi.Models
{
    public enum Game
    {
        Minecraft,
        GTA_V,
        Fortnite,
        Rocket_League,
        Call_Of_Duty,
        Roblox,
        Pubg,
        Apex_Legends
    }
    public class Post
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserID { get; set; }
        public Game Game { get; set; }

        //Navigation property
        public Register Register { get; set; }
        public User User { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
