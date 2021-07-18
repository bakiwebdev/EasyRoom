using System;

namespace EasyRoomServiceApi.Models
{
    public class Message
    {
        public int ID { get; set; }
        public int FromID { get; set; }
        public int ToID { get; set; }
        public string Body { get; set; }
        public DateTime DateTime { get; set; }

        //Navigation Property
        public virtual User From { get; set; }
        public virtual User To { get; set; }
    }
}
