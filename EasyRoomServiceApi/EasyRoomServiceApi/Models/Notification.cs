using System;

namespace EasyRoomServiceApi.Models
{
    public class Notification
    {
        public int ID { get; set; }
        public bool Status { get; set; }
        public int UserID { get; set; }
        public int PostID { get; set; }
        public DateTime Date { get; set; }

        //Navigation Property
        public User User { get; set; }
        public Post Post { get; set; }
        public Friend Friend { get; set; }

    }
}
