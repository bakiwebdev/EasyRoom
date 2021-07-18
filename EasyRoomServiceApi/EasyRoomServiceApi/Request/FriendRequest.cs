namespace EasyRoomServiceApi.Request
{
    public class FriendRequest
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int FriendID { get; set; }
        public bool Status { get; set; }
    }
}
