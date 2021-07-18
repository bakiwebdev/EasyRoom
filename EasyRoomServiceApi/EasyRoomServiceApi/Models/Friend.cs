using System.Collections.Generic;

namespace EasyRoomServiceApi.Models
{
    public class Friend
    {
        public int ID { get; set; }
        public bool Status { get; set; }
        public int UserID { get; set; }
        public int PartnerID { get; set; }

        //Navigation Property
        public ICollection<Notification> Notifications { get; set; }
        public virtual User User { get; set; }
        public virtual User Partner { get; set; }

    }
}
