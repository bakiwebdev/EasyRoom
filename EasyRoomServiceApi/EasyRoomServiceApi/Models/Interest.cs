namespace EasyRoomServiceApi.Models
{
    public class Interest
    {
        public int ID { get; set; }
        public int Game { get; set; }
        public int UserID { get; set; }

        //Navigation Property
        public User User { get; set; }
    }
}
